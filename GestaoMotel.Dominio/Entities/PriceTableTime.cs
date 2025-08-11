using GestaoMotel.Domain.Entities.Base;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Domain.Entities;

public class PriceTableTime : BaseEntity
{
    public PriceTableTime() { }

    public ushort? RuleOrder { get; set; }
    public Guid? PriceTableId { get; set; }
    public PriceTable? PriceTable { get; set; }
    public Schedules Schedule { get; set; }
    public Prices Price { get; set; }

    public PriceTableTime(Prices prices,Schedules schedules)
    {
        Price =  prices;
        Schedule = schedules;
    }
}
