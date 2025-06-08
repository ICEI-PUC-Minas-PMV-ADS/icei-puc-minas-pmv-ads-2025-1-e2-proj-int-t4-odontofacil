using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoFacil.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamResultFilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "caminho_arquivo_resultado",
                table: "Resultado_Exame",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "caminho_arquivo_resultado",
                table: "Resultado_Exame");
        }
    }
}
