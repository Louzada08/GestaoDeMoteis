namespace GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;

public interface IObserver
{
    void Update(ISubject subject);
}
