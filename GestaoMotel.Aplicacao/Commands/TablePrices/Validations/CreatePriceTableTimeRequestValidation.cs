using FluentValidation;
using GestaoMotel.Application.Commands.TablePrices.Requests;
using static GestaoMotel.Domain.Entities.PriceTableTime;

namespace GestaoMotel.Application.Commands.TablePrices.Validations
{
    public class CreatePriceTableTimeRequestValidation : AbstractValidator<CreatePriceTableTimeRequest>
    {
        public CreatePriceTableTimeRequestValidation()
        {
            RuleFor(x => x.RuleOrder)
                .Must(ValidationRuleOrder).WithMessage("Ordem da regra de uso deve ser maior que zero");
            RuleFor(x => x.PriceTableId)
                .NotEmpty().WithMessage("Id da tabela de preços é obrigatório");
            RuleFor(x => x.Price.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Preço por hora é obrigatório");
            RuleFor(x => x.Price.DiscountPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Preço com desconto por hora é obrigatório");
            RuleFor(x => x.Price.PriceAdditional)
                .GreaterThanOrEqualTo(0).WithMessage("Preço com acrescimo por hora é obrigatório");
            RuleFor(x => x.Schedule.MinimumUsageTime)
                .NotEmpty().WithMessage("Tempo minimo de uso é obrigatório");
            RuleFor(x => x.Schedule.MaximumUsageTime)
                .NotEmpty().WithMessage("Tempo maximo de uso é obrigatório");
            RuleFor(x => x.Schedule.TimeForAdditionalCalculation)
                .NotEmpty().WithMessage("Tempo adicional para calculo do valor adicional é obrigatório");
        }
        private bool ValidationRuleOrder(ushort? value)
        {
            return value > 0;
        }
    }
}
