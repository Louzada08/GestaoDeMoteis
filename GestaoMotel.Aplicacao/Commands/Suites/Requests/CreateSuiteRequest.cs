using GestaoMotel.Application.Commands.Suites.Validations;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.Messages;

namespace GestaoMotel.Application.Commands.Suites.Requests;

public class CreateSuiteRequest : Command
{
    public int Number { get; set; }
    public Guid? CategoryId { get; set; }
    public StateSuiteEnum StateSuite { get; set; }

    public override bool IsValid()
    {
        ValidationResult = new CreateSuiteRequestValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
