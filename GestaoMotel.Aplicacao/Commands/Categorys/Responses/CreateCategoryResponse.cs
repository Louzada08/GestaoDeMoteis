using GestaoMotel.Domain.Entities;

namespace GestaoMotel.Application.Commands.Categorys.Responses;

public class CreateCategoryResponse
{
    public string Name { get; set; } = string.Empty;
    public string Acronym { get; set; } = string.Empty;
    public Guid? PriceTableId { get; set; }
    public PriceTable? PricesTable { get; set; }
}
