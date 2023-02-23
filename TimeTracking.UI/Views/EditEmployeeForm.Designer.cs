using System.Windows.Forms;

namespace TimeTracking.UI.Views
{
    partial class EditEmployeeForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.appartment = new System.Windows.Forms.TextBox();
            this.house = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.city = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.birthDate = new System.Windows.Forms.DateTimePicker();
            this.comboDepartments = new System.Windows.Forms.ComboBox();
            this.comboPositions = new System.Windows.Forms.ComboBox();
            this.remote = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.photo = new System.Windows.Forms.PictureBox();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(556, 673);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.appartment, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.house, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.street, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.city, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.firstName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.birthDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboDepartments, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboPositions, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.remote, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 405);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // appartment
            // 
            this.appartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appartment.Location = new System.Drawing.Point(169, 243);
            this.appartment.Name = "appartment";
            this.appartment.Size = new System.Drawing.Size(384, 27);
            this.appartment.TabIndex = 1;
            this.appartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // house
            // 
            this.house.Dock = System.Windows.Forms.DockStyle.Fill;
            this.house.Location = new System.Drawing.Point(169, 203);
            this.house.Name = "house";
            this.house.Size = new System.Drawing.Size(384, 27);
            this.house.TabIndex = 1;
            // 
            // street
            // 
            this.street.Dock = System.Windows.Forms.DockStyle.Fill;
            this.street.Location = new System.Drawing.Point(169, 163);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(384, 27);
            this.street.TabIndex = 1;
            // 
            // city
            // 
            this.city.Dock = System.Windows.Forms.DockStyle.Fill;
            this.city.Location = new System.Drawing.Point(169, 123);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(384, 27);
            this.city.TabIndex = 1;
            // 
            // lastName
            // 
            this.lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastName.Location = new System.Drawing.Point(169, 43);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(384, 27);
            this.lastName.TabIndex = 1;
            // 
            // firstName
            // 
            this.firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstName.Location = new System.Drawing.Point(169, 3);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(384, 27);
            this.firstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 40);
            this.label9.TabIndex = 7;
            this.label9.Text = "Position";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 40);
            this.label8.TabIndex = 6;
            this.label8.Text = "Department";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 40);
            this.label7.TabIndex = 5;
            this.label7.Text = "Appartment";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 40);
            this.label6.TabIndex = 4;
            this.label6.Text = "House";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 40);
            this.label5.TabIndex = 3;
            this.label5.Text = "Street";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 40);
            this.label4.TabIndex = 2;
            this.label4.Text = "City";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Birth Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Last Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // birthDate
            // 
            this.birthDate.AllowDrop = true;
            this.birthDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.birthDate.Location = new System.Drawing.Point(169, 83);
            this.birthDate.Name = "birthDate";
            this.birthDate.Size = new System.Drawing.Size(384, 27);
            this.birthDate.TabIndex = 9;
            // 
            // comboDepartments
            // 
            this.comboDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboDepartments.FormattingEnabled = true;
            this.comboDepartments.Location = new System.Drawing.Point(169, 283);
            this.comboDepartments.Name = "comboDepartments";
            this.comboDepartments.Size = new System.Drawing.Size(384, 28);
            this.comboDepartments.TabIndex = 10;
            // 
            // comboPositions
            // 
            this.comboPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboPositions.FormattingEnabled = true;
            this.comboPositions.Location = new System.Drawing.Point(169, 323);
            this.comboPositions.Name = "comboPositions";
            this.comboPositions.Size = new System.Drawing.Size(384, 28);
            this.comboPositions.TabIndex = 11;
            // 
            // remote
            // 
            this.remote.AutoSize = true;
            this.remote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remote.Location = new System.Drawing.Point(169, 363);
            this.remote.Name = "remote";
            this.remote.Size = new System.Drawing.Size(384, 39);
            this.remote.TabIndex = 12;
            this.remote.Text = "remote";
            this.remote.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.photo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddPhoto, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonCancel, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(556, 264);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // photo
            // 
            this.photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photo.Location = new System.Drawing.Point(281, 3);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(272, 126);
            this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo.TabIndex = 0;
            this.photo.TabStop = false;
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddPhoto.Location = new System.Drawing.Point(3, 3);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(272, 126);
            this.buttonAddPhoto.TabIndex = 1;
            this.buttonAddPhoto.Text = "Add Photo";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Lime;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(3, 135);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(272, 126);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Red;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(281, 135);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(272, 126);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // EditEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 673);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditEmployeeForm";
            this.Text = "EditEmployeeForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker birthDate;
        private TextBox firstName;
        private TextBox appartment;
        private TextBox house;
        private TextBox street;
        private TextBox city;
        private TextBox lastName;
        private ComboBox comboDepartments;
        private ComboBox comboPositions;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox photo;
        private Button buttonAddPhoto;
        private Button buttonSave;
        private Button buttonCancel;
        private CheckBox remote;
    }
}