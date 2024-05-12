using Microsoft.EntityFrameworkCore;
using TestTaskAlkona.Application.Services;
using TestTaskAlkona.Core.Interfaces;
using TestTaskAlkona.MVC.Filters;
using TestTaskAlkona.Persistance;
using TestTaskAlkona.Persistance.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews(opts =>
        {
            opts.Filters.Add<GlobalExceptionFilter>();
        });

        builder.Services.AddScoped<IContractRepository, ContractRepository>();
        builder.Services.AddScoped<IContractService, ContractService>();


        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<AppDbContext>(opts =>
        {
            opts.UseNpgsql(connectionString);
        });

        builder.Services.AddProblemDetails();

        var app = builder.Build();

        app.UseStatusCodePages(async context =>
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            if (request.Headers.XRequestedWith == "XMLHttpRequest")
            {
                response.ContentType = "application/json";
                await response.WriteAsync("{\"status\": " + (int)context.HttpContext.Response.StatusCode + "}");
            }
            else
            {
                context.HttpContext.Response.Redirect("/Error/");
            }
        });

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}