using AutoMapper;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class PositionProfiler: Profile
{
    public PositionProfiler() 
    {
        CreateMap<PositionData, Position>();
        CreateProjection<Position, PositionListItem>()
            .ForMember(p => p.Id, o => o.MapFrom(x => x.PositionId))
            .ForMember(p => p.Title, o => o.MapFrom(x => x.Title));
    }
}
