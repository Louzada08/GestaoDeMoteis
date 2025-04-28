using System.ComponentModel;

namespace GestaoMotel.Domain.Enums;
public enum TypePriceEnum
{
    [Description("Permanencia")]
    PricePermanence = 0,
    [Description("Diaria")]
    PriceDaily = 1,
    [Description("Pernoite")]
    PriceOvernight = 2
}

