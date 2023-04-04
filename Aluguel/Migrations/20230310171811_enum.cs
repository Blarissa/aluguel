using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aluguel.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:e_funcao", "administrativo,reparador")
                .Annotation("Npgsql:Enum:e_nacionalidade", "brasileiro,estrangeiro")                
                .Annotation("Npgsql:Enum:e_status_ciclista", "pendente,ativo,bloqueado");           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:e_funcao", "administrativo,reparador")
                .OldAnnotation("Npgsql:Enum:e_nacionalidade", "brasileiro,estrangeiro")                
                .OldAnnotation("Npgsql:Enum:e_status_ciclista", "pendente,ativo,bloqueado");

            migrationBuilder.AlterColumn<int>(
                name: "funcao",
                table: "funcionarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "e_funcao");
        }
    }
}
