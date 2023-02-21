using TimeTracking.DTOs;
using TimeTracking.Shared.Commands;
namespace TimeTracking.AppCore;

public interface IPositionsCrudService
    : IAsyncCommandHandler<NewPositionCommand>
{    
}
