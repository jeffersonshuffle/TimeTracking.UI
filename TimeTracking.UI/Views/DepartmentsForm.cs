using TimeTracking.DTOs;
using TimeTracking.UI.ViewModels;
using static TimeTracking.UI.Views.DetailsForm;

namespace TimeTracking.UI.Views
{
    public partial class DepartmentsForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource= new CancellationTokenSource(TimeSpan.FromSeconds(20));
                
        private readonly IDepartmentsViewModel _viewModel;
        public DepartmentsForm(IDepartmentsViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            base.OnLoad(e);
            await ReloadAsync();
            departmentTitle.DataBindings.Add(new Binding( "Text", _viewModel.Department, nameof(_viewModel.Department.Name)));
            departmentsList.ResumeLayout(false);
        }

        protected async Task ReloadAsync()
        {
            ResetCTS();
            await _viewModel.Initialize(_cancellationTokenSource.Token);            
            InitializeList();
            departmentsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ResetCTS()
        {
            if (!_cancellationTokenSource.TryReset())
            {
                _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            }
        }

        private void InitializeList()
        {
            departmentsList.DataSource = null;
            departmentsList.SuspendLayout();
            departmentsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            departmentsList.MultiSelect = false;
            foreach (var prop in typeof(DepartmentListItem).GetProperties())
            {
                var c = new DataGridViewTextBoxColumn();
                c.DataPropertyName = prop.Name;
                c.Name = prop.Name;
                departmentsList.Columns.Add(c);
            }
            departmentsList.DataSource = _viewModel.Departments.ToArray();
            if (departmentsList.Rows.Count > 0)
            {
                departmentsList.Rows[0].Selected = true;
                _viewModel.SelectedIndex = 0;
            }
        }

        private async void departmentsList_SelectionChanged(object sender, EventArgs e)
        {
            if (departmentsList.SelectedCells.Count > 0)
            {
                _viewModel.SelectedIndex = departmentsList.SelectedCells[0].RowIndex;
            }
            ResetCTS();
            await _viewModel.SetDepartmentAsync(_cancellationTokenSource.Token);
            departmentTitle.Text = _viewModel.Department.Name;
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            using var form = new DetailsForm();
            EventHandler<DescriptionChangedEventArgs> handler =
                (o, e) => _viewModel.Department.Description = e.Description;
            form.DescriptionChanged += handler;
            form.Description = _viewModel.Department.Description;
            form.ShowDialog();
            form.DescriptionChanged -= handler;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _viewModel.SetNewDepartment();
            departmentTitle.Text = _viewModel.Department.Name;
            _viewModel.SelectedIndex = -1;
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            ResetCTS();
            _viewModel.Department.Name = departmentTitle.Text;
            await _viewModel.SaveAsync(_cancellationTokenSource.Token);
            _viewModel.SelectedIndex = 0;
            await ReloadAsync();
        }

        private async  void buttonDelete_Click(object sender, EventArgs e)
        {
            ResetCTS();
            await _viewModel.DeleteAsync(_cancellationTokenSource.Token);
            _viewModel.SelectedIndex = 0;
            await ReloadAsync();
        }
    }
}
