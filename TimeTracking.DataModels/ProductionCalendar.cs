using System;
using System.Collections.Generic;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.DataModels
{
    public class ProductionCalendar
    {
        public Guid ID { get; set; }
        public Guid EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<CalendarItem> Days { get; set; }
    }
}
