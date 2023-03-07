using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aluguel.Migrations
{
    public partial class ciclistacartaodecreditoemprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ciclistas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    url_foto_documento = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    nacionalidade = table.Column<int>(type: "integer", nullable: false),
                    data_hora_cadastro = table.Column<DateTime>(type: "Timestamp without Time Zone", nullable: false, defaultValueSql: "now()"),
                    data_hora_confirmacao = table.Column<DateTime>(type: "Timestamp without Time Zone", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    passaporte_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ciclistas", x => x.id);
                    table.ForeignKey(
                        name: "fk_ciclistas_passaportes_passaporte_id",
                        column: x => x.passaporte_id,
                        principalTable: "passaportes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cartoes_de_credito",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<string>(type: "text", nullable: false),
                    mes_validade = table.Column<int>(type: "integer", nullable: false),
                    ano_validade = table.Column<int>(type: "integer", nullable: false),
                    codigo_seguranca = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    ciclista_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartoes_de_credito", x => x.id);
                    table.ForeignKey(
                        name: "fk_cartoes_de_credito_ciclistas_ciclista_id",
                        column: x => x.ciclista_id,
                        principalTable: "ciclistas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emprestimos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_hora = table.Column<DateTime>(type: "Timestamp without Time Zone", nullable: false, defaultValueSql: "now()"),
                    valor = table.Column<float>(type: "real", nullable: false),
                    data_hora_pagamento = table.Column<DateTime>(type: "Timestamp without Time Zone", nullable: true),
                    cartao_de_credito_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ciclista_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bicicleta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tranca_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emprestimos", x => x.id);
                    table.ForeignKey(
                        name: "fk_emprestimos_cartoes_de_credito_cartao_de_credito_id",
                        column: x => x.cartao_de_credito_id,
                        principalTable: "cartoes_de_credito",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_emprestimos_ciclistas_ciclista_id",
                        column: x => x.ciclista_id,
                        principalTable: "ciclistas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cartoes_de_credito_ciclista_id",
                table: "cartoes_de_credito",
                column: "ciclista_id");

            migrationBuilder.CreateIndex(
                name: "ix_ciclistas_passaporte_id",
                table: "ciclistas",
                column: "passaporte_id");

            migrationBuilder.CreateIndex(
                name: "ix_emprestimos_cartao_de_credito_id",
                table: "emprestimos",
                column: "cartao_de_credito_id");

            migrationBuilder.CreateIndex(
                name: "ix_emprestimos_ciclista_id",
                table: "emprestimos",
                column: "ciclista_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimos");

            migrationBuilder.DropTable(
                name: "cartoes_de_credito");

            migrationBuilder.DropTable(
                name: "ciclistas");
        }
    }
}
