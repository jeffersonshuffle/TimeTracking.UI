using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

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

    public async Task ExecuteAsync(UpdateCommand<Guid, DepartmentData> command, CancellationToken token = default)
    {
        var update = await _departments.Set.Where(e => e.ID == command.Identity).FirstOrDefaultAsync(token);
        if (update == null) return;
        _mapper.Map(command.Data, update);
        _departments.Update(update);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(DeleteCommand<Guid> command, CancellationToken token = default)
    {
        var toDel = await _departments.Set.Where(entity => entity.ID == command.Identity).FirstOrDefaultAsync(token);
        if (toDel == null) return;
        _departments.Delete(toDel);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
