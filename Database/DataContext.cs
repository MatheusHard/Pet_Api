using Microsoft.EntityFrameworkCore;
using Pet_Api.Models;

namespace Pet_Api.Database
{
    public class DataContext : DbContext
    {
        public DbSet<TipoPet> TiposPets { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<Pet> Pets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

             var connectionString = configuration.GetConnectionString("DefaultConnection");

            //var connectionString = "server=localhost;port=3306;database=petapi;user=root;password=1234";

            optionsBuilder.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString),
                        p => p.EnableRetryOnFailure(maxRetryCount: 3, ///Colocar quantidade de Retry
                                                    maxRetryDelay: TimeSpan.FromSeconds(4),
                                                    errorNumbersToAdd: null));
        }
    }
}





