using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations;

internal class DepartmentConfiguration : DepartmentConfigurationBase
{
    protected override void ConfigureDatabase(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department", "time_tracking");
        builder.Property(x => x.ID).HasColumnName("ID")
            .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(),b => new Guid(b));
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Description).HasColumnName("description");
    }

    protected override string PrimaryKeyName => "idx_pk_department";
}
