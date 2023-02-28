namespace TimeTracking.Shared.Commands
{
    public class CreateCommand<TData> : BaseCommand
    {
        public TData Data { get; set; }
    }
}
