using AutoMapper;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.AppCore.Profilers;

internal class EmployeeByDepartmentProfiler : Profile
{
    public EmployeeByDepartmentProfiler() 
    {
        CreateMap<EmployeeByDepartment, EmployeeByDepartmentDetails>()
            .ForMember(x => x.FullName, o => o.MapFrom(d => $"{d.FirstName} {d.LastName}"));
    }
}
