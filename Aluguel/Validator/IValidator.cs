﻿using Aluguel.Models;

namespace Aluguel.Validator
{
    public interface IValidator
    {
        bool Nome(string valor);
        bool Email(string valor);
        bool Senha(string valor1, string valor2);
        bool Documento(string valor);
    }
}
