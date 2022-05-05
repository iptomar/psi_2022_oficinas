using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class SeedGestores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoPagamento",
                table: "MetodoPagamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoServico",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassServico",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Caucao",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Gestores",
                columns: new[] { "GestorID", "Email", "PrimeiroNome" },
                values: new object[] { 1, "gestor1@mail.com", "Gestor1" });

            migrationBuilder.InsertData(
                table: "Gestores",
                columns: new[] { "GestorID", "Email", "PrimeiroNome" },
                values: new object[] { 2, "gestor2@mail.com", "Gestor2" });

            migrationBuilder.InsertData(
                table: "Gestores",
                columns: new[] { "GestorID", "Email", "PrimeiroNome" },
                values: new object[] { 3, "gestor3@mail.com", "Gestor3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "TipoPagamento",
                table: "MetodoPagamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstadoServico",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassServico",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caucao",
                table: "Marcacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
