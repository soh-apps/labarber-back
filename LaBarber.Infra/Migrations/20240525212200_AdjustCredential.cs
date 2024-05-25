using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChangePasswordCode",
                table: "Credential",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ChangedPassword",
                table: "Credential",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Credential",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePasswordCode",
                table: "Credential");

            migrationBuilder.DropColumn(
                name: "ChangedPassword",
                table: "Credential");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Credential");

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
    }
}
