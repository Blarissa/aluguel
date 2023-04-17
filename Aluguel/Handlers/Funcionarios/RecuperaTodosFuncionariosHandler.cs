using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Data.Dtos;
using Aluguel.Handlers.Contracts;
using Aluguel.Queries.Funcionarios;
using Aluguel.Repositorios.Contracts;
using AutoMapper;
using System.Runtime.InteropServices;

namespace Aluguel.Handlers.Funcionarios
{
    public class RecuperaTodosFuncionariosHandler : IHandlerQuery<RecuperaTodosFuncionariosQuery>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;

        public RecuperaTodosFuncionariosHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle([Optional] RecuperaTodosFuncionariosQuery query)
        {
            var funcionarios = _mapper.Map<List<ReadFuncionarioDto>>(_repository.RecuperarTodos());

            return new OkCommandResult(funcionarios);
        }
    }
}
