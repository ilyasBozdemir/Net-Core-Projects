using Application.Repositories;
using Domain.Entities.Identity;
using Infrastructure.IdentitySettings;
using Infrastructure.IdentitySettings.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Extensions.Seeding;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration Configuration = null)
        {
            serviceCollection.AddDbContext<IMSDbContext>
                (options => options.UseSqlServer(DbConfiguration.ConnectionString));


            serviceCollection.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;


                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.SignIn.RequireConfirmedEmail = true;

            }).AddUserValidator<UserValidator>()
              .AddPasswordValidator<PasswordValidator>()
              .AddErrorDescriber<ErrorDescriber>()
              .AddEntityFrameworkStores<IMSDbContext>();

            serviceCollection.AddScoped<DbInitializer>();

            serviceCollection.AddScoped<IApartmentRepository, EfApartmentRepository>();


        }
    }
}
