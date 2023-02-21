using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.UI.Models
{
    internal class EmployeeListModel
    {
        public Guid EmployeeId { get; init; }
        public string FullName { get; init; }
        public string PersonnelNumber { get; init; }
        public string Position { get; init; }
    }
}
