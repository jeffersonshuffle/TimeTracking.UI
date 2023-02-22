using TimeTracking.Abstractions;
using TimeTracking.AppCore;
using TimeTracking.AppCore.Addresses;
using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    internal class EditEmployeeViewModel : IEditEmployeeViewModel, ISelfRegisteredService<IEditEmployeeViewModel>
    {
        private readonly IEmployeeCrudService _employeeCrud;
        private readonly IAssignmentCrudService _assignmentCrud;
        private readonly IDeparmentsQueryService _deparments;
        private readonly IPositionsQueryService _positions;
        private readonly IAddressQueryService _addressQuery;

        public EditEmployeeViewModel(
            IEmployeeCrudService employeeCrud
            , IDeparmentsQueryService deparments
            , IPositionsQueryService positions
            , IAssignmentCrudService assignmentCrud
            , IAddressQueryService addressQuery
            )
        {
            _employeeCrud = employeeCrud;
            _deparments = deparments;
            _positions = positions;
            _assignmentCrud = assignmentCrud;
            _addressQuery = addressQuery;
        }

        
        public IEnumerable<string> GetPositionNames()
        {
            foreach (var p in Positions) yield return p.Title;
        }
        public IEnumerable<string> GetDepartmentNames()
        {
            foreach (var d in Departments) yield return d.Name;
        }
        public PositionListItem[] Positions { get; private set; }
        public DepartmentListItem[] Departments { get; private set; }
        public EmployeeEditModel Employee { get; private set; }
        public AddressEditModel Address { get; private set; }
        public int DepartmentIndex { get; set; }
        public int PositionIndex { get; set; }

        public async Task Initialize(CancellationToken token)
        {
            Positions = await _positions.GetPositionsAsync(token);
            Departments = await _deparments.GetDepartmentsAsync(token);
        }

        public void CreateNewEmployee()
        {
            Address = new AddressEditModel(new AddressData());
            Employee = new EmployeeEditModel(new EmployeeData());
        }

        public async Task SetEmployeeFromDetailsAsync(EmployeeDetails employee, CancellationToken token = default)
        {
            Employee = new EmployeeEditModel(employee.ID, employee.Data);
        }

        public async Task<bool> AddNewAssignmentAsync(CancellationToken token = default)
        {
            var result = false;
            try
            {
                result = true;
            }
            catch (Exception ex)
            { }
            return result;
        }
    }
}
