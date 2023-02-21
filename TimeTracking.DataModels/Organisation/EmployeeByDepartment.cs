using System;

namespace TimeTracking.DataModels.Organisation
{
    public class EmployeeByDepartment
    {
        public Guid DepartmentID { get; set; }
        public Guid EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonnelNumber { get; set; }
        public string EmployeePosition { get; set; }
    }
}
