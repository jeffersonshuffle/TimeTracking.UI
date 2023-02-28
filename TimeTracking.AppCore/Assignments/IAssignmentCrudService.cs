using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

public interface IAssignmentCrudService
    : IAsyncCommandHandler<NewAssignmentCommand>
    , IAsyncCommandHandler<UpdateCommand<Guid, AssignmentData>>
    , IAsyncCommandHandler<DeleteCommand<Guid>>
{    
}
