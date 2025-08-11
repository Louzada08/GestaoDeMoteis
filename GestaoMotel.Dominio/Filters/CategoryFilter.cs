using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace GestaoMotel.Domain.Filters;

public class CategoryFilter : ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.StartsWith, HasName = "Name", CaseSensitive = false)]
    public string? Name { get; set; }

    [QueryOperator(Operator = WhereOperator.Contains, HasName = "Acronym", CaseSensitive = false)]
    public string? Acronym { get; set; }

    public int? Number { get; set; }
    public int Limit { get; set; } = 30;
    public int Page { get; set; } = 1;
    public int? Section { get; set; }

}
