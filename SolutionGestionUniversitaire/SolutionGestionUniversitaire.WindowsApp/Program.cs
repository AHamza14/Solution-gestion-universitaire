using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SolutionGestionUniversitaire.Core.Interfaces;
using SolutionGestionUniversitaire.Core.Services;
using SolutionGestionUniversitaire.Infrastructure;
using SolutionGestionUniversitaire.Infrastructure.Repositories;

namespace SolutionGestionUniversitaire.WindowsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddDbContext<SolutionGestionUniversitaireContext>(options => options.UseSqlServer(@"Data Source=HAMZAX1\SQLEXPRESS;Database=SystemeSGUDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=""SQL Server Management Studio"";Command Timeout=0"));
                  services.AddSingleton<AjouterProfForm>();
                  services.AddLogging(configure => configure.AddConsole());
                  services.AddScoped<IProfesseurRepository, ProfesseurRepository>();
                  services.AddScoped<IEtudiantRepository, EtudiantRepository>();
                  services.AddScoped<IGestionUniversitaireService, GestionUniversitaireService>();

              });

            var host = builder.Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var forms = services.GetRequiredService<AjouterProfForm>();
                    Application.Run(forms);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}