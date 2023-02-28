using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels;

namespace TimeTracking.DAL.Configurations;
internal class EmployeeCalendarItemConfiguration : EmployeeCalendarItemConfigurationBase
{
    protected override void ConfigureDatabase(EntityTypeBuilder<EmployeeCalendarItem> builder)
    {
        builder.ToTable("employee_calendar_item", "time_tracking");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.EmployeeID).HasColumnName("employee_id")
            .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
        builder.Property(x => x.DayMarkID).HasColumnName("day_mark_id");
        builder.Property(x => x.Date).HasColumnName("date")
            .HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
    }

    protected override string PrimaryKeyName => "idx_pk_employee_calendar_item";
    protected override string DayMarkForeignKeyName => "fk_item_day_mark";
    protected override string EmployeeForeignKeyName => "fk_item_employee";

}
