using Aluguel.Models;
using Aluguel.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data.Configuracoes
{
    public class PassaporteConfiguration : IEntityTypeConfiguration<Passaporte>
    {
        public void Configure(EntityTypeBuilder<Passaporte> builder)
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero)
                .IsRequired();

            builder.Property<DateTime>(p => p.DataValidade)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(p => p.Pais)
                .WithMany()
                .HasForeignKey(p => p.PaisId);
        }
    }
}

