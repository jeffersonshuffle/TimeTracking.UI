using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public abstract class PositionAssignmentConfigurationBase : IEntityTypeConfiguration<PositionAssignment>
    {
        public void Configure(EntityTypeBuilder<PositionAssignment> builder)
        {
            builder.HasKey(x => x.ID).HasName(PrimaryKeyName);
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.DateCreated).IsRequired(true).ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.DateModified).IsRequired(true).ValueGeneratedOnAddOrUpdate();
            builder.HasOne(x => x.Position).WithMany().HasForeignKey(p => p.PositionID)
                .HasConstraintName(PositionForeignKeyName).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Employee).WithOne(e => e.Assignment).HasForeignKey<PositionAssignment>(p => p.EmployeeID)
                .HasConstraintName(EmployeeForeignKeyName).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Department).WithMany(d => d.EmployeeAsingments).HasForeignKey(a => a.DepartmentID)
                .HasConstraintName(DepartmenrForeignKeyName).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.DepartmentID).IsRequired(true);
            builder.Property(x => x.EmployeeID).IsRequired(true);
            builder.Property(x => x.PositionID).IsRequired(true);
            builder.Property(x => x.EmploymentType).IsRequired(true);
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<PositionAssignment> builder);

        protected abstract string DepartmenrForeignKeyName { get; }
        protected abstract string PositionForeignKeyName { get; }
        protected abstract string EmployeeForeignKeyName { get; }
        protected abstract string PrimaryKeyName { get; }
    }
}
