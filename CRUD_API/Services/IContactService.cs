using CRUD_API.Models.Contacts;
using CRUD_API.Repositories.Common;
using CRUD_API.VMs;
using System.Linq.Expressions;

namespace CRUD_API.Services;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsWithOptionalDependenciesAsync(params Expression<Func<Contact, object>>[] includeProperties);
    Task<IEnumerable<Contact>> GetAllContactsWithAllDependenciesAsync();
    Task<Contact> GetContactByIdWithAllDependenciesAsync(int id);
    Task<int> CreateContactWithDependenciesAsync(PostContactRequestVm data);
    Task<int> UpdateContactWithDependenciesAsync(PutContactRequestVm data);
    Task<int> DeleteContactWithDependenciesAsync(int id);
}

