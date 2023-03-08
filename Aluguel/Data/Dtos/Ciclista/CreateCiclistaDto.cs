﻿namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreateCiclistaDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public PassaporteDto? Passaporte { get; set; }
        public int Nacionalidade { get; set; }
        public string Email { get; set; }
        public Uri UrlFotoDocumento { get; set; }
        public string Senha { get; set; }
    }
}
