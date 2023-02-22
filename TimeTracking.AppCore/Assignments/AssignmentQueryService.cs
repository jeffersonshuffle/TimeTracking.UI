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
    internal class AssignmentQueryService : IAssignmentQueryService, ISelfRegisteredService<IAssignmentQueryService>
    {
        private readonly IQueryableDataAdapter<PositionAssignment> _assignments;
        private readonly IMapper _mapper;
        public AssignmentQueryService(IQueryableDataAdapter<PositionAssignment> assignments, IMapper mapper)
        {
            _assignments = assignments;
            _mapper = mapper;
        }

        public async Task<AssignmentListItem[]> HandleAsync(GetAssignmentsByDepartmentQuery query, CancellationToken token = default)
        {
            return await _assignments.AsQueryable().ProjectTo<AssignmentListItem>(_mapper.ConfigurationProvider).ToArrayAsync();

        }
    }
}
