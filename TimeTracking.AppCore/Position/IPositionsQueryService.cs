using TimeTracking.Shared.DTOs;
namespace TimeTracking.AppCore;

public interface IPositionsQueryService
{
    Task<PositionListItem[]> GetPositionsAsync(CancellationToken token = default);
}
