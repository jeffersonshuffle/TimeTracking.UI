using TimeTracking.Shared.Commands;
namespace TimeTracking.AppCore.Addresses;

public interface IAddressCrudService
    : IAsyncCommandHandler<NewAddressCommand>
{    
}
