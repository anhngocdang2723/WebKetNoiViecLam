using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginRegisterWeb.Data;
using LoginRegisterWeb.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LoginRegisterWebContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginRegisterWebContextConnection' not found.");

builder.Services.AddDbContext<LoginRegisterWebContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LoginRegisterWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LoginRegisterWebContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Map("/redirect-to-project2", builder =>
{
    builder.Use(async (context, next) =>
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var httpClient = context.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient("WebApp-KetNoiViecLam");
            var response = await httpClient.GetAsync("/"); // Đổi đường dẫn tương ứng với Project 2

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
                context.Response.StatusCode = (int)response.StatusCode;
                await context.Response.WriteAsync(content);
            }
            else
            {
                // Xử lý lỗi nếu cần thiết
                await next();
            }
        }
        else
        {
            await next();
        }
    });
});

app.MapWhen(context => context.User.Identity.IsAuthenticated, builder =>
{
    builder.Use(async (context, next) =>
    {
        var httpClient = context.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient("WebApp-KetNoiViecLam");
        var response = await httpClient.GetAsync(context.Request.Path);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync(content);
        }
        else
        {
            // Xử lý lỗi nếu cần thiết
            await next();
        }
    });
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginHome}/{action=Index}/{id?}");

app.Run();
