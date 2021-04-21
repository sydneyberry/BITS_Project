using BITS_Project.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using BITS_Project;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var rentalContext = services.GetRequiredService<RentalContext>();
                    rentalContext.Database.EnsureCreated();

                    var reservationContext = services.GetRequiredService<ReservationContext>();
                    reservationContext.Database.EnsureCreated();

                    var tournamentContext = services.GetRequiredService<TournamentContext>();
                    tournamentContext.Database.EnsureCreated();

                    var equipmentContext = services.GetRequiredService<EquipmentContext>();
                    equipmentContext.Database.EnsureCreated();

                    DbInitializer.Initialize(rentalContext, equipmentContext);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}