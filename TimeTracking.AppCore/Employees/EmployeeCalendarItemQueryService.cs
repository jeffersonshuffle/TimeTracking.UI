using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
using TimeTracking.Shared.Specifications;

namespace TimeTracking.AppCore.Employees;

internal class EmployeeCalendarItemQueryService : IEmployeeCalendarItemQueryService, ISelfRegisteredService<IEmployeeCalendarItemQueryService>
{
    private readonly IQueryableDataAdapter<EmployeeCalendarItem> _calendarQuery;
    private readonly IMapper _mapper;
    public EmployeeCalendarItemQueryService(IQueryableDataAdapter<EmployeeCalendarItem> calendarQuery, IMapper mapper)
    {
        _calendarQuery = calendarQuery;
        _mapper = mapper;
    }
    public async Task<EmployeeCalendarItemDetails[]> HandleAsync(Query<Guid> query, CancellationToken token = default)
    {
        var res = await _calendarQuery.AsQueryable().Where(x => x.EmployeeID.Equals(query.Specification))
            .ToPageAsync(x => x.Date, token);
        return _mapper.Map<EmployeeCalendarItemDetails[]>(res);
    }

    public async Task<EmployeeCalendarItemDetails[]> HandleAsync(FilterByEmployeeWithMonthSpecification query, CancellationToken token = default)
    {
        var res = await _calendarQuery.AsQueryable().Where(x => x.EmployeeID.Equals(query.EmployeeID))
            .Where(x => x.Date.Year == query.Year)
            .Where(x => x.Date.Month == query.Month)
            .ToPageAsync(x => x.Date, token);
        return _mapper.Map<EmployeeCalendarItemDetails[]>(res);
    }
}
