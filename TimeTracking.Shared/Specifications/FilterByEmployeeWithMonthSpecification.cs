using System;

namespace TimeTracking.Shared.Specifications
{
    public class FilterByEmployeeWithMonthSpecification
    {
        public Guid EmployeeID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; } = DateTime.UtcNow.Year;
    }
}
