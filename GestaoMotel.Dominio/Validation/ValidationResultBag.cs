using FluentValidation.Results;

namespace GestaoMotel.Domain.Validation;

public class ValidationResultBag : ValidationResult
{
    public object? Data { get; set; }
}
