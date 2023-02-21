using TimeTracking.DTOs;

namespace TimeTracking.UI.ViewModels
{
    public interface IDepartmentsViewModel
    {
        DepartmentListItem[] Departments { get; }
        int SelectedIndex { get; set; }

        Task Initialize(CancellationToken token = default);
    }
}