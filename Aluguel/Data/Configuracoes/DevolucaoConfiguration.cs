using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data;

public class DevolucaoConfiguration : IEntityTypeConfiguration<Devolucao>
{
    public void Configure(EntityTypeBuilder<Devolucao> builder)
    {
        //definindo primary key com valor autogerado
        builder.Property(d => d.Id).ValueGeneratedOnAdd();
        builder.HasKey(d => d.Id);

        //definindo propriedade valor not null
        builder.Property(d => d.Valor)
            .IsRequired();

        //definindo propriedade datahora com atribuição de valor quando é adicionado na tabela
        builder.Property(d => d.DataHora)
            .HasColumnType("Timestamp without Time Zone")
            .HasDefaultValueSql("now()");

        //definindo propriedade datahorapagamento
        builder.Property(d => d.DataHoraPagamento)
            .HasColumnType("Timestamp without Time Zone");

        //definindo relacionamento cartaodecredito x devolucao
        builder.HasOne(d => d.CartaoDeCredito)
            .WithMany(cc => cc.Devolucoes)
            .HasForeignKey(d => d.CartaoDeCreditoId);

        ////definindo relacionamento tranca x devolucao
        //builder.HasOne(d => d.Tranca)
        //    .WithMany(t => t.Devolucoes)
        //    .HasForeignKey(d => d.TrancaId);

        //definindo relacionamento emprestimo x devolucao
        builder.HasOne(d => d.Emprestimo)
            .WithOne(e => e.Devolucao)
            .HasForeignKey<Devolucao>(d => d.EmprestimoId);
    }
}
