using AutoMapper;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class AssignedEmployeeProfiler : Profile
{
    public AssignedEmployeeProfiler() 
    {
        CreateMap<AssignedEmployee, AssignedEmployeeListItem>();
    }
}
