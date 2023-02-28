using System;

namespace TimeTracking.Shared.DTOs
{
    public class EmployeeCalendarItemDetails
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DayMarkID { get; set; }    
        public Guid EmployeeID { get; set; }
    }
}
