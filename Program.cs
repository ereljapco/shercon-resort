using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SherconResort.Web.Data;
using SherconResort.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add custom repository and add connection string
builder.Services.AddDbContext<ResortContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ResortConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
// builder.Services.AddIdentityApiEndpoints<IdentityRole>().AddEntityFrameworkStores<ResortContext>().AddDefaultTokenProviders();
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ResortContext>().AddDefaultTokenProviders();

// Build app
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

// app.MapIdentityApi<IdentityUser>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
