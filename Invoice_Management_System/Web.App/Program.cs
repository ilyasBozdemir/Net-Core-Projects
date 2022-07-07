using Persistence;
using Application;
using Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Application.DependencyResolvers.Autofac;
using System.Reflection;
using Services;
using Persistence.Extensions.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration); 
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host
    .ConfigureContainer<ContainerBuilder>
    (builder => builder.RegisterModule(new AutofacBusinessModule()));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
    app.UseItToSeedSqlServer();   

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
//- Authentication is the act of validating the user is who they are
//- Kimlik doðrulama, kullanýcýnýn kim olduðunu doðrulama eylemidir.
app.UseAuthorization();
//- Authorization is the act of validating that a user can access the resource
//- Yetkilendirme, bir kullanýcýnýn kaynaða eriþebileceðini doðrulama eylemidir

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default",
         pattern: "{controller=Auth}/{action=Login}/{id?}");
    //pattern: "{controller=Home}/{action=Login}/{id?}");


    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Auth}/{action=Login}/{id?}"

    );
});
app.Run();