using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD_API.SQL
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseSqlServer("server=.,1433;initial catalog=CRUD_API_DB;User Id=dbuser;Password=1qaz!QAZ;MultipleActiveResultSets=True;TrustServerCertificate=True;");

            return new AppDbContext(builder.Options);
        }
    }
}
