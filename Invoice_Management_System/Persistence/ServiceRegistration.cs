using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration Configuration = null)
        {
            serviceCollection.AddDbContext<IMSDbContext>
                (options => options.UseSqlServer(DbConfiguration.ConnectionString));

            serviceCollection.AddScoped<IApartmentRepository, EfApartmentRepository>();

        }
    }
}
