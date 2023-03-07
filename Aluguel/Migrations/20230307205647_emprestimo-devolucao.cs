using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aluguel.Migrations
{
    public partial class emprestimodevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "devolucoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_hora = table.Column<DateTime>(type: "Timestamp without Time Zone", nullable: false, defaultValueSql: "now()"),
                    valor = table.Column<float>(type: "real", nullable: false),
                    data_hora_pagamento = table.Column<DateTime>(type: "Timestamp without Time Zone", nullable: false),
                    emprestimo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tranca_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cartao_de_credito_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_devolucoes", x => x.id);
                    table.ForeignKey(
                        name: "fk_devolucoes_cartoes_de_credito_cartao_de_credito_id",
                        column: x => x.cartao_de_credito_id,
                        principalTable: "cartoes_de_credito",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_devolucoes_emprestimos_emprestimo_id",
                        column: x => x.emprestimo_id,
                        principalTable: "emprestimos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_devolucoes_cartao_de_credito_id",
                table: "devolucoes",
                column: "cartao_de_credito_id");

            migrationBuilder.CreateIndex(
                name: "ix_devolucoes_emprestimo_id",
                table: "devolucoes",
                column: "emprestimo_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devolucoes");
        }
    }
}
