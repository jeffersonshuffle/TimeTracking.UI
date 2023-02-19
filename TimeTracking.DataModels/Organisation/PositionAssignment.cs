using System;

namespace TimeTracking.DataModels.Organisation
{
    public class PositionAssignment
    {
        public PositionAssignment() { ID= Guid.NewGuid(); }
        public Guid ID { get; private set; }        
        public Guid DepartmentID { get; set; }
        public virtual Department Department { get; }
        public Guid EmployeeID { get; set; }
        public virtual Employee Employee { get; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int PositionID { get; set; }
        public virtual Position Position { get; }
    }
}
