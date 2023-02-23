using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Helpers;
using TimeTracking.UI.Properties;

namespace TimeTracking.UI.Models
{
    public class EmployeeListItemModel
    {
        private readonly AssignedEmployeeListItem employee;
        public EmployeeListItemModel(AssignedEmployeeListItem employee) => this.employee = employee;
        
        public Guid EmployeeID => employee.EmployeeID;
        public string FirstNameget => employee.FirstName;
        public string LastName => employee.LastName;
        public string EmployeePosition => employee.EmployeePosition;
        public string AddressLine => employee.AddressLine;
        public DateTime BirthDate => employee.BirthDate;

        public int Age => employee.Age;

        public Image Photo => ImageHelper.ByteArrayToImage(employee.Photo) ?? Resources.nophoto;

        public bool IsRemote => employee.IsRemote;
    }
}
