using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Addingcontacttobarber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cellphone",
                table: "Barber",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Barber",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 7, 14, 17, 25, 55, 631, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "SigningPlan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BarberLimit", "BarberUnitLimit" },
                values: new object[] { 2, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cellphone",
                table: "Barber");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Barber");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 7, 6, 13, 51, 34, 908, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "SigningPlan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BarberLimit", "BarberUnitLimit" },
                values: new object[] { 10, 2 });
        }
    }
}
