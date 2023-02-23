using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Addresses;
public class AddressCrudService : IAddressCrudService, ISelfRegisteredService<IAddressCrudService>
{
    private readonly IRepository<Address> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AddressCrudService(IRepository<Address> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository= repository;
        _unitOfWork= unitOfWork;
        _mapper= mapper;
    }
    public async Task ExecuteAsync(NewAddressCommand command, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(nameof(command));
        var address = new Address();
        _mapper.Map(command.New, address);
        _repository.Insert(address);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(DeleteCommand<int> command, CancellationToken token = default)
    {
        var toDel = await _repository.Set.Where(entity => entity.Id == command.Identity).FirstOrDefaultAsync(token);
        if (toDel == null) return;
        _repository.Delete(toDel);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task ExecuteAsync(UpdateCommand<int, AddressData> command, CancellationToken token = default)
    {
        var update = await _repository.Set.Where(entity => entity.Id == command.Identity).FirstOrDefaultAsync(token);
        if (update == null) return;
        _mapper.Map(command.Data, update);
        _repository.Update(update);
        await _unitOfWork.SaveChangesAsync(token);

    }
}
