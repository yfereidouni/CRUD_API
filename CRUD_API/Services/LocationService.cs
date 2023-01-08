using CRUD_API.Models.Locations;
using CRUD_API.Repositories.Common;
using CRUD_API.SQL;

namespace CRUD_API.Services;

public class LocationService : BaseEntityRepository<Location>, ILocationService
{
    public LocationService(AppDbContext context) : base(context) { }
}