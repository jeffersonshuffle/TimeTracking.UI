using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public abstract class EmployeeByDepartmentConfigurationBase : IEntityTypeConfiguration<EmployeeByDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeByDepartment> builder)
        {
            builder.ToView(EmployeeByDepartmentListView).HasKey(x => x.EmployeeID);
            ConfigureDatabase(builder);
        }
        protected abstract void ConfigureDatabase(EntityTypeBuilder<EmployeeByDepartment> builder);

        protected abstract string EmployeeByDepartmentListView { get; }
    }
}
