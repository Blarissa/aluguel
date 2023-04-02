using Aluguel.Data.Dtos.Ciclista;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Aluguel.Data.Dao
{
    public interface IDao<T>
    {       
        public void Adicionar(T t);
        public void Deletar(T t);                
        public IList<T> RecuperarTodos();
    }
}
