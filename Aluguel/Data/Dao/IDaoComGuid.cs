namespace Aluguel.Data.Dao
{
    public interface IDaoComGuid<T> : IDao<T>
    {
        public T? RecuperarPorGuid(Guid idGuid);
    }
}
