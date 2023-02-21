using TimeTracking.DTOs;
using TimeTracking.Shared.Commands;
namespace TimeTracking.AppCore;

public interface IDeparmentsCrudService
    : IAsyncCommandHandler<NewDepartmentCommand>
{    
}
