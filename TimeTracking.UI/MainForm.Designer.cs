namespace TimeTracking.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEditEmployees = new System.Windows.Forms.Button();
            this.buttonTimeTracking = new System.Windows.Forms.Button();
            this.buttonDepartments = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonEditEmployees, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTimeTracking, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDepartments, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAbout, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonEditEmployees
            // 
            this.buttonEditEmployees.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonEditEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditEmployees.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEditEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonEditEmployees.Image = global::TimeTracking.UI.Properties.Resources.employee;
            this.buttonEditEmployees.Location = new System.Drawing.Point(316, 3);
            this.buttonEditEmployees.Name = "buttonEditEmployees";
            this.buttonEditEmployees.Size = new System.Drawing.Size(308, 219);
            this.buttonEditEmployees.TabIndex = 1;
            this.buttonEditEmployees.Text = "Edit Employees";
            this.buttonEditEmployees.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEditEmployees.UseVisualStyleBackColor = false;
            this.buttonEditEmployees.Click += new System.EventHandler(this.buttonEditEmployees_Click);
            // 
            // buttonTimeTracking
            // 
            this.buttonTimeTracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonTimeTracking.BackgroundImage = global::TimeTracking.UI.Properties.Resources.tt;
            this.buttonTimeTracking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTimeTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTimeTracking.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonTimeTracking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonTimeTracking.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonTimeTracking.Location = new System.Drawing.Point(3, 228);
            this.buttonTimeTracking.Name = "buttonTimeTracking";
            this.buttonTimeTracking.Size = new System.Drawing.Size(307, 219);
            this.buttonTimeTracking.TabIndex = 2;
            this.buttonTimeTracking.Text = "Time Tracking";
            this.buttonTimeTracking.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.buttonTimeTracking.UseVisualStyleBackColor = false;
            this.buttonTimeTracking.Click += new System.EventHandler(this.buttonTimeTracking_Click);
            // 
            // buttonDepartments
            // 
            this.buttonDepartments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonDepartments.BackgroundImage = global::TimeTracking.UI.Properties.Resources.departments;
            this.buttonDepartments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDepartments.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDepartments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonDepartments.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDepartments.Location = new System.Drawing.Point(316, 228);
            this.buttonDepartments.Name = "buttonDepartments";
            this.buttonDepartments.Size = new System.Drawing.Size(308, 219);
            this.buttonDepartments.TabIndex = 3;
            this.buttonDepartments.Text = "Departments";
            this.buttonDepartments.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonDepartments.UseVisualStyleBackColor = false;
            this.buttonDepartments.Click += new System.EventHandler(this.buttonDepartments_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonAbout.BackgroundImage = global::TimeTracking.UI.Properties.Resources.clock;
            this.buttonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAbout.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAbout.Location = new System.Drawing.Point(3, 3);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(307, 219);
            this.buttonAbout.TabIndex = 4;
            this.buttonAbout.Text = "Time Tracking Editor";
            this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonEditEmployees;
        private Button buttonTimeTracking;
        private Button buttonDepartments;
        private Button buttonAbout;
    }
}