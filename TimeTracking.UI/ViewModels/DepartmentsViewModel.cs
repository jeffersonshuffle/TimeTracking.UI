using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.AppCore;
using TimeTracking.DTOs;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    internal class DepartmentsViewModel : IDepartmentsViewModel, ISelfRegisteredService<IDepartmentsViewModel>
    {
        private readonly IDeparmentsQueryService _service;
        private readonly IMapper _mapper;
        public DepartmentsViewModel(IDeparmentsQueryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        private DepartmentListItem[] _deparments;
        public DepartmentListItem[] Departments => _deparments;
        public int SelectedIndex { get; set; }
        public async Task Initialize(CancellationToken token = default)
        {
            await LoadDepartments(token);            
        }

        private async Task LoadDepartments(CancellationToken token = default)
        {
            _deparments = await _service.GetDepartmentsAsync(token);
        }
    }
}
