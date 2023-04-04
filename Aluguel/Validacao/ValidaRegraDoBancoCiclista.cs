using Aluguel.Data.Dao;
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
            //return _ciclistaRepository.RecuperarTodos().Any(c => c.Cpf == cpf);
            throw new NotImplementedException();
        }

        //se existe algum ciclista com o id passado
        public bool IdCiclista(Guid idCiclista)
        {
            //return _ciclistaRepository.RecuperarTodos().Any(c => c.id == idCiclista);
            throw new NotImplementedException();
        }               

        //se o código do pais existe
        public bool Passaporte(string codigo)
        {
            return _paisRepository
                .RecuperarTodos()
                .Any(p => p.Codigo == codigo);
        }
    }
}
