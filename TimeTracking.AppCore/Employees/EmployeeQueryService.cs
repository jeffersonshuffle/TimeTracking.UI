using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;

namespace TimeTracking.AppCore
{
    internal class EmployeeQueryService : IEmployeeQueryService, ISelfRegisteredService<IEmployeeQueryService>
    {
        private readonly IQueryableDataAdapter<Department> _employees;
        private readonly IMapper _mapper;
        public EmployeeQueryService(IQueryableDataAdapter<Department> employees, IMapper mapper)
        {
            _employees = employees;
            _mapper = mapper;
        }

        public async Task<EmployeeListItem[]> HandleAsync(GetEmployeesByDepartmentQuery query, CancellationToken token = default)
        {
            return await _employees.AsQueryable().ProjectTo<EmployeeListItem>(_mapper.ConfigurationProvider).ToArrayAsync();

        }
    }
}
