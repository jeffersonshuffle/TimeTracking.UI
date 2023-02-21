using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public class EmployeeByDepartmentConfiguration : EmployeeByDepartmentConfigurationBase
    {
        protected override void ConfigureDatabase(EntityTypeBuilder<EmployeeByDepartment> builder)
        {

        }

        protected override string EmployeeByDepartmentListView => "employee_by_department_list_view";
    }
}
