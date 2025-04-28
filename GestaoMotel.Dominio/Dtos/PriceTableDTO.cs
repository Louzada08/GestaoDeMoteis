using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.Domain.Dtos;

public class PriceTableDTO
{
    public PriceTableDTO() { this.PriceTableTimesDTO = new List<PriceTableTimeDTO>(); }

    public TypePriceEnum TypePrice { get; set; }
    public TimeOnly ToleranceTime { get; set; }
    public WeekDay? WeekDay { get; set; }
    public TimeOnly PeriodStartTimes { get; set; } 
    public TimeOnly PeriodEndTimes { get; set; }
    public PromotionPeriod? PromotionPeriod { get; set; }
    public Guid? CategoryId { get; set; }

    public ICollection<PriceTableTimeDTO> PriceTableTimesDTO { get; set; }
}
