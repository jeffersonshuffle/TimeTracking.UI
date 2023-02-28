using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
using TimeTracking.Shared.Specifications;
using TimeTracking.Shared;
using Microsoft.EntityFrameworkCore;


namespace TimeTracking.AppCore.Employees;

internal class AssignedEmployeeQueryService : IAssignedEmployeeQueryService, ISelfRegisteredService<IAssignedEmployeeQueryService>
{
    private readonly IQueryableDataAdapter<AssignedEmployee> _employees;
    private readonly IMapper _mapper;

    public AssignedEmployeeQueryService(IQueryableDataAdapter<AssignedEmployee> employees, IMapper mapper)
    {
        _employees = employees;
        _mapper = mapper;
    }

    public async Task<AssignedEmployeeListItem[]> HandleAsync(Query<SearchStringSpecification> query, CancellationToken token = default)
    {
        var searchStr = query.Specification.SearchPattern.ToContainsPattern();        
        var result = await _employees.AsQueryable().Where(x => EF.Functions.Like(x.LastName, searchStr)
            || EF.Functions.Like(x.FirstName, searchStr)).ToPageAsync(e => e.LastName, token);
        return _mapper.Map<AssignedEmployeeListItem[]>(result);
    }

    public async Task<AssignedEmployeeListItem[]> ListAsync(CancellationToken token = default)
    {
        var result = await _employees.AsQueryable().ToPageAsync(e => e.LastName, token);
        return _mapper.Map<AssignedEmployeeListItem[]>(result);
    }
}
