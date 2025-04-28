using System.ComponentModel;

namespace GestaoMotel.Domain.Enums;

public enum StateSuiteEnum
{
    [Description("Livre")]
    Free = 0,
    [Description("Ocupada")]
    Busy = 1,
    [Description("Vistoria")]
    Survey = 2,
    [Description("Limpando")]
    Cleaning = 3,
    [Description("Em Manutenção")]
    UnderMaintenance = 4
}
