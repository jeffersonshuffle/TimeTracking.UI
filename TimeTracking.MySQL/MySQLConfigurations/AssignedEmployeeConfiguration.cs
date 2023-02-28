using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DAL.Configurations
{
    public class AssignedEmployeeConfiguration : AssignedEmployeeConfigurationBase
    {
        protected override void ConfigureDatabase(EntityTypeBuilder<AssignedEmployee> builder)
        {

        }

        protected override string AssignedEmployeeListView => "employee_list_view";
    }
}
