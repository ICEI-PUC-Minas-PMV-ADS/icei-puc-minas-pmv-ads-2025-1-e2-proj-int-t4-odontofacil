

#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoFacil.Migrations
{
    
    public partial class UpdateExamSchemaAgain : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
