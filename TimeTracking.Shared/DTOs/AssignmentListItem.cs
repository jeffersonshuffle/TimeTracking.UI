using System;

namespace TimeTracking.Shared.DTOs
{
    public class AssignmentListItem
    {
        public Guid ID { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid EmployeeID { get; set; }
        public int PositionID { get; set; }
    }
}