using TimeTracking.Shared.DTOs;

namespace TimeTracking.Shared.Commands
{
    public class NewAssignmentCommand
    {
        public AssignmentData New { get; set; }
        public EmployeeData? Employee { get; set; }
    }
}