using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel.Data;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {       
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Valor)
            .IsRequired();

        builder.Property(e => e.DataHora)
            .HasColumnType("Timestamp without Time Zone")
            .HasDefaultValueSql("now()");          

        builder.Property(e => e.DataHoraPagamento)
            .HasColumnType("Timestamp without Time Zone");
          
        builder.HasOne(e => e.Ciclista)
            .WithMany(c => c.Emprestimos)
            .HasForeignKey(e => e.CiclistaId);

        builder.HasOne(e => e.CartaoDeCredito)
            .WithMany(cc => cc.Emprestimos)
            .HasForeignKey(e => e.CartaoDeCreditoId);

        builder.HasOne(e => e.Bicicleta)
            .WithMany(b => b.Emprestimos)
            .HasForeignKey(e => e.BicicletaId);
        
        builder.HasOne(e => e.Tranca)
            .WithMany(t => t.Emprestimos)
            .HasForeignKey(e => e.TrancaId);

        builder.HasOne(e => e.Devolucao)
            .WithOne(d => d.Emprestimo)
            .HasForeignKey<Devolucao>(d => d.EmprestimoId);
    }
}
