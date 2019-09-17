using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NexusSaaS.Entity;
using System.IO;
using NexusSaaS.Models;

namespace NexusSaaS.Data
{
    public class NexusSaaSDbContext : DbContext
    {
        public NexusSaaSDbContext(DbContextOptions<NexusSaaSDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();
        //    optionsBuilder.UseMySql(configuration["ConnectionStrings:NexusSaaSDb"]);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleUser>()
                .HasKey(ru => new { ru.UserId, ru.RoleId });

            //modelBuilder.Entity<UserEntity>()
            //                .HasMany(u => u.RoleUsers)
            //                .WithOne(u => u.UserEntity).IsRequired()
            //                .HasForeignKey(u => u.UserEntity);

            //modelBuilder.Entity<Role>()
            //            .HasMany(r => r.RoleUsers)
            //            .WithOne(r => r.Role).IsRequired()
            //            .HasForeignKey(r => r.RoleId);
        }


        #region Khai bao dbset
        public DbSet<FeatureEntity> Features { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        #endregion
    }
}
