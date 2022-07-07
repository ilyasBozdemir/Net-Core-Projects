using Application.Repositories;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Extensions.DbInitializer;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration Configuration = null)
        {
            serviceCollection.AddDbContext<IMSDbContext>
                (options => options.UseSqlServer(DbConfiguration.ConnectionString));

            serviceCollection.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<IMSDbContext>();

            serviceCollection.AddScoped<DbInitializer>();

            serviceCollection.AddScoped<IApartmentRepository, EfApartmentRepository>();

        }
    }
}
