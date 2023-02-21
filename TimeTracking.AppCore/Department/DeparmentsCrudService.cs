using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;

namespace TimeTracking.AppCore;

internal class DeparmentsCrudService : IDeparmentsCrudService, ISelfRegisteredService<IDeparmentsCrudService>
{
    private readonly IRepository<Department> _departments;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeparmentsCrudService(IRepository<Department> departments, IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _departments = departments;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(NewDepartmentCommand command, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        var newDepartment = new Department();
        _mapper.Map(command.New, newDepartment);
        _departments.Insert(newDepartment);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
