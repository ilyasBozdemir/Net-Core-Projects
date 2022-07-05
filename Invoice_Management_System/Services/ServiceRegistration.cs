using IMS.Business.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstracts;

namespace Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddScoped<IApartmentService, ApartmentManager>();

        }
    }
}
