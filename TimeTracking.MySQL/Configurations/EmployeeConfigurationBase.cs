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
            builder.Property(x => x.JobTitle).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.BirthDate).IsRequired(true);
            builder.OwnsOne<Address>(x => x.Address);

            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<Employee> builder);

        protected abstract string PrimaryKeyName { get; }
    }
}
