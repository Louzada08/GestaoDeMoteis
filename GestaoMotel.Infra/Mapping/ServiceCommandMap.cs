using GestaoMotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMotel.Infra.Mapping;

public class ServiceCommandMap : IEntityTypeConfiguration<ServiceCommand>
{
    public void Configure(EntityTypeBuilder<ServiceCommand> builder)
    {
        builder.ToTable("ServiceCommand");
        builder.HasKey(x => x.Id);

        builder.HasIndex(f => f.UserId)
            .IsUnique();
        builder.HasIndex(f => f.UserInspectionId)
            .IsUnique();
        builder.HasIndex(f => f.CleaningUserId)
            .IsUnique();
        builder.HasIndex(f => f.SuiteId)
            .IsUnique();
    }
}