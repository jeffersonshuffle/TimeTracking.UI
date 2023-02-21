using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore;

internal class PositionsQueryService : IPositionsQueryService, ISelfRegisteredService<IPositionsQueryService>
{
    private readonly IQueryableDataAdapter<Position> _positions;
    private readonly IMapper _mapper;
    public PositionsQueryService(IQueryableDataAdapter<Position> positions, IMapper mapper)
    {
        _positions = positions;
        _mapper = mapper;
    }

    public async Task<PositionListItem[]> GetPositionsAsync(CancellationToken token = default)
    {
        return await _positions.AsQueryable().ProjectTo<PositionListItem>(_mapper.ConfigurationProvider).ToArrayAsync();
    }
}
