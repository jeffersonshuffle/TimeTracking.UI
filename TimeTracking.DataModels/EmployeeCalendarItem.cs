using System;

namespace TimeTracking.DataModels
{
    public class EmployeeCalendarItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DayMarkID { get; set; }    
        public Guid EmployeeID { get; set; }
        public virtual DayMark Mark { get; set; }
    }
}
