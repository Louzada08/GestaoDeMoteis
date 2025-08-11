using GestaoMotel.Application.Commands.Categorys.Validations;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Messages;

namespace GestaoMotel.Application.Commands.Categorys.Requests;

public class CreateCategoryRequest : Command
{
    public string Name { get; set; } = string.Empty;
    public string Acronym { get; set; } = string.Empty;

    public override bool IsValid()
    {
        ValidationResult = new CreateCategoryRequestValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
