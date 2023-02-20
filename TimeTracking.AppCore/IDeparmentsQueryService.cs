using TimeTracking.DTOs;
using TimeTracking.Shared.Queries;
namespace TimeTracking.AppCore;

public interface IDeparmentsQueryService
    : IAsyncQueryHandler<GetDepartmentsQuery, DepartmentListItem[]>
{
    Task<DepartmentListItem[]> GetDepartmentsAsync(CancellationToken token = default);
}
