using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.Addresses;

public interface IAddressCrudService
    : IAsyncCommandHandler<NewAddressCommand>
    , IAsyncCommandHandler<DeleteCommand<int>>
    , IAsyncCommandHandler<UpdateCommand<int, AddressData>>

{
}
