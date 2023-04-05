using Aluguel.Commands.Contracts;
using Aluguel.Queries.Contracts;
using System.Runtime.InteropServices;

namespace Aluguel.Handlers.Contracts;

public interface IHandler<T> where T : ICommand {
    ICommandResult Handle(T command);
}
public interface IHandlerQuery<T> where T : IQuery
{
    ICommandResult Handle([Optional]T query);
}