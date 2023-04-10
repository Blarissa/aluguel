using Aluguel.Data;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Aluguel.Repositorios
{
    public class AluguelRepository : IAluguelRepository
    {
        private AluguelContexto contexto;

        public AluguelRepository(AluguelContexto contexto)
        {
            this.contexto = contexto;
        }

        public void RealizaAluguel(Emprestimo emprestimo)
        {
            contexto.Emprestimos.Add(emprestimo);
            contexto.SaveChanges();
        }

        public IList<Emprestimo?> RecuperaAlugueis()
        {
            throw new NotImplementedException();
        }

        public IList<Emprestimo?> RecuperaAlugueisAtivos()
        {
            throw new NotImplementedException();
        }

        public IList<Emprestimo?> RecuperaAlugueisPorCiclista(Guid idCiclista)
        {
            throw new NotImplementedException();
        }

        public Emprestimo? RecuperaAluguelAtivo(Guid idCiclista)
        {
            throw new NotImplementedException();
        }

        public Emprestimo? RecuperaAluguelPorCiclista(Guid idCiclista)
        {
            throw new NotImplementedException();
        }

        public Emprestimo? RecuperaAluguelPorId(Guid id)
        {
            return contexto.Emprestimos.Include(e => e.Bicicleta)
                .Include(e => e.Tranca)
                .Include(e => e.Ciclista)
                .ThenInclude(c => c.Cartoes)
                .FirstOrDefault(e => e.Id == id);
        }

        public IList<ReadEmprestimoDto> RecuperaTodosAlugueisPorCiclista(Guid idCiclista)
        {
            throw new NotImplementedException();
        }
    }
}
