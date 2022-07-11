using Persistence;
using Application;
using Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Services.DependencyResolvers.Autofac;
using System.Reflection;
using Services;
using Persistence.Extensions.Seeding;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration); 
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>
    (builder => builder.RegisterModule(new AutofacModule()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseItToSeedSqlServer();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
   
//app.UseConsoleLogMiddleware();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseSession();

//app.Use(async (context, next) =>
//{
//    var token = context.Session.GetString("Token");
//    if (!string.IsNullOrEmpty(token))
//    {
//        context.Request.Headers.Add("Authorization", "Bearer " + token);
//    }
//    await next();
//});

app.UseStatusCodePages(async context => {
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        response.Redirect("/Auth/Login");
    }
    else if (response.StatusCode == (int)HttpStatusCode.Forbidden)
    {
        response.Redirect("/Home/Forbidden");
    }
});


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
      //pattern: "{controller=Auth}/{action=Login}/{id?}");
      pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Auth}/{action=Login}/{id?}"

    );
});
app.Run();