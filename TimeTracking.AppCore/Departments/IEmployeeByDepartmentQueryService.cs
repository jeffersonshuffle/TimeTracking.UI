using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Queries;

namespace TimeTracking.AppCore;

public interface IEmployeeByDepartmentQueryService
    : IAsyncQueryHandler<Query<Guid>, EmployeeByDepartmentDetails[]>
{
}
