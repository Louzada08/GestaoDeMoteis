using GestaoMotel.Domain.Entities.Base;

namespace GestaoMotel.Domain.Entities;

public class Category : BaseEntity
{
    public Category() { }

    public string Name { get; set; }
    public string Acronym { get; set; }
}