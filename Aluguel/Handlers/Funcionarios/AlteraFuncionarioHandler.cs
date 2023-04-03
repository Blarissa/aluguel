using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Data.Dtos;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class AlteraFuncionarioHandler : IHandler<AlteraFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;

        public AlteraFuncionarioHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        public ICommandResult Handle(AlteraFuncionarioCommand command)
        {
            if (!command.Valida)
                return new GenericCommandResult(command.Erros.ToArray());

            var funcionario = _repository.RecuperarPorMatricula(command.Matricula);

            _mapper.Map(command.FuncionarioDto, funcionario);
            _repository.Alterar(funcionario);

            return new GenericCommandResult(funcionario);
        }
    }
}
