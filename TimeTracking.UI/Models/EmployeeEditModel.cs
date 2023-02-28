using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracking.DataModels.Organisation;
using TimeTracking.Shared;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Helpers;
using TimeTracking.UI.Properties;

namespace TimeTracking.UI.Models
{
    public class EmployeeEditModel: ObservableObject
    {
        private readonly EmployeeData employee;
        public EmployeeEditModel(EmployeeData employee) : this(Guid.Empty, employee){}

        public EmployeeEditModel(Guid employeeID, EmployeeData employee)
        {
            this.employee = employee;
            EmployeeID = employeeID;
        }
        public EmployeeData EmployeeData => employee; 
        public Guid EmployeeID { get; init; }
        public string FirstName
        {
            get => employee.FirstName;
            set => SetProperty(employee.FirstName, value, employee, (u, n) => u.FirstName = n);
        }
        public string LastName
        {
            get => employee.LastName;
            set => SetProperty(employee.LastName, value, employee, (u, n) => u.LastName = n);
        }
        public string PersonnelNumber
        {
            get 
            { 
                return employee.PersonnelNumber.ToString().AppendZeroes(5);
            }
            set => SetProperty(employee.LastName, value, employee, (u, n) => u.LastName = n);
        }
        public DateTime BirthDate
        {
            get => employee.BirthDate;
            set => SetProperty(employee.BirthDate, value, employee, (u, n) => u.BirthDate = n);
        }
        public Image Photo
        {
            get => ImageHelper.ByteArrayToImage(employee.Photo) ?? Resources.nophoto; 
            set => SetProperty(employee.Photo, value != null ? ImageHelper.ImageToByte(value) : new byte[0], employee, (u, n) => u.Photo = n);
        }
        private bool _EmploymentType = false;
        public bool EmploymentType
        {
            get => _EmploymentType;
            set => SetProperty(ref _EmploymentType, value);
        }
    }
}
