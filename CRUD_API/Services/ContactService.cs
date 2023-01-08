using System.Linq.Expressions;
using CRUD_API.Models.Contacts;
using CRUD_API.Models.Locations;
using CRUD_API.Models.Phones;
using CRUD_API.Repositories.Common;
using CRUD_API.Repositories.Contacts;
using CRUD_API.Repositories.Locations;
using CRUD_API.Repositories.Phones;
using CRUD_API.VMs;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IPhoneRepository _phoneRepository;

    public ContactService(IContactRepository contactRepository,
        ILocationRepository locationRepository,
        IPhoneRepository phoneRepository)
    {
        _contactRepository = contactRepository;
        _locationRepository = locationRepository;
        _phoneRepository = phoneRepository;
    }
    public async Task<IEnumerable<Contact>> GetAllContactsWithAllDependenciesAsync()
    {
        return await _contactRepository.GetAllContactsWithAllDependenciesAsync();
    }

    public async Task<IEnumerable<Contact>> GetAllContactsWithOptionalDependenciesAsync(params Expression<Func<Contact, object>>[] includeProperties)
    {
        return await _contactRepository.GetAllWithOptionalDependenciesAsync(includeProperties);
    }

    public async Task<Contact> GetContactByIdWithAllDependenciesAsync(int id)
    {
        return await _contactRepository.GetContactByIdWithAllDependenciesAsync(id);
    }

    public async Task<int> CreateContactWithDependenciesAsync(PostContactRequestVm data)
    {
        var location = new Location
        {
            City = data.Location!.City,
            StreetNumber = data.Location.StreetNumber,
            PostalCode = data.Location.PostalCode,
            StreetName = data.Location.StreetName
        };
        await _locationRepository.Add(location);

        var newContact = new Contact()
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Email = data.Email,
            LocationId = location.Id,
        };

        await _contactRepository.Add(newContact);

        foreach (var phone in data.Phones!)
        {
            var newPhone = new Phone()
            {
                PhoneNumber = phone.PhoneNumber!,

                ContactId = newContact.Id,
                PhoneTypeId = phone.PhoneTypeId,
            };
            await _phoneRepository.Add(newPhone);
        }

        return newContact.Id;
    }

    public async Task<int> UpdateContactWithDependenciesAsync(PutContactRequestVm data)
    {
        var contact = await GetContactByIdWithAllDependenciesAsync(data.Id);

        contact.Location.City = data.Location!.City;
        contact.Location.StreetName = data.Location.StreetName;
        contact.Location.StreetNumber = data.Location.StreetNumber;
        contact.Location.PostalCode = data.Location.PostalCode;

        foreach (var phone in contact.Phones)
        {
            foreach (var ph in data.Phones)
            {
                if (phone.Id == ph.Id)
                {
                    phone.PhoneNumber = ph.PhoneNumber;
                    phone.PhoneTypeId = ph.PhoneTypeId;
                }
            }
        }

        contact.FirstName = data.FirstName;
        contact.LastName = data.LastName;
        contact.Email = data.Email;

        await _contactRepository.Update(contact);

        return contact.Id;
    }

    public async Task<int> DeleteContactWithDependenciesAsync(int id)
    {
        var contact = await GetContactByIdWithAllDependenciesAsync(id);
        
        contact.Phones.Clear();

        await _contactRepository.Delete(contact);
        
        await _locationRepository.Delete(contact.Location);

        return contact.Id;
    }

}