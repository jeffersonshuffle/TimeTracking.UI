using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
namespace TimeTracking.AppCore;
public interface IDeparmentsQueryService
    : IAsyncQueryHandler<GetDepartmentsQuery, DepartmentListItem[]>
    , IAsyncEntityFinder<Guid, DepartmentDetails>
{
    Task<DepartmentListItem[]> GetDepartmentsAsync(CancellationToken token = default);
}
