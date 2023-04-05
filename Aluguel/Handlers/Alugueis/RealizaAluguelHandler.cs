using Aluguel.Commands.Alugueis;
using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using Aluguel.Validacao;
using AutoMapper;

namespace Aluguel.Handlers.Alugueis
{
    public class RealizaAluguelHandler : IHandler<RealizarAluguelCommand>
    {
        private readonly IAluguelRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidaRegraBancoFuncionario _valida;

        public RealizaAluguelHandler(IAluguelRepository repository, IMapper mapper)
        { 
            _repository = repository;
            _mapper = mapper;
            _valida = new ValidaRegraDoBancoCiclista(_repository);
        }

        public ICommandResult Handle(RealizarAluguelCommand command)
        {
            
        }
    }
}
