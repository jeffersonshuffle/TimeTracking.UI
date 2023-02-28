using System;

namespace TimeTracking.Shared.DTOs
{
    public class EmployeeCalendarItemData
    {
        public DateTime Date { get; set; }
        public int DayMarkID { get; set; }    
        public Guid EmployeeID { get; set; }
    }
}
