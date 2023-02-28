using AutoMapper;
using TimeTracking.DataModels.Organisation;
using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class DepartmentProfiler: Profile
{
    public DepartmentProfiler() 
    {
        CreateProjection<Department, DepartmentListItem>()
            .ForMember(d => d.DepartmentId, o => o.MapFrom(dd => dd.ID))
            .ForMember(d => d.Name, o => o.MapFrom(dd => dd.Name));
        CreateMap<DepartmentData, Department>();
        CreateMap<Department, DepartmentData>();
        CreateMap<Department, DepartmentDetails>();
            
    }
}
