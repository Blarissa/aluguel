using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data
{
    public class CiclistaConfiguration : IEntityTypeConfiguration<Ciclista>
    {
        public void Configure(EntityTypeBuilder<Ciclista> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired();

            builder.Property<DateTime>(c => c.DataNascimento).IsRequired().HasColumnType("date");

            builder.Property(c => c.Email).IsRequired();

            builder.Property(c => c.UrlFotoDocumento).IsRequired();

            builder.Property(c => c.Status).IsRequired();

            builder.Property(c => c.Nacionalidade).IsRequired();

            builder.Property(c => c.DataHoraCadastro).HasColumnType("Timestamp without Time Zone").HasDefaultValueSql("now()");

            builder.Property(c => c.DataHoraConfirmacao).IsRequired().HasColumnType("Timestamp without Time Zone");

            //Relacao com cartoes de credito
            builder.HasMany(c => c.Cartoes).WithOne(cc => cc.Ciclista).HasForeignKey(cc => cc.CiclistaId);

            //Relacao com emprestimos realizados
            builder.HasMany(c => c.Emprestimos).WithOne(e => e.Ciclista).HasForeignKey(e => e.CiclistaId);
        }
    }
}
