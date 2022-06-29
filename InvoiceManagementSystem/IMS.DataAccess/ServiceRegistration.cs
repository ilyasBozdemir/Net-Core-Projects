using IMS.DataAccess.Context.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;



namespace IMS.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            //services.AddDbContext<InvoiceManagementDbContext>(options => options.UseSqlServer
            //(Configuration.GetConnectionString("localServer")));
            string conString = "Server=DESKTOP-GNTS7VU;Database=InvoiceManagementDB;Trusted_Connection=True;";


            //services.AddDbContext<InvoiceManagementDbContext>(options => options.UseSqlServer(conString));

        }
    }
}
