namespace Aluguel.Data.Dao
{
    public interface IDaoComInt<T> : IDao<T>
    {
        public T? RecuperarPorId(int id);
    }
}
