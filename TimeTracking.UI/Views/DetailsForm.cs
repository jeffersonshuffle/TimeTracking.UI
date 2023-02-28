namespace TimeTracking.UI.Views
{
    public partial class DetailsForm : Form
    {
        public class DescriptionChangedEventArgs : EventArgs
        {
            public string Description { get; set; }
        }
        public event EventHandler<DescriptionChangedEventArgs> DescriptionChanged;

        protected virtual void OnDescriptionChanged(DescriptionChangedEventArgs e)
        {
            DescriptionChanged?.Invoke(this, e);
        }
        public DetailsForm()
        {
            InitializeComponent();
            this.Visible = false;
        }

        TaskCompletionSource<DialogResult> _tcs;

        public Task<DialogResult> ShowModalAsync()
        {
            _tcs = new TaskCompletionSource<DialogResult>();

            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.BringToFront();
            return _tcs.Task;
        }

        private void btmCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _tcs.SetResult(DialogResult.Cancel);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _tcs.SetResult(DialogResult.OK);
            this.Visible = false;
        }

        public string Description
        {
            get { return description.Text; }
            set { description.Text = value; }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            OnDescriptionChanged(new DescriptionChangedEventArgs { Description = description.Text });
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
