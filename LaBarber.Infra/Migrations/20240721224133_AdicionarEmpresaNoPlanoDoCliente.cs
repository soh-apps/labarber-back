using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarEmpresaNoPlanoDoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "MonthlyPlan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MonthlyPlan",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 7, 21, 22, 41, 33, 130, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPlan_CompanyId",
                table: "MonthlyPlan",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPlan_Company_CompanyId",
                table: "MonthlyPlan",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPlan_Company_CompanyId",
                table: "MonthlyPlan");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyPlan_CompanyId",
                table: "MonthlyPlan");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "MonthlyPlan");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MonthlyPlan");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 7, 14, 17, 25, 55, 631, DateTimeKind.Utc).AddTicks(2478));
        }
    }
}
