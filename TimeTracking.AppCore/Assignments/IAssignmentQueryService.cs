using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
namespace TimeTracking.AppCore;

public interface IAssignmentQueryService
    : IAsyncQueryHandler<GetAssignmentsByDepartmentQuery, AssignmentListItem[]>
{
    
}
