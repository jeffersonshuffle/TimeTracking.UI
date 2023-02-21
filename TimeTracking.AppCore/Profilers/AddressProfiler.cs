using AutoMapper;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Profilers;

internal class AddressProfiler: Profile
{
    public AddressProfiler() 
    {
        CreateMap<AddressData, Address>();
        CreateProjection<Address, AddressListItem>()
            .ForMember(d => d.Id, o => o.MapFrom(dd => dd.Id))
            .ForMember(x => x.Street, o => o.MapFrom(a => a.Street))
            .ForMember(x => x.Appartment, o => o.MapFrom(a => a.Appartment))
            .ForMember(x => x.House, o => o.MapFrom(a => a.House))
            .ForMember(x => x.City, o => o.MapFrom(a => a.City));            
    }
}
