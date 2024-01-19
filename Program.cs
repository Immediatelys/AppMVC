using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<AppDbContext>(option =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
    option.UseSqlServer(connectionString);
});


builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<PlanetService>();

// thiet lap duong dan thay the khi tim trong /Views/Controllers/action khong thay
builder.Services.Configure<RazorViewEngineOptions>(option =>
{
    /*
        {0} : Action
        {1} : controller
        {2} : Areas
    */

    option.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/sayhi", async (context) =>
    {
        await context.Response.WriteAsync("hello world");
    });

    // endpoints.MapControllers
    // endpoints.MapControllerRoute
    // endpoints.MapDefaultControllerRoute
    // endpoints.MapAreaControllerRoute

    // [AcceptVerbs]
    // [Route]
    // [HttpGet]
    // [HttpPost]
    // [HttpPut]
    // [HttpDelete]
    // [HttpHead]
    // [HttpPatch]

    endpoints.MapControllers();



    // endpoints.MapControllerRoute(
    //     name: "first",
    //     pattern: "{url:regex(^((xemsanpham)|(viewproduct)$)}/{id:range(2,4)}",
    //     defaults: new
    //     {
    //         controller = "First",
    //         action = "ViewProduct"
    //     }
    //     // constraints: new {
    //     //     // url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct)$"),
    //     //     // id = new RangeRouteConstraint(1,3)
    //     // }

    // );

    endpoints.MapAreaControllerRoute(
        name: "products",
        areaName: "ProductManage",
        pattern: "{controller}/{action=Index}/{id?}"

    );




    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"

    );

    endpoints.MapRazorPages();
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.MapRazorPages();

app.Run();
