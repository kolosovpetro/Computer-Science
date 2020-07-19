namespace HospitalControlPanel.Forms
{
    partial class AddEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeForm));
            this.EmployeeDataGroupBox = new System.Windows.Forms.GroupBox();
            this.RegisterNewEmployee = new System.Windows.Forms.Button();
            this.GMCField = new System.Windows.Forms.TextBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.IdField = new System.Windows.Forms.TextBox();
            this.SurnameField = new System.Windows.Forms.TextBox();
            this.NameField = new System.Windows.Forms.TextBox();
            this.GMCLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AdministratorRadioButton = new System.Windows.Forms.RadioButton();
            this.LaryngologistRadioButton = new System.Windows.Forms.RadioButton();
            this.NeurologistRadioButton = new System.Windows.Forms.RadioButton();
            this.UrologistRadioButton = new System.Windows.Forms.RadioButton();
            this.CardiologistRadioButton = new System.Windows.Forms.RadioButton();
            this.NurseRadioButton = new System.Windows.Forms.RadioButton();
            this.EmployeeDataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeDataGroupBox
            // 
            this.EmployeeDataGroupBox.Controls.Add(this.RegisterNewEmployee);
            this.EmployeeDataGroupBox.Controls.Add(this.GMCField);
            this.EmployeeDataGroupBox.Controls.Add(this.PasswordField);
            this.EmployeeDataGroupBox.Controls.Add(this.UsernameField);
            this.EmployeeDataGroupBox.Controls.Add(this.IdField);
            this.EmployeeDataGroupBox.Controls.Add(this.SurnameField);
            this.EmployeeDataGroupBox.Controls.Add(this.NameField);
            this.EmployeeDataGroupBox.Controls.Add(this.GMCLabel);
            this.EmployeeDataGroupBox.Controls.Add(this.PasswordLabel);
            this.EmployeeDataGroupBox.Controls.Add(this.UsernameLabel);
            this.EmployeeDataGroupBox.Controls.Add(this.IdLabel);
            this.EmployeeDataGroupBox.Controls.Add(this.SurnameLabel);
            this.EmployeeDataGroupBox.Controls.Add(this.NameLabel);
            this.EmployeeDataGroupBox.Controls.Add(this.AdministratorRadioButton);
            this.EmployeeDataGroupBox.Controls.Add(this.LaryngologistRadioButton);
            this.EmployeeDataGroupBox.Controls.Add(this.NeurologistRadioButton);
            this.EmployeeDataGroupBox.Controls.Add(this.UrologistRadioButton);
            this.EmployeeDataGroupBox.Controls.Add(this.CardiologistRadioButton);
            this.EmployeeDataGroupBox.Controls.Add(this.NurseRadioButton);
            this.EmployeeDataGroupBox.Location = new System.Drawing.Point(17, 25);
            this.EmployeeDataGroupBox.Name = "EmployeeDataGroupBox";
            this.EmployeeDataGroupBox.Size = new System.Drawing.Size(424, 267);
            this.EmployeeDataGroupBox.TabIndex = 0;
            this.EmployeeDataGroupBox.TabStop = false;
            this.EmployeeDataGroupBox.Text = "Specify Employee Data";
            // 
            // RegisterNewEmployee
            // 
            this.RegisterNewEmployee.Location = new System.Drawing.Point(239, 195);
            this.RegisterNewEmployee.Name = "RegisterNewEmployee";
            this.RegisterNewEmployee.Size = new System.Drawing.Size(129, 23);
            this.RegisterNewEmployee.TabIndex = 18;
            this.RegisterNewEmployee.Text = "Register New Employee";
            this.RegisterNewEmployee.UseVisualStyleBackColor = true;
            this.RegisterNewEmployee.Click += new System.EventHandler(this.RegisterNewEmployee_Click);
            // 
            // GMCField
            // 
            this.GMCField.Location = new System.Drawing.Point(283, 134);
            this.GMCField.Name = "GMCField";
            this.GMCField.Size = new System.Drawing.Size(86, 20);
            this.GMCField.TabIndex = 17;
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(283, 112);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(86, 20);
            this.PasswordField.TabIndex = 16;
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(283, 90);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(86, 20);
            this.UsernameField.TabIndex = 15;
            // 
            // IdField
            // 
            this.IdField.Location = new System.Drawing.Point(283, 68);
            this.IdField.Name = "IdField";
            this.IdField.Size = new System.Drawing.Size(86, 20);
            this.IdField.TabIndex = 14;
            // 
            // SurnameField
            // 
            this.SurnameField.Location = new System.Drawing.Point(283, 46);
            this.SurnameField.Name = "SurnameField";
            this.SurnameField.Size = new System.Drawing.Size(86, 20);
            this.SurnameField.TabIndex = 13;
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(283, 24);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(86, 20);
            this.NameField.TabIndex = 12;
            // 
            // GMCLabel
            // 
            this.GMCLabel.AutoSize = true;
            this.GMCLabel.Location = new System.Drawing.Point(197, 141);
            this.GMCLabel.Name = "GMCLabel";
            this.GMCLabel.Size = new System.Drawing.Size(71, 13);
            this.GMCLabel.TabIndex = 11;
            this.GMCLabel.Text = "GMC Number";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(197, 119);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(197, 97);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 9;
            this.UsernameLabel.Text = "Username";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(197, 75);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(56, 13);
            this.IdLabel.TabIndex = 8;
            this.IdLabel.Text = "Id Number";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(197, 53);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(49, 13);
            this.SurnameLabel.TabIndex = 7;
            this.SurnameLabel.Text = "Surname";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(197, 31);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name";
            // 
            // AdministratorRadioButton
            // 
            this.AdministratorRadioButton.AutoSize = true;
            this.AdministratorRadioButton.Location = new System.Drawing.Point(26, 143);
            this.AdministratorRadioButton.Name = "AdministratorRadioButton";
            this.AdministratorRadioButton.Size = new System.Drawing.Size(85, 17);
            this.AdministratorRadioButton.TabIndex = 5;
            this.AdministratorRadioButton.Text = "Administrator";
            this.AdministratorRadioButton.UseVisualStyleBackColor = true;
            // 
            // LaryngologistRadioButton
            // 
            this.LaryngologistRadioButton.AutoSize = true;
            this.LaryngologistRadioButton.Location = new System.Drawing.Point(26, 120);
            this.LaryngologistRadioButton.Name = "LaryngologistRadioButton";
            this.LaryngologistRadioButton.Size = new System.Drawing.Size(87, 17);
            this.LaryngologistRadioButton.TabIndex = 4;
            this.LaryngologistRadioButton.Text = "Laryngologist";
            this.LaryngologistRadioButton.UseVisualStyleBackColor = true;
            // 
            // NeurologistRadioButton
            // 
            this.NeurologistRadioButton.AutoSize = true;
            this.NeurologistRadioButton.Location = new System.Drawing.Point(26, 97);
            this.NeurologistRadioButton.Name = "NeurologistRadioButton";
            this.NeurologistRadioButton.Size = new System.Drawing.Size(78, 17);
            this.NeurologistRadioButton.TabIndex = 3;
            this.NeurologistRadioButton.Text = "Neurologist";
            this.NeurologistRadioButton.UseVisualStyleBackColor = true;
            // 
            // UrologistRadioButton
            // 
            this.UrologistRadioButton.AutoSize = true;
            this.UrologistRadioButton.Location = new System.Drawing.Point(26, 74);
            this.UrologistRadioButton.Name = "UrologistRadioButton";
            this.UrologistRadioButton.Size = new System.Drawing.Size(66, 17);
            this.UrologistRadioButton.TabIndex = 2;
            this.UrologistRadioButton.Text = "Urologist";
            this.UrologistRadioButton.UseVisualStyleBackColor = true;
            // 
            // CardiologistRadioButton
            // 
            this.CardiologistRadioButton.AutoSize = true;
            this.CardiologistRadioButton.Location = new System.Drawing.Point(26, 51);
            this.CardiologistRadioButton.Name = "CardiologistRadioButton";
            this.CardiologistRadioButton.Size = new System.Drawing.Size(79, 17);
            this.CardiologistRadioButton.TabIndex = 1;
            this.CardiologistRadioButton.Text = "Cardiologist";
            this.CardiologistRadioButton.UseVisualStyleBackColor = true;
            // 
            // NurseRadioButton
            // 
            this.NurseRadioButton.AutoSize = true;
            this.NurseRadioButton.Checked = true;
            this.NurseRadioButton.Location = new System.Drawing.Point(26, 28);
            this.NurseRadioButton.Name = "NurseRadioButton";
            this.NurseRadioButton.Size = new System.Drawing.Size(53, 17);
            this.NurseRadioButton.TabIndex = 0;
            this.NurseRadioButton.TabStop = true;
            this.NurseRadioButton.Text = "Nurse";
            this.NurseRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 304);
            this.Controls.Add(this.EmployeeDataGroupBox);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEmployeeForm";
            this.Text = "Add New Employee";
            this.EmployeeDataGroupBox.ResumeLayout(false);
            this.EmployeeDataGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RadioButton AdministratorRadioButton;
        private System.Windows.Forms.RadioButton CardiologistRadioButton;
        private System.Windows.Forms.GroupBox EmployeeDataGroupBox;
        private System.Windows.Forms.TextBox GMCField;
        private System.Windows.Forms.Label GMCLabel;
        private System.Windows.Forms.TextBox IdField;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.RadioButton LaryngologistRadioButton;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.RadioButton NeurologistRadioButton;
        private System.Windows.Forms.RadioButton NurseRadioButton;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button RegisterNewEmployee;
        private System.Windows.Forms.TextBox SurnameField;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.RadioButton UrologistRadioButton;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.Label UsernameLabel;

        #endregion
    }
}