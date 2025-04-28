using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Application.Commands.Categorys.Responses;

public class CreatePriceTableResponse
{
    public TypePriceEnum TypePrice { get; set; }
    public TimeOnly ToleranceTime { get; set; }
    public WeekDay? WeekDay { get; set; }
    public TimeOnly PeriodStartTimes { get; set; } = TimeOnly.MinValue;
    public TimeOnly PeriodEndTimes { get; set; } = TimeOnly.MaxValue;
    public PromotionPeriod? promotionPeriod { get; set; }
    public Guid? CategoryId { get; private set; }
    public ICollection<PriceTableTime> PriceTableTimes { get; private set; }
}
