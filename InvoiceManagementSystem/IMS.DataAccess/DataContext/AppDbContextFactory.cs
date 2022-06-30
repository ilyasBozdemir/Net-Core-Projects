using IMS.DataAccess.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IMS.DataAccess.DataContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<InvoiceManagementDbContext>
    {
        public InvoiceManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoiceManagementDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-GNTS7VU;Database=IMSWDB;Trusted_Connection=True;");

            

            return new InvoiceManagementDbContext(optionsBuilder.Options);
        }
    }
}
