using TimeTracking.Abstractions;
using TimeTracking.AppCore;
using TimeTracking.AppCore.Addresses;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    internal class EmployeeListViewModel : IEmployeeListViewModel, ISelfRegisteredService<IEmployeeListViewModel>
    {
        private readonly IAssignedEmployeeQueryService _assignedEmployeeQuery;
        private readonly IEmployeeCrudService _employeeCrud;
        private readonly IEmployeeQueryService _employeeQuery;
        private readonly IAddressCrudService _addressCrud;
        public EmployeeListViewModel(IAssignedEmployeeQueryService assignedEmployeeQuery, IEmployeeCrudService employeeCrud
            , IEmployeeQueryService employeeQuery, IAddressCrudService addressCrud)
        {
            _assignedEmployeeQuery = assignedEmployeeQuery;
            _employeeCrud = employeeCrud;
            _employeeQuery = employeeQuery;
            _addressCrud= addressCrud;
        }
        public int SelectedIndex { get; set; }
        public AssignedEmployeeListItem[] EmployeeList { get; private set; }
        public IEnumerable<EmployeeListItemModel> GetList()
        {
            foreach (var item in EmployeeList)
            {
                yield return new EmployeeListItemModel(item);
            }
        }
        public async Task InitializeAsync(CancellationToken token = default)
        {
            EmployeeList = await _assignedEmployeeQuery.ListAsync(token);
            SelectedIndex = 0;
        }

        public async Task SearchAsync(string searchPattern, CancellationToken token = default)
        {
            EmployeeList = await _assignedEmployeeQuery.HandleAsync(new Shared.Queries.Query<Shared.Specifications.SearchStringSpecification> 
            {
                Specification = new Shared.Specifications.SearchStringSpecification { SearchPattern = searchPattern }
            },token);
            SelectedIndex = 0;
        }

        public async Task<bool> DeleteAsync( CancellationToken token = default)
        {
            try
            {
                var details = await _employeeQuery.FindAsync(EmployeeList[SelectedIndex].EmployeeID, token);
                await _addressCrud.ExecuteAsync(new DeleteCommand<int> { Identity = details.Data.AddressId }, token);
                await _employeeCrud.ExecuteAsync(new DeleteCommand<Guid> { Identity = EmployeeList[SelectedIndex].EmployeeID }, token);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
