using Aluguel.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aluguel.Data.Dao.Devolucao
{
    public class DevolucaoDao
    {

        private AluguelContexto contexto;
        public DevolucaoDao(AluguelContexto ctxt)
        {
            this.contexto = ctxt;
        }

        public Emprestimo? BuscarEmprestimoAberto(Guid idBicicleta, Guid idTranca)
        {
            var query = from emp in contexto.Emprestimos
                        where emp.BicicletaId == idBicicleta && emp.TrancaId== idTranca && emp.Devolucao == null
                        select emp;

            return query.FirstOrDefault();
        }
    }
}
