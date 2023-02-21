
using TimeTracking.Shared.DTOs;

namespace TimeTracking.Shared.Commands
{
    public class NewDepartmentCommand : BaseCommand
    {
        public DepartmentData New { get; set; }
    }
}
