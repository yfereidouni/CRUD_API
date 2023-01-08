using CRUD_API.Models.Locations;
using CRUD_API.Repositories.Common;
using CRUD_API.SQL;

namespace CRUD_API.Repositories.Locations;

public class LocationRepository : BaseEntityRepository<Location>, ILocationRepository
{
    public LocationRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
