using Application.Utilities.Interceptors;
using  Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace Application.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<Services.Concretes.ApartmentManager>().As<Services.AbstractsIApartmentService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
