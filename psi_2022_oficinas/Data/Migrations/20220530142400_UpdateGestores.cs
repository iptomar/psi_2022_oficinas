using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class UpdateGestores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OficinasServiços_Oficinas_ListaOficinasIdOficina",
                table: "OficinasServiços");

            migrationBuilder.DropForeignKey(
                name: "FK_OficinasServiços_Serviços_ListaServicosIdServ",
                table: "OficinasServiços");

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
                value: "ffdb1269-803b-4416-8b6b-6c78adbd8c6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "2ba845ee-f7a2-4619-bfb7-05ac6376e5a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "6268b351-77b3-47dc-a667-32a1d0605350");

            migrationBuilder.InsertData(
                table: "Gestores",
                columns: new[] { "GestorID", "Email", "PrimeiroNome" },
                values: new object[,]
                {
                    { 4, "gestor4@mail.com", "Gestor4" },
                    { 5, "gestor5@mail.com", "Gestor5" },
                    { 6, "gestor6@mail.com", "Gestor6" },
                    { 7, "gestor7@mail.com", "Gestor7" },
                    { 8, "gestor8@mail.com", "Gestor8" },
                    { 9, "gestor9@mail.com", "Gestor9" },
                    { 10, "gestor10@mail.com", "Gestor10" },
                    { 11, "gestor11@mail.com", "Gestor11" },
                    { 12, "gestor12@mail.com", "Gestor12" },
                    { 13, "gestor13@mail.com", "Gestor13" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OficinasServiços_Oficinas_ListaOficinasIdOficina",
                table: "OficinasServiços",
                column: "ListaOficinasIdOficina",
                principalTable: "Oficinas",
                principalColumn: "IdOficina",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OficinasServiços_Serviços_ListaServicosIdServ",
                table: "OficinasServiços",
                column: "ListaServicosIdServ",
                principalTable: "Serviços",
                principalColumn: "IdServ",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OficinasServiços_Oficinas_ListaOficinasIdOficina",
                table: "OficinasServiços");

            migrationBuilder.DropForeignKey(
                name: "FK_OficinasServiços_Serviços_ListaServicosIdServ",
                table: "OficinasServiços");

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Gestores",
                keyColumn: "GestorID",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "0d77811d-e529-45d3-9fd1-c11fc9d8c292");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C",
                column: "ConcurrencyStamp",
                value: "b4b00e61-930d-4dba-b2d4-c74e0178c19d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "G",
                column: "ConcurrencyStamp",
                value: "7c9bd6df-c3df-4595-af34-420e57016da3");

            migrationBuilder.InsertData(
                table: "Oficinas",
                columns: new[] { "IdOficina", "CodigoPostal", "IdGestor", "Imagem", "Localidade", "Morada", "Nome", "NumTelemovel" },
                values: new object[,]
                {
                    { 1, "2300-532", 1, "aral.png", "Tomar", "Avenida Condestável Dom Nuno Álvares Pereira, 2", "Aral", "249310070" },
                    { 2, "2300-310", 2, "autoidealnabao.png", "Tomar", "Lugar do Alvito", "Auto Ideal do Nabao", "249310810" },
                    { 3, "2300-442", 3, "autobarreiro.png", "Tomar", " Estrada Barreiro 3 - B", "Auto Barreiro", "249316896" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OficinasServiços_Oficinas_ListaOficinasIdOficina",
                table: "OficinasServiços",
                column: "ListaOficinasIdOficina",
                principalTable: "Oficinas",
                principalColumn: "IdOficina",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OficinasServiços_Serviços_ListaServicosIdServ",
                table: "OficinasServiços",
                column: "ListaServicosIdServ",
                principalTable: "Serviços",
                principalColumn: "IdServ",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
