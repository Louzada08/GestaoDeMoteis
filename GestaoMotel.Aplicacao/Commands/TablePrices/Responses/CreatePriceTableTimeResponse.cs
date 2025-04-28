using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Application.Commands.TablePrices.Validations;

public class CreatePriceTableTimeResponse
{
    public ushort? RuleOrder { get; set; }
    public Guid? PriceTableId { get; set; }
    public Schedules Schedule { get; set; } 
    public Prices Prices { get; set; }
}
