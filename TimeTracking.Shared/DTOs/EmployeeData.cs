using System;

namespace TimeTracking.Shared.DTOs
{
    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonnelNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; }
        public int AddressId { get; set; }
    }
}