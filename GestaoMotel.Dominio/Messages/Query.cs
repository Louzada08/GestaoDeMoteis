using FluentValidation.Results;
using GestaoMotel.Domain.Validation;
using MediatR;

namespace GestaoMotel.Core.Messages
{
    public abstract class Query : IRequest<ValidationResultBag>
    {
        public ValidationResult ValidationResult { get; } = new ValidationResultBag();

        public abstract bool IsValid();
    }
}
