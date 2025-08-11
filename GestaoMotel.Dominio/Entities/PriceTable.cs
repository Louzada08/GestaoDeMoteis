using GestaoMotel.Domain.Entities.Base;
using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Domain.Entities;

public class PriceTable : BaseEntity, IAggregateRoot
{
    public PriceTable() 
    {
        this.PriceTableTimes = new List<PriceTableTime>();
        this.WeekDay = WeekDay;
        this.PromotionPeriod = PromotionPeriod;
    }

    public TypePriceEnum TypePrice { get; set; }
    public TimeOnly ToleranceTime { get; set; }
    public WeekDay? WeekDay { get; set; }
    public TimeOnly PeriodStartTimes { get; set; } = TimeOnly.MinValue;
    public TimeOnly PeriodEndTimes { get; set; } = TimeOnly.MaxValue;
    public PromotionPeriod? PromotionPeriod { get; set; }
    public Guid? CategoryId { get; private set; }  
    public ICollection<PriceTableTime> PriceTableTimes { get; set; }

    public void AssignCategoryId(Guid? id) => CategoryId = id; 
}
