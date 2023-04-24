namespace Aluguel.Models.Entidades;

public class ListaDeErros
{
    public Dictionary<string, string> Erros { get; set; }
    
    public ListaDeErros()
    {
        Erros = new Dictionary<string, string>();
        AdicionaErros();       
    }
 
    public void AdicionaErros()
    {   
        //Quando uma entidade não é encontrada
        Erros.Add("000", "Não encontrado!");

        //Erros relacionados a aluguel no formato 000a
        Erros.Add("001a", "Nome inválido!");
        Erros.Add("002a", "CPF inválido!");
        Erros.Add("003a", "Data inválida!");
        Erros.Add("004a", "Cartão inválido!");
        Erros.Add("005a", "Idade inválida!");
        Erros.Add("006a", "Email inválido!");
        Erros.Add("007a", "Senha inválida!");
        Erros.Add("008a", "Passaporte inválido!");
        Erros.Add("009a", "Foto do documento inválida!");         
    
        Erros.Add("010a", "Código do país inválido!");
        Erros.Add("011a", "Status do ciclísta inválido!");
        Erros.Add("012a", "Função do funcionário inválido!");
        Erros.Add("013a", "Nacionalidade inválida!");
        Erros.Add("014a", "Formato inválido!");
        Erros.Add("015a", "Entidade não cadastrada!");
        Erros.Add("016a", "Entidade já ativada!");
        Erros.Add("017a", "Ciclista está inativo ou bloqueado!");
        Erros.Add("018a", "Ciclista não pode pegar outra bicicleta!");
        Erros.Add("019a", "CPF já cadastrado!");
        Erros.Add("020a", "Email já cadastrado!");
        Erros.Add("021a", "Somente ciclista estrangeiro deve preencher o passaporte!");
        Erros.Add("022a", "Somente ciclista brasileiro deve preencher o CPF!");
        Erros.Add("023a", "Código país inválido!");

        //Erros relacionados a equipamento no formato 000e
        Erros.Add("001e", "Tranca deve está com status ocupada!");       
        Erros.Add("002e", "Tranca não existe!");
        Erros.Add("003e", "Bicicleta deve está disponível!");
        Erros.Add("004e", "Há um reparo requisitado, a bicicleta não pode ser alugada!");
        Erros.Add("005e", "Não existe biciclietas na tranca!");
        Erros.Add("006e", "Tranca não responde!");

        //Erros relacionados a externo no formato 000x
        Erros.Add("001x", "Erro no pagamento ou pagamento não autorizado!");
        Erros.Add("002x", "Cartão reprovado ou dados inválidos!");
        Erros.Add("003x", "Erro no envio do email!");
    }

    public string RetornaErro(string codigo)
    {
        return Erros
            .Where(e => e.Key == codigo)
            .FirstOrDefault()
            .Value;
    }
}
