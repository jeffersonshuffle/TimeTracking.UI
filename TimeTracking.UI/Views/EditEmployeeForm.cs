using System.ComponentModel;
using System.Net.Security;
using TimeTracking.UI.Properties;
using TimeTracking.UI.ViewModels;

namespace TimeTracking.UI.Views
{
    public partial class EditEmployeeForm : Form
    {
        private readonly IEditEmployeeViewModel _viewModel;
        private Action<IEditEmployeeViewModel> _viewModelInitializer = vm => vm.CreateNewEmployee();
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        public EditEmployeeForm(IEditEmployeeViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            photo.Image = Resources.nophoto;
        }

        public void SetViewModelInitialezer(Action<IEditEmployeeViewModel> initializer) 
        {
            if (initializer == null) return;
            _viewModelInitializer = initializer; 
        }

        protected async override void OnLoad(EventArgs e)
        {
            await _viewModel.Initialize(_cancellationTokenSource.Token);
            BindViewModel();
            ResetCTS();
            base.OnLoad(e);
        }

        private void ResetCTS()
        {
            if (!_cancellationTokenSource.TryReset())
            {
                _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            }
        }

        private void BindViewModel()
        {
            ClearBindings(this);
            BindComboBox(comboPositions, _viewModel.GetPositionNames());
            _viewModel.PositionIndex = comboPositions.SelectedIndex;
            comboPositions.SelectedIndexChanged += (o, e) =>
            {
                _viewModel.PositionIndex = comboPositions.SelectedIndex;
            };
            BindComboBox(comboDepartments, _viewModel.GetDepartmentNames());
            _viewModel.DepartmentIndex = comboDepartments.SelectedIndex;
            comboDepartments.SelectedIndexChanged += (o, e) =>
            {
                _viewModel.DepartmentIndex = comboDepartments.SelectedIndex;
            };
            BindProperties();
        }

        private void BindProperties()
        {
            ClearBindings(this);
            _viewModelInitializer?.Invoke(_viewModel);
            birthDate.Value = DateTime.Now - 18 * TimeSpan.FromDays(365);
            firstName.DataBindings.Add("Text", _viewModel.Employee, nameof(_viewModel.Employee.FirstName));
            lastName.DataBindings.Add("Text", _viewModel.Employee, nameof(_viewModel.Employee.LastName));
            birthDate.DataBindings.Add("Value", _viewModel.Employee, nameof(_viewModel.Employee.BirthDate));
            photo.DataBindings.Add("Image", _viewModel.Employee, nameof(_viewModel.Employee.Photo));
            city.DataBindings.Add("Text", _viewModel.Address, nameof(_viewModel.Address.City));
            street.DataBindings.Add("Text", _viewModel.Address, nameof(_viewModel.Address.Street));
            house.DataBindings.Add("Text", _viewModel.Address, nameof(_viewModel.Address.House));
            appartment.DataBindings.Add("Text", _viewModel.Address, nameof(_viewModel.Address.Appartment));
            remote.DataBindings.Add("Checked", _viewModel.Employee, nameof(_viewModel.Employee.EmploymentType));
        }

        protected override void OnClosed(EventArgs e)
        {
            ClearBindings(this);
            ClearComboBox(comboDepartments);
            ClearComboBox(comboPositions);
            _viewModel.Clear();
            base.OnClosed(e);
        }

        private void RemoveBindings(Control ctrl)
        {
            if (ctrl == null) return;
            foreach (Control c in ctrl.Controls)
            {
                for (var i = 0; i < c.DataBindings.Count; i++)
                {
                    c.DataBindings.Remove(c.DataBindings[i]);
                }
                RemoveBindings(c);
            }
        }

        private void ClearBindings(Control ctrl)
        {
            if (ctrl == null) return;
            Binding[] bindings = new Binding[ctrl.DataBindings.Count];
            ctrl.DataBindings.CopyTo(bindings, 0);
            ctrl.DataBindings.Clear();

            foreach (Binding binding in bindings)
            {
                TypeDescriptor.Refresh(binding.DataSource);
            }
            foreach (Control cc in ctrl.Controls)
            {
                ClearBindings(cc);
            }
        }

        private void BindComboBox(ComboBox box, IEnumerable<string> names)
        {
            foreach (var n in names)
            {
                box.Items.Add(n);
            }
            box.SelectedIndex = 0;            
        }

        private void ClearComboBox(ComboBox box)
        {
            box.Items.Clear();
            box.SelectedIndex = -1;
        }


        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        photo.Image = Image.FromFile(openFileDialog.FileName);
                        _viewModel.Employee.Photo = photo.Image;
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Error occured!"); }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            var result = await _viewModel.SaveOrUpdateAssignmentAsync(_cancellationTokenSource.Token);
            ResetCTS();
            if (result)
            {
                MessageBox.Show("Entity Saved");
            }
            else
            {
                MessageBox.Show("Error occured");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
