using Aluguel.Data;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Repositorios
{
    public class DevolucaoRepository : IDevolucaoRepository
    {
        private AluguelContexto contexto;
        public DevolucaoRepository(AluguelContexto ctxt)
        {
            this.contexto = ctxt;
        }
        public Emprestimo? BuscarEmprestimoAberto(Guid idBicicleta, Guid idTranca)
        {
            var query = from emp in contexto.Emprestimos
                        where emp.BicicletaId == idBicicleta && emp.TrancaId == idTranca && emp.Devolucao == null
                        select emp;

            return query.FirstOrDefault();
        }
    }
}
