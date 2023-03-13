using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aluguel.Migrations
{
    public partial class adicionadodevolucaoIdEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_devolucoes_emprestimos_emprestimo_id",
                table: "devolucoes");

            migrationBuilder.AddColumn<Guid>(
                name: "devolucao_id",
                table: "emprestimos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_devolucoes_emprestimos_emprestimo_id1",
                table: "devolucoes",
                column: "emprestimo_id",
                principalTable: "emprestimos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_devolucoes_emprestimos_emprestimo_id1",
                table: "devolucoes");

            migrationBuilder.DropColumn(
                name: "devolucao_id",
                table: "emprestimos");

            migrationBuilder.AddForeignKey(
                name: "fk_devolucoes_emprestimos_emprestimo_id",
                table: "devolucoes",
                column: "emprestimo_id",
                principalTable: "emprestimos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
