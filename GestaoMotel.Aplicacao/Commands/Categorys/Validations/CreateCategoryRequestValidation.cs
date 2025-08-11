using FluentValidation;
using GestaoMotel.Application.Commands.Categorys.Requests;

namespace GestaoMotel.Application.Commands.Categorys.Validations;

class CreateCategoryRequestValidation : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório");
        RuleFor(x => x.Acronym)
        .NotEmpty().WithMessage("Abreviação é obrigatório");
    }
}