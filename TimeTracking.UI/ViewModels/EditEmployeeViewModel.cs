using TimeTracking.Abstractions;
using TimeTracking.AppCore;
using TimeTracking.AppCore.Addresses;
using TimeTracking.DTOs;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;
using TimeTracking.Shared.Commands;
using TimeTracking.DataModels.Organisation;

namespace TimeTracking.UI.ViewModels;

internal class EditEmployeeViewModel : IEditEmployeeViewModel, ISelfRegisteredService<IEditEmployeeViewModel>
{
    private readonly IEmployeeCrudService _employeeCrud;
    private readonly IEmployeeQueryService _employeeQuery;
    private readonly IAssignmentCrudService _assignmentCrud;
    private readonly IDeparmentsQueryService _deparments;
    private readonly IPositionsQueryService _positions;
    private readonly IAddressQueryService _addressQuery;
    private readonly IAddressCrudService _addressCrud;

    public EditEmployeeViewModel(
        IEmployeeCrudService employeeCrud
        , IEmployeeQueryService employeeQuery
        , IDeparmentsQueryService deparments
        , IPositionsQueryService positions
        , IAssignmentCrudService assignmentCrud
        , IAddressQueryService addressQuery
        , IAddressCrudService addressCrud
        )
    {
        _employeeCrud = employeeCrud;
        _employeeQuery = employeeQuery;
        _deparments = deparments;
        _positions = positions;
        _assignmentCrud = assignmentCrud;
        _addressQuery = addressQuery;
        _addressCrud = addressCrud;
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
    public Guid AssignmentID { get; set; } = Guid.Empty;

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
        var addressDetails = await _addressQuery.FindAsync(employee.Data.AddressId, token);
        Address = new AddressEditModel(addressDetails.Id, addressDetails.Data);
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
            await _assignmentCrud.ExecuteAsync(new UpdateCommand<Guid, AssignmentData>
            {
                Identity = AssignmentID,
                Data = new AssignmentData
                {
                    EmployeeID = Employee.EmployeeID,
                    DepartmentID = Departments[DepartmentIndex].DepartmentId,
                    PositionID = Positions[PositionIndex].Id,
                    EmploymentType = Employee.EmploymentType
                }}, token);
            Employee.EmployeeData.Address = Address.AddressData;
            Employee.EmployeeData.AddressId = Address.AddressId;
            await _employeeCrud.ExecuteAsync( new UpdateCommand<Guid, EmployeeData>
            {
                Identity = Employee.EmployeeID,
                Data = Employee.EmployeeData
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
