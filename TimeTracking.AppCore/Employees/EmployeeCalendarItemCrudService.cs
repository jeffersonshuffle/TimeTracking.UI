using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

internal class EmployeeCalendarItemCrudService : IEmployeeCalendarItemCrudService, ISelfRegisteredService<IEmployeeCalendarItemCrudService>
{
    private readonly IRepository<EmployeeCalendarItem> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmployeeCalendarItemCrudService(IRepository<EmployeeCalendarItem> repository
        , IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(CreateCommand<EmployeeCalendarItemData> command, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        var @new = new EmployeeCalendarItem();
        _mapper.Map(command.Data, @new);
        _repository.Insert(@new);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(DeleteCommand<int> command, CancellationToken token = default)
    {
        var toDel = await _repository.Set.Where(entity => entity.Id == command.Identity).FirstOrDefaultAsync(token);
        if (toDel == null) return;
        _repository.Delete(toDel);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(UpdateCommand<int, EmployeeCalendarItemData> command, CancellationToken token = default)
    {
        var update = await _repository.Set.Where(e => e.Id == command.Identity).FirstOrDefaultAsync(token);
        if (update == null) return;
        _mapper.Map(command.Data, update);
        _repository.Update(update);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
