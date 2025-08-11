using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace GestaoMotel.Domain.Filters
{
    public class PriceTableFilter : ICustomQueryable
    {
        [QueryOperator(Operator = WhereOperator.LessThanOrEqualWhenNullable, HasName = "CategoryId")]
        public Guid? CategoryId { get; set; }
        public int? Number { get; set; }
        public int Limit { get; set; } = 30;
        public int Page { get; set; } = 1;
        public int? Section { get; set; }
    }
}
