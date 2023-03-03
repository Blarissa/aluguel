using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data;

public class CartaoDeCreditoConfiguration : IEntityTypeConfiguration<CartaoDeCredito>
{
    public void Configure(EntityTypeBuilder<CartaoDeCredito> builder)
    {
        builder.Property(cc => cc.Id).ValueGeneratedOnAdd();
        builder.HasKey(cc =>cc.Id);

        builder.Property(cc => cc.Nome)
            .IsRequired();

        builder.Property(cc => cc.Numero)
            .IsRequired();

        builder.Property(cc => cc.MesValidade)
            .IsRequired();

        builder.Property(cc => cc.AnoValidade)
            .IsRequired();

        builder.Property(cc => cc.CodigoSeguranca)
            .IsRequired();

        builder.Property(cc => cc.Status)
            .IsRequired();
        
        builder.HasOne(cc => cc.Ciclista)
            .WithMany(c => c.Cartoes)
            .HasForeignKey(cc => cc.CiclistaId);

        builder.HasMany(cc => cc.Emprestimos)
            .WithOne(e => e.CartaoDeCredito)
            .HasForeignKey(e => e.CartaoDeCreditoId);               

        builder.HasMany(cc => cc.Devolucoes)
            .WithOne(d => d.CartaoDeCredito)
            .HasForeignKey(d => d.CartaoDeCreditoId);
    }
}
