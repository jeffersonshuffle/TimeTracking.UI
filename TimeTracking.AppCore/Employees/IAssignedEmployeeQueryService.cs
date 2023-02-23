using TimeTracking.Shared.DTOs;
namespace TimeTracking.AppCore;

public interface IAssignedEmployeeQueryService
{
    Task<AssignedEmployeeListItem[]> ListAsync(CancellationToken token = default);
}
