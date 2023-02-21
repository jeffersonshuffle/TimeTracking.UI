using AutoMapper;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class PositionProfiler: Profile
{
    public PositionProfiler() 
    {
        CreateMap<PositionData, Position>();
        CreateMap<Position, PositionListItem>();
    }
}
