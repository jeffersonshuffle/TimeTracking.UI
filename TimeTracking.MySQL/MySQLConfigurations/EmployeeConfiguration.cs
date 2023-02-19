using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations;
internal class EmployeeConfiguration : EmployeeConfigurationBase
{
    protected override void ConfigureDatabase(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee", "time_tracking");
        builder.Property(x => x.ID).HasColumnName("ID")
            .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
        builder.Property(x => x.FirstName).HasColumnName("first_name");
        builder.Property(x => x.LastName).HasColumnName("last_name");
        builder.Property(x => x.BirthDate).HasColumnName("birth_date").HasColumnType("DATETIME");
        builder.Property(x => x.Photo).HasColumnName("photo").HasColumnType("BLOB");
        builder.Property(x => x.PersonnelNumber).HasColumnName("personnel_number");
    }

    protected override int PhotoMaxLength => 1_000_000_000;
    protected override string PrimaryKeyName => "idx_pk_employee";
}
