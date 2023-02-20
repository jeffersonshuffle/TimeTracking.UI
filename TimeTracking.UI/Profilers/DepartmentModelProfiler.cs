using AutoMapper;
using TimeTracking.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.Profilers
{
    internal class DepartmentModelProfiler: Profile
    {
        public DepartmentModelProfiler()
        {
            CreateMap<DepartmentListItem, DepartmentListModel>();
        }
    }
}
