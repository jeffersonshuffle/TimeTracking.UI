using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

internal class AssignmentCrudService : IAssignmentCrudService, ISelfRegisteredService<IAssignmentCrudService>
{
    private readonly IRepository<PositionAssignment> _assignments;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AssignmentCrudService(IRepository<PositionAssignment> Assignments, IEmployeeCrudService employees, IUnitOfWork unitOfWork, IMapper mapper) 
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
            employee.Address = new Address();
            command.Employee.Address = command.Address;
            _mapper.Map(command.Employee, employee);
            @new.Employee = employee;
        }
        _assignments.Insert(@new);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(UpdateCommand<Guid, AssignmentData> command, CancellationToken token = default)
    {
        var update = await _assignments.Set.Where(e => e.ID == command.Identity).FirstOrDefaultAsync(token);
        if (update == null) return;
        _mapper.Map(command.Data, update);
        _assignments.Update(update);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(DeleteCommand<Guid> command, CancellationToken token = default)
    {
        var toDel = await _assignments.Set.Where(entity => entity.ID == command.Identity).FirstOrDefaultAsync(token);
        if (toDel == null) return;
        _assignments.Delete(toDel);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
