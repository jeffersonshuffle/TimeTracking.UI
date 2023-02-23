using System;

namespace TimeTracking.DataModels.Organisation
{
    public class AssignedEmployee
    {
        public Guid EmployeeID { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public DateTime BirthDate { get; set;}
        public string EmployeePosition { get; set;}    
        public bool IsRemote { get; set;}
        public string AddressLine { get; set;}
        public byte[] Photo { get; set;}
    }
}
