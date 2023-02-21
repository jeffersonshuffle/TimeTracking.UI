using System;

namespace TimeTracking.DataModels.Organisation
{
    public class PositionAssignment
    {
        public PositionAssignment() { ID= Guid.NewGuid(); }
        public Guid ID { get; private set; }        
        public Guid DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public Guid EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int PositionID { get; set; }
        public virtual Position Position { get; set; }
    }
}
