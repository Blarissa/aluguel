using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class AtualizarCiclistaCommand : BaseValidacao, ICommand
{
    public Guid Id { get; set; }
    public UpdateCiclitasDto UpdateCiclitasDto { get; set; }

    public AtualizarCiclistaCommand(Guid id, UpdateCiclitasDto updateCiclitasDto)
    {
        Id = id;
        UpdateCiclitasDto = updateCiclitasDto;
    }
 
    public bool Validar()
    {
        return Valida;
    }
}