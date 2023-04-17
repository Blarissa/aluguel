namespace Aluguel.Validacao.Interfaces
{
    public interface IValidaRegraEquipamento
    {
        Task<bool> BicicletaDisponivel(Guid idTranca);
        Task<bool> BicicletaEmReparo(Guid idTranca);
        Task<bool> ExisteBicicletaNaTranca(Guid idTranca);
        Task<bool> ExisteTranca(Guid idTranca);
        Task<bool> StatusTranca(Guid idTranca);
        Task<bool> TrancaResponde(Guid idTranca);
    }
}