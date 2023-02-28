using TimeTracking.Shared.DTOs;

namespace TimeTracking.UI.Views;

public class CalendarItemChangedEventArgs : EventArgs
{
    public readonly EmployeeCalendarItemDetails Data;
    public CalendarItemChangedEventArgs(EmployeeCalendarItemDetails data) => Data = data;
}

public partial class EmployeeCalendarControl : UserControl
{
    public EmployeeCalendarControl(DayMarkDetails[] dayMarks, EmployeeCalendarItemDetails data)
    {
        DayMarks = dayMarks.ToArray();
        Data = data;
        InitializeComponent();
    }

    public EventHandler<CalendarItemChangedEventArgs> CalendarItemChanged;

    protected virtual void OnCalendarItemChanged(CalendarItemChangedEventArgs e)
    {
        CalendarItemChanged?.Invoke(this, e);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        comboMarks.DisplayMember = nameof(DayMarkDetails.Short);
        comboMarks.ValueMember = nameof(DayMarkDetails.ID);
        comboMarks.DataSource = DayMarks;
        comboMarks.SelectedIndexChanged += (o, e) =>
        {
            Data.DayMarkID =  (int)comboMarks.SelectedValue;
            //OnCalendarItemChanged(new CalendarItemChangedEventArgs(Data));
        };
        SelectItemByValue(Data.DayMarkID.ToString());
        dayOfWeek.Text = Data.Date.DayOfWeek.ToString();
        date.Text = Data.Date.ToString();
    }

    private void SelectItemByValue( string value)
    {
        for (int i = 0; i < comboMarks.Items.Count; i++)
        {
            var prop = comboMarks.Items[i].GetType().GetProperty(comboMarks.ValueMember);
            if (prop != null && prop.GetValue(comboMarks.Items[i], null).ToString() == value)
            {
                comboMarks.SelectedIndex = i;
                break;
            }
        }
    }
    public DayMarkDetails[] DayMarks { get; set; }
    public EmployeeCalendarItemDetails Data {get; set;}
}
