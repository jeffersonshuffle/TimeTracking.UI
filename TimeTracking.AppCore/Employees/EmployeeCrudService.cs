using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;

namespace TimeTracking.AppCore;

internal class EmployeeCrudService : IEmployeeCrudService, ISelfRegisteredService<IEmployeeCrudService>
{
    private readonly IRepository<Employee> _employees;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmployeeCrudService(IRepository<Employee> employees, IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _employees = employees;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(NewEmployeeCommand command, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        var @new = new Employee();
        _mapper.Map(command.New, @new);
        if (command.Address != null)
        {
            var address = new Address();
            _mapper.Map(command.Address, address);
            @new.Address= address;
        }
        _employees.Insert(@new);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
