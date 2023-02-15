using System;

namespace TimeTracking.DataModels.Organisation
{
    public class Employee
    {
        public Employee() { ID = Guid.NewGuid();  }
        public Guid ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string JobTitle { get; set; }
        public byte[] Photo { get; set; }        
        public Address Address { get; set; }
        public Guid DepartmentID { get; set; }
        public virtual ProductionCalendar Calendar { get; set; }
    }
}
