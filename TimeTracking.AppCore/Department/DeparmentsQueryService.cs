using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.DTOs;
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
