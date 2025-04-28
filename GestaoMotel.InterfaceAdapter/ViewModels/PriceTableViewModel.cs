using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.ValueObjects;

namespace GestaoMotel.InterfaceAdapter.ViewModels
{
    public class PriceTableViewModel
    {
        public PriceTableViewModel()
        {
            PriceTableTimes = new List<PriceTableTimeViewModel>();
        }

        public TypePriceEnum TypePrice { get; set; }
        public TimeOnly ToleranceTime { get; set; }
        public WeekDay? WeekDay { get; set; }
        public TimeOnly PeriodStartTimes { get; set; }
        public TimeOnly PeriodEndTimes { get; set; }
        public PromotionPeriod? PromotionPeriod { get; set; }
        public Guid? CategoryId { get; set; }
        public List<PriceTableTimeViewModel> PriceTableTimes { get; set; }
    }
}
