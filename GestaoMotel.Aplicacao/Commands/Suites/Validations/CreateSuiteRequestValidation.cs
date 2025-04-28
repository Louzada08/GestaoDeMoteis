using FluentValidation;
using GestaoMotel.Application.Commands.Suites.Requests;

namespace GestaoMotel.Application.Commands.Suites.Validations;

class CreateSuiteRequestValidation : AbstractValidator<CreateSuiteRequest>
{
    public CreateSuiteRequestValidation()
    {
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O numero é obrigatório");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Selecione uma Categoria");
        RuleFor(x => x.StateSuite)
        .IsInEnum().WithMessage("Tipo de estado da suíte inválido");
    }
}