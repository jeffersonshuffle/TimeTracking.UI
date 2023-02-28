using System;

namespace TimeTracking.Shared.DTOs
{
    public class EmployeePersonalInfoListItem
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonnelNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
