using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels;

namespace TimeTracking.DAL.Configurations
{
    public abstract class EmployeeCalendarItemConfigurationBase : IEntityTypeConfiguration<EmployeeCalendarItem>
    {
        public void Configure(EntityTypeBuilder<EmployeeCalendarItem> builder)
        {
            builder.HasKey(x => x.Id).HasName(PrimaryKeyName);            
            builder.Property(x => x.Date).IsRequired(true);
            builder.HasOne(d => d.Mark).WithMany().HasForeignKey(m => m.DayMarkID)
                .HasConstraintName(DayMarkForeignKeyName).OnDelete(DeleteBehavior.Cascade);
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<EmployeeCalendarItem> builder);

        protected abstract string PrimaryKeyName { get; }
        protected abstract string DayMarkForeignKeyName { get; }
        protected abstract string EmployeeForeignKeyName { get; }
    }
}
