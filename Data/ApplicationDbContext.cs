using LazyLoading.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LazyLoading.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Reading> Readings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sensor>().HasData(new Sensor { Id = -1, SensorName="LM35",SensorType="Temperature"});
            builder.Entity<Sensor>().HasData(new Sensor { Id = -2, SensorName="Smoke", SensorType="Smoke"});

            builder.Entity<Reading>().HasData(new Reading { Id = -1, SensorId = -1, Value="20"});
            builder.Entity<Reading>().HasData(new Reading { Id = -2, SensorId = -1, Value = "30" });
            builder.Entity<Reading>().HasData(new Reading { Id = -3, SensorId = -2, Value = "100" });

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
