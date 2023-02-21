
using TimeTracking.Shared.DTOs;

namespace TimeTracking.Shared.Commands
{
    public class NewEmployeeCommand : BaseCommand
    {
        public EmployeeData New { get; set; }
        public AddressData? Address { get; set; }
    }
}
