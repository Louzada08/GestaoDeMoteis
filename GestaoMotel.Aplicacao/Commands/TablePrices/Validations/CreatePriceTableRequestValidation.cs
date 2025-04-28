using FluentValidation;
using GestaoMotel.Application.Commands.TablePrices.Requests;

namespace GestaoMotel.Application.Commands.Categorys.Validations;

class CreatePriceTableRequestValidation : AbstractValidator<CreatePriceTableRequest>
{
    public CreatePriceTableRequestValidation()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Id da categoria é obrigatório");
        RuleFor(x => x.TypePrice)
            .IsInEnum().WithMessage("Informe: 0=permanencia, 1=pernoite, 2=diária");
        RuleFor(x => x.ToleranceTime)
        .GreaterThanOrEqualTo(TimeOnly.MinValue)
        .LessThanOrEqualTo(TimeOnly.MaxValue).WithMessage("Tempo de tolerancia invalido");

        RuleFor(x => x.PeriodStartTimes)
            .Must(BeAValidDate)
            .WithMessage("A data fornecida é inválida.");
    }
    private bool BeAValidDate(TimeOnly date)
    {
        return date != default(TimeOnly);
    }

}