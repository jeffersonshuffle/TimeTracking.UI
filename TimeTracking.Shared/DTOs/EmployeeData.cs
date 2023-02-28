using System;

namespace TimeTracking.Shared.DTOs
{
    public class EmployeeData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonnelNumber { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now - 18 * TimeSpan.FromDays(365);
        public byte[] Photo { get; set; }
        public int AddressId { get; set; }
        public AddressData? Address { get; set; }
    }
}