using AutoMapper;
using TimeTracking.DataModels;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class EmployeeCalendarItemProfiler : Profile
{
    public EmployeeCalendarItemProfiler() 
    {
        CreateMap<EmployeeCalendarItem, EmployeeCalendarItemDetails>();
        CreateMap<EmployeeCalendarItemData, EmployeeCalendarItem>();
        CreateMap<EmployeeCalendarItemDetails, EmployeeCalendarItemData > ();
    }
}
