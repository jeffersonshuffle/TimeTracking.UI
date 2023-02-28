using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
using TimeTracking.Shared.Specifications;

namespace TimeTracking.AppCore;

public interface IAssignedEmployeeQueryService
    : IAsyncQueryHandler<Query<SearchStringSpecification>, AssignedEmployeeListItem[]>
{
    Task<AssignedEmployeeListItem[]> ListAsync(CancellationToken token = default);
}
