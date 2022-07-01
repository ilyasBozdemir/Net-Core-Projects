
using IMS.Business.DependencyResolvers;
using IMS.Core.DependencyResolvers;
using IMS.Core.Extensions;
using IMS.Core.Utilities.IoC;
using IMS.DataAccess.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using IMS.Core.Middlewares.ConsoleLog;
using System.Reflection;

namespace IMS.Business.Extensions
{
    public class ServiceColectionsExtensions
    {
        public IConfiguration Configuration { get; }
        public ServiceColectionsExtensions(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //
            services.AddDbContext<InvoiceManagementDbContext>();

            //services.AddDbContext<InvoiceManagementDbContext>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //   x => x.MigrationsAssembly("WebApplication")));

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new BusinessModule(),
                new CoreModule()
            });
            
        }
    }
}
