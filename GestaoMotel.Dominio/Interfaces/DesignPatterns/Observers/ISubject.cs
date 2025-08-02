using System.Diagnostics;

namespace GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;

public interface ISubject
{
    public decimal State { get; set; }
    public decimal PrecoNovo { get; set; }
    public Stopwatch TempoUso { get; set; }
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
    void SomeBusinessLogic();
}
