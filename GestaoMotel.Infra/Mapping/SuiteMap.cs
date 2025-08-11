using GestaoMotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMotel.Infra.Mapping;

public class SuiteMap : IEntityTypeConfiguration<Suite>
{
    public void Configure(EntityTypeBuilder<Suite> builder) 
    {
        builder.ToTable("Suite");
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.CategoryId)
            .IsUnique(false);

        builder.Property(u => u.Number)
            .IsRequired();

        builder.Property(u => u.DownloadedFrom)
            .IsRequired(false);

        //builder.HasOne(x => x.CreatedBy)
        //    .WithMany().OnDelete(DeleteBehavior.NoAction);

    }
}
