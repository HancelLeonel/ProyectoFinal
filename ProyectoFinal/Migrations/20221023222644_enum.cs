using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movimiento_FacturaId",
                table: "Movimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_FacturaId",
                table: "Movimiento",
                column: "FacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movimiento_FacturaId",
                table: "Movimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_FacturaId",
                table: "Movimiento",
                column: "FacturaId",
                unique: true);
        }
    }
}
