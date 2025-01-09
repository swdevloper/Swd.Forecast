using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class ForecastContext: DbContext
    {

        public DbSet<TypeOfMeasuredData> TypeOfMeasuredData { get; set; }
        public DbSet<TypeOfRecommendation> TypeOfRecommendation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string serverName = "DEVELOPERPC-01";
            string dbName = "Swd.Forecast";
            string connectionString = string.Empty;

            connectionString = String.Format("Server={0};Database={1};Trusted_Connection=True;TrustServerCertificate=True", serverName, dbName);

            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new TypeOfRecommendationConfig());
            modelBuilder.ApplyConfiguration(new TypeOfMeasuredDataConfig());
            modelBuilder.ApplyConfiguration(new RecipientConfig());
            modelBuilder.ApplyConfiguration(new MeasuredDataConfig());
            modelBuilder.ApplyConfiguration(new RecommendationConfig());


        }
    }
}
