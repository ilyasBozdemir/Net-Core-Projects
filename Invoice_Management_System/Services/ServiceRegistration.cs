using Application.Interfaces.UnitOfWork;
using IMS.Business.Services.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.UnitOfWorks;
using Services.Abstracts;
using System.Text;

namespace Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
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
        }
    }
}
