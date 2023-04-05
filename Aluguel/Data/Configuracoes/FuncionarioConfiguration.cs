using Aluguel.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data.Configuracoes
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(f => f.Matricula)
                .ValueGeneratedOnAdd();

            builder.HasKey(f => f.Matricula);            

            builder.Property(f => f.Nome)
                .IsRequired();

            builder.Property(f => f.Email)
                .IsRequired();

            builder.Property(f => f.Senha)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .IsRequired();

            builder.Property(f => f.Idade)
                .IsRequired();
        
            builder.Property(f => f.Funcao)                
                .HasColumnType("e_funcao")
                .IsRequired();
        }
    }
}
