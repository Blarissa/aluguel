﻿using Aluguel.Commands;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Commands.Results;
using Aluguel.Handlers.Contracts;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Handlers.Funcionarios
{
    public class DeletaFuncionarioHandler : IHandler<DeletaFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;        
        private readonly IValidaRegraBancoFuncionario _valida;

        public DeletaFuncionarioHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
            _valida = new ValidaRegraDoBancoFuncionario(_repository);
        }

        public ICommandResult Handle(DeletaFuncionarioCommand command)
        {
            //se o funcionário existe
            if (!_valida.IdFuncionario(command.Matricula))
            {
                command.AdicionarErro(new Erro("000"));

                return new NotFoundCommandResult(command.Erros);
            }

            var funcionario = _repository.RecuperarPorMatricula(command.Matricula);
            _repository.Deletar(funcionario);

            return new OkCommandResult(funcionario);
        }        
    }
}
