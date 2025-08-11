using GestaoMotel.Domain.Entities.Base;
using GestaoMotel.Domain.Enums;

namespace GestaoMotel.Domain.Entities;

public class Suite : BaseEntity, IAggregateRoot
{
    public Suite() { }

    public int Number { get; set; }
    public Guid? CategoryId { get; private set; }
    public int? DownloadedFrom { get; set; }
    public StateSuiteEnum StateSuite { get; set; }
}
