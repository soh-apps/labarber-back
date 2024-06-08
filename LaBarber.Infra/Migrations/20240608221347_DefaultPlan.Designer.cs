﻿// <auto-generated />
using System;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20240608221347_DefaultPlan")]
    partial class DefaultPlan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LaBarber.Domain.Entities.AppUser.AppUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("CompanyId");

                    b.Property<int>("CredentialId")
                        .HasColumnType("integer")
                        .HasColumnName("CredentialId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("RegisterDate");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CredentialId");

                    b.ToTable("AppUser");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CredentialId = 1,
                            Name = "admin",
                            RegisterDate = new DateTime(2024, 6, 8, 22, 13, 47, 326, DateTimeKind.Utc).AddTicks(1150),
                            Status = 1
                        });
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Appointment.AppointmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text")
                        .HasColumnName("AdditionalInfo");

                    b.Property<int>("BarberId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberId");

                    b.Property<int>("BarberUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitId");

                    b.Property<decimal?>("CommissionValue")
                        .HasColumnType("numeric")
                        .HasColumnName("CommissionValue");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("CompanyId");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("CustomerId");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CustomerName");

                    b.Property<DateTime>("EndAppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndAppointmentDate");

                    b.Property<bool>("IsCommissioned")
                        .HasColumnType("boolean")
                        .HasColumnName("IsCommissioned");

                    b.Property<int?>("PaymentMethod")
                        .HasColumnType("integer")
                        .HasColumnName("PaymentMethod");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("ServiceId");

                    b.Property<DateTime>("StartAppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("StartAppointmentDate");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("BarberUnitId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberAvailabilityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberId");

                    b.Property<TimeSpan>("EndWorkingHour")
                        .HasColumnType("interval")
                        .HasColumnName("EndWorkingHour");

                    b.Property<TimeSpan>("StartWorkingHour")
                        .HasColumnType("interval")
                        .HasColumnName("StartWorkingHour");

                    b.Property<int>("WorkingDay")
                        .HasColumnType("integer")
                        .HasColumnName("WorkingDay");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.ToTable("BarberAvailability");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("City");

                    b.Property<bool>("Commissioned")
                        .HasColumnType("boolean")
                        .HasColumnName("Commissioned");

                    b.Property<int>("CredentialId")
                        .HasColumnType("integer")
                        .HasColumnName("CredentialId");

                    b.Property<DateTime?>("LastPayment")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastPayment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("NextPayment")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("NextPayment");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("RegisterDate");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("State");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("BarberUnitId");

                    b.HasIndex("CredentialId");

                    b.ToTable("Barber");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberPaymentHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberId");

                    b.Property<int>("BarberUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitId");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("PaymentDate");

                    b.Property<decimal>("PaymentValue")
                        .HasColumnType("numeric")
                        .HasColumnName("PaymentValue");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("BarberUnitId");

                    b.ToTable("BarberPaymentHistory");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberUnitAvailabilityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitId");

                    b.Property<TimeSpan>("EndWorkingHour")
                        .HasColumnType("interval")
                        .HasColumnName("EndWorkingHour");

                    b.Property<TimeSpan>("StartWorkingHour")
                        .HasColumnType("interval")
                        .HasColumnName("StartWorkingHour");

                    b.Property<int>("WorkingDay")
                        .HasColumnType("integer")
                        .HasColumnName("WorkingDay");

                    b.HasKey("Id");

                    b.HasIndex("BarberUnitId");

                    b.ToTable("BarberUnitAvailability");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberUnitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("City");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Complement");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("State");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("BarberUnit");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberWalletEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberId");

                    b.Property<decimal>("Commission")
                        .HasColumnType("numeric")
                        .HasColumnName("Commission");

                    b.Property<decimal>("Earnings")
                        .HasColumnType("numeric")
                        .HasColumnName("Earnings");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.ToTable("BarberWallet");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Company.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("LastPayment")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastPayment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<DateTime>("NextPayment")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("NextPayment");

                    b.Property<int>("SigningPlanId")
                        .HasColumnType("integer")
                        .HasColumnName("SigningPlanId");

                    b.HasKey("Id");

                    b.HasIndex("SigningPlanId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Credential.CredentialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChangePasswordCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ChangePasswordCode");

                    b.Property<bool>("ChangedPassword")
                        .HasColumnType("boolean")
                        .HasColumnName("ChangedPassword");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Password");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer")
                        .HasColumnName("ProfileId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Credential");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChangePasswordCode = "",
                            ChangedPassword = false,
                            Email = "admin@labarber.com.br",
                            Password = "21826A058D9D3DBCDB208EEF87DB2C024BDD6A7DE9ADC1C344E14010EA3730D0A0093A8F57C5AC9EE6ED335B0136764D51E7B9543C8F2EA06F89EC3688ACDADA",
                            ProfileId = 1,
                            Username = "teste"
                        });
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Customer.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("CompanyId");

                    b.Property<int>("CredentialId")
                        .HasColumnType("integer")
                        .HasColumnName("CredentialId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<DateTime?>("LastPayment")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastPayment");

                    b.Property<bool>("MonthlyPayer")
                        .HasColumnType("boolean")
                        .HasColumnName("MonthlyPayer");

                    b.Property<int?>("MonthlyPlanId")
                        .HasColumnType("integer")
                        .HasColumnName("MonthlyPlanId");

                    b.Property<decimal?>("MonthlyValue")
                        .HasColumnType("numeric")
                        .HasColumnName("MonthlyValue");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("NextPayment")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("NextPayment");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CredentialId");

                    b.HasIndex("MonthlyPlanId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Customer.CustomerPaymentHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberId");

                    b.Property<int>("BarberUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitId");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("CustomerId");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("PaymentDate");

                    b.Property<decimal>("PaymentValue")
                        .HasColumnType("numeric")
                        .HasColumnName("PaymentValue");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("BarberUnitId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CustomerPaymentHistory");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.MonthlyPlan.MonthlyPlanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("MonthlyPlan");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Profile.ProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("RegisterDate");

                    b.HasKey("Id");

                    b.ToTable("Profile");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Master",
                            RegisterDate = new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560)
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Admin",
                            RegisterDate = new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560)
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Manager",
                            RegisterDate = new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560)
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Barber",
                            RegisterDate = new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560)
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Customer",
                            RegisterDate = new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560)
                        });
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Service.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberUnitId")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitId");

                    b.Property<int>("CommissionPercent")
                        .HasColumnType("integer")
                        .HasColumnName("CommissionPercent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<TimeSpan?>("TimeToComplete")
                        .HasColumnType("interval")
                        .HasColumnName("TimeToComplete");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("BarberUnitId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.SigningPlan.SigningPlanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BarberLimit")
                        .HasColumnType("integer")
                        .HasColumnName("BarberLimit");

                    b.Property<int>("BarberUnitLimit")
                        .HasColumnType("integer")
                        .HasColumnName("BarberUnitLimit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer")
                        .HasColumnName("PaymentType");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("SigningPlan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarberLimit = 10,
                            BarberUnitLimit = 2,
                            Name = "gratuito",
                            PaymentType = 0,
                            Value = 0m
                        });
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.AppUser.AppUserEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Company.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("LaBarber.Domain.Entities.Credential.CredentialEntity", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Credential");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Appointment.AppointmentEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberEntity", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberUnitEntity", "BarberUnit")
                        .WithMany()
                        .HasForeignKey("BarberUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Company.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Customer.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("LaBarber.Domain.Entities.Service.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("BarberUnit");

                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberAvailabilityEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberEntity", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberUnitEntity", "BarberUnit")
                        .WithMany()
                        .HasForeignKey("BarberUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Credential.CredentialEntity", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BarberUnit");

                    b.Navigation("Credential");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberPaymentHistoryEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberEntity", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberUnitEntity", "BarberUnit")
                        .WithMany()
                        .HasForeignKey("BarberUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("BarberUnit");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberUnitAvailabilityEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberUnitEntity", "BarberUnit")
                        .WithMany()
                        .HasForeignKey("BarberUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BarberUnit");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberUnitEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Company.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Barber.BarberWalletEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberEntity", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Company.CompanyEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.SigningPlan.SigningPlanEntity", "SigningPlan")
                        .WithMany()
                        .HasForeignKey("SigningPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SigningPlan");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Credential.CredentialEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Profile.ProfileEntity", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Customer.CustomerEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Company.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Credential.CredentialEntity", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.MonthlyPlan.MonthlyPlanEntity", "MonthlyPlan")
                        .WithMany()
                        .HasForeignKey("MonthlyPlanId");

                    b.Navigation("Company");

                    b.Navigation("Credential");

                    b.Navigation("MonthlyPlan");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Customer.CustomerPaymentHistoryEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberEntity", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberUnitEntity", "BarberUnit")
                        .WithMany()
                        .HasForeignKey("BarberUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Customer.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaBarber.Domain.Entities.Service.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Barber");

                    b.Navigation("BarberUnit");

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LaBarber.Domain.Entities.Service.ServiceEntity", b =>
                {
                    b.HasOne("LaBarber.Domain.Entities.Barber.BarberUnitEntity", "BarberUnit")
                        .WithMany()
                        .HasForeignKey("BarberUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BarberUnit");
                });
#pragma warning restore 612, 618
        }
    }
}
