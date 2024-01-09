using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp_KetNoiViecLam.Data;
using Microsoft.AspNetCore.Identity;
using UserIdentity.Areas.Identity.Data;
using UserIdentity.Data;
using WebApp_KetNoiViecLam.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebApp_KetNoiViecLamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApp_KetNoiViecLamContext") ?? throw new InvalidOperationException("Connection string 'WebApp_KetNoiViecLamContext' not found.")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Điều chỉnh theo yêu cầu của dự án của bạn
})
.AddEntityFrameworkStores<WebApp_KetNoiViecLamContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeWeb}/{action=Index}/{id?}");

app.Run();