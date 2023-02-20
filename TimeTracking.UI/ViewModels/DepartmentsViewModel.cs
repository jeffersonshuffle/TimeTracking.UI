using AutoMapper;
using TimeTracking.AppCore;
using TimeTracking.UI.Models;

namespace TimeTracking.UI.ViewModels
{
    internal class DepartmentsViewModel
    {
        private readonly IDeparmentsQueryService _service;
        private readonly IMapper _mapper;
        public DepartmentsViewModel(IDeparmentsQueryService service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }   
        private DepartmentListModel[] _deparments;
        public DepartmentListModel[] Departments => _deparments;
        public Guid SelectedId { get; private set; }
        public async Task Initialize(CancellationToken token = default)
        {
            await LoadDepartments(token);
        }

        private async Task LoadDepartments(CancellationToken token = default)
        {
            var departments = await _service.GetDepartmentsAsync(token);
            _mapper.Map(departments, _deparments);
            SelectedId = _deparments != null ? _deparments[0].DepartmentId : default;
        }
    }
}
