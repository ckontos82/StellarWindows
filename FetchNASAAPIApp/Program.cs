using FetchNASAAPIApp.DAO;
using FetchNASAAPIApp.DAO.Interface;
using FetchNASAAPIApp.Database;
using FetchNASAAPIApp.Services;
using FetchNASAAPIApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FetchNASAAPIApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient("NasaClient", client =>
            {
                client.BaseAddress = new Uri("https://api.nasa.gov/planetary/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<INasaApiService, NasaApiService>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPictureDAO, PictureDAO>();
            builder.Services.AddScoped<IPictureService, PictureService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
