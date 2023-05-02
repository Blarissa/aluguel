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

    //adicionando ciclista brasileiro
    public void AdicionarCiclistaComCartao(Ciclista ciclista, CartaoDeCredito cartaoDeCredito)
    {
        _contexto.Ciclistas.Add(ciclista);
        _contexto.CartoesDeCredito.Add(cartaoDeCredito);
        _contexto.SaveChanges();
    }

    //atualizando ciclista
    public void AtualizarCiclista(Ciclista ciclista)
    {
        _contexto.Entry(ciclista).State = EntityState.Modified;
        _contexto.SaveChanges();
    }

    //pesquisa ciclista por id
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

    //todos os ciclistas
    public IList<Ciclista> BuscarTodos()
    {
        return _contexto.Ciclistas
               .Include(c => c.Emprestimos)
               .ThenInclude(c => c.CartaoDeCredito)
               .Include(c => c.Passaporte)
               .ThenInclude(c => c.Pais).ToList();
    }

    //status de um ciclista
    public EStatusCiclista RetornaStatusCiclista(Guid idCiclista)
    {
        return BuscarPorId(idCiclista).Status;
    }
    
    //se o email já foi cadastrado
    public bool EmailExiste(string email)
    {
        var ciclista = _contexto.Ciclistas.FirstOrDefault(c => c.Email == email);

        return ciclista != null;
    }

    //se o passaporte já foi cadastrado
    public bool PassaporteExiste(string numero)
    {
        return _contexto.Passaportes
            .Any(p => p.Numero.Equals(numero));
    }

    //emprestimo ativo de um ciclista, se existir
    public Emprestimo? RetornaEmprestimoAtivo(Guid idCiclista)
    {
        return BuscarPorId(idCiclista)
            .Emprestimos
            .Where(e => e.Devolucao.Equals(null))
            .FirstOrDefault();
    }

    //todos os emprestimos de um ciclista
    public IList<Emprestimo> RetornaEmprestimosPorCiclista(Guid idCiclista)
    {
        return BuscarPorId(idCiclista).Emprestimos;
    }

    //último cartão de crédito adicionado de um ciclista, se existir
    public CartaoDeCredito? UltimoCataoAdicionado(Guid idCiclista)
    {
        return BuscarPorId(idCiclista).Cartoes.LastOrDefault();                         
    }
}