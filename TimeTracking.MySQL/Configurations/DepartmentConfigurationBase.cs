using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public abstract class DepartmentConfigurationBase : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.ID).HasName(PrimaryKeyName);
            builder.Property(x => x.ID).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(500);
            
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<Department> builder);

        protected abstract string PrimaryKeyName { get; }
    }
}
