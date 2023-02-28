using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
using TimeTracking.Shared.Specifications;

namespace TimeTracking.AppCore.Employees;

public interface IEmployeeCalendarItemQueryService
    : IAsyncQueryHandler<Query<Guid>, EmployeeCalendarItemDetails[]>
    , IAsyncQueryHandler<FilterByEmployeeWithMonthSpecification, EmployeeCalendarItemDetails[]>
{
}
