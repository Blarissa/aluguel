using Aluguel.Commands.Contracts;

namespace Aluguel.Handlers.Contracts;

public interface IHandler<T> where T : ICommand {
    ICommandResult Handle(T command);
}