using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoDeUsinas.Migrations
{
    public partial class SeedFornecedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "SOLARIAN" },
                    { 2, "FUTURA" },
                    { 3, "CENTRAL GERADORA FAZENDA MODELO" },
                    { 4, "NOVA MUNDO" },
                    { 5, "SOLARE" },
                    { 6, "UNISOL" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
