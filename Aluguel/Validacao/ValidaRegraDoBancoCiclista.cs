using Aluguel.Models;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Validacao
{
    public class ValidaRegraDoBancoCiclista : IValidaRegraDoBancoCiclista
    {
        ICiclistaRepository _ciclistaRepository;
        IPaisRepository _paisRepository;

        public ValidaRegraDoBancoCiclista(ICiclistaRepository ciclistaRepository)
        {
            _ciclistaRepository = ciclistaRepository;
        }        

        public ValidaRegraDoBancoCiclista(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        //se existe algum ciclista com o cpf passado
        public bool CPFCiclista(string cpf)
        {
            return _ciclistaRepository
                  .BuscarTodos()
                  .Any(c => c.Cpf == cpf);            
        }

        //se existe algum ciclista com o id passado
        public bool IdCiclista(Guid idCiclista)
        {
            return _ciclistaRepository
                   .BuscarTodos()
                   .Any(c => c.Id == idCiclista);            
        }               

        //se o código do pais existe
        public bool Passaporte(string codigo)
        {
            return _paisRepository
                   .RecuperarTodos()
                   .Any(p => p.Codigo == codigo);
        }
        
        //se o ciclista pode alugar uma bicicleta
        public bool PodeAlugar(Guid idCiclista)
        {
            return _ciclistaRepository
                .BuscarPorId(idCiclista)
                .PodeFazerEmprestimo();                                     
        }
        
        //se o status do ciclista está ativo
        public bool Status(Guid idCiclista)
        {
            return _ciclistaRepository
                   .RetornaStatusCiclista(idCiclista)
                   .Equals(EStatusCiclista.ATIVO);
        }

    }
}
