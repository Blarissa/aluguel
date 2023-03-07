using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data.Configuracoes
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Matricula)
                .IsRequired();

            builder.Property(f => f.Nome)
                .IsRequired();

            builder.Property(f => f.Email)
                .IsRequired();

            builder.Property(f => f.Senha)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .IsRequired();

            builder.Property<DateTime>(f => f.DataNascimento)
                .IsRequired()
                .HasColumnType("date");
        
            builder.Property(f => f.Funcao)
                .IsRequired();
        }
    }
}
