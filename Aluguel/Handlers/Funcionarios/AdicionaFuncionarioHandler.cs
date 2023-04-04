using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Handlers.Contracts;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class AdicionaFuncionarioHandler : IHandler<AdicionaFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;

        public AdicionaFuncionarioHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(AdicionaFuncionarioCommand command)
        {
            if(!command.Validar())
                return new GenericCommandResult(command.Erros);

            var funcionario = _mapper.Map<Funcionario>(command.funcionarioDto);

            _repository.Adicionar(funcionario);

            return new GenericCommandResult(funcionario);
        }
    }
}
