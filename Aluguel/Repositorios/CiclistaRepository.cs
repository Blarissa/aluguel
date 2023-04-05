using Aluguel.Data;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Aluguel.Repositorios;

public class CiclistaRepository : ICiclistaRepository
{
    private readonly AluguelContexto _contexto;

    public CiclistaRepository(AluguelContexto contexto)
    {
        _contexto = contexto;
    }

    public void AdicionarCiclistaComCartao(Ciclista ciclista, CartaoDeCredito cartaoDeCredito)
    {
        _contexto.Ciclistas.Add(ciclista);
        _contexto.CartoesDeCredito.Add(cartaoDeCredito);
        _contexto.SaveChanges();
    }

    public void AtualizarCiclista(Ciclista ciclista)
    {
        _contexto.Entry(ciclista).State = EntityState.Modified;
        _contexto.SaveChanges();
    }

    public Ciclista? BuscarPorId(Guid id)
    {
        var ciclista = _contexto.Ciclistas
            .Include(c => c.Emprestimos)
            .ThenInclude(c => c.CartaoDeCredito)
            .Include(c => c.Passaporte)
            .ThenInclude(c => c.Pais)
            .FirstOrDefault(c => c.Id == id);

        return ciclista;
    }

    public bool EmailExiste(string email)
    {
        var ciclista = _contexto.Ciclistas.FirstOrDefault(c => c.Email == email);

        return ciclista != null;
    }
}