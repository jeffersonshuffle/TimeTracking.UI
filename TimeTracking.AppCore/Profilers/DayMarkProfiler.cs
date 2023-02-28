using AutoMapper;
using TimeTracking.DataModels;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class DayMarkProfiler: Profile
{
    public DayMarkProfiler() 
    {
        CreateMap<DayMark, DayMarkDetails>();
    }
}
