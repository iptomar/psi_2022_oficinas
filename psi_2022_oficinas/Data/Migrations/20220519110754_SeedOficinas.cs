using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class SeedOficinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "87189018-9ce4-432e-9553-b9fb09350c9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "1a23699b-d9bd-4998-beaa-346a34e58117");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "93937725-1a7b-4e38-86d9-42ef825d08f5");

            migrationBuilder.InsertData(
                table: "Oficinas",
                columns: new[] { "IdOficina", "CodigoPostal", "IdGestor", "Imagem", "Localidade", "Morada", "Nome", "NumTelemovel" },
                values: new object[,]
                {
                    { 1, "2300-532", 1, "aral.png", "Tomar", "Avenida Condestável Dom Nuno Álvares Pereira, 2", "Aral", "249310070" },
                    { 2, "2300-310", 2, "autoidealnabao.png", "Tomar", "Lugar do Alvito", "Auto Ideal do Nabao", "249310810" },
                    { 3, "2300-442", 3, "autobarreiro.png", "Tomar", " Estrada Barreiro 3 - B", "Auto Barreiro", "249316896" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "9344830a-b66f-4da0-9061-818d671e8cd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "d5f2c52f-e23a-4bc8-82a8-e97af40286f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "02ec590e-e2b3-42a2-aed1-349e4e861467");
        }
    }
}
