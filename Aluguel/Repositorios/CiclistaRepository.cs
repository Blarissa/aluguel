using Aluguel.Data;
using Aluguel.Models;
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

    public IList<Ciclista> BuscarTodos()
    {
        return _contexto.Ciclistas
               .Include(c => c.Emprestimos)
               .ThenInclude(c => c.CartaoDeCredito)
               .Include(c => c.Passaporte)
               .ThenInclude(c => c.Pais).ToList();
    }

    public bool EmailExiste(string email)
    {
        var ciclista = _contexto.Ciclistas.FirstOrDefault(c => c.Email == email);

        return ciclista != null;
    }

    public Emprestimo? RetornaEmprestimoAtivo(Guid idCiclista)
    {
        return BuscarPorId(idCiclista)
            .Emprestimos
            .Where(e => e.Devolucao.Equals(null))
            .FirstOrDefault();
    }

    public IList<Emprestimo> RetornaEmprestimosPorCiclista(Guid idCiclista)
    {
        return BuscarPorId(idCiclista).Emprestimos;
    }

    public EStatusCiclista RetornaStatusCiclista(Guid idCiclista)
    {
        return BuscarPorId(idCiclista).Status;
    }

    public CartaoDeCredito? UltimoCataoAdicionado(Guid idCiclista)
    {
        return BuscarPorId(idCiclista).Cartoes.LastOrDefault();                         
    }
}