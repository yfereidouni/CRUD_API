using CRUD_API.Models.Phones;
using CRUD_API.Repositories.Common;
using CRUD_API.SQL;

namespace CRUD_API.Services;

public class PhoneTypeService : BaseEntityRepository<PhoneType>, IPhoneTypeService
{
    public PhoneTypeService(AppDbContext context) : base(context) { }
}