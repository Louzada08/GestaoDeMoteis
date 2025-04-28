using GestaoMotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMotel.Infra.Mapping
{
    public class PriceTableTimeMap : IEntityTypeConfiguration<PriceTableTime>
    {
        public void Configure(EntityTypeBuilder<PriceTableTime> builder)
        {
            builder.ToTable("PriceTableTime");
            builder.HasKey(x => x.Id);

//            builder.HasIndex(x => x.RuleOrder)
//                .IsUnique();

            builder.OwnsOne(x => x.Price)
                .Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(6,2)");
            builder.OwnsOne(x => x.Price)
                .Property(x => x.DiscountPrice)
                .HasColumnName("DiscountPrice")
                .HasColumnType("decimal(6,2)");
            builder.OwnsOne(x => x.Price)
                .Property(x => x.PriceAdditional)
                .HasColumnName("PriceAdditional")
                .HasColumnType("decimal(6,2)");

            builder.OwnsOne(x => x.Schedule)
                .Property(x => x.MaximumUsageTime)
                .HasColumnType("varchar(11)")
                .HasColumnName("MaximumUsageTime")
                .IsRequired(true);
            builder.OwnsOne(x => x.Schedule)
                .Property(x => x.MinimumUsageTime)
                .HasColumnType("varchar(11)")
                .HasColumnName("MinimumUsageTime")
                .IsRequired(true);
        }
    }
}
