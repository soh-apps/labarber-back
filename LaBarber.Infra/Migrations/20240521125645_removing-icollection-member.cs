using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBarber.Infra.Migrations
{
    /// <inheritdoc />
    public partial class removingicollectionmember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_BarberUnit_BarberUnitEntityId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_BarberUnitEntityId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "BarberUnitEntityId",
                table: "AppUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberUnitEntityId",
                table: "AppUser",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_BarberUnitEntityId",
                table: "AppUser",
                column: "BarberUnitEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_BarberUnit_BarberUnitEntityId",
                table: "AppUser",
                column: "BarberUnitEntityId",
                principalTable: "BarberUnit",
                principalColumn: "Id");
        }
    }
}
