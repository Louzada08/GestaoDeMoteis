using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using Backoffice.Core.Validation;

namespace Backoffice.Core.Messages
{
    public abstract class Query : IRequest<ValidationResultBag>
    {
        public ValidationResult ValidationResult { get; } = new ValidationResultBag();

        public abstract bool IsValid();
    }
}
