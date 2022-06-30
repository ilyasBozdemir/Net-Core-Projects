using IMS.Core.Utilities.IoC;
using IMS.DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using IMS.DataAccess.Concretes.EntityFramework;
using IMS.Business.Services.Abstracts;
using IMS.Business.Services.Concretes;
using IMS.Business.Services.CreditCardService.PaymentAPI.Concretes;
using IMS.Business.Services.CreditCardService.PaymentAPI.Abstracts;
using IMS.DataAccess.Context.EntityFramework;
using IMS.DataAccess.Concretes;
using System.Reflection;

namespace IMS.Business.DependencyResolvers
{
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<InvoiceManagementDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IApartmentRepository, EfApartmentRepository>();
            services.AddScoped<IApartmentTypeRepository, EfApartmentTypeRepository>();
            services.AddScoped<IHouseRepository, EfHouseRepository>();
            services.AddScoped<IInvoiceRepository, EfInvoiceRepository>();
            services.AddScoped<IInvoiceTypeRespository, EfInvoiceTypeRepository>();
            services.AddScoped<IResidentRepository, EfResidentRepository>();
            services.AddScoped<ILogRepository, EfLogRepository>();
            services.AddScoped<IInvoicePaymentRepository, EfInvoicePaymentRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IApartmentService, ApartmentManager>();
            services.AddScoped<IApartmentTypeService, ApartmentTypeManager>();
            services.AddScoped<IHouseService, HouseManager>();
            services.AddScoped<IInvoiceTypeService, InvoiceTypeManager>();
            services.AddScoped<IResidentService, ResidentManager>();
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IInvoicePaymentService, InvoicePaymentManager>();

            services.AddScoped<IPaymentService, PaymentManager>();


        }
    }
}
