using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace psi_2022_oficinas.Data.Migrations
{
    public partial class NewTableServiços : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serviços",
                columns: table => new
                {
                    IdServ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviços", x => x.IdServ);
                });

            migrationBuilder.CreateTable(
                name: "OficinasServiços",
                columns: table => new
                {
                    ListaOficinasIdOficina = table.Column<int>(type: "int", nullable: false),
                    ListaServicosIdServ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficinasServiços", x => new { x.ListaOficinasIdOficina, x.ListaServicosIdServ });
                    table.ForeignKey(
                        name: "FK_OficinasServiços_Oficinas_ListaOficinasIdOficina",
                        column: x => x.ListaOficinasIdOficina,
                        principalTable: "Oficinas",
                        principalColumn: "IdOficina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OficinasServiços_Serviços_ListaServicosIdServ",
                        column: x => x.ListaServicosIdServ,
                        principalTable: "Serviços",
                        principalColumn: "IdServ",
                        onDelete: ReferentialAction.Restrict);
                });

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
                table: "Serviços",
                columns: new[] { "IdServ", "Servico" },
                values: new object[,]
                {
                    { 1, "Ar Condicionado" },
                    { 2, "Estofos" },
                    { 3, "Vidros" },
                    { 4, "Mecânica" },
                    { 5, "Pneus" },
                    { 6, "Inspeção Periódica" },
                    { 7, "Bate-chapas" },
                    { 8, "Cortesia/Mobilidade" },
                    { 9, "Eletricidade/Eletrónica" },
                    { 10, "Lavagem" },
                    { 11, "Pintura" },
                    { 12, "Tuning" },
                    { 13, "Assistência em Viagem" },
                    { 14, "GPL Auto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OficinasServiços_ListaServicosIdServ",
                table: "OficinasServiços",
                column: "ListaServicosIdServ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OficinasServiços");

            migrationBuilder.DropTable(
                name: "Serviços");

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
        }
    }
}
