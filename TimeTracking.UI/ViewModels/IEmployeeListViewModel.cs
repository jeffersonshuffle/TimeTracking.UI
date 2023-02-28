using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels;

public interface IEmployeeListViewModel
{
    int SelectedIndex { get; set; }
    Task<bool> DeleteAsync( CancellationToken token = default);
    Task InitializeAsync(CancellationToken token = default);
    IEnumerable<EmployeeListItemModel> GetList();
    Task SearchAsync(string searchPattern, CancellationToken token = default);

    AssignedEmployeeListItem[] EmployeeList
    {
        get;
    }
}