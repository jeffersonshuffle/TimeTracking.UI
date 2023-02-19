using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations;

public abstract class PositionConfigurationBase : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(x => x.PositionId).HasName(PrimaryKeyName);            
        builder.Property(x => x.Title).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
        ConfigureDatabase(builder);
    }
    protected abstract void ConfigureDatabase(EntityTypeBuilder<Position> builder);

    protected abstract string PrimaryKeyName { get; }
}
