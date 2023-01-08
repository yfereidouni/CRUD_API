using CRUD_API.Models.Contacts;
using CRUD_API.Repositories.Common;

namespace CRUD_API.Repositories.Contacts;

public interface IContactRepository : IBaseEntityRepository<Contact>
{
    Task<IEnumerable<Contact>> GetAllContactsWithAllDependenciesAsync();
    Task<Contact> GetContactByIdWithAllDependenciesAsync(int id);
}
