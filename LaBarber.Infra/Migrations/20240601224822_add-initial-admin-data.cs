using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addinitialadmindata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Credential",
                columns: new[] { "Id", "ChangePasswordCode", "ChangedPassword", "Email", "Password", "ProfileId", "Username" },
                values: new object[] { 1, "", false, "admin@labarber.com.br", "21826A058D9D3DBCDB208EEF87DB2C024BDD6A7DE9ADC1C344E14010EA3730D0A0093A8F57C5AC9EE6ED335B0136764D51E7B9543C8F2EA06F89EC3688ACDADA", 1, "teste" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CompanyId", "CredentialId", "Name", "RegisterDate", "Status" },
                values: new object[] { 1, null, 1, "admin", new DateTime(2024, 6, 1, 22, 48, 21, 827, DateTimeKind.Utc).AddTicks(9665), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
