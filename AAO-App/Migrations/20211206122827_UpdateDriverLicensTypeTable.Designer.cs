﻿// <auto-generated />
using System;
using AAO_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AAO_App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211206122827_UpdateDriverLicensTypeTable")]
    partial class UpdateDriverLicensTypeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AAO_App.Models.Availability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailabilityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("AvailabilityId");

                    b.HasIndex("AvailabilityTypeId");

                    b.HasIndex("DriverId");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("AAO_App.Models.AvailabilityType", b =>
                {
                    b.Property<int>("AvailabilityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvailabilityTypeId");

                    b.ToTable("AvailabilityTypes");
                });

            modelBuilder.Entity("AAO_App.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AAO_App.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AAO_App.Models.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.HasIndex("CityId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AAO_App.Models.DepartmentHasEmployee", b =>
                {
                    b.Property<int>("DepartmentHasEmployeesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentsDepId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmppId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentHasEmployeesId");

                    b.HasIndex("DepartmentsDepId");

                    b.HasIndex("EmployeesEmployeeId");

                    b.ToTable("DepartmentHasEmployees");
                });

            modelBuilder.Entity("AAO_App.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DriverLicensType")
                        .HasColumnType("int");

                    b.Property<int?>("DriverLicensTypesDriverLicensTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverId");

                    b.HasIndex("DriverLicensTypesDriverLicensTypeId");

                    b.HasIndex("LoginId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("AAO_App.Models.DriverLicensType", b =>
                {
                    b.Property<int>("DriverLicensTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("LicensTypeId")
                        .HasColumnType("int");

                    b.HasKey("DriverLicensTypeId");

                    b.ToTable("DriverLicensTypes");
                });

            modelBuilder.Entity("AAO_App.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AAO_App.Models.LicensType", b =>
                {
                    b.Property<int>("LicensTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DriverLicensTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LicensExpDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("LicensImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LicensName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicensTypeId");

                    b.HasIndex("DriverLicensTypeId");

                    b.ToTable("LicensTypes");
                });

            modelBuilder.Entity("AAO_App.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("AAO_App.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverBuddy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("MessageContents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TripInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.HasIndex("CityId");

                    b.HasIndex("DriverId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("AAO_App.Models.Availability", b =>
                {
                    b.HasOne("AAO_App.Models.AvailabilityType", "AvailabilityTypes")
                        .WithMany()
                        .HasForeignKey("AvailabilityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_App.Models.Driver", "Drivers")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailabilityTypes");

                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("AAO_App.Models.City", b =>
                {
                    b.HasOne("AAO_App.Models.Country", "Countries")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("AAO_App.Models.Department", b =>
                {
                    b.HasOne("AAO_App.Models.City", "Cities")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("AAO_App.Models.DepartmentHasEmployee", b =>
                {
                    b.HasOne("AAO_App.Models.Department", "Departments")
                        .WithMany()
                        .HasForeignKey("DepartmentsDepId");

                    b.HasOne("AAO_App.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId");

                    b.Navigation("Departments");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AAO_App.Models.Driver", b =>
                {
                    b.HasOne("AAO_App.Models.DriverLicensType", "DriverLicensTypes")
                        .WithMany("Driver")
                        .HasForeignKey("DriverLicensTypesDriverLicensTypeId");

                    b.HasOne("AAO_App.Models.Login", "UserLogin")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DriverLicensTypes");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("AAO_App.Models.LicensType", b =>
                {
                    b.HasOne("AAO_App.Models.DriverLicensType", null)
                        .WithMany("LicensType")
                        .HasForeignKey("DriverLicensTypeId");
                });

            modelBuilder.Entity("AAO_App.Models.Trip", b =>
                {
                    b.HasOne("AAO_App.Models.City", "Cities")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_App.Models.Driver", "Drivers")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_App.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Drivers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AAO_App.Models.DriverLicensType", b =>
                {
                    b.Navigation("Driver");

                    b.Navigation("LicensType");
                });
#pragma warning restore 612, 618
        }
    }
}
