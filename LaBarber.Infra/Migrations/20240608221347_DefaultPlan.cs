using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DefaultPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 6, 8, 22, 13, 47, 326, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.InsertData(
                table: "SigningPlan",
                columns: new[] { "Id", "BarberLimit", "BarberUnitLimit", "Name", "PaymentType", "Value" },
                values: new object[] { 1, 10, 2, "gratuito", 0, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SigningPlan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 6, 1, 22, 48, 21, 827, DateTimeKind.Utc).AddTicks(9665));
        }
    }
}
