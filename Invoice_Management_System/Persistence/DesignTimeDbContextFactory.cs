using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Context;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IMSDbContext>
    {
        public IMSDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<IMSDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new IMSDbContext(dbContextOptionsBuilder.Options);
        }
      
    }
}
