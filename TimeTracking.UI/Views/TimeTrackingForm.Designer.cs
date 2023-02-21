namespace TimeTracking.UI.Views
{
    partial class TimeTrackingForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listDepartments = new System.Windows.Forms.ListBox();
            this.tabMonths = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listDepartments
            // 
            this.listDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDepartments.FormattingEnabled = true;
            this.listDepartments.ItemHeight = 20;
            this.listDepartments.Location = new System.Drawing.Point(3, 23);
            this.listDepartments.Name = "listDepartments";
            this.listDepartments.ScrollAlwaysVisible = true;
            this.listDepartments.Size = new System.Drawing.Size(473, 541);
            this.listDepartments.TabIndex = 0;
            // 
            // tabMonths
            // 
            this.tabMonths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMonths.Location = new System.Drawing.Point(0, 0);
            this.tabMonths.Name = "tabMonths";
            this.tabMonths.SelectedIndex = 0;
            this.tabMonths.Size = new System.Drawing.Size(959, 567);
            this.tabMonths.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 21);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMonths);
            this.splitContainer1.Size = new System.Drawing.Size(1442, 567);
            this.splitContainer1.SplitterDistance = 479;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listDepartments);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 567);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Departments";
            // 
            // TimeTrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 612);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TimeTrackingForm";
            this.Text = "TimeTrackingForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listDepartments;
        private SplitContainer splitContainer1;
        
        private GroupBox groupBox1;
        private TabControl tabMonths;
    }
}