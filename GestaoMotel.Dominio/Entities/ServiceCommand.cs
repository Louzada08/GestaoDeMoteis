using GestaoMotel.Domain.Entities.Base;

namespace GestaoMotel.Domain.Entities;

public class ServiceCommand : BaseEntity, IAggregateRoot
{
    public Guid? SuiteId { get; set; }
    public DateTime? OpeningDateTime { get; set; }
    public DateTime? ClosingDateTime { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UserInspectionId { get; set; }
    public Guid? CleaningUserId { get; set; }
    public Suite Suite { get; set; }
    
    public ServiceCommand() { }
}
