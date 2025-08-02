using GestaoMotel.Domain.Filters;

namespace GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;

public interface IPricePermanceObserver
{
    public decimal Update(decimal price);
}
