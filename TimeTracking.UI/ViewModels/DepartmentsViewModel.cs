using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.AppCore;
using TimeTracking.DTOs;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    internal class DepartmentsViewModel : IDepartmentsViewModel, ISelfRegisteredService<IDepartmentsViewModel>
    {
        private readonly IDeparmentsQueryService _service;
        private readonly IDeparmentsCrudService _deparmentsCrud;
        private readonly IMapper _mapper;
        public DepartmentsViewModel(IDeparmentsQueryService service, IDeparmentsCrudService deparmentsCrud, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _deparmentsCrud = deparmentsCrud;
        }

        private DepartmentListItem[] _deparments;
        public DepartmentListItem[] Departments => _deparments;

        public DepartmentEditModel Department { get; set; }

        public void SetNewDepartment()
        {
            Department = new DepartmentEditModel(Guid.Empty, new Shared.DTOs.DepartmentData());
        }

        public async Task SetDepartmentAsync(CancellationToken token = default)
        {
            var details = await _service.FindAsync(Departments[SelectedIndex].DepartmentId, token);
            Department = new DepartmentEditModel(details.ID, details.Data);
        }
        public void SelectedIndexChanged()
        {
            SetDepartmentAsync().GetAwaiter().GetResult();
        }
        public int SelectedIndex { get; set; } = 0;
        public async Task Initialize(CancellationToken token = default)
        {
            await LoadAsync(token);
            if (Departments?.Length > 0)
            {                
                await SetDepartmentAsync(token);
            }
            else
            {
                Department = new DepartmentEditModel(new Shared.DTOs.DepartmentData());
            }
        }

        public async Task LoadAsync(CancellationToken token = default)
        {
            _deparments = await _service.GetDepartmentsAsync(token);
            if (_deparments?.Length > 0)
            {
                var details = await _service.FindAsync(_deparments[0].DepartmentId, token);
                Department = new DepartmentEditModel(details.ID, details.Data);
            }
        }

        public async Task DeleteAsync(CancellationToken token = default)
        {
            if (Department.DepartmentID == Guid.Empty) return;
            await _deparmentsCrud.ExecuteAsync(new DeleteCommand<Guid> { Identity = Department.DepartmentID });
        }

        public async Task SaveAsync(CancellationToken token = default)
        {
            if (Department.DepartmentID == Guid.Empty)
            {
                await _deparmentsCrud.ExecuteAsync(new NewDepartmentCommand
                {
                    New = Department.DepartmentData
                }, token);
            }
            else
            {
                await _deparmentsCrud.ExecuteAsync(new UpdateCommand<Guid, DepartmentData>
                {
                    Identity = Department.DepartmentID,
                    Data = Department.DepartmentData 
                }, token);
            }
        }
    }
}
