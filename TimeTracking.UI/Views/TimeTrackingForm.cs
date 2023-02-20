using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracking.UI.Views
{
    public partial class TimeTrackingForm : Form
    {
        public TimeTrackingForm()
        {
            this.SuspendLayout();
            InitializeComponent();
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.AutoSize = true;
            listDepartments.DisplayMember = "Departments";
            listDepartments.Items.Add(new { Name = "Computer 1", Path = "C:\\001" });
            listDepartments.Items.Add(new { Name = "Computer 3", Path = "C:\\002" });
            InitMonths();
            tabMonths.Dock = DockStyle.Fill;
            // select first item just for example
            listDepartments.SelectedIndex = 0;
            tabMonths.Dock = DockStyle.Fill;
            this.ResumeLayout(false);
            this.tabMonths.ResumeLayout(false);
        }

        private void InitMonths()
        {
            string[] months = {"Январь", "February", "March", "April", "May", "June", "Jule", "August", "September", "October", "November", "December"};
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
