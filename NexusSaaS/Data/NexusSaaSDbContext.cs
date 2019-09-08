using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NexusSaaS.Models;
using System.IO;

namespace NexusSaaS.Data
{
    public class NexusSaaSDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseMySql(configuration["ConnectionStrings:NexusSaaSDb"]);
        }

        public DbSet<FeatureModel> Features { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
    }
}
