﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Profile",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BarberUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Complement = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberUnit_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: true),
                    BarberUnitEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_BarberUnit_BarberUnitEntityId",
                        column: x => x.BarberUnitEntityId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUser_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUser_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    BarberUnitId = table.Column<int>(type: "integer", nullable: false),
                    Commissioned = table.Column<bool>(type: "boolean", nullable: false),
                    LastPayment = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextPayment = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barber_BarberUnit_BarberUnitId",
                        column: x => x.BarberUnitId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barber_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarberUnitAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkingDay = table.Column<int>(type: "integer", nullable: false),
                    StartWorkingHour = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndWorkingHour = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BarberUnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberUnitAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberUnitAvailability_BarberUnit_BarberUnitId",
                        column: x => x.BarberUnitId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TimeToComplete = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    CommissionPercent = table.Column<int>(type: "integer", nullable: false),
                    BarberUnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_BarberUnit_BarberUnitId",
                        column: x => x.BarberUnitId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarberAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkingDay = table.Column<int>(type: "integer", nullable: false),
                    StartWorkingHour = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndWorkingHour = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberAvailability_Barber_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarberPaymentHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentValue = table.Column<decimal>(type: "numeric", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false),
                    BarberUnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberPaymentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberPaymentHistory_BarberUnit_BarberUnitId",
                        column: x => x.BarberUnitId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarberPaymentHistory_Barber_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    StartAppointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndAppointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    IsCommissioned = table.Column<bool>(type: "boolean", nullable: false),
                    CommissionValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    BarberUnitId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_BarberUnit_BarberUnitId",
                        column: x => x.BarberUnitId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Barber_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPaymentHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentValue = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false),
                    BarberUnitId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPaymentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentHistory_BarberUnit_BarberUnitId",
                        column: x => x.BarberUnitId,
                        principalTable: "BarberUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentHistory_Barber_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentHistory_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentHistory_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyId",
                table: "Customer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MonthlyPlanId",
                table: "Customer",
                column: "MonthlyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_SigningPlanId",
                table: "Company",
                column: "SigningPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BarberId",
                table: "Appointment",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BarberUnitId",
                table: "Appointment",
                column: "BarberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CompanyId",
                table: "Appointment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CustomerId",
                table: "Appointment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceId",
                table: "Appointment",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_BarberUnitEntityId",
                table: "AppUser",
                column: "BarberUnitEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_CompanyId",
                table: "AppUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ProfileId",
                table: "AppUser",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Barber_BarberUnitId",
                table: "Barber",
                column: "BarberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Barber_ProfileId",
                table: "Barber",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberAvailability_BarberId",
                table: "BarberAvailability",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberPaymentHistory_BarberId",
                table: "BarberPaymentHistory",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberPaymentHistory_BarberUnitId",
                table: "BarberPaymentHistory",
                column: "BarberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberUnit_CompanyId",
                table: "BarberUnit",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberUnitAvailability_BarberUnitId",
                table: "BarberUnitAvailability",
                column: "BarberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentHistory_BarberId",
                table: "CustomerPaymentHistory",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentHistory_BarberUnitId",
                table: "CustomerPaymentHistory",
                column: "BarberUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentHistory_CustomerId",
                table: "CustomerPaymentHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentHistory_ServiceId",
                table: "CustomerPaymentHistory",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_BarberUnitId",
                table: "Service",
                column: "BarberUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_SigningPlan_SigningPlanId",
                table: "Company",
                column: "SigningPlanId",
                principalTable: "SigningPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Company_CompanyId",
                table: "Customer",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_MonthlyPlan_MonthlyPlanId",
                table: "Customer",
                column: "MonthlyPlanId",
                principalTable: "MonthlyPlan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_SigningPlan_SigningPlanId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_CompanyId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_MonthlyPlan_MonthlyPlanId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "BarberAvailability");

            migrationBuilder.DropTable(
                name: "BarberPaymentHistory");

            migrationBuilder.DropTable(
                name: "BarberUnitAvailability");

            migrationBuilder.DropTable(
                name: "CustomerPaymentHistory");

            migrationBuilder.DropTable(
                name: "Barber");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "BarberUnit");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CompanyId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_MonthlyPlanId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Company_SigningPlanId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customer");
        }
    }
}
