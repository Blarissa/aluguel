using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Handlers.Contracts;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;
using Aluguel.Validacao;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class AdicionaFuncionarioHandler : IHandler<AdicionaFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidaRegraBancoFuncionario _valida;

        public AdicionaFuncionarioHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _valida = new ValidaRegraDoBancoFuncionario(_repository);
        }

        public ICommandResult Handle(AdicionaFuncionarioCommand command)
        {
            //validação dos dados passados
            if (!command.Validar())
            {
                //se já existe o cpf
                if (_valida.CPFFuncionario(command.FuncionarioDto.Cpf))
                    command.AdicionarErro(new Erro(
                        ListaDeErros.CpfCod,
                        ListaDeErros.CpfMsg));
             
                return new GenericCommandResult(command.Erros);
            }
                     
            var funcionario = _mapper.Map<Funcionario>(command.FuncionarioDto);

            _repository.Adicionar(funcionario);

            return new GenericCommandResult(funcionario);
        }
    }
}
