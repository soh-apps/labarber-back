using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Company",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Company",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5570));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 13, 55, 49, 538, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 13, 55, 49, 538, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 13, 55, 49, 538, DateTimeKind.Utc).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 13, 55, 49, 538, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 13, 55, 49, 538, DateTimeKind.Utc).AddTicks(1978));
        }
    }
}
