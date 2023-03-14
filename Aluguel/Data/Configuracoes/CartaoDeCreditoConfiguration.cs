using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data;

public class CartaoDeCreditoConfiguration : IEntityTypeConfiguration<CartaoDeCredito>
{
    public void Configure(EntityTypeBuilder<CartaoDeCredito> builder)
    {
        //definindo primary key com valor autogerado
        builder.Property(cc => cc.Id).ValueGeneratedOnAdd();
        builder.HasKey(cc =>cc.Id);

        //definindo propriedade nome not null
        builder.Property(cc => cc.Nome)
            .IsRequired();

        //definindo propriedade numero not null
        builder.Property(cc => cc.Numero)
            .IsRequired();

        //definindo propriedade mesvalidade not null
        builder.Property(cc => cc.MesValidade)
            .IsRequired();

        //definindo propriedade anovalidade not null
        builder.Property(cc => cc.AnoValidade)
            .IsRequired();

        //definindo propriedade codigoseguranca not null
        builder.Property(cc => cc.CodigoSeguranca)
            .IsRequired();

        //definindo propriedade de status do cartão de crédito
        builder.Property(cc => cc.Status)
            .HasColumnType("e_status_cartao")
            .IsRequired();

        //definindo relacionamento ciclista x cartaodecredito
        builder.HasOne(cc => cc.Ciclista)
            .WithMany(c => c.Cartoes)
            .HasForeignKey(cc => cc.CiclistaId);

        //definindo relacionamento emprestimo x cartaodecredito
        builder.HasMany(cc => cc.Emprestimos)
            .WithOne(e => e.CartaoDeCredito)
            .HasForeignKey(e => e.CartaoDeCreditoId);

        //definindo relacionamento devolucao x cartaodecredito
        builder.HasMany(cc => cc.Devolucoes)
            .WithOne(d => d.CartaoDeCredito)
            .HasForeignKey(d => d.CartaoDeCreditoId);
    }
}
