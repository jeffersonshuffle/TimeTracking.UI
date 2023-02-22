using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    public interface IEditEmployeeViewModel
    {
        AddressEditModel Address { get;  }
        DepartmentListItem[] Departments { get; }
        EmployeeEditModel Employee { get;  }
        PositionListItem[] Positions { get; }
        IEnumerable<string> GetPositionNames();
        IEnumerable<string> GetDepartmentNames();
        int DepartmentIndex { get; set; }
        int PositionIndex { get; set; }

        Task<bool> AddNewAssignmentAsync(CancellationToken token = default);
        Task Initialize(CancellationToken token);
        Task SetEmployeeFromDetailsAsync(EmployeeDetails employee, CancellationToken token = default);
        void CreateNewEmployee();
    }
}