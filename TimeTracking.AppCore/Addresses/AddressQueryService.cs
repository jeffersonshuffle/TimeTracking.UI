using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Addresses;

internal class AddressQueryService : IAddressQueryService, ISelfRegisteredService<IAddressQueryService>
{
    private readonly IQueryableDataAdapter<Address> _addresses;
    private readonly IMapper _mapper;
    public AddressQueryService(IQueryableDataAdapter<Address> addresses, IMapper mapper)
    {
        _addresses= addresses;
        _mapper = mapper;
    }

    public async Task<AddressDetails> FindAsync(int entityId, CancellationToken token = default)
    {
        var address = await _addresses.AsQueryable().Where(a => a.Id == entityId).FirstOrDefaultAsync(token);
        var details = new AddressDetails { Data = new AddressData() };
        _mapper.Map(address, details.Data);
        _mapper.Map(address, details);
        return details;

    }

    public async Task<AddressListItem[]> GetAddressesAsync(CancellationToken token = default)
    {
        return await _addresses.AsQueryable().ProjectTo<AddressListItem>(_mapper.ConfigurationProvider).ToArrayAsync();
    }
}
