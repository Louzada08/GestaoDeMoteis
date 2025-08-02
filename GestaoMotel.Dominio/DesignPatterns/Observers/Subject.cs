using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;
using System.Diagnostics;

namespace GestaoMotel.Domain.DesignPatterns.Observers;

public class Subject : ISubject
{
    public decimal State { get; set; } = -0;
    public decimal PrecoNovo { get; set; } = -0;
    public Stopwatch TempoUso { get; set; } = new Stopwatch();

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        Console.WriteLine("Assunto: Anexado um observador.");
        TempoUso.Start();
        this._observers.Add(observer);
        System.Threading.Thread.Sleep(2000);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public void SomeBusinessLogic()
    {
        Console.WriteLine("\nAssunto: Estou fazendo algo importante.");
        //this.State = new Random().Next(0, 10);

        Thread.Sleep(1000);

        Console.WriteLine("Assunto: Meu estado acabou de mudar para " + this.State);
        this.Notify();
    }
}
