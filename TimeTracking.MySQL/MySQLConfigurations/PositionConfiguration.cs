using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations;
internal class PositionConfiguration : PositionConfigurationBase
{
    protected override void ConfigureDatabase(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("position", "time_tracking");

        builder.Property(x => x.PositionId).HasColumnName("position_id");
        builder.Property(x => x.Title).HasColumnName("title");
        builder.Property(x => x.Description).HasColumnName("description");
    }

    protected override string PrimaryKeyName { get; } = "idx_pk_position";
}
