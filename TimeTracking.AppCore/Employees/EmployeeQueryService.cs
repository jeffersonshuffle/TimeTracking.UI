using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
using TimeTracking.Shared;
using System.Configuration;

namespace TimeTracking.AppCore
{
    internal class EmployeeQueryService : IEmployeeQueryService, ISelfRegisteredService<IEmployeeQueryService>
    {
        private readonly IQueryableDataAdapter<Employee> _employees;
        private readonly IMapper _mapper;
        public EmployeeQueryService(IQueryableDataAdapter<Employee> employees, IMapper mapper)
        {
            _employees = employees;
            _mapper = mapper;
        }

        public async Task<EmployeeDetails> FindAsync(Guid entityId, CancellationToken token = default)
        {
            var emp = await _employees.AsQueryable().Where(e => e.ID.Equals(entityId)).FirstOrDefaultAsync(token);
            var details = new EmployeeDetails { Data = new EmployeeData()};
            _mapper.Map(emp, details.Data);
            _mapper.Map(emp, details);
            return details;
        }

        public async Task<int> GeneratePersonelNumberAsync(CancellationToken token = default)
        {            
            return await _employees.AsQueryable().Select(e => e.PersonnelNumber).OrderByDescending(x => x).FirstAsync() + 1;
        }

        public async Task<EmployeePersonalInfoListItem[]> HandleAsync(GetEmployeePersonalInfoListQuery query, CancellationToken token = default)
        {
            var queriable = _employees.AsQueryable();
            if (!string.IsNullOrEmpty(query.SearchPattern) && !string.IsNullOrWhiteSpace(query.SearchPattern))
            {
                var searchStr = query.SearchPattern.ToLower().ToContainsPattern();
                queriable = queriable.Where(x => EF.Functions.Like(x.FirstName.ToLower(), searchStr) 
                    || EF.Functions.Like(x.LastName.ToLower(), searchStr));

            }
            return await queriable.ProjectTo<EmployeePersonalInfoListItem>(_mapper.ConfigurationProvider)
                .ToPageAsync(e => e.LastName, token);
        }
    }
}
