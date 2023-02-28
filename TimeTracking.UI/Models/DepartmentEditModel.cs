using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.UI.Models
{
    public class DepartmentEditModel : ObservableObject
    {
        private readonly DepartmentData department;
        public DepartmentEditModel(DepartmentData department) : this(Guid.Empty, department) {}

        public DepartmentEditModel(Guid departmentID, DepartmentData department)
        {
            this.department = department;
            DepartmentID = departmentID;
        }
        public DepartmentData DepartmentData => department; 
        public Guid DepartmentID { get; init; }
        public string Name
        {
            get => department.Name;
            set => SetProperty(department.Name, value, department, (u, n) => u.Name = n);
        }
        public string Description
        {
            get => department.Description;
            set => SetProperty(department.Description, value, department, (u, n) => department.Description = n);
        }
    }
}
