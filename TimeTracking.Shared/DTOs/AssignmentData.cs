using System;

namespace TimeTracking.Shared.DTOs
{
    public class AssignmentData
    {
        public Guid DepartmentID { get; set; }        
        public Guid EmployeeID { get; set; } = Guid.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int PositionID { get; set; }
    }
}