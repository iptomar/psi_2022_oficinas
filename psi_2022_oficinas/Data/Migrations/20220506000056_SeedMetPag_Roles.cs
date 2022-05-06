using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class SeedMetPag_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "A", "989cdd45-c92c-436d-9489-2c2811c51b8d", "Admin", "ADMIN" },
                    { "C", "989e1c89-cf77-4b04-a431-39acd8bea63d", "Cliente", "CLIENTE" },
                    { "G", "a6ba1e1e-cd9c-4c7b-a4a6-768138a26b1e", "Gestor", "GESTOR" }
                });

            migrationBuilder.InsertData(
                table: "MetodoPagamento",
                columns: new[] { "IdPagamento", "TipoPagamento" },
                values: new object[,]
                {
                    { 1, "Multibanco" },
                    { 2, "MBway" },
                    { 3, "Cartão de Crédito" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G");

            migrationBuilder.DeleteData(
                table: "MetodoPagamento",
                keyColumn: "IdPagamento",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MetodoPagamento",
                keyColumn: "IdPagamento",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MetodoPagamento",
                keyColumn: "IdPagamento",
                keyValue: 3);
        }
    }
}
