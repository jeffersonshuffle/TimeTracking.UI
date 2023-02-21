using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracking.UI.ViewModels;

namespace TimeTracking.UI.Views
{
    public partial class TimeTrackingForm : Form
    {
        private CancellationTokenSource _cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        private readonly IDepartmentsViewModel _viewModel;
        public TimeTrackingForm(IDepartmentsViewModel viewModel)
        {
            _viewModel = viewModel;
            this.SuspendLayout();
            InitializeComponent();
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.AutoSize = true;
            listDepartments.DisplayMember = "Departments";
            InitMonths();
            tabMonths.Dock = DockStyle.Fill;            
            tabMonths.Dock = DockStyle.Fill;
            this.ResumeLayout(false);
            this.tabMonths.ResumeLayout(false);
        }

        protected async override void OnLoad(EventArgs e)
        {
            await InitDepartment(_cts.Token);
            if (!_cts.TryReset())
            {
                _cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            }
            base.OnLoad(e);
        }

        private async Task InitDepartment(CancellationToken token = default)
        {
            await _viewModel.Initialize(token);
            foreach (var d in _viewModel.Departments)
            {
                listDepartments.Items.Add(d.Name);
            }
            listDepartments.SelectedIndex = 0;
            _viewModel.SelectedIndex = listDepartments.SelectedIndex;
            listDepartments.SelectedIndexChanged += async (o, e) => 
            {
                _viewModel.SelectedIndex = listDepartments.SelectedIndex;
                //MessageBox.Show($" SelectedIndex {_viewModel.SelectedIndex} ");
            };
        }


        private void InitMonths()
        {
            string[] months = {"January", "February", "March", "April", "May", "June", "Jule", "August", "September", "October", "November", "December"};
            for (var i = 0; i < 12; i++)
            {
                var tabPage = new TabPage { Text = $"{months[i]}" };                
                tabPage.Size = new System.Drawing.Size(256, 214);
                tabPage.TabIndex = i;

                var calendar = new EmployeeCalendarControl();
                calendar.Dock = DockStyle.Fill;
                tabPage.Controls.Add(calendar);                
                tabMonths.TabPages.Add(tabPage);
            } 
        }
    }
}
