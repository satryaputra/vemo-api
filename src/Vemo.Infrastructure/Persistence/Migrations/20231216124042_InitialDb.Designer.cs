﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vemo.Infrastructure.Persistence;

#nullable disable

namespace Vemo.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231216124042_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vemo.Domain.Entities.Notifications.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Users.AuthInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Otp")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OtpExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AuthInfos");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d478e2c-e27b-4c71-b0de-8779d92c2e62"),
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 470, DateTimeKind.Utc).AddTicks(5273),
                            Email = "admin@vemo.com",
                            Name = "admin",
                            Password = "czOPTC7GUjb2N+GHVpwBHfuCuLIseT1PKjuiOE44iJmdl+lv",
                            Role = "admin"
                        },
                        new
                        {
                            Id = new Guid("a306652d-6dba-4e74-bac4-2515ff7864d4"),
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7474),
                            Email = "customer@vemo.com",
                            Name = "customer",
                            Password = "LHWkaVWNzPZS8piwSlznbnn39+rZa076AUCb422fPW/gyt47",
                            Role = "customer"
                        });
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.ConditionPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastMaintenance")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ConditionParts");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.MaintenancePart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("MaintenanceFinalPrice")
                        .HasColumnType("double precision");

                    b.Property<double>("MaintenanceServiceFinalPrice")
                        .HasColumnType("double precision");

                    b.Property<Guid>("MaintenanceVehicleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceVehicleId");

                    b.HasIndex("PartId");

                    b.ToTable("MaintenanceParts");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.MaintenanceVehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("MaintenanceVehicles");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AgeInMonth")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("MaintenancePrice")
                        .HasColumnType("real");

                    b.Property<float>("MaintenanceServicePrice")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("VehicleType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b64bd30-e011-4a3d-9375-c2dafd112746"),
                            AgeInMonth = 4,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7579),
                            MaintenancePrice = 50000f,
                            MaintenanceServicePrice = 10000f,
                            Name = "Oli"
                        },
                        new
                        {
                            Id = new Guid("ce84e32e-b732-4235-a74f-dc7a08d9db57"),
                            AgeInMonth = 10,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7582),
                            MaintenancePrice = 30000f,
                            MaintenanceServicePrice = 20000f,
                            Name = "Radiator"
                        },
                        new
                        {
                            Id = new Guid("da8198bd-b5d0-451b-a8cb-77bc14d6db22"),
                            AgeInMonth = 6,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7587),
                            MaintenancePrice = 25000f,
                            MaintenanceServicePrice = 5000f,
                            Name = "Busi"
                        },
                        new
                        {
                            Id = new Guid("1cfbba50-68c2-48d8-935c-e75c7459b9b8"),
                            AgeInMonth = 5,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7589),
                            MaintenancePrice = 40000f,
                            MaintenanceServicePrice = 15000f,
                            Name = "Rem"
                        },
                        new
                        {
                            Id = new Guid("9025bed6-60ce-4ba0-b440-754bc9b130ef"),
                            AgeInMonth = 24,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7591),
                            MaintenancePrice = 300000f,
                            MaintenanceServicePrice = 25000f,
                            Name = "Ban"
                        },
                        new
                        {
                            Id = new Guid("eeaaad84-03b2-4db6-bb08-65feddfa2ca7"),
                            AgeInMonth = 3,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7593),
                            MaintenancePrice = 20000f,
                            MaintenanceServicePrice = 10000f,
                            Name = "Aki"
                        },
                        new
                        {
                            Id = new Guid("1e335e39-3dd1-4210-8a77-f119cb26feb0"),
                            AgeInMonth = 8,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7596),
                            MaintenancePrice = 60000f,
                            MaintenanceServicePrice = 20000f,
                            Name = "V-Belt",
                            VehicleType = "matic"
                        },
                        new
                        {
                            Id = new Guid("b4522f19-1ea2-4dea-bfaa-6ab708f2ffc7"),
                            AgeInMonth = 12,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7598),
                            MaintenancePrice = 100000f,
                            MaintenanceServicePrice = 20000f,
                            Name = "CVT",
                            VehicleType = "matic"
                        },
                        new
                        {
                            Id = new Guid("717786c0-7673-486b-9d39-cb7a41d4033c"),
                            AgeInMonth = 8,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7600),
                            MaintenancePrice = 100000f,
                            MaintenanceServicePrice = 20000f,
                            Name = "Rantai dan Gear",
                            VehicleType = "manual"
                        },
                        new
                        {
                            Id = new Guid("8f8d9d55-3011-4dc4-b819-873e82f7f751"),
                            AgeInMonth = 9,
                            CreatedAt = new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7601),
                            MaintenancePrice = 100000f,
                            MaintenanceServicePrice = 20000f,
                            Name = "Kampas Kopling",
                            VehicleType = "manual"
                        });
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PurchasingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Notifications.Notification", b =>
                {
                    b.HasOne("Vemo.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Users.AuthInfo", b =>
                {
                    b.HasOne("Vemo.Domain.Entities.Users.User", "User")
                        .WithOne("UserAuthInfo")
                        .HasForeignKey("Vemo.Domain.Entities.Users.AuthInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.ConditionPart", b =>
                {
                    b.HasOne("Vemo.Domain.Entities.Vehicles.Part", "Part")
                        .WithMany("ConditionParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vemo.Domain.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany("ConditionParts")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.MaintenancePart", b =>
                {
                    b.HasOne("Vemo.Domain.Entities.Vehicles.MaintenanceVehicle", "MaintenanceVehicle")
                        .WithMany("MaintenanceParts")
                        .HasForeignKey("MaintenanceVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vemo.Domain.Entities.Vehicles.Part", "Part")
                        .WithMany("MaintenanceParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceVehicle");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.MaintenanceVehicle", b =>
                {
                    b.HasOne("Vemo.Domain.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany("MaintenanceVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.HasOne("Vemo.Domain.Entities.Users.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("UserAuthInfo");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.MaintenanceVehicle", b =>
                {
                    b.Navigation("MaintenanceParts");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.Part", b =>
                {
                    b.Navigation("ConditionParts");

                    b.Navigation("MaintenanceParts");
                });

            modelBuilder.Entity("Vemo.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.Navigation("ConditionParts");

                    b.Navigation("MaintenanceVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}