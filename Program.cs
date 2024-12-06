using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MailroomApplication.Models;
using MvcPackage.Data;
using MailroomApplication.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcPackageContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcPackageContext") ?? throw new InvalidOperationException("Connection string 'MvcPackageContext' not found.")));

var connectionString = builder.Configuration.GetConnectionString("LoginDbContext");

builder.Services.AddDbContext<LoginDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LoginDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    LoginInitialize.Initialize(services, userManager).Wait();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();
app.Run();
