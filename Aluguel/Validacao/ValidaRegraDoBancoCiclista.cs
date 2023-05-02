using Aluguel.Models;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Validacao
{
    public class ValidaRegraDoBancoCiclista : IValidaRegraDoBancoCiclista
    {
        ICiclistaRepository _ciclistaRepository;
        IPaisRepository _paisRepository;

        public ValidaRegraDoBancoCiclista(ICiclistaRepository ciclistaRepository,
            IPaisRepository paisRepository)
        {
            _ciclistaRepository = ciclistaRepository;
            _paisRepository = paisRepository;
        }        

        //se existe algum ciclista com o cpf passado
        public bool CPFCiclista(string cpf)
        {
            return _ciclistaRepository
                  .BuscarTodos()
                  .Any(c => c.Cpf == cpf);            
        }

        //se existe algum ciclista com o email passado
        public bool EmailCiclista(string email)
        {
            return _ciclistaRepository.EmailExiste(email);
        }

        //se existe algum ciclista com o id passado
        public bool IdCiclista(Guid idCiclista)
        {
            return _ciclistaRepository
                   .BuscarTodos()
                   .Any(c => c.Id == idCiclista);            
        }

        //se o pais existir no banco é valido
        public bool Pais(string codigo)
        {
            return _paisRepository
                .PaisExiste(codigo);
        }

        //se o passaporte não existir é válido
        public bool Passaporte(string codigo)
        {
            return !_ciclistaRepository
                .PassaporteExiste(codigo); 
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
