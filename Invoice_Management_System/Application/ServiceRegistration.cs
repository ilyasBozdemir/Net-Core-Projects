using Microsoft.Extensions.DependencyInjection;

using FluentValidation;
using Application.Validators.FluentValidation;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Application.Utilities.Inversion_Of_Control;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration Configuration = null)
        {
            //Validators > FluentValidation register

            //services.AddScoped<IValidator<ApartmentType>, ApartmentValidator>();

            services.AddValidatorsFromAssemblyContaining<ApartmentValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<ApartmentTypeValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<HouseValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<InvoicePaymentValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<InvoiceTypeValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<InvoiceValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<ResidentValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<UserValidator>(ServiceLifetime.Transient);

            // 

            // builder.Services.AddScoped<IPersonRepository, PersonRepository>();


            //

            ServiceTool.Create(services);

            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
           

        }
    }
}
