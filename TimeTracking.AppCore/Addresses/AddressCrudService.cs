using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;

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
}
