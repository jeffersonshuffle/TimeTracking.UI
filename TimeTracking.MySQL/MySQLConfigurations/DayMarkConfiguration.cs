using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels;

namespace TimeTracking.DAL.Configurations;

internal class DayMarkConfiguration : DayMarkConfigurationBase
{
    protected override void ConfigureDatabase(EntityTypeBuilder<DayMark> builder)
    {
        builder.ToTable("day_mark", "time_tracking");
        builder.Property(x => x.ID).HasColumnName("id");
        builder.Property(x => x.Short).HasColumnName("short");
        builder.Property(x => x.Name).HasColumnName("name");
    }

    protected override string PrimaryKeyName => "idx_pk_day_mark";
}
