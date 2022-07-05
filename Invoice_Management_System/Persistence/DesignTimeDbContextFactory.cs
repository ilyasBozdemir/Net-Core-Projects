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

            dbContextOptionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            //dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-GNTS7VU;Database=InvoiceManagementDB;Trusted_Connection=True;");
            return new IMSDbContext(dbContextOptionsBuilder.Options);
        }
      
    }
}
