namespace HospitalControlPanel.Forms
{
    partial class StaffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffForm));
            this.UpdateEmpListButton = new System.Windows.Forms.Button();
            this.EmployeesListGroupBox = new System.Windows.Forms.GroupBox();
            this.EmployeesList = new System.Windows.Forms.RichTextBox();
            this.EmployeeCount = new System.Windows.Forms.Label();
            this.YourAccountLabel = new System.Windows.Forms.Label();
            this.EmployeesListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateEmpListButton
            // 
            this.UpdateEmpListButton.Location = new System.Drawing.Point(61, 100);
            this.UpdateEmpListButton.Name = "UpdateEmpListButton";
            this.UpdateEmpListButton.Size = new System.Drawing.Size(133, 23);
            this.UpdateEmpListButton.TabIndex = 7;
            this.UpdateEmpListButton.Text = "Update Employee List";
            this.UpdateEmpListButton.UseVisualStyleBackColor = true;
            this.UpdateEmpListButton.UseWaitCursor = true;
            this.UpdateEmpListButton.Click += new System.EventHandler(this.UpdateEmpListButton_Click);
            // 
            // EmployeesListGroupBox
            // 
            this.EmployeesListGroupBox.Controls.Add(this.EmployeesList);
            this.EmployeesListGroupBox.Location = new System.Drawing.Point(58, 129);
            this.EmployeesListGroupBox.Name = "EmployeesListGroupBox";
            this.EmployeesListGroupBox.Size = new System.Drawing.Size(601, 225);
            this.EmployeesListGroupBox.TabIndex = 5;
            this.EmployeesListGroupBox.TabStop = false;
            this.EmployeesListGroupBox.Text = "Employees List";
            this.EmployeesListGroupBox.UseWaitCursor = true;
            // 
            // EmployeesList
            // 
            this.EmployeesList.Location = new System.Drawing.Point(3, 19);
            this.EmployeesList.Name = "EmployeesList";
            this.EmployeesList.ReadOnly = true;
            this.EmployeesList.Size = new System.Drawing.Size(594, 205);
            this.EmployeesList.TabIndex = 0;
            this.EmployeesList.Text = "";
            this.EmployeesList.UseWaitCursor = true;
            // 
            // EmployeeCount
            // 
            this.EmployeeCount.AutoSize = true;
            this.EmployeeCount.Location = new System.Drawing.Point(535, 61);
            this.EmployeeCount.Name = "EmployeeCount";
            this.EmployeeCount.Size = new System.Drawing.Size(124, 13);
            this.EmployeeCount.TabIndex = 6;
            this.EmployeeCount.Text = "Current Employee Count:";
            this.EmployeeCount.UseWaitCursor = true;
            // 
            // YourAccountLabel
            // 
            this.YourAccountLabel.AutoSize = true;
            this.YourAccountLabel.Location = new System.Drawing.Point(63, 27);
            this.YourAccountLabel.Name = "YourAccountLabel";
            this.YourAccountLabel.Size = new System.Drawing.Size(95, 13);
            this.YourAccountLabel.TabIndex = 8;
            this.YourAccountLabel.Text = "YourAccountLabel";
            this.YourAccountLabel.UseWaitCursor = true;
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 450);
            this.Controls.Add(this.YourAccountLabel);
            this.Controls.Add(this.UpdateEmpListButton);
            this.Controls.Add(this.EmployeesListGroupBox);
            this.Controls.Add(this.EmployeeCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffForm";
            this.Text = "StaffForm";
            this.UseWaitCursor = true;
            this.EmployeesListGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateEmpListButton;
        private System.Windows.Forms.GroupBox EmployeesListGroupBox;
        private System.Windows.Forms.RichTextBox EmployeesList;
        private System.Windows.Forms.Label EmployeeCount;
        private System.Windows.Forms.Label YourAccountLabel;
    }
}