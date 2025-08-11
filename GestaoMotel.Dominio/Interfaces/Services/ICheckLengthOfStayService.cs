namespace GestaoMotel.Domain.Interfaces.Services;

public interface ICheckLengthOfStayService
{
    public Task<bool> CalculatePriceAndLengthOfStay();
}
