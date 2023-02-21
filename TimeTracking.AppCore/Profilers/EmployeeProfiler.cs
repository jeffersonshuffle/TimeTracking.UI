using AutoMapper;
using TimeTracking.DataModels.Organisation;
using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class EmployeeProfiler: Profile
{
    public EmployeeProfiler() 
    {
        CreateProjection<Employee, EmployeeListItem>();
        CreateMap<EmployeeData, Employee>();
    }
}
