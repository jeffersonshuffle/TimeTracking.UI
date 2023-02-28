using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations;
internal class PositionAssignmentConfiguration : PositionAssignmentConfigurationBase
{
    protected override void ConfigureDatabase(EntityTypeBuilder<PositionAssignment> builder)
    {
        builder.ToTable("position_assignment", "time_tracking");
        builder.Property(x => x.ID).HasColumnName("ID")
            .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
        builder.Property(x => x.DateCreated).HasColumnName("date_created")
            .HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
        builder.Property(x => x.DateModified).HasColumnName("date_modified")
            .HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
        builder.Property(x => x.DepartmentID).HasColumnName("department_ID")
            .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
        builder.Property(x => x.EmployeeID).HasColumnName("employee_ID")
            .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
        builder.Property(x => x.PositionID).HasColumnName("position_ID");
        builder.Property(x => x.EmploymentType).HasColumnName("employment_type").HasColumnType("tinyint(1)");
    }

    protected override string PrimaryKeyName => "idx_pk_position_assignment";
    protected override string DepartmenrForeignKeyName => "fk_department_position_assignment";
    protected override string PositionForeignKeyName => "fk_position_position_assignment";
    protected override string EmployeeForeignKeyName => "fk_employee_position_assignment";

}
