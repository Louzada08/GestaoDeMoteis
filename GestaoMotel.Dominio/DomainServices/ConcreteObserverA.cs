using GestaoMotel.Domain.DesignPatterns.Observers;
using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;

namespace GestaoMotel.Domain.DomainServices;

public class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).TempoUso.Elapsed.Seconds > 10 && subject.State != subject.PrecoNovo)
        {
            subject.State = subject.PrecoNovo;
            Console.WriteLine($"Observador A: Reagiu a valor:{subject.State} e tempo:{subject.TempoUso.Elapsed.Seconds}.");
        }
    }
}
