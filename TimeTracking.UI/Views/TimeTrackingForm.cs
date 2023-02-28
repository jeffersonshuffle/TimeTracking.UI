using AutoMapper;
using TimeTracking.AppCore;
using TimeTracking.AppCore.DayMarks;
using TimeTracking.AppCore.Employees;
using TimeTracking.DataModels.Organisation;
using TimeTracking.DTOs;
using TimeTracking.Shared.Commands;
using TimeTracking.Shared.DTOs;
using TimeTracking.Shared.Queries;
using TimeTracking.Shared.Specifications;

namespace TimeTracking.UI.Views;

public partial class TimeTrackingForm : Form
{
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    private readonly IDeparmentsQueryService _deparmentsQuery;
    private readonly IEmployeeByDepartmentQueryService _employeeQuery;
    private readonly IDayMarksQueryService _dayMarksQuery;
    private readonly IEmployeeCalendarItemQueryService _calendarQuery;
    private readonly IEmployeeCalendarItemCrudService _calendarCrud;
    private readonly IMapper _mapper;
    public TimeTrackingForm(IDeparmentsQueryService deparmentsQuery
        , IEmployeeByDepartmentQueryService employeeQuery
        , IDayMarksQueryService dayMarksQuery
        , IEmployeeCalendarItemQueryService calendarQuery 
        , IEmployeeCalendarItemCrudService calendarCrud
        , IMapper mapper)
    {
        _deparmentsQuery = deparmentsQuery;
        _employeeQuery = employeeQuery;
        _dayMarksQuery = dayMarksQuery;
        _calendarQuery = calendarQuery;
        _calendarCrud= calendarCrud;
        _mapper = mapper;
        this.SuspendLayout();
        InitializeComponent();
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.AutoSize = true;
        listDepartments.DisplayMember = "Departments";
        this.button2.Click += async (o, e) => await this.button2_Click(o, e);
        this.button1.Click += async (o, e) => await this.button1_Click(o, e);
        this.buttonSave.Click += async (o, e) =>
        {
            buttonSave.Enabled = false;
            await SaveCalendar();
            buttonSave.Enabled = true;
        };
        InitMonths();
        this.ResumeLayout(false);
    }    

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        listDepartments.Items.Clear();
        listCalendar.Items.Clear();
        listCalendar.Controls.Clear();
    }

    protected async override void OnLoad(EventArgs e)
    {            
        ResetCTS();
        DayMarks = await _dayMarksQuery.ListAllAsync(_cancellationTokenSource.Token);
        Departments = await _deparmentsQuery.GetDepartmentsAsync(_cancellationTokenSource.Token);
        await InitDaymarks();
        await InitDepartment();
        base.OnLoad(e);
    }

    private List<EmployeeCalendarItemDetails> CalendarItems { get; set; } = new List<EmployeeCalendarItemDetails>();
    private EmployeeByDepartmentDetails[] Employees { get; set; }
    private DepartmentListItem[] Departments { get; set; }
    private DayMarkDetails[] DayMarks { get; set; }
    private int SelectedIndex { get; set; }

    private async Task InitDaymarks()
    {
        ResetCTS();
        DayMarks = await _dayMarksQuery.ListAllAsync(_cancellationTokenSource.Token);
    }
    private async Task InitDepartment()
    {            
        foreach (var d in Departments)
        {
            listDepartments.Items.Add(d.Name);
        }
        listDepartments.SelectedIndex = 0;
        SelectedIndex = listDepartments.SelectedIndex;
        listDepartments.SelectedIndexChanged += async (o, e) => 
        {
            SelectedIndex = listDepartments.SelectedIndex;
            listDepartments.Enabled = false;
            await LoadEmployeesAndCalendar();
            listDepartments.Enabled = true;
        };
        listDepartments.Enabled = false;
        await LoadEmployeesAndCalendar();
        listDepartments.Enabled = true;
    }

    private async Task LoadEmployeesAndCalendar()
    {
        ResetCTS();
        Employees = await _employeeQuery.HandleAsync(
            new Query<Guid> { Specification = Departments[SelectedIndex].DepartmentId }
            , _cancellationTokenSource.Token);
        BindEmployees();
    }

    private async Task LoadCalendarFor(Guid EmployeeID) 
    {
        CalendarItems.Clear();
        ResetCTS();
        var calendar = await _calendarQuery.HandleAsync(new FilterByEmployeeWithMonthSpecification
        {
            EmployeeID = EmployeeID,
            Month = monthNumber + 1
        }, _cancellationTokenSource.Token);

        if (calendar == null || calendar.Length == 0)
        {
            var days = DateTime.DaysInMonth(DateTime.Now.Year, monthNumber + 1);
            calendar = new EmployeeCalendarItemDetails[days];
            for (var d = 0; d < days; d++)
            {
                calendar[d] = new EmployeeCalendarItemDetails
                {
                    Date = new DateTime(DateTime.Now.Year, monthNumber + 1, d + 1),
                    EmployeeID = EmployeeID,
                    DayMarkID = 1
                };
            }
        }
        CalendarItems.AddRange(calendar);
        BindCalendar();
    }

    void BindCalendar()     
    { 
        listCalendar.SuspendLayout();
        listCalendar.Controls.Clear();
        var count = 0;
        var x = 10;
        var y = 10;
        var step = 100;
        foreach (var c in CalendarItems)
        {
            var ctrl = new EmployeeCalendarControl(DayMarks, c);
            ctrl.Location = new Point(x , y);
            count++;
            if (count == 7)
            {
                count = 0;
                y += step;
                x = 10 - step;
            }
            x += step;
            //ctrl.CalendarItemChanged += (o, e) =>
            //{
            //    var idx = CalendarItems.FindIndex(x => x.EmployeeID.Equals(e.Data.EmployeeID) && x.Date.Equals(e.Data.Date) );
            //    CalendarItems[idx].DayMarkID = e.Data.DayMarkID;
            //};
            listCalendar.Controls.Add(ctrl);
        }
    }
    
    class EmployeeList
    {
        public Guid EmployeeID { get; set; }
        public string Name { get; set; }
    }

    private List<EmployeeList> List { get; set; } = new List<EmployeeList>();
    private async Task BindEmployees()
    {
        employeesList.Items.Clear();
        employeesList.SuspendLayout();
        employeesList.DisplayMember = nameof(EmployeeList.Name);
        employeesList.BeginUpdate();

        employeesList.Items.AddRange(Employees);
        employeesList.EndUpdate();
        employeesList.SelectedIndex = 0;
        employeesList.SelectedIndexChanged += async (o, e) =>
        {
            employeesList.Enabled = false;
            ResetCTS();
            await LoadCalendarFor(Employees[employeesList.SelectedIndex].EmployeeID);
            employeesList.Enabled = true;
        };
        employeesList.Enabled = false;
        await LoadCalendarFor(Employees[employeesList.SelectedIndex].EmployeeID);
        employeesList.Enabled = true;
    }

    private void ResetCTS()
    {
        if (!_cancellationTokenSource.TryReset())
        {
            _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        }
    }

    private string[] _months = { "January", "February", "March", "April", "May", "June", "Jule", "August", "September", "October", "November", "December" };
    private int monthNumber = 0;
    private void InitMonths()
    {
        monthNumber = 0;
        months.Text = _months[monthNumber];
    }

    private async Task button1_Click(object sender, EventArgs e)
    {
        monthNumber++;
        if (monthNumber > 11)  monthNumber = 0;
        months.Text = _months[monthNumber];
        ResetCTS();
        employeesList.Enabled = false;
        await LoadCalendarFor(Employees[employeesList.SelectedIndex].EmployeeID);
        employeesList.Enabled = true;
    }

    private async Task button2_Click(object sender, EventArgs e)
    {
        monthNumber--;
        if (monthNumber < 0) monthNumber = 11;
        months.Text = _months[monthNumber];
        ResetCTS();
        employeesList.Enabled = false;
        await LoadCalendarFor(Employees[employeesList.SelectedIndex].EmployeeID);
        employeesList.Enabled = true;

    }

    private async Task SaveCalendar()
    {
        ResetCTS();
        foreach (EmployeeCalendarControl c in listCalendar.Controls)
        {
            if (c?.Data == null) continue;
            var data = new EmployeeCalendarItemData();
            _mapper.Map(c.Data, data);
            if (c.Data.Id == 0)
            {
                await _calendarCrud.ExecuteAsync(
                    new Shared.Commands.CreateCommand<EmployeeCalendarItemData> { Data = data }
                    , _cancellationTokenSource.Token);
            }
            else
            {
                await _calendarCrud.ExecuteAsync(
                    new UpdateCommand<int, EmployeeCalendarItemData> { Identity = c.Data.Id, Data = data }
                    , _cancellationTokenSource.Token);
            }
        }
    }
}
