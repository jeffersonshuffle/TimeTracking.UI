using System;

namespace TimeTracking.Shared.DTOs
{
    public class AssignedEmployeeListItem
    {
        public Guid EmployeeID { get; set;}
        public Guid AssignmentID { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public DateTime BirthDate { get; set;}
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public string EmployeePosition { get; set;}    
        public bool IsRemote { get; set;}
        public string AddressLine { get; set;}
        public byte[] Photo { get; set; }
    }
}
