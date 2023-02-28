using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

public interface  IEmployeeCalendarItemCrudService
    : IAsyncCommandHandler<CreateCommand<EmployeeCalendarItemData>>
    , IAsyncCommandHandler<DeleteCommand<int>>
    , IAsyncCommandHandler<UpdateCommand<int, EmployeeCalendarItemData>>
{    
}
