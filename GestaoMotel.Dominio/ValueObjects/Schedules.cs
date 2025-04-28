namespace GestaoMotel.Domain.ValueObjects;

public class Schedules
{
    public string MinimumUsageTime { get; set; } = string.Empty;
    public string MaximumUsageTime { get; set; } = string.Empty;
    public TimeOnly TimeForAdditionalCalculation { get; set; }

    public Schedules(string minimumUsageTime, string maximumUsageTime, TimeOnly timeForAdditionalCalculation)
    {
        MinimumUsageTime = minimumUsageTime;
        MaximumUsageTime = maximumUsageTime;
        TimeForAdditionalCalculation = timeForAdditionalCalculation;
    }
}
