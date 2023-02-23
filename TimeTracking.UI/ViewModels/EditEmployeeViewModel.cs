using TimeTracking.Abstractions;
using TimeTracking.AppCore;
using TimeTracking.AppCore.Addresses;
using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels;

internal class EditEmployeeViewModel : IEditEmployeeViewModel, ISelfRegisteredService<IEditEmployeeViewModel>
{
    private readonly IEmployeeCrudService _employeeCrud;
    private readonly IEmployeeQueryService _employeeQuery;
    private readonly IAssignmentCrudService _assignmentCrud;
    private readonly IDeparmentsQueryService _deparments;
    private readonly IPositionsQueryService _positions;
    private readonly IAddressQueryService _addressQuery;

    public EditEmployeeViewModel(
        IEmployeeCrudService employeeCrud
        , IEmployeeQueryService employeeQuery
        , IDeparmentsQueryService deparments
        , IPositionsQueryService positions
        , IAssignmentCrudService assignmentCrud
        , IAddressQueryService addressQuery
        )
    {
        _employeeCrud = employeeCrud;
        _employeeQuery = employeeQuery;
        _deparments = deparments;
        _positions = positions;
        _assignmentCrud = assignmentCrud;
        _addressQuery = addressQuery;
    }

    public void Clear()
    {
        Positions = null;
        Departments = null;
        Employee = null;
        Address = null;
        DepartmentIndex = 0;
        PositionIndex = 0;
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

    public async Task SetEmployeeFromDetailsAsync(Guid employeeID, CancellationToken token = default)
    {
        EmployeeDetails employee = await _employeeQuery.FindAsync(employeeID, token);
        Employee = new EmployeeEditModel(employee.ID, employee.Data);
    }

    public async Task<bool> SaveOrUpdateAssignmentAsync(CancellationToken token = default)
    {
        if (Employee.EmployeeID == Guid.Empty)
        {
            return await AddNewAssignmentAsync(token);
        }
        return await UpdateAssignmentAsync(token);
    }

    private async Task<bool> UpdateAssignmentAsync(CancellationToken token = default)
    {
        var result = false;
        try
        {
            await _assignmentCrud.ExecuteAsync(new Shared.Commands.NewAssignmentCommand
            {
                Employee = Employee.EmployeeData,
                Address = Address.AddressData,
                New = new AssignmentData
                {
                    DepartmentID = Departments[DepartmentIndex].DepartmentId,
                    PositionID = Positions[PositionIndex].Id,
                    EmploymentType = Employee.EmploymentType
                }
            }, token);
            result = true;
        }
        catch (Exception ex)
        { }
        return result;
    }


    private async Task<bool> AddNewAssignmentAsync(CancellationToken token = default)
    {
        var result = false;
        try
        {
            Employee.EmployeeData.PersonnelNumber = await _employeeQuery.GeneratePersonelNumberAsync(token);
            await _assignmentCrud.ExecuteAsync(new Shared.Commands.NewAssignmentCommand { 
                Employee = Employee.EmployeeData,
                Address = Address.AddressData,
                New = new AssignmentData
                {
                    DepartmentID = Departments[DepartmentIndex].DepartmentId,
                    PositionID = Positions[PositionIndex].Id,
                    EmploymentType = Employee.EmploymentType
                }
            }, token);
            result = true;
        }
        catch (Exception ex)
        { }
        return result;
    }
}
