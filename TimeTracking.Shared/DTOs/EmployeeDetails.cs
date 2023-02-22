using System;

namespace TimeTracking.Shared.DTOs
{
    public class EmployeeDetails
    {
        public Guid ID { get; set; }
        public EmployeeData Data { get; set; }
    }
}