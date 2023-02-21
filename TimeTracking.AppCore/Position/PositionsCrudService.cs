using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Commands;
namespace TimeTracking.AppCore;

public class PositionsCrudService : IPositionsCrudService, ISelfRegisteredService<IPositionsCrudService>
{
    private readonly IRepository<Position> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PositionsCrudService(IRepository<Position> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository= repository;
        _unitOfWork= unitOfWork;
        _mapper= mapper;
    }
    public async Task ExecuteAsync(NewPositionCommand command, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(nameof(command));
        var position = new Position();
        _mapper.Map(command.New, position);
        _repository.Insert(position);
        await _unitOfWork.SaveChangesAsync(token);
    }
}
