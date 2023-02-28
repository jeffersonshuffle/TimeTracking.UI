using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

public interface IDeparmentsCrudService
    : IAsyncCommandHandler<NewDepartmentCommand>
    , IAsyncCommandHandler<UpdateCommand<Guid, DepartmentData>>
{
    Task ExecuteAsync(DeleteCommand<Guid> command, CancellationToken token = default);
}
