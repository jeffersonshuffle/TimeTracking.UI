using TimeTracking.Shared.Commands;
namespace TimeTracking.AppCore;

public interface IEmployeeCrudService
    : IAsyncCommandHandler<NewEmployeeCommand>
{    
}
