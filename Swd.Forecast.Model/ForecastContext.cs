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
        public DbSet<Recipient> Recipient { get; set; }
        public DbSet<MeasuredData> MeasuredData { get; set; }
        public DbSet<Recommendation> Recommendation { get; set; }
        public DbSet<CommunicationList> CommunicationList  { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string serverName = "DEVELOPERPC-01";
            string dbName = "Swd.Forecast";
            string userName = "swd.forecast";
            string password = "Pa$$w0rd";
            string connectionString = string.Empty;

            connectionString = String.Format("Server={0};Database={1};Trusted_Connection=True;TrustServerCertificate=True", serverName, dbName);
            //connectionString = String.Format("Server={0};Database={1};User Id={2};Password={3};TrustServerCertificate=True", serverName, dbName, userName, password);

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
            modelBuilder.ApplyConfiguration(new CommunicationListConfig());
        }
    }
}
