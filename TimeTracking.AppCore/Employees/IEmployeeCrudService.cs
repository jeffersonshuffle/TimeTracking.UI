using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

public interface IEmployeeCrudService
    : IAsyncCommandHandler<NewEmployeeCommand>
    , IAsyncCommandHandler<DeleteCommand<Guid>>
    , IAsyncCommandHandler<UpdateCommand<Guid, EmployeeData>>
{    
}
