using Application.Interfaces.UnitOfWork;
using Services.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.UnitOfWorks;
using Services.Abstracts;
using System.Text;
using Microsoft.AspNetCore.Http;
using Domain.Entities.Identity;
using Infrastructure.IdentitySettings.Requirements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.IdentitySettings;
using Application.Helpers;

namespace Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddScoped<IClaimsTransformation, ClaimsTransformation>();
            serviceCollection.AddScoped<IAuthorizationHandler, FreeTrialExpireHandler>();
            serviceCollection.AddScoped<IAuthorizationHandler, MinimumAgeHandler>();

            serviceCollection.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            serviceCollection.AddScoped<EmailHelper>();
            serviceCollection.AddScoped<TwoFactorAuthenticationService>();


            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddTransient<IApartmentService, ApartmentManager>();


            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        //Oluşturulacak token değerini kimlerin/hangi originlerin/sitelerin kullanıcı belirlediğimiz değerdir
                        ValidateIssuer = true, 
                        //Oluşturulacak token değerini kimin dağıttını ifade edeceğimiz alandır.
                        ValidateLifetime = true,
                        //Oluşturulan token değerinin süresini kontrol edecek olan doğrulamadır.
                        ValidateIssuerSigningKey = true,
                        //Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden security key verisinin doğrulanmasıdır.
                        ValidAudience = configuration["Token:Audience"],
                        ValidIssuer = configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]))
                    };
                });

            // serviceCollection.AddAuthentication()
            //.AddFacebook(options =>
            //{
            //    options.AppId = Configuration.GetValue<string>("ExternalLoginProviders:Facebook:AppId");
            //    options.AppSecret = Configuration.GetValue<string>("ExternalLoginProviders:Facebook:AppSecret");
            //    // options.CallbackPath = new PathString("/User/FacebookCallback");
            //})
            //.AddGoogle(options =>
            //{
            //    options.ClientId = Configuration.GetValue<string>("ExternalLoginProviders:Google:ClientId");
            //    options.ClientSecret = Configuration.GetValue<string>("ExternalLoginProviders:Google:ClientSecret");
            //})
            //.AddMicrosoftAccount(options =>
            //{
            //    options.ClientId = Configuration.GetValue<string>("ExternalLoginProviders:Microsoft:ClientId");
            //    options.ClientSecret = Configuration.GetValue<string>("ExternalLoginProviders:Microsoft:ClientSecret");
            //});

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
        }
    }
}
