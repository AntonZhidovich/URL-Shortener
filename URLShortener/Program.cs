namespace URLShortenerApp;

using Microsoft.EntityFrameworkCore;
using URLShortenerApp.Data;
using URLShortenerApp.Shortener;

static class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDBContext>(options => options.UseMySql(
            builder.Configuration.GetConnectionString("MariaDBConnection"),
			new MySqlServerVersion(new Version(10, 3, 39))));
        builder.Services.AddTransient<IUrlShortener, UrlShortener>();
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.Run();
    }
}
