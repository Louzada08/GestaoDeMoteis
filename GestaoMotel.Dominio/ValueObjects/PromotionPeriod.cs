namespace GestaoMotel.Domain.ValueObjects;

public class PromotionPeriod
{
    public bool Active { get; set; } = false;
    public DateTime? InitialPromotionPeriod { get; set; }
    public DateTime? FinalPromotionPeriod { get; set; }
}
