using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.Validation;

namespace GestaoMotel.Domain.Mediator.Interfaces;

public interface IMediatorHandler
{
    public Task PublishEvent<T>(T evnt) where T : Event;
    public Task<ValidationResultBag> SendCommand<T>(T command) where T : Command;
}
