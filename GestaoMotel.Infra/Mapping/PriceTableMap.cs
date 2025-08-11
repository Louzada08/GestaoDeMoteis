using GestaoMotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMotel.Infra.Mapping
{
    public class PriceTableMap : IEntityTypeConfiguration<PriceTable>
    {
        public void Configure(EntityTypeBuilder<PriceTable> builder)
        {
            builder.ToTable("PriceTable");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.CategoryId)
                .IsUnique(false);

            builder.HasMany(p => p.PriceTableTimes)
                .WithOne(p => p.PriceTable)
                .HasForeignKey(f => f.PriceTableId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.TypePrice)
                .IsRequired()
                .HasColumnName("TypePrice");

            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasMonday)
                .HasDefaultValue(false)
                .HasColumnName("HasMonday");
            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasSunday)
                .HasDefaultValue(false)
                .HasColumnName("HasSunday");
            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasTuesday)
                .HasDefaultValue(false)
                .HasColumnName("HasTuesday");
            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasThursday)
                .HasDefaultValue(false)
                .HasColumnName("HasThursday");
            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasWednesday)
                .HasDefaultValue(false)
                .HasColumnName("HasWednesday");
            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasFriday)
                .HasDefaultValue(false)
                .HasColumnName("HasFriday");
            builder.OwnsOne(x => x.WeekDay)
                .Property(x => x.HasSaturday)
                .HasDefaultValue(false)
                .HasColumnName("HasSaturday");

            builder.OwnsOne(x => x.PromotionPeriod)
                .Property(x => x.Active)
                .HasDefaultValue(false)
                .HasColumnName("Active");
            builder.OwnsOne(x => x.PromotionPeriod)
                .Property(x => x.InitialPromotionPeriod)
                .HasColumnName("InitialPromotionPeriod");
            builder.OwnsOne(x => x.PromotionPeriod)
                .Property(x => x.FinalPromotionPeriod)
                .HasColumnName("FinalPromotionPeriod");
        }
    }
}
