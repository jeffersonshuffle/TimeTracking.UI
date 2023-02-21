

using TimeTracking.Shared.DTOs;

namespace TimeTracking.Shared.Commands
{
    public class NewPositionCommand : BaseCommand
    {
        public PositionData New { get; set; }
    }
}
