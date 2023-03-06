using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        //definindo primary key com valor autogerado
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        //definindo propriedade valor not null
        builder.Property(e => e.Valor)
            .IsRequired();

        //definindo propriedade datahora com atribuição de valor quando é adicionado na tabela
        builder.Property(e => e.DataHora)
            .HasColumnType("Timestamp without Time Zone")
            .HasDefaultValueSql("now()");

        //definindo propriedade datahorapagamento
        builder.Property(e => e.DataHoraPagamento)
            .HasColumnType("Timestamp without Time Zone");

        //definindo relacionamento ciclista x emprestimo
        builder.HasOne(e => e.Ciclista)
            .WithMany(c => c.Emprestimos)
            .HasForeignKey(e => e.CiclistaId);

        //definindo relacionamento cartaodecredito x emprestimo
        builder.HasOne(e => e.CartaoDeCredito)
            .WithMany(cc => cc.Emprestimos)
            .HasForeignKey(e => e.CartaoDeCreditoId);

        //definindo relacionamento bicicleta x emprestimo
        builder.HasOne(e => e.Bicicleta)
            .WithMany(b => b.Emprestimos)
            .HasForeignKey(e => e.BicicletaId);

        //definindo relacionamento tranca x emprestimo
        builder.HasOne(e => e.Tranca)
            .WithMany(t => t.Emprestimos)
            .HasForeignKey(e => e.TrancaId);

        //definindo relacionamento devolucao x emprestimo
        builder.HasOne(e => e.Devolucao)
            .WithOne(d => d.Emprestimo)
            .HasForeignKey<Devolucao>(d => d.EmprestimoId);
    }
}
