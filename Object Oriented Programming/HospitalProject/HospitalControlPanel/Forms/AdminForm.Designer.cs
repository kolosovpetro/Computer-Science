namespace HospitalControlPanel.Forms
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.YourAccountLabel = new System.Windows.Forms.Label();
            this.EditEmployeeLabel = new System.Windows.Forms.Label();
            this.EditEmployeeIDTextBox = new System.Windows.Forms.TextBox();
            this.UpdateEmpListButton = new System.Windows.Forms.Button();
            this.EmployeeCount = new System.Windows.Forms.Label();
            this.EditEmployeeButton = new System.Windows.Forms.Button();
            this.AddEmployee = new System.Windows.Forms.Button();
            this.EmployeesListGroupBox = new System.Windows.Forms.GroupBox();
            this.EmployeesList = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.EmployeesListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.YourAccountLabel);
            this.groupBox1.Controls.Add(this.EditEmployeeLabel);
            this.groupBox1.Controls.Add(this.EditEmployeeIDTextBox);
            this.groupBox1.Controls.Add(this.UpdateEmpListButton);
            this.groupBox1.Controls.Add(this.EmployeeCount);
            this.groupBox1.Controls.Add(this.EditEmployeeButton);
            this.groupBox1.Controls.Add(this.AddEmployee);
            this.groupBox1.Controls.Add(this.EmployeesListGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administration";
            // 
            // YourAccountLabel
            // 
            this.YourAccountLabel.AutoSize = true;
            this.YourAccountLabel.Location = new System.Drawing.Point(249, 39);
            this.YourAccountLabel.Name = "YourAccountLabel";
            this.YourAccountLabel.Size = new System.Drawing.Size(95, 13);
            this.YourAccountLabel.TabIndex = 9;
            this.YourAccountLabel.Text = "YourAccountLabel";
            // 
            // EditEmployeeLabel
            // 
            this.EditEmployeeLabel.AutoSize = true;
            this.EditEmployeeLabel.Location = new System.Drawing.Point(35, 74);
            this.EditEmployeeLabel.Name = "EditEmployeeLabel";
            this.EditEmployeeLabel.Size = new System.Drawing.Size(132, 13);
            this.EditEmployeeLabel.TabIndex = 6;
            this.EditEmployeeLabel.Text = "Edit Employee Data By ID:";
            // 
            // EditEmployeeIDTextBox
            // 
            this.EditEmployeeIDTextBox.Location = new System.Drawing.Point(34, 100);
            this.EditEmployeeIDTextBox.Name = "EditEmployeeIDTextBox";
            this.EditEmployeeIDTextBox.Size = new System.Drawing.Size(133, 20);
            this.EditEmployeeIDTextBox.TabIndex = 5;
            // 
            // UpdateEmpListButton
            // 
            this.UpdateEmpListButton.Location = new System.Drawing.Point(34, 155);
            this.UpdateEmpListButton.Name = "UpdateEmpListButton";
            this.UpdateEmpListButton.Size = new System.Drawing.Size(133, 23);
            this.UpdateEmpListButton.TabIndex = 4;
            this.UpdateEmpListButton.Text = "Update Employee List";
            this.UpdateEmpListButton.UseVisualStyleBackColor = true;
            this.UpdateEmpListButton.Click += new System.EventHandler(this.UpdateEmpListButton_Click);
            // 
            // EmployeeCount
            // 
            this.EmployeeCount.AutoSize = true;
            this.EmployeeCount.Location = new System.Drawing.Point(323, 100);
            this.EmployeeCount.Name = "EmployeeCount";
            this.EmployeeCount.Size = new System.Drawing.Size(124, 13);
            this.EmployeeCount.TabIndex = 3;
            this.EmployeeCount.Text = "Current Employee Count:";
            // 
            // EditEmployeeButton
            // 
            this.EditEmployeeButton.Location = new System.Drawing.Point(34, 126);
            this.EditEmployeeButton.Name = "EditEmployeeButton";
            this.EditEmployeeButton.Size = new System.Drawing.Size(133, 23);
            this.EditEmployeeButton.TabIndex = 2;
            this.EditEmployeeButton.Text = "Edit Employee Data";
            this.EditEmployeeButton.UseVisualStyleBackColor = true;
            this.EditEmployeeButton.Click += new System.EventHandler(this.EditEmployeeButton_Click);
            // 
            // AddEmployee
            // 
            this.AddEmployee.Location = new System.Drawing.Point(34, 39);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(129, 23);
            this.AddEmployee.TabIndex = 1;
            this.AddEmployee.Text = "Add Employee";
            this.AddEmployee.UseVisualStyleBackColor = true;
            this.AddEmployee.Click += new System.EventHandler(this.AddEmployee_Click);
            // 
            // EmployeesListGroupBox
            // 
            this.EmployeesListGroupBox.Controls.Add(this.EmployeesList);
            this.EmployeesListGroupBox.Location = new System.Drawing.Point(31, 184);
            this.EmployeesListGroupBox.Name = "EmployeesListGroupBox";
            this.EmployeesListGroupBox.Size = new System.Drawing.Size(671, 225);
            this.EmployeesListGroupBox.TabIndex = 0;
            this.EmployeesListGroupBox.TabStop = false;
            this.EmployeesListGroupBox.Text = "Employees List";
            // 
            // EmployeesList
            // 
            this.EmployeesList.Location = new System.Drawing.Point(0, 19);
            this.EmployeesList.Name = "EmployeesList";
            this.EmployeesList.ReadOnly = true;
            this.EmployeesList.Size = new System.Drawing.Size(671, 205);
            this.EmployeesList.TabIndex = 0;
            this.EmployeesList.Text = "";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Control Panel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.EmployeesListGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox EmployeesListGroupBox;
        private System.Windows.Forms.RichTextBox EmployeesList;
        private System.Windows.Forms.Button EditEmployeeButton;
        private System.Windows.Forms.Button AddEmployee;
        private System.Windows.Forms.Label EmployeeCount;
        private System.Windows.Forms.Button UpdateEmpListButton;
        private System.Windows.Forms.TextBox EditEmployeeIDTextBox;
        private System.Windows.Forms.Label EditEmployeeLabel;
        private System.Windows.Forms.Label YourAccountLabel;
    }
}