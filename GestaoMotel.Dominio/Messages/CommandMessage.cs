using FluentValidation.Results;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.Validation;
using MediatR;

namespace GestaoMotel.Infra.Repositories;

public abstract class CommandMessage : Message, IRequest<ValidationResultBag>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();

    protected CommandMessage() => Timestamp = DateTime.Now;

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}
