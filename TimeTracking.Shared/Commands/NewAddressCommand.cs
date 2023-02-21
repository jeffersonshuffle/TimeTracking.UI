using TimeTracking.Shared.DTOs;

namespace TimeTracking.Shared.Commands
{
    public class NewAddressCommand : BaseCommand
    {
        public AddressData New { get; set; }
    }
}
