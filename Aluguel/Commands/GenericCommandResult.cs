using Aluguel.Commands.Contracts;
using Aluguel.Models.Entidades;
using System.Net;

namespace Aluguel.Commands;

public class GenericCommandResult : ICommandResult
{
    public object Data { get; set; }
    public HttpStatusCode Status { get; set; }

    public GenericCommandResult()
    {
        
    }

    public GenericCommandResult(object data)
    {
        Data = data;
    }    
}