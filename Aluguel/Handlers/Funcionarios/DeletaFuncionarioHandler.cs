using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class DeletaFuncionarioHandler : IHandler<DeletaFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;

        public DeletaFuncionarioHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(DeletaFuncionarioCommand command)
        {
            if (!command.Valida)
                return new GenericCommandResult(command.Erros.ToArray());

            var funcionario = _repository.RecuperarPorMatricula(command.Matricula);
            _repository.Deletar(funcionario);

            return new GenericCommandResult(command);
        }        
    }
}
