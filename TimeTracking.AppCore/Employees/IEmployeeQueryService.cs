using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
namespace TimeTracking.AppCore;

public interface IEmployeeQueryService
    : IAsyncQueryHandler<GetEmployeesByDepartmentQuery, EmployeeListItem[]>
{
}
