﻿// <auto-generated />
using System;
using Aluguel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aluguel.Migrations
{
    [DbContext(typeof(AluguelContexto))]
    partial class AluguelContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "e_funcao", new[] { "administrativo", "reparador" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "e_nacionalidade", new[] { "brasileiro", "estrangeiro" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "e_status_cartao", new[] { "ativo", "desativado" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "e_status_ciclista", new[] { "pendente", "ativo", "bloqueado" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Aluguel.Models.CartaoDeCredito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AnoValidade")
                        .HasColumnType("integer")
                        .HasColumnName("ano_validade");

                    b.Property<Guid>("CiclistaId")
                        .HasColumnType("uuid")
                        .HasColumnName("ciclista_id");

                    b.Property<int>("CodigoSeguranca")
                        .HasColumnType("integer")
                        .HasColumnName("codigo_seguranca");

                    b.Property<int>("MesValidade")
                        .HasColumnType("integer")
                        .HasColumnName("mes_validade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("numero");

                    b.Property<int>("Status")
                        .HasColumnType("e_status_cartao")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_cartoes_de_credito");

                    b.HasIndex("CiclistaId")
                        .HasDatabaseName("ix_cartoes_de_credito_ciclista_id");

                    b.ToTable("cartoes_de_credito", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.Ciclista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataHoraCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Timestamp without Time Zone")
                        .HasColumnName("data_hora_cadastro")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DataHoraConfirmacao")
                        .HasColumnType("Timestamp without Time Zone")
                        .HasColumnName("data_hora_confirmacao");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("Nacionalidade")
                        .HasColumnType("e_nacionalidade")
                        .HasColumnName("nacionalidade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<Guid?>("PassaporteId")
                        .HasColumnType("uuid")
                        .HasColumnName("passaporte_id");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("senha");

                    b.Property<int>("Status")
                        .HasColumnType("e_status_ciclista")
                        .HasColumnName("status");

                    b.Property<string>("UrlFotoDocumento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url_foto_documento");

                    b.HasKey("Id")
                        .HasName("pk_ciclistas");

                    b.HasIndex("PassaporteId")
                        .HasDatabaseName("ix_ciclistas_passaporte_id");

                    b.ToTable("ciclistas", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.Devolucao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CartaoDeCreditoId")
                        .HasColumnType("uuid")
                        .HasColumnName("cartao_de_credito_id");

                    b.Property<DateTime>("DataHora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Timestamp without Time Zone")
                        .HasColumnName("data_hora")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DataHoraPagamento")
                        .HasColumnType("Timestamp without Time Zone")
                        .HasColumnName("data_hora_pagamento");

                    b.Property<Guid>("EmprestimoId")
                        .HasColumnType("uuid")
                        .HasColumnName("emprestimo_id");

                    b.Property<Guid>("TrancaId")
                        .HasColumnType("uuid")
                        .HasColumnName("tranca_id");

                    b.Property<float>("Valor")
                        .HasColumnType("real")
                        .HasColumnName("valor");

                    b.HasKey("Id")
                        .HasName("pk_devolucoes");

                    b.HasIndex("CartaoDeCreditoId")
                        .HasDatabaseName("ix_devolucoes_cartao_de_credito_id");

                    b.HasIndex("EmprestimoId")
                        .IsUnique()
                        .HasDatabaseName("ix_devolucoes_emprestimo_id");

                    b.ToTable("devolucoes", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BicicletaId")
                        .HasColumnType("uuid")
                        .HasColumnName("bicicleta_id");

                    b.Property<Guid>("CartaoDeCreditoId")
                        .HasColumnType("uuid")
                        .HasColumnName("cartao_de_credito_id");

                    b.Property<Guid>("CiclistaId")
                        .HasColumnType("uuid")
                        .HasColumnName("ciclista_id");

                    b.Property<DateTime>("DataHora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Timestamp without Time Zone")
                        .HasColumnName("data_hora")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DataHoraPagamento")
                        .HasColumnType("Timestamp without Time Zone")
                        .HasColumnName("data_hora_pagamento");

                    b.Property<Guid?>("DevolucaoId")
                        .HasColumnType("uuid")
                        .HasColumnName("devolucao_id");

                    b.Property<Guid>("TrancaId")
                        .HasColumnType("uuid")
                        .HasColumnName("tranca_id");

                    b.Property<float>("Valor")
                        .HasColumnType("real")
                        .HasColumnName("valor");

                    b.HasKey("Id")
                        .HasName("pk_emprestimos");

                    b.HasIndex("CartaoDeCreditoId")
                        .HasDatabaseName("ix_emprestimos_cartao_de_credito_id");

                    b.HasIndex("CiclistaId")
                        .HasDatabaseName("ix_emprestimos_ciclista_id");

                    b.ToTable("emprestimos", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.Funcionario", b =>
                {
                    b.Property<int>("Matricula")
                        .HasColumnType("integer")
                        .HasColumnName("matricula");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("Funcao")
                        .HasColumnType("e_funcao")
                        .HasColumnName("funcao");

                    b.Property<int>("Idade")
                        .HasColumnType("integer")
                        .HasColumnName("idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("senha");

                    b.HasKey("Matricula")
                        .HasName("pk_funcionarios");

                    b.ToTable("funcionarios", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.Pais", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_paises");

                    b.ToTable("paises", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.Passaporte", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("date")
                        .HasColumnName("data_validade");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("numero");

                    b.Property<Guid>("PaisId")
                        .HasColumnType("uuid")
                        .HasColumnName("pais_id");

                    b.HasKey("Id")
                        .HasName("pk_passaportes");

                    b.HasIndex("PaisId")
                        .IsUnique()
                        .HasDatabaseName("ix_passaportes_pais_id");

                    b.ToTable("passaportes", (string)null);
                });

            modelBuilder.Entity("Aluguel.Models.CartaoDeCredito", b =>
                {
                    b.HasOne("Aluguel.Models.Ciclista", "Ciclista")
                        .WithMany("Cartoes")
                        .HasForeignKey("CiclistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cartoes_de_credito_ciclistas_ciclista_id");

                    b.Navigation("Ciclista");
                });

            modelBuilder.Entity("Aluguel.Models.Ciclista", b =>
                {
                    b.HasOne("Aluguel.Models.Passaporte", "Passaporte")
                        .WithMany()
                        .HasForeignKey("PassaporteId")
                        .HasConstraintName("fk_ciclistas_passaportes_passaporte_id");

                    b.Navigation("Passaporte");
                });

            modelBuilder.Entity("Aluguel.Models.Devolucao", b =>
                {
                    b.HasOne("Aluguel.Models.CartaoDeCredito", "CartaoDeCredito")
                        .WithMany("Devolucoes")
                        .HasForeignKey("CartaoDeCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_devolucoes_cartoes_de_credito_cartao_de_credito_id");

                    b.HasOne("Aluguel.Models.Emprestimo", "Emprestimo")
                        .WithOne("Devolucao")
                        .HasForeignKey("Aluguel.Models.Devolucao", "EmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_devolucoes_emprestimos_emprestimo_id1");

                    b.Navigation("CartaoDeCredito");

                    b.Navigation("Emprestimo");
                });

            modelBuilder.Entity("Aluguel.Models.Emprestimo", b =>
                {
                    b.HasOne("Aluguel.Models.CartaoDeCredito", "CartaoDeCredito")
                        .WithMany("Emprestimos")
                        .HasForeignKey("CartaoDeCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_emprestimos_cartoes_de_credito_cartao_de_credito_id");

                    b.HasOne("Aluguel.Models.Ciclista", "Ciclista")
                        .WithMany("Emprestimos")
                        .HasForeignKey("CiclistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_emprestimos_ciclistas_ciclista_id");

                    b.Navigation("CartaoDeCredito");

                    b.Navigation("Ciclista");
                });

            modelBuilder.Entity("Aluguel.Models.Passaporte", b =>
                {
                    b.HasOne("Aluguel.Models.Pais", "Pais")
                        .WithOne("Passaporte")
                        .HasForeignKey("Aluguel.Models.Passaporte", "PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_passaportes_paises_pais_id");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Aluguel.Models.CartaoDeCredito", b =>
                {
                    b.Navigation("Devolucoes");

                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("Aluguel.Models.Ciclista", b =>
                {
                    b.Navigation("Cartoes");

                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("Aluguel.Models.Emprestimo", b =>
                {
                    b.Navigation("Devolucao");
                });

            modelBuilder.Entity("Aluguel.Models.Pais", b =>
                {
                    b.Navigation("Passaporte")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
