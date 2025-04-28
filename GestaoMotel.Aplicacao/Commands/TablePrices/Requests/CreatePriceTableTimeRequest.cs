using GestaoMotel.Application.Commands.TablePrices.Validations;
using GestaoMotel.Domain.Messages;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Application.Commands.TablePrices.Requests;

public class CreatePriceTableTimeRequest : Command
{
    public ushort? RuleOrder { get; set; }
    public Guid? PriceTableId { get; set; }
    public Schedules Schedule { get; set; }
    public Prices Price { get; set; }

    public CreatePriceTableTimeRequest()
    {
        this.Schedule = Schedule;
        this.Price = Price;
    }

    public override bool IsValid()
    {
        ValidationResult = new CreatePriceTableTimeRequestValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
