namespace TimeTracking.UI.Views
{
    partial class EmployeeCalendarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dayOfWeek = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.comboMarks = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dayOfWeek
            // 
            this.dayOfWeek.AutoSize = true;
            this.dayOfWeek.Location = new System.Drawing.Point(12, 0);
            this.dayOfWeek.Name = "dayOfWeek";
            this.dayOfWeek.Size = new System.Drawing.Size(0, 20);
            this.dayOfWeek.TabIndex = 0;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(12, 29);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(0, 20);
            this.date.TabIndex = 1;
            // 
            // comboMarks
            // 
            this.comboMarks.FormattingEnabled = true;
            this.comboMarks.Location = new System.Drawing.Point(12, 52);
            this.comboMarks.Name = "comboMarks";
            this.comboMarks.Size = new System.Drawing.Size(69, 28);
            this.comboMarks.TabIndex = 2;
            // 
            // EmployeeCalendarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboMarks);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dayOfWeek);
            this.Name = "EmployeeCalendarControl";
            this.Size = new System.Drawing.Size(87, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label dayOfWeek;
        private Label date;
        private ComboBox comboMarks;
    }
}
