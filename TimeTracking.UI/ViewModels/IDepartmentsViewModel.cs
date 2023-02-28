using TimeTracking.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    public interface IDepartmentsViewModel
    {
        DepartmentListItem[] Departments { get; }
        int SelectedIndex { get; set; }
        DepartmentEditModel Department { get; set; }

        Task DeleteAsync(CancellationToken token = default);
        Task Initialize(CancellationToken token = default);
        Task LoadAsync(CancellationToken token);
        Task SaveAsync(CancellationToken token);
        Task SetDepartmentAsync(CancellationToken token = default);
        void SetNewDepartment();
    }
}