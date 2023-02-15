using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.DataModels
{
    public class CalendarItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DayMarkID { get; set; }
        public virtual DayMark Mark { get; set; }
    }
}
