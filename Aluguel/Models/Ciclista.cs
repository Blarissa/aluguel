using Newtonsoft.Json;

namespace Aluguel.Models;

public class Ciclista
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public Uri UrlFotoDocumento { get; set; }
    public EStatusCiclista Status { get; set; }
    public ENacionalidade Nacionalidade { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public DateTime DataHoraConfirmacao { get; set; }
    
    public string? Cpf { get; set; }
    public Guid? PassaporteId { get; set; }

    public virtual Passaporte Passaporte { get; set; }
    [JsonIgnore]
    public virtual IList<CartaoDeCredito> Cartoes { get; set; }
    [JsonIgnore]
    public virtual IList<Emprestimo> Emprestimos { get; set; }


    public Ciclista()
    {
        Emprestimos = new List<Emprestimo>();
        Cartoes = new List<CartaoDeCredito>();
    }

    public void Ativar()
    {
        Status = EStatusCiclista.ATIVO;
    }

    public void AtualizarDados(Ciclista ciclista)
    {
        Nome = ciclista.Nome;
        Status = ciclista.Status;
        DataNascimento = ciclista.DataNascimento;
        Cpf = ciclista.Cpf;
        Passaporte.AtualizarDados(ciclista.Passaporte);
        Nacionalidade = ciclista.Nacionalidade;
        Email = ciclista.Email;
        UrlFotoDocumento = ciclista.UrlFotoDocumento;
    }

    public bool PodeFazerEmprestimo()
    {
        var ultimoEmprestimo = Emprestimos.LastOrDefault();

        return ultimoEmprestimo?.Devolucao == null;
    }

    public Guid? BuscarBicicletaDoEmprestimoAtivo()
    {
        var emprestimo = Emprestimos.Last();

        var bicicletaId = emprestimo.EmprestimoAtivo() ? emprestimo?.BicicletaId : null;

        return bicicletaId;
    }
}