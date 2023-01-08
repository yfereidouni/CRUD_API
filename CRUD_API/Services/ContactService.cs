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


    public async Task<int> AddNewContactWithDependenciesAsync(ContactRequestVm data)
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



    public Task<IEnumerable<Contact>> GetAllContactsWithOptionalDependenciesAsync(params Expression<Func<Contact, object>>[] includeProperties)
    {
        return _contactRepository.GetAllWithOptionalDependenciesAsync(includeProperties);
    }

    public async Task<IEnumerable<Contact>> GetAllContactsWithAllDependenciesAsync()
    {
        return await _contactRepository.GetAllContactsWithAllDependenciesAsync();
    }

    public async Task<Contact> GetContactByIdWithAllDependenciesAsync(int id)
    {
        return await _contactRepository.GetContactByIdWithAllDependenciesAsync(id);
    }
}