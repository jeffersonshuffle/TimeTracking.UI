using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.DayMarks;

public interface IDayMarksQueryService
{
    Task<DayMarkDetails[]> ListAllAsync(CancellationToken token = default);
}
