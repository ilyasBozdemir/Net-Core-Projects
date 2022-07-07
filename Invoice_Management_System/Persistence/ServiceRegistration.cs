using Application.Helpers;
using Application.Repositories;
using Domain.Entities.Identity;
using Infrastructure.IdentitySettings;
using Infrastructure.IdentitySettings.Requirements;
using Infrastructure.IdentitySettings.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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


            serviceCollection.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            serviceCollection.AddScoped<EmailHelper>();
            serviceCollection.AddScoped<TwoFactorAuthenticationService>();

            serviceCollection.AddIdentity<User, Role>(options =>
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

            serviceCollection.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/User/Login");
                options.LogoutPath = new PathString("/User/Logout");
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");

                options.Cookie = new()
                {
                    Name = "IdentityCookie",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            serviceCollection.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = Configuration.GetValue<string>("ExternalLoginProviders:Facebook:AppId");
                    options.AppSecret = Configuration.GetValue<string>("ExternalLoginProviders:Facebook:AppSecret");
                    // options.CallbackPath = new PathString("/User/FacebookCallback");
                })
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration.GetValue<string>("ExternalLoginProviders:Google:ClientId");
                    options.ClientSecret = Configuration.GetValue<string>("ExternalLoginProviders:Google:ClientSecret");
                })
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = Configuration.GetValue<string>("ExternalLoginProviders:Microsoft:ClientId");
                    options.ClientSecret = Configuration.GetValue<string>("ExternalLoginProviders:Microsoft:ClientSecret");
                });

            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireClaim("Admin", OperationClaims.Admin!);
                });

                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.RequireClaim("User", OperationClaims.User!);
                });

                options.AddPolicy("AnonymousPolicy", policy =>
                {
                    policy.RequireClaim("Anonymous", OperationClaims.Anonymous!);
                });

                options.AddPolicy("FreeTrialPolicy", policy =>
                {
                    policy.Requirements.Add(new FreeTrialExpireRequirement());
                });

                options.AddPolicy("AtLeast18Policy", policy =>
                {
                    policy.AddRequirements(new MinimumAgeRequirement(18));
                });
            });


            serviceCollection.AddScoped<DbInitializer>();

            serviceCollection.AddScoped<IClaimsTransformation, ClaimsTransformation>();


            serviceCollection.AddScoped<IApartmentRepository, EfApartmentRepository>();


        }
    }
}
