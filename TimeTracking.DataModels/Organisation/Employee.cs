using System;
using System.Collections.Generic;

namespace TimeTracking.DataModels.Organisation
{
    public class Employee
    {
        public Employee() { ID = Guid.NewGuid();  }
        public Guid ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonnelNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual PositionAssignment Assignment { get; set; }
        public virtual ICollection<EmployeeCalendarItem> Calendar { get; set; }
    }
}
