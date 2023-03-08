namespace Aluguel.Validator
{
    public interface IValidator
    {
        public bool Nome(string valor);
        public bool Email(string valor);
        public bool Senha(string valor1, string valor2);
        public bool Documento(string valor);        
    }
}
