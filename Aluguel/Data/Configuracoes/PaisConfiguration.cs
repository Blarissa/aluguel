using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            //definindo primary key com valor autogerado
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);

            //definindo propriedade codigo not null e tamanho 2
            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(2)")
                .IsRequired();

            //definindo propriedade nome not null
            builder.Property(p => p.Nome)
                .IsRequired();
        }
    }
}
