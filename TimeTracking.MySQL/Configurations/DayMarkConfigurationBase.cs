using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels;

namespace TimeTracking.DAL.Configurations;

public abstract class DayMarkConfigurationBase : IEntityTypeConfiguration<DayMark>
{
    public void Configure(EntityTypeBuilder<DayMark> builder)
    {
        builder.HasKey(x => x.ID).HasName(PrimaryKeyName);            
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.Short).IsRequired(true).HasMaxLength(10);
        ConfigureDatabase(builder);
    }
    protected abstract void ConfigureDatabase(EntityTypeBuilder<DayMark> builder);

    protected abstract string PrimaryKeyName { get; }
}
