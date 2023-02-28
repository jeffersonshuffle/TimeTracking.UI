using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;

namespace TimeTracking.AppCore
{
    internal class DeparmentsQueryService : IDeparmentsQueryService, ISelfRegisteredService<IDeparmentsQueryService>
    {
        private readonly IQueryableDataAdapter<Department> _departments;
        private readonly IMapper _mapper;
        public DeparmentsQueryService(IQueryableDataAdapter<Department> departments, IMapper mapper)
        {
            _departments = departments;
            _mapper = mapper;
        }

        public async Task<DepartmentDetails> FindAsync(Guid entityId, CancellationToken token = default)
        {
            var dep = await _departments.AsQueryable().Where(e => e.ID.Equals(entityId)).FirstOrDefaultAsync(token);
            if (dep == null) return null;
            var details = new DepartmentDetails {ID = dep.ID, Data = new DepartmentData() };
            _mapper.Map(dep, details.Data);
            return details;

        }

        public async Task<DepartmentListItem[]> GetDepartmentsAsync(CancellationToken token = default)
        {
            return await _departments.AsQueryable().ProjectTo<DepartmentListItem>(_mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<DepartmentListItem[]> HandleAsync(GetDepartmentsQuery query, CancellationToken token = default)
        {
            return await _departments.AsQueryable().ProjectTo<DepartmentListItem>(_mapper.ConfigurationProvider).ToArrayAsync();
        }
    }
}
