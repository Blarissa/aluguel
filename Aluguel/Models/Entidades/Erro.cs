namespace Aluguel.Models.Entidades;

public class Erro
{    
    public string Codigo { get; set; }    
    public string Mensagem { get; set; }

    public Erro(string codigo, string mensagem)
    {
        Codigo = codigo;
        Mensagem = mensagem;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}\n" +
               $"Mensagem: {Mensagem}\n";
    }
}

public static class ListaDeErros
{
    public const string NaoEncrontradoCod = "000a";
    public const string NaoEncrontradoMsg = "Não encontrado!";

    public const string NomeCod = "001a";
    public const string NomeMsg = "Nome inválido!";

    public const string CpfCod = "002a";
    public const string CpfMsg = "CPF inválido!";

    public const string DataCod = "003a";
    public const string DataMsg = "Data inválida!";

    public const string CartaoCod = "004a";
    public const string CartaoMsg = "Cartão inválido!";

    public const string IdadeCod = "005a";
    public const string IdadeMsg = "Idade inválida!";

    public const string EmailCod = "006a";
    public const string EmailMsg = "Email inválido!";

    public const string SenhaCod = "007a";
    public const string SenhaMsg = "Senha inválida!";

    public const string PassaporteCod = "008a";
    public const string PassaporteMsg = "Passaporte inválido!";

    public const string FotoCod = "009a";
    public const string FotoMsg = "Foto do documento inválida!";

    public const string PaisCod = "010a";
    public const string PaisMsg = "Código do país inválido";

    public const string StatusCod = "011a";
    public const string StatusMsg = "Status do funcionário inválido";

    public const string FuncaoCod = "012a";
    public const string FuncaoMsg = "Função do funcionário inválida";

    public const string NacionalidadeCod = "013a";
    public const string NacionalidadeMsg = "Nacionalidade inválida";

    public const string FormatoCod = "014a";
    public const string CFormatoMsg = "Formato inválido";

    public const string EntidadeNaoCadastradaCod = "015a";
    public const string EntidadeNaoCadastradaMsg = "Entidade não cadastrada!";

    public const string EntidadeAtivadaCod = "016a";
    public const string EntidadeAtivadaMsg = "Entidade já ativada!";

    public const string CiclistaInativoCod = "017a";
    public const string CiclistaInativoMsg = "Ciclista está inativo ou bloqueado!";

    public const string TrancaCod = "018a";
    public const string TrancaMsg = "Tranca deve está com status ocupada!";

    public const string TrancaInexistenteCod = "019a";
    public const string TrancaInexistenteMsg = "Tranca não existe!";

    public const string NaoPodeAlugarCod = "020a";
    public const string NaoPodeAlugarMsg = "Ciclista não pode pegar outra bicicleta!";

    public const string TrancaNaoRespondeCod = "021a";
    public const string TrancaNaoRespondeMsg = "Tranca deve está com status ocupada!";
    
    public const string BicicletaIndisponivelCod = "022a";
    public const string BicicletaIndisponivelMsg = "Bicicleta deve está disponível!";
    
    public const string BicicletaEmReparoCod = "023a";
    public const string BicicletaEmReparoMsg = "Há um reparo requisitado, a bicicleta não pode ser alugada!";

    public const string SemBicicletaCod = "024a";
    public const string SemBicicletaMsg = "Não existe biciclietas na tranca!";
}
