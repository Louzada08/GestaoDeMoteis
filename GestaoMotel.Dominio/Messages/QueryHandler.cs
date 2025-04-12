using FluentValidation.Results;
using Backoffice.Core.Validation;

namespace Backoffice.Core.Messages
{
    public abstract class QueryHandler
    {
        protected ValidationResultBag ValidationResult;

        protected QueryHandler()
        {
            ValidationResult = new ValidationResultBag();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    }
}
