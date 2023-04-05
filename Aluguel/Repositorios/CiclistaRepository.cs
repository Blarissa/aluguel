using Aluguel.Data;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;

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
        throw new NotImplementedException();
    }

    public Ciclista BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool EmailExiste(string email)
    {
        throw new NotImplementedException();
    }
}