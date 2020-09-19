using PromoHunter.Domain.Commands.Contracts;

namespace PromoHunter.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}