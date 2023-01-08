using CRUD_API.Models.Phones;
using CRUD_API.Repositories.Common;
using CRUD_API.SQL;

namespace CRUD_API.Repositories.Phones;

public class PhoneRepository : BaseEntityRepository<Phone>, IPhoneRepository
{
    public PhoneRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
