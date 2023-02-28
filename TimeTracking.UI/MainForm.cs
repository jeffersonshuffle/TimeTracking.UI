using TimeTracking.UI.Views;

namespace TimeTracking.UI
{
    public partial class MainForm : Form
    {
        private readonly EmloyeeListForm _emloyeeList;
        private readonly TimeTrackingForm _timeTrackingForm;
        private readonly DepartmentsForm _departmentsForm;
        public MainForm(EmloyeeListForm emloyeeList, TimeTrackingForm timeTrackingForm, DepartmentsForm departmentsForm)
        {
            InitializeComponent();
            _emloyeeList = emloyeeList;
            _timeTrackingForm = timeTrackingForm;
            _departmentsForm= departmentsForm;
        }

        private void buttonEditEmployees_Click(object sender, EventArgs e)
        {
            buttonEditEmployees.Enabled = false;
            _emloyeeList.ShowDialog();
            buttonEditEmployees.Enabled = true;
        }

        private void buttonTimeTracking_Click(object sender, EventArgs e)
        {
            buttonTimeTracking.Enabled = false;
            _timeTrackingForm.ShowDialog();
            buttonTimeTracking.Enabled = true;
        }

        private void buttonDepartments_Click(object sender, EventArgs e)
        {
            buttonTimeTracking.Enabled = false;
            _departmentsForm.ShowDialog();
            buttonTimeTracking.Enabled = true;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Time tracking editor");
        }
    }
}