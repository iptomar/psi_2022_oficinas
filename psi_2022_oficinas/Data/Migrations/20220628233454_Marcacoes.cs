using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class Marcacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "17c6ad72-33ad-4369-b062-a7f5d7b13ab9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "de59a06d-3bb6-4182-bd03-2175188f2570");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "beeed477-b369-4842-8201-5c9fe28055be");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
