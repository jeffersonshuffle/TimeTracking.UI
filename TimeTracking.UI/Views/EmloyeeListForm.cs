using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracking.AppCore;
using TimeTracking.Shared.DTOs;
using TimeTracking.UI.Models;
using TimeTracking.UI.ViewModels;

namespace TimeTracking.UI.Views
{
    public partial class EmloyeeListForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource= new CancellationTokenSource(TimeSpan.FromSeconds(20));
        private void ResetCTS()
        {
            if (!_cancellationTokenSource.TryReset())
            {
                _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            }
        }
        private readonly IEmployeeListViewModel _viewModel;
        private readonly EditEmployeeForm _editEmployeeForm;
        public EmloyeeListForm(IEmployeeListViewModel viewModel, EditEmployeeForm editEmployeeForm)
        {
            _viewModel = viewModel;
            _editEmployeeForm = editEmployeeForm;
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            base.OnLoad(e);
            await InitializeListAsync(_cancellationTokenSource.Token);
        }

        private async Task InitializeListAsync(CancellationToken token = default) 
        {
            employeeList.SuspendLayout();
            employeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeeList.MultiSelect = false;
            employeeList.RowTemplate.Height = 80;
            
            await _viewModel.InitializeAsync(token);
            var photoName = typeof(EmployeeListItemModel).GetProperty("Photo")?.Name;
            var column = new DataGridViewImageColumn();
            column.Width = 80;
            column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            column.DataPropertyName = "Photo";
            column.Name = "Photo";
            employeeList.Columns.Add(column);
            foreach (var prop in typeof(EmployeeListItemModel).GetProperties())
            {
                if (prop.Name != photoName)
                {
                    if (prop.Name == nameof(EmployeeListItemModel.IsRemote))
                    {
                        var c = new DataGridViewCheckBoxColumn();
                        c.DataPropertyName = nameof(EmployeeListItemModel.IsRemote);
                        c.Name = nameof(EmployeeListItemModel.IsRemote);
                        employeeList.Columns.Add(c);
                    }
                    else
                    {
                        var c = new DataGridViewTextBoxColumn();
                        c.DataPropertyName = prop.Name;
                        c.Name = prop.Name;
                        employeeList.Columns.Add(c);
                    }
                }
            }
            employeeList.DataSource = _viewModel.GetList().ToArray();
            if (employeeList.Rows.Count > 0) employeeList.Rows[0].Selected = true;
            employeeList.ResumeLayout(false);
        }

        private void SizeAllRows(Object sender, EventArgs e)
        {
            employeeList.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
        private void employeeList_SelectionChanged(object sender, EventArgs e)
        {
            if (employeeList.SelectedCells.Count > 0)
            {
                _viewModel.SelectedIndex = employeeList.SelectedCells[0].RowIndex;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _editEmployeeForm.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (await _viewModel.DeleteAsync(_cancellationTokenSource.Token))
            {
                MessageBox.Show("Successfully Deleted");
            }
            else
            {
                MessageBox.Show("Error!");
            }
            ResetCTS();
            ClearBindings(this);
            await InitializeListAsync(_cancellationTokenSource.Token);
            ResetCTS(); 
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
    }
}
