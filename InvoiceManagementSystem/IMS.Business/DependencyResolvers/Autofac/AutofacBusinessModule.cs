using Autofac;
using IMS.Business.Services.Abstracts;
using IMS.Business.Services.Concretes;
using IMS.Business.Services.CreditCardService.PaymentAPI.Abstracts;
using IMS.Business.Services.CreditCardService.PaymentAPI.Concretes;
using IMS.DataAccess.Abstracts;
using IMS.DataAccess.Concretes;
using IMS.DataAccess.Concretes.EntityFramework;
using Autofac.Extras.DynamicProxy;
using IMS.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using IMS.Core.Utilities.Security.JWT;

namespace IMS.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IUnitOfWork>().As<UnitOfWork>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();//böyle olcak

            builder.RegisterType<IUserRepository>().As<EfUserRepository>();
            builder.RegisterType<IApartmentRepository>().As<EfApartmentRepository>();

            builder.RegisterType<IApartmentTypeRepository>().As<EfApartmentTypeRepository>();
            builder.RegisterType<IHouseRepository>().As<EfHouseRepository>();
            builder.RegisterType<IInvoiceRepository>().As<EfInvoiceRepository>();
            builder.RegisterType<IInvoiceTypeRespository>().As<UnitOfWork>();
            builder.RegisterType<IResidentRepository>().As<EfResidentRepository>();
            builder.RegisterType<ILogRepository>().As<EfLogRepository>();
            builder.RegisterType<IInvoicePaymentRepository>().As<EfInvoicePaymentRepository>();
           
            builder.RegisterType<IUserService>().As<UserManager>();
            builder.RegisterType<IAuthService>().As<AuthManager>();
            builder.RegisterType<IApartmentService>().As<ApartmentManager>();
            builder.RegisterType<IApartmentTypeService>().As<ApartmentTypeManager>();
            builder.RegisterType<IHouseService>().As<HouseManager>();
            builder.RegisterType<IInvoiceTypeService>().As<InvoiceTypeManager>();

            builder.RegisterType<IResidentService>().As<ResidentManager>();
            builder.RegisterType<IInvoiceService>().As<InvoiceManager>();
            builder.RegisterType<IInvoicePaymentService>().As<InvoicePaymentManager>();

            builder.RegisterType<IPaymentService>().As<PaymentManager>();

       
             builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
