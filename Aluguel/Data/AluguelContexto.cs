﻿using Aluguel.Data.Configuracoes;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aluguel.Data
{
    public class AluguelContexto : DbContext
    {
        public DbSet<Ciclista> Ciclistas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Passaporte> Passaportes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<CartaoDeCredito> CartoesDeCredito { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Devolucao> Devolucoes { get; set; }

        public AluguelContexto(DbContextOptions options) : base(options)
        {            
        }

        public AluguelContexto()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Bicicleta>();
            modelBuilder.Ignore<Tranca>();

            modelBuilder.HasPostgresEnum<EFuncao>();
            modelBuilder.HasPostgresEnum<ENacionalidade>();
            modelBuilder.HasPostgresEnum<EStatusCiclista>();

            modelBuilder.ApplyConfiguration(new EmprestimoConfiguration());
            modelBuilder.ApplyConfiguration(new CartaoDeCreditoConfiguration());
            modelBuilder.ApplyConfiguration(new DevolucaoConfiguration());
            modelBuilder.ApplyConfiguration(new CiclistaConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new PassaporteConfiguration());
        }
    }
}
