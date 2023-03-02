using Aluguel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace Aluguel.Data;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {       
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Valor)            
            .IsRequired();

        builder.Property<DateTime>(e => e.DataHora)
            .HasColumnType("Timestamp without Time Zone")
            .HasComputedColumnSql("now()");

        builder.Property<DateTime?>(e => e.DataHoraPagamento)
            .HasColumnType("Timestamp without Time Zone");

        //builder.Property(e => e.CiclistaId);
        //builder.Property(e => e.BicicletaId);
        //builder.Property(e => e.TrancaId);
          
        builder.HasOne(e => e.Ciclista)
            .WithMany(c => c.Emprestimos);
        
        builder.HasOne(e => e.Bicicleta)
            .WithMany(b => b.Emprestimos);
        
        builder.HasOne(e => e.Tranca)
            .WithMany(t => t.Emprestimos);
    }
}
