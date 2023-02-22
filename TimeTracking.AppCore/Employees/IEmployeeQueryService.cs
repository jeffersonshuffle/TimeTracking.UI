using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
namespace TimeTracking.AppCore;

public interface IEmployeeQueryService
    : IAsyncQueryHandler<GetEmployeePersonalInfoListQuery, EmployeePersonalInfoListItem[]>
    , IAsyncEntityFinder<Guid, EmployeeDetails>
{
    Task<int> GeneratePersonelNumberAsync(CancellationToken token = default);
}
