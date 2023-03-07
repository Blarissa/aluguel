﻿namespace Aluguel.Models
{
    public class Ciclista
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Uri UrlFotoDocumento { get; set; }
        public int Status { get; set; }
        public int Nacionalidade { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraConfirmacao { get; set; }
        
        public string? Cpf { get; set; }
        public Guid? PassaporteId { get; set; }

        public virtual Passaporte Passaporte { get; set; }
        public virtual IList<CartaoDeCredito> Cartoes { get; set; }
        public virtual IList<Emprestimo> Emprestimos { get; set; }


        public Ciclista()
        {
            Emprestimos = new List<Emprestimo>();
            Cartoes = new List<CartaoDeCredito>();
        }
    }
}
