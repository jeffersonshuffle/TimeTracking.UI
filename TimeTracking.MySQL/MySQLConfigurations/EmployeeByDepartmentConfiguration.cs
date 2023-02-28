using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public class EmployeeByDepartmentConfiguration : EmployeeByDepartmentConfigurationBase
    {
        protected override void ConfigureDatabase(EntityTypeBuilder<EmployeeByDepartment> builder)
        {
            builder.Property(x => x.DepartmentID).HasColumnName("DepartmentID")
                .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
            builder.Property(x => x.EmployeeID).HasColumnName("EmployeeID")
                .HasColumnType("BINARY(16)").HasConversion(g => g.ToByteArray(), b => new Guid(b));
        }

        protected override string EmployeeByDepartmentListView => "employee_by_department_list_view";
    }
}
