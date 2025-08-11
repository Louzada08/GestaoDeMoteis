using GestaoMotel.Domain.Interfaces.Base;

namespace GestaoMotel.Domain.Entities.Base;

public class BaseEntity : IBaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public BaseEntity(DateTime createdAt) : this()
    {
        CreatedAt = createdAt;
    }

    public BaseEntity(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}
