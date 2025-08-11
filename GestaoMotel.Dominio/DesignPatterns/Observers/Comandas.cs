using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;
using System;

namespace GestaoMotel.Domain.DesignPatterns.Observers;

public class Comandas
{
    private Guid commandId { get; set; } = Guid.Empty;
    private Guid? suiteId { get; set; } = Guid.Empty;
    private decimal novoValorHora { get; set; } = 0;

    private List<IPricePermanceObserver> _observersCommand;

    private List<Comandas> observers = new List<Comandas>();

    public Comandas()
    {
        this.commandId = Guid.Empty;
        this.suiteId = Guid.Empty;
        this.novoValorHora = 0;
        this._observersCommand = new List<IPricePermanceObserver>() ?? new List<IPricePermanceObserver>();
    }

    public Comandas(Guid commandId, Guid? suiteId, decimal novoValorHora, List<IPricePermanceObserver>? observers = null)
    {
        this.commandId = Guid.Empty;
        this.suiteId = Guid.Empty;
        this.novoValorHora = 0;
        this._observersCommand = new List<IPricePermanceObserver>() ?? new List<IPricePermanceObserver>();
    }

    public decimal SetPricePermanence(decimal valorComanda, decimal valorTable)
    {
        if (valorComanda != valorTable)
        {
            novoValorHora = valorTable;
        }

        return novoValorHora;
    }

    public void AddCommandObservers(IPricePermanceObserver pricePermanceObserver)
    {
        _observersCommand.Add(pricePermanceObserver);
    }

    public void NotifyObservers()
    {
        foreach(IPricePermanceObserver item in _observersCommand)
        {
            item.Update(novoValorHora);
        }
    }
}