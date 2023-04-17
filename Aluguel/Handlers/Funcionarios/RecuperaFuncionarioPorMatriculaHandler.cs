using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Data.Dtos;
using Aluguel.Handlers.Contracts;
using Aluguel.Models.Entidades;
using Aluguel.Queries.Funcionarios;
using Aluguel.Repositorios.Contracts;
using Aluguel.Validacao;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class RecuperaFuncionarioPorMatriculaHandler : IHandlerQuery<RecuperaFuncionarioPorMatriculaQuery>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidaRegraBancoFuncionario _valida;

        public RecuperaFuncionarioPorMatriculaHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(RecuperaFuncionarioPorMatriculaQuery? query)
        {
            //se existe o funcionário
            if (!_valida.IdFuncionario(query.Matricula))
            {
                query.AdicionarErro(new Erro("000"));

                return new NotFoundCommandResult(query.Erros);
            }

            var funcionario = _repository
                .RecuperarPorMatricula(query.Matricula);

            _mapper.Map<ReadFuncionarioDto>(funcionario);

            return new OkCommandResult(funcionario);
        }
    }
}
