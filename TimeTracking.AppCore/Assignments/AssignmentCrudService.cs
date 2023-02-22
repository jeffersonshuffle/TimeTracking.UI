using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;

namespace TimeTracking.AppCore;

internal class AssignmentCrudService : IAssignmentCrudService, ISelfRegisteredService<IAssignmentCrudService>
{
    private readonly IRepository<PositionAssignment> _assignments;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AssignmentCrudService(IRepository<PositionAssignment> Assignments, IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _assignments = Assignments;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(NewAssignmentCommand command, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        if (command.New.EmployeeID == Guid.Empty & command.Employee == null) throw new InvalidOperationException();
        var @new = new PositionAssignment();
        _mapper.Map(command.New, @new);
        if (command.Employee != null && command.New.EmployeeID == Guid.Empty)
        {
            var employee = new Employee();
            _mapper.Map(command.Employee, employee);
            @new.EmployeeID = employee.ID;
            @new.Employee = employee;
        }        
        _assignments.Insert(@new);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
