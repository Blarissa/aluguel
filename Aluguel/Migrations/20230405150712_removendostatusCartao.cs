using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aluguel.Migrations
{
    public partial class removendostatusCartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("status", "cartoes_de_credito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
