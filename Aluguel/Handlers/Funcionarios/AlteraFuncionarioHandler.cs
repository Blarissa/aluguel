﻿using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Commands.Results;
using Aluguel.Handlers.Contracts;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using Aluguel.Validacao;
using AutoMapper;

namespace Aluguel.Handlers.Funcionarios
{
    public class AlteraFuncionarioHandler : IHandler<AlteraFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidaRegraBancoFuncionario _valida;

        public AlteraFuncionarioHandler(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _valida = new ValidaRegraDoBancoFuncionario(_repository);
        }        

        public ICommandResult Handle(AlteraFuncionarioCommand command)
        {
            //se existe o funcionário
            if (!_valida.IdFuncionario(command.Matricula)) { 
                command.AdicionarErro(new Erro("000"));

                return new NotFoundCommandResult(command.Erros);
            }

            //validações dos dados passados
            if (!command.Valida)
                return new UnprocessableEntityCommandResult(
                    command.Erros);

            var funcionario = _repository
                .RecuperarPorMatricula(command.Matricula);

            _mapper.Map(command.FuncionarioDto, funcionario);
            _repository.Alterar(funcionario);

            return new OkCommandResult(funcionario);
        }
    }
}
