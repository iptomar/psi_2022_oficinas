using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class TesteAplicacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "8d8c467b-434c-40d1-8bf2-2706098ab53d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "0de27f31-4c40-49f0-a7ed-db2c39c99ef5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "afefa3f7-821c-4338-bf72-0fbc5cb904ca");

            migrationBuilder.InsertData(
                table: "Marcacoes",
                columns: new[] { "IdMarcacao", "Caucao", "ClassServico", "DataPedido", "Descricao", "EstadoServico", "IdCliente", "IdOficina", "IdPagamento" },
                values: new object[] { 1, "1", "1", new DateTime(2022, 6, 28, 23, 42, 38, 493, DateTimeKind.Local).AddTicks(216), "1", "1", 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marcacoes",
                keyColumn: "IdMarcacao",
                keyValue: 1);

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
        }
    }
}
