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
                AdicionarErro(new Erro(
                    ListaDeErros.FuncaoCod,
                    ListaDeErros.FuncaoMsg));

            if (!validacao.Nome(FuncionarioDto.Nome))
                AdicionarErro(new Erro(
                    ListaDeErros.NomeCod,
                    ListaDeErros.NomeMsg));

            if (!validacao.Senha(FuncionarioDto.Senha,
                FuncionarioDto.ConfirmaSenha))
                AdicionarErro(new Erro(
                    ListaDeErros.SenhaCod,
                    ListaDeErros.SenhaMsg));

            if (!validacao.Email(FuncionarioDto.Email))
                AdicionarErro(new Erro(
                    ListaDeErros.EmailCod,
                    ListaDeErros.EmailMsg));

            if (!validacao.Idade(FuncionarioDto.Idade))
                AdicionarErro(new Erro(
                    ListaDeErros.IdadeCod,
                    ListaDeErros.IdadeMsg));

            return Valida; 
        }
    }
}
