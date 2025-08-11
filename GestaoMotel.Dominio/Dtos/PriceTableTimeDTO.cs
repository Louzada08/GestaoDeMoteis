using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Domain.Dtos;

public class PriceTableTimeDTO
{
    public ushort? RuleOrder { get; set; }
    public Guid? PriceTableId { get; set; }
    public Schedules Schedule { get; set; }
    public Prices Price { get; set; }
}
