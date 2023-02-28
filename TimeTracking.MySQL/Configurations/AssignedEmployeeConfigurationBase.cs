using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public abstract class AssignedEmployeeConfigurationBase : IEntityTypeConfiguration<AssignedEmployee>
    {
        public void Configure(EntityTypeBuilder<AssignedEmployee> builder)
        {
            builder.ToView(AssignedEmployeeListView).HasKey(x => x.EmployeeID);
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<AssignedEmployee> builder);

        protected abstract string AssignedEmployeeListView { get; }
    }
}
