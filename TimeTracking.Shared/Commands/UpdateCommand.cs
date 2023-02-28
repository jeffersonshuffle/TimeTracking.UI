namespace TimeTracking.Shared.Commands
{
    public class UpdateCommand<TIdentity, TData>: BaseCommand
    {
        public TIdentity Identity { get; set; }
        public TData Data { get; set; }
    }
}
