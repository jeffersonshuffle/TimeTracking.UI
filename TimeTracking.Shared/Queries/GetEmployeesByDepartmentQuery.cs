using System;

namespace TimeTracking.Shared.Queries
{
    public class GetEmployeesByDepartmentQuery: BaseQuery
    {
        public Guid DepartmentID { get; set; }  
    }
}
