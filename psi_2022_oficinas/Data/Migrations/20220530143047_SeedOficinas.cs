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

            migrationBuilder.InsertData(
                table: "Oficinas",
                columns: new[] { "IdOficina", "CodigoPostal", "IdGestor", "Imagem", "Localidade", "Morada", "Nome", "NumTelemovel" },
                values: new object[,]
                {
                    { 1, "1400 - 145", 1, "id1_boxcarvulcolisboa.jpg", "Lisboa", "Rua Fernão Mendes Pinto Lote M-T", "Boxcar Vulco Lisboa", "912 360 073" },
                    { 2, "4705 - 084", 2, "id2_braga.jpg", "Braga", "Avenida Cidade do Porto n.º 182, Ferreiros", "Confiauto Braga", "252 248 500" },
                    { 3, "4445 - 245", 3, "id3_autoarcadgua2.jpg", "Valongo, Porto", "Rua 1º de Maio n.º 614B, Alfena", "Auto Arca D'Água 2", "229 689 811" },
                    { 4, "2900 - 395", 4, "id4.jpg", "Setúbal", "Rua Guilherme Gomes Fernandes n.º 1", "Manuel Jorge Santos Pereira", "921321817" },
                    { 5, "2825 - 895", 5, "id5_jsa.jpg", "Almada, Setúbal", "Rua 27 de Julho n.º 27, Trafaria", "JSA", "960 306 191" },
                    { 6, "3105-238", 6, "id6_meiricarro.jpg", "Pombal, Leiria", "Rua das Covinhas, Santiago de Litém", "MEIRICARRO", "236 948 477" },
                    { 7, "3500-188", 7, "id7_automotor.jpg", "Viseu", "Travassós de Baixo, Estrada São João da Carreira", "Automotorsport", "918 702 101" },
                    { 8, "3070-604", 8, "id8.jpg", "Mira, Coimbra", "Rua da Floresta n.º 255, Carapelhos", "Auto Carapelhos", "231 451 782" },
                    { 9, "2005-002", 9, "id9_martinho.jpg", "Santarém", "Rua Doutor Hilário Barreiro Nunes Lote 26B, Zona Industrial", "Martinho Auto", "243 302 228" },
                    { 10, "2460-477", 10, "id10.jpg", "Alcobaça, Leiria", "Zona Industrial Cabeço de Deus", "Auto Nogueiras", "262 585 252" },
                    { 11, "3800-301", 11, "id11_corvauto.jpg", "Aveiro", "Rua Duarte Ludgero, Esgueira", "Corvauto", "234 303 150" },
                    { 12, "5300-107", 12, "id12.jpg", "Bragança", "Avenida das Cantarias n.º 130", "Auto Imperial", "273 302 600" },
                    { 13, "8100-289", 13, "id13_rinoauto.jpg", "Loulé, Faro", "Cerro Cabeça de Câmara", "Rino - Auto Alexandre", "289 410 660" }
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

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Oficinas",
                keyColumn: "IdOficina",
                keyValue: 13);

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
        }
    }
}
