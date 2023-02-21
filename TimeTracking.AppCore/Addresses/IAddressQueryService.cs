using TimeTracking.Shared.DTOs;
namespace TimeTracking.AppCore.Addresses;

public interface IAddressQueryService
{
    Task<AddressListItem[]> GetAddressesAsync(CancellationToken token = default);
}
