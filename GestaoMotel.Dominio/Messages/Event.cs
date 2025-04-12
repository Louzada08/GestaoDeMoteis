using MediatR;

namespace GestaoMotel.Domain.Messages;

public class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    public Event()
    {
        Timestamp = DateTime.Now;
    }
}
