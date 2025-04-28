using GestaoMotel.Application.Commands.Categorys.Validations;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Application.Commands.TablePrices.Requests;

public class CreatePriceTableRequest : Command
{
    public TypePriceEnum TypePrice { get; set; }
    public TimeOnly ToleranceTime { get; set; }
    public WeekDay? WeekDay { get; set; }
    public TimeOnly PeriodStartTimes { get; set; } = TimeOnly.MinValue;
    public TimeOnly PeriodEndTimes { get; set; } = TimeOnly.MaxValue;
    public PromotionPeriod? promotionPeriod { get; set; }
    public Guid? CategoryId { get; set; }

    public void AssignCategoryId(Guid? id) => CategoryId = id;

    public override bool IsValid()
    {
        ValidationResult = new CreatePriceTableRequestValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
