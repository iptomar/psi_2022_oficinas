using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class SeedRelacMN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "19cc1fe5-6ee5-46e5-89e9-8bff01cb65e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "20b65401-9c1e-440b-94d8-31175dece4fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "6e512566-dfe6-45c6-90aa-3e69d0db068c");

            migrationBuilder.InsertData(
                table: "OficinasServiços",
                columns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 14 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 7 },
                    { 3, 9 },
                    { 3, 11 },
                    { 3, 12 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 13 },
                    { 4, 14 }
                });

            migrationBuilder.InsertData(
                table: "OficinasServiços",
                columns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 4 },
                    { 5, 7 },
                    { 5, 11 },
                    { 5, 14 },
                    { 6, 1 },
                    { 6, 4 },
                    { 6, 6 },
                    { 6, 7 },
                    { 6, 8 },
                    { 6, 9 },
                    { 6, 11 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 7 },
                    { 7, 8 },
                    { 7, 9 },
                    { 7, 11 },
                    { 7, 12 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 8, 6 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 8, 13 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 6 },
                    { 9, 7 },
                    { 9, 8 }
                });

            migrationBuilder.InsertData(
                table: "OficinasServiços",
                columns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                values: new object[,]
                {
                    { 9, 9 },
                    { 9, 10 },
                    { 9, 11 },
                    { 10, 1 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 5 },
                    { 10, 7 },
                    { 10, 9 },
                    { 10, 11 },
                    { 10, 13 },
                    { 11, 6 },
                    { 11, 7 },
                    { 11, 9 },
                    { 11, 11 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 12, 4 },
                    { 12, 5 },
                    { 12, 6 },
                    { 12, 7 },
                    { 12, 8 },
                    { 12, 9 },
                    { 12, 10 },
                    { 12, 11 },
                    { 12, 14 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 4 },
                    { 13, 5 },
                    { 13, 6 },
                    { 13, 7 },
                    { 13, 8 },
                    { 13, 9 },
                    { 13, 10 },
                    { 13, 11 },
                    { 13, 12 },
                    { 13, 13 },
                    { 13, 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 12, 14 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 6 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 7 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 9 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "OficinasServiços",
                keyColumns: new[] { "ListaOficinasIdOficina", "ListaServicosIdServ" },
                keyValues: new object[] { 13, 14 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "08742509-6aaa-41b9-a956-22828f15a0c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "824d8155-930a-450c-b2d1-f15419048ee4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "8385b1a9-4be2-40dd-8a2b-bf89c94e14ba");
        }
    }
}
