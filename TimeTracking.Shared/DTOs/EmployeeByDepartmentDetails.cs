using System;
using TimeTracking.Shared;

namespace TimeTracking.DataModels.Organisation
{
    public class EmployeeByDepartmentDetails
    {
        public Guid DepartmentID { get; set; }
        public Guid EmployeeID { get; set; }
        public string FullName { get; set; }
        public int PersonnelNumber { get; set; }
        public string EmployeePosition { get; set; }

        public override string ToString()
        {
            return $"{FullName} {EmployeePosition} {PersonnelNumber.ToString().AppendZeroes(4)}";
        }
    }
}
