using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.MySQL;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

internal class EmployeeCrudService : IEmployeeCrudService, ISelfRegisteredService<IEmployeeCrudService>
{
    private readonly IRepository<Employee> _employees;
    private readonly IRepository<Address> _addresses;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStorageProvider _database;
    public EmployeeCrudService(IRepository<Employee> employees, IRepository<Address> addresses, IStorageProvider database
        , IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _employees = employees;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _database = database;
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

    public async Task ExecuteAsync(DeleteCommand<Guid> command, CancellationToken token = default)
    {
        var toDel = await _employees.Set.Where(entity => entity.ID == command.Identity).Include(e => e.Address).FirstOrDefaultAsync(token);
        if (toDel == null) return;
        _employees.Delete(toDel);
        _addresses.Delete(toDel.Address);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(UpdateCommand<Guid, EmployeeData> command, CancellationToken token = default)
    {
        var update = await _employees.Set.Where(e => e.ID == command.Identity).Include(e => e.Address).FirstOrDefaultAsync(token);
        if (update == null) return;
        _mapper.Map(command.Data, update);
        _employees.Update(update);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
