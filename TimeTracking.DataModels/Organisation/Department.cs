using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.DataModels.Organisation
{
    public class Department
    {
        public Department() { ID= Guid.NewGuid(); }
        public Guid ID { get; private set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<PositionAssignment> EmployeeAsingments { get; set; }
    }
}
