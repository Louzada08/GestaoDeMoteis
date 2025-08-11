namespace GestaoMotel.Domain.ValueObjects;

public class Prices
{
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal PriceAdditional { get; set; }

    public Prices(decimal price, decimal discountPrice, decimal priceAdditional)
    {
        Price = price;
        DiscountPrice = discountPrice;
        PriceAdditional = priceAdditional;
    }
}
