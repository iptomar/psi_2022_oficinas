using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class AlteracaoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegisto",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "6dc43337-d00d-417f-904e-3464f14fa1b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "2aaa0a73-8439-4d55-bb44-cafa17ee3671");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "76bef8e7-e717-4acc-82be-b9e02d133d7f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegisto",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "989cdd45-c92c-436d-9489-2c2811c51b8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "989e1c89-cf77-4b04-a431-39acd8bea63d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "a6ba1e1e-cd9c-4c7b-a4a6-768138a26b1e");
        }
    }
}
