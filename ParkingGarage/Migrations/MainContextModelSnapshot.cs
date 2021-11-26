﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingGarage.Data;

namespace ParkingGarage.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParkingGarage.Models.ParkingLot.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LicensePlateId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlateId")
                        .IsUnique();

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("Vehicle.Vehicle", b =>
                {
                    b.Property<string>("LicensePlateId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Class")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Ticket")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("LicensePlateId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParkingGarage.Models.ParkingLot.ParkingLot", b =>
                {
                    b.HasOne("Vehicle.Vehicle", "Vehicle")
                        .WithOne("ParkingLot")
                        .HasForeignKey("ParkingGarage.Models.ParkingLot.ParkingLot", "LicensePlateId");
                });
#pragma warning restore 612, 618
        }
    }
}
