using Microsoft.EntityFrameworkCore;
using TestBlazorAPP.Components;
using TestBlazorAPP.Database;
using TestBlazorAPP.Services;

namespace TestBlazorAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /* Um das Passwort für die Datenbank zu verstecken verwenden wir User Secrets
                Dazu muss die "Developer Powershell" geöffnet werden und das Modul initialisiert werden
                dotnet user-secrets init
                dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=mydb;Username=myuser;Password=YourSecurePassword"
                Blazor verwendet dann automatisch des secret sofern es aus der appsettings.json entfernt wurde
            */

            // DB Verbindung
            builder.Services.AddDbContextFactory<AppDBContext>(options =>
                //options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString")));
                options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnectionString")));

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Füge Bootstrap hinzu
            builder.Services.AddBlazorBootstrap();
            // Füge eigenes Service hinzu
            builder.Services.AddScoped<DataService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
