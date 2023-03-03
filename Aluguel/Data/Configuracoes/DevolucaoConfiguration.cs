using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data;

public class DevolucaoConfiguration : IEntityTypeConfiguration<Devolucao>
{
    public void Configure(EntityTypeBuilder<Devolucao> builder)
    {
        builder.Property(d => d.Id).ValueGeneratedOnAdd();
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Valor)
            .IsRequired();

        builder.Property(d => d.DataHora)
            .HasColumnType("Timestamp without Time Zone")
            .HasDefaultValueSql("now()");

        builder.Property(d => d.DataHoraPagamento)
            .HasColumnType("Timestamp without Time Zone");

        builder.HasOne(d => d.CartaoDeCredito)
            .WithMany(cc => cc.Devolucoes)
            .HasForeignKey(d => d.CartaoDeCreditoId);

        builder.HasOne(d => d.Tranca)
            .WithMany(t => t.Devolucoes)
            .HasForeignKey(d => d.TrancaId);

        builder.HasOne(d => d.Emprestimo)
            .WithOne(e => e.Devolucao)
            .HasForeignKey<Devolucao>(d => d.EmprestimoId);
    }
}
