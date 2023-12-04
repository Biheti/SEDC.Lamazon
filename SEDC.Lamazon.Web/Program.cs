using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Context;
using SEDC.Lamazon.DataAccess.Inplementations;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.Implementations;
using SEDC.Lamazon.Services.Interfaces;

namespace SEDC.Lamazon.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<LamazonDbContext>(options =>
        {
            options.UseSqlServer("Server=DESKTOP-T1Q6HKH\\SQLEXPRESS;Database=LamazonStoreDB;TrustServerCertificate=true;Trusted_Connection=True");
        });


        builder.Services.AddScoped<IProductRepository,ProductRepository >();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
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