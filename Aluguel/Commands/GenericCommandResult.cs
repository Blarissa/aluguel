using Aluguel.Commands.Contracts;

namespace Aluguel.Commands;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult() { }

    public GenericCommandResult(object data)
    {
        Data = data;
    }

    public object Data { get; set; }
}