using System.Net;

namespace Aluguel.Commands.Contracts;

public interface ICommandResult
{
    object Data { get; set; }
    HttpStatusCode Status { get; set; }
}