using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.InterfaceAdapter.ViewModels;

public class PriceTableTimeViewModel
{
    public ushort? RuleOrder { get; set; }
    public Guid? PriceTableId { get; set; }
    public Schedules Schedule { get; set; }
    public Prices Price { get; set; }
}
