namespace TimeTracking.Shared.Queries
{
    public class Query<TSpecification>: BaseQuery
    {
        public TSpecification Specification{get;set;}
    }
}
