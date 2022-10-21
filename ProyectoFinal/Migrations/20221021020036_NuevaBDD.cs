using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class NuevaBDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Cliente_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cliente_ClienteId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Factura");
        }
    }
}
