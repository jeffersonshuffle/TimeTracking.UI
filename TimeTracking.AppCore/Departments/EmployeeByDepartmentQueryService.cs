using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.Queries;

namespace TimeTracking.AppCore;

internal class EmployeeByDepartmentQueryService : IEmployeeByDepartmentQueryService, ISelfRegisteredService<IEmployeeByDepartmentQueryService>
{
    private readonly IQueryableDataAdapter<EmployeeByDepartment> _employeeQuery;
    private readonly IMapper _mapper;
    public  EmployeeByDepartmentQueryService(IQueryableDataAdapter<EmployeeByDepartment> employeeQuery, IMapper mapper)
    {
        _employeeQuery = employeeQuery;
        _mapper = mapper;
    }
    public async Task<EmployeeByDepartmentDetails[]> HandleAsync(Query<Guid> query, CancellationToken token = default)
    {
        var res = await _employeeQuery.AsQueryable().Where(e => e.DepartmentID.Equals(query.Specification))
            .ToPageAsync(e => e.FirstName, token);
        return _mapper.Map<EmployeeByDepartmentDetails[]>(res);
    }
}
