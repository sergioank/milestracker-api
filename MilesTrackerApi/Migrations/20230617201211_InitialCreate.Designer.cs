﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilesTrackerApi.Data;

#nullable disable

namespace MilesTrackerApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230617201211_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MilesTrackerApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MPG")
                        .HasColumnType("int");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Fuel_log", b =>
                {
                    b.Property<int>("Fuel_log_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Fuel_log_id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<float>("Cost_per_unit")
                        .HasColumnType("real");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Odometer_reading")
                        .HasColumnType("int");

                    b.Property<float>("Total_cost")
                        .HasColumnType("real");

                    b.Property<int>("Vehicle_id")
                        .HasColumnType("int");

                    b.HasKey("Fuel_log_id");

                    b.HasIndex("Vehicle_id");

                    b.ToTable("FuelLogs");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Maintenance", b =>
                {
                    b.Property<int>("Maintenance_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Maintenance_Id"));

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vehicle_Id")
                        .HasColumnType("int");

                    b.HasKey("Maintenance_Id");

                    b.HasIndex("Vehicle_Id");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Setting", b =>
                {
                    b.Property<int>("Setting_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Setting_Id"));

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Distance_Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fuel_Consumption_Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Setting_Id");

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Trip", b =>
                {
                    b.Property<int>("Trip_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Trip_Id"));

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("End_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("Vehicle_Id")
                        .HasColumnType("int");

                    b.HasKey("Trip_Id");

                    b.HasIndex("User_Id");

                    b.HasIndex("Vehicle_Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Vehicle", b =>
                {
                    b.Property<int>("Vehicle_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Vehicle_Id"));

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("License_Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Odometer")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Vehicle_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Fuel_log", b =>
                {
                    b.HasOne("MilesTrackerApi.Models.Vehicle", "Vehicle")
                        .WithMany("FuelLogs")
                        .HasForeignKey("Vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Maintenance", b =>
                {
                    b.HasOne("MilesTrackerApi.Models.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("Vehicle_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Setting", b =>
                {
                    b.HasOne("MilesTrackerApi.Models.User", null)
                        .WithOne("Setting")
                        .HasForeignKey("MilesTrackerApi.Models.Setting", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Trip", b =>
                {
                    b.HasOne("MilesTrackerApi.Models.User", "User")
                        .WithMany("Trips")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MilesTrackerApi.Models.Vehicle", "Vehicle")
                        .WithMany("Trips")
                        .HasForeignKey("Vehicle_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Vehicle", b =>
                {
                    b.HasOne("MilesTrackerApi.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.User", b =>
                {
                    b.Navigation("Setting")
                        .IsRequired();

                    b.Navigation("Trips");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MilesTrackerApi.Models.Vehicle", b =>
                {
                    b.Navigation("FuelLogs");

                    b.Navigation("Maintenances");

                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
