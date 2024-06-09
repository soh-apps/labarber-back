using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adddadosenderecobarbeiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Barber",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Barber",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Barber");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Barber");
        }
    }
}
