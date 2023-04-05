using Aluguel.Commands.Contracts;
using System.Net;

namespace Aluguel.Commands;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult() {
        Status = HttpStatusCode.InternalServerError;
    }

    public GenericCommandResult(object data)
    {
        Data = data;
        Status = HttpStatusCode.InternalServerError;
    }

    public object Data { get; set; }
    public HttpStatusCode Status { get; set; }
}