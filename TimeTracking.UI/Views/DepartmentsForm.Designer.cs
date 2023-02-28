namespace TimeTracking.UI.Views
{
    partial class DepartmentsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.departmentTitle = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.departmentsList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsList)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.departmentsList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.36723F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.68361F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.94916F));
            this.tableLayoutPanel2.Controls.Add(this.departmentTitle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSearch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonNew, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.search, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDetails, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(33, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(545, 136);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // departmentTitle
            // 
            this.departmentTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.departmentTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.departmentTitle.Location = new System.Drawing.Point(3, 86);
            this.departmentTitle.Name = "departmentTitle";
            this.departmentTitle.Size = new System.Drawing.Size(295, 47);
            this.departmentTitle.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSearch.BackgroundImage = global::TimeTracking.UI.Properties.Resources.search;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSearch.Location = new System.Drawing.Point(304, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(144, 62);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.Turquoise;
            this.buttonNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNew.Location = new System.Drawing.Point(454, 3);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(88, 62);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // search
            // 
            this.search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.search.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.search.Location = new System.Drawing.Point(3, 18);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(295, 47);
            this.search.TabIndex = 2;
            // 
            // buttonDetails
            // 
            this.buttonDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDetails.Location = new System.Drawing.Point(304, 71);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(144, 62);
            this.buttonDetails.TabIndex = 4;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // departmentsList
            // 
            this.departmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.departmentsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentsList.Location = new System.Drawing.Point(33, 145);
            this.departmentsList.Name = "departmentsList";
            this.departmentsList.RowHeadersWidth = 51;
            this.departmentsList.RowTemplate.Height = 29;
            this.departmentsList.Size = new System.Drawing.Size(545, 230);
            this.departmentsList.TabIndex = 1;
            this.departmentsList.SelectionChanged += new System.EventHandler(this.departmentsList_SelectionChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonDelete, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonSave, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(33, 381);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(545, 66);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.IndianRed;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.Location = new System.Drawing.Point(3, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(137, 60);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(390, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(152, 60);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // DepartmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DepartmentsForm";
            this.Text = "DepartmentsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsList)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView departmentsList;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonCancel;
        private Button buttonSave;
        private Button buttonSearch;
        private Button buttonNew;
        private TextBox search;
        private TextBox departmentTitle;
        private Button buttonDetails;
        private Button buttonDelete;
    }
}