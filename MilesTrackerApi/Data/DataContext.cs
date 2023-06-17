using System;
using System.Collections.Generic;
using System.Drawing;
using MilesTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MilesTrackerApi.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Fuel_log> FuelLogs { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasKey(t => t.Trip_Id);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.User)
                .WithMany(u => u.Trips)
                .HasForeignKey(t => t.User_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Vehicle)
                .WithMany(v => v.Trips)
                .HasForeignKey(t => t.Vehicle_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Vehicle_Id);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.User)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(v => v.User_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Other entity configurations

            modelBuilder.Entity<User>()
    .HasOne(u => u.Setting)
    .WithOne()
    .HasForeignKey<Setting>(s => s.User_Id)
    .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}

