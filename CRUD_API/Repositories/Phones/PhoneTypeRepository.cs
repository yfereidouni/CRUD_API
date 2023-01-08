using CRUD_API.Models.Phones;
using CRUD_API.Repositories.Common;
using CRUD_API.SQL;

namespace CRUD_API.Repositories.Phones;

public class PhoneTypeRepository : BaseEntityRepository<PhoneType>, IPhoneTypeRepository
{
    public PhoneTypeRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }
}