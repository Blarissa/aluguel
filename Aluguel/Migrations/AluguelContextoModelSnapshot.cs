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

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Aluguel.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("Funcao")
                        .HasColumnType("integer")
                        .HasColumnName("funcao");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("matricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("senha");

                    b.HasKey("Id")
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

            modelBuilder.Entity("Aluguel.Models.Pais", b =>
                {
                    b.Navigation("Passaporte")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
