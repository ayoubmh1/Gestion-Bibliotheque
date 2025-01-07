using Bibliotheque.Data;
using Bibliotheque.Services;
using Microsoft.EntityFrameworkCore;

namespace Bibliotheque
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetBibliotheque")));


            //les services que je dois ajouter hh
            builder.Services.AddScoped<ServiceLivre>();
            builder.Services.AddScoped<ServiceEmprunt>();
            builder.Services.AddScoped<ServiceNotification>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
