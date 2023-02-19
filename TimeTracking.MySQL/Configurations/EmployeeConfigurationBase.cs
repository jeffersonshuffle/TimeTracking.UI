using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public abstract class EmployeeConfigurationBase : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.ID).HasName(PrimaryKeyName);
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.PersonnelNumber).IsRequired(true);
            builder.HasIndex(x => x.PersonnelNumber).IsUnique();
            builder.Property(x => x.BirthDate).IsRequired(true);
            builder.Property(x => x.Photo).IsRequired(false).HasMaxLength(PhotoMaxLength);
            builder.Property(x => x.AddressId).IsRequired(true);
            builder.HasOne(x => x.Address).WithMany().HasForeignKey(e => e.AddressId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Calendar).WithOne().HasForeignKey(c => c.EmployeeID).OnDelete(DeleteBehavior.Cascade);
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<Employee> builder);

        protected abstract int PhotoMaxLength { get; }
        protected abstract string PrimaryKeyName { get; }
    }
}
