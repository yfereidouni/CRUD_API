using CRUD_API.Models.Contacts;
using CRUD_API.Repositories.Common;
using CRUD_API.SQL;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories.Contacts;

public class ContactRepository : BaseEntityRepository<Contact>, IContactRepository
{
    private readonly AppDbContext _appDbContext;

    public ContactRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsWithAllDependenciesAsync()
    {
        return (await AppDbContext.Contacts!
            .Include(c => c.Location)
            .Include(c => c.Phones)!
            .ThenInclude(ph => ph.PhoneType)
            .ToListAsync())!;
    }

    public async Task<Contact> GetContactByIdWithAllDependenciesAsync(int id)
    {
        return (await AppDbContext.Contacts!
            .Where(c => c.Id == id)
            .Include(c => c.Phones)
            .ThenInclude(i => i.PhoneType)
            .Include(l => l.Location)
            .SingleOrDefaultAsync())!;
    }
}
