using TimeTracking.Shared.Commands;
namespace TimeTracking.AppCore;

public interface IAssignmentCrudService
    : IAsyncCommandHandler<NewAssignmentCommand>
{    
}
