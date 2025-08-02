using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;

namespace GestaoMotel.Domain.DesignPatterns.Observers;

public class ComandaObserver : IPricePermanceObserver
{
    private decimal valorNovo { get; set; } = 0;

    public decimal SetPricePermanence(decimal valorComanda, decimal valorTable)
    {
        if (valorComanda != valorTable)
        {
            valorComanda = valorTable;
        }

        return valorComanda;
    }

    public decimal Update(decimal price)
    {
        valorNovo = price;
        return valorNovo;
    }
}