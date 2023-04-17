using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;
using Aluguel.Models.Entidades;
using Aluguel.Validacao;

namespace Aluguel.Commands.Funcionarios
{
    public class AlteraFuncionarioCommand : BaseValidacao, ICommand
    {
        public int Matricula { get; set; }
        public UpdateFuncionarioDto FuncionarioDto { get; set;}
        IValida validacao;

        public AlteraFuncionarioCommand(int matricula, UpdateFuncionarioDto funcionarioDto)
        {
            Matricula = matricula;
            FuncionarioDto = funcionarioDto;
            validacao = new Valida();
        }
        
        public bool Validar()
        {            
            if (!validacao.Funcao(FuncionarioDto.Funcao))
                AdicionarErro(new Erro("012a"));

            if (!validacao.Nome(FuncionarioDto.Nome))
                AdicionarErro(new Erro("001a"));

            if (!validacao.Senha(FuncionarioDto.Senha,
                FuncionarioDto.ConfirmaSenha))
                AdicionarErro(new Erro("007a"));

            if (!validacao.Email(FuncionarioDto.Email))
                AdicionarErro(new Erro("006a"));

            if (!validacao.Idade(FuncionarioDto.Idade))
                AdicionarErro(new Erro("005a"));

            return Valida; 
        }
    }
}
