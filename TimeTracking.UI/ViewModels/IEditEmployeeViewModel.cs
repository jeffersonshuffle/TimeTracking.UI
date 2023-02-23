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
        void Clear();
        IEnumerable<string> GetPositionNames();
        IEnumerable<string> GetDepartmentNames();
        int DepartmentIndex { get; set; }
        int PositionIndex { get; set; }

        Task<bool> SaveOrUpdateAssignmentAsync(CancellationToken token = default);
        Task Initialize(CancellationToken token);
        Task SetEmployeeFromDetailsAsync(Guid employeeID, CancellationToken token = default);
        void CreateNewEmployee();
    }
}