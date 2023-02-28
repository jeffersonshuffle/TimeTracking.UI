using TimeTracking.Shared.DTOs;
namespace TimeTracking.AppCore.Addresses;

public interface IAddressQueryService : IAsyncEntityFinder<int, AddressDetails>
{
    Task<AddressListItem[]> GetAddressesAsync(CancellationToken token = default);
}
