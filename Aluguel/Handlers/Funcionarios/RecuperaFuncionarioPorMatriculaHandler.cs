using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;
using Aluguel.Handlers.Contracts;
using Aluguel.Models;
using Aluguel.Queries.Funcionarios;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class RecuperaFuncionarioPorMatriculaHandler : IHandlerQuery<RecuperaFuncionarioPorMatriculaQuery>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;

        public RecuperaFuncionarioPorMatriculaHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(RecuperaFuncionarioPorMatriculaQuery? query)
        {
            var funcionario = _repository.RecuperarPorMatricula(query.Matricula);

            _mapper.Map<ReadFuncionarioDto>(funcionario);

            return new GenericCommandResult(funcionario);
        }
    }
}
