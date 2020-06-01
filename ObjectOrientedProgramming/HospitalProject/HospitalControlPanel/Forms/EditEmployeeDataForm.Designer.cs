namespace HospitalControlPanel.Forms
{
    partial class EditEmployeeDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployeeDataForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteCurrentEmployeeButton = new System.Windows.Forms.Button();
            this.SetShiftDay = new System.Windows.Forms.Button();
            this.ShiftDayIndexField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmployeeNameLabel = new System.Windows.Forms.Label();
            this.ChangeGMCButton = new System.Windows.Forms.Button();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.ChangeUsernameButton = new System.Windows.Forms.Button();
            this.ChangeSurnameButton = new System.Windows.Forms.Button();
            this.ChangeNameButton = new System.Windows.Forms.Button();
            this.GMCField = new System.Windows.Forms.TextBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.SurnameField = new System.Windows.Forms.TextBox();
            this.NameField = new System.Windows.Forms.TextBox();
            this.GMCLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteCurrentEmployeeButton);
            this.groupBox1.Controls.Add(this.SetShiftDay);
            this.groupBox1.Controls.Add(this.ShiftDayIndexField);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EmployeeNameLabel);
            this.groupBox1.Controls.Add(this.ChangeGMCButton);
            this.groupBox1.Controls.Add(this.ChangePasswordButton);
            this.groupBox1.Controls.Add(this.ChangeUsernameButton);
            this.groupBox1.Controls.Add(this.ChangeSurnameButton);
            this.groupBox1.Controls.Add(this.ChangeNameButton);
            this.groupBox1.Controls.Add(this.GMCField);
            this.groupBox1.Controls.Add(this.PasswordField);
            this.groupBox1.Controls.Add(this.UsernameField);
            this.groupBox1.Controls.Add(this.SurnameField);
            this.groupBox1.Controls.Add(this.NameField);
            this.groupBox1.Controls.Add(this.GMCLabel);
            this.groupBox1.Controls.Add(this.PasswordLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Controls.Add(this.SurnameLabel);
            this.groupBox1.Controls.Add(this.NameLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // DeleteCurrentEmployeeButton
            // 
            this.DeleteCurrentEmployeeButton.Location = new System.Drawing.Point(180, 209);
            this.DeleteCurrentEmployeeButton.Name = "DeleteCurrentEmployeeButton";
            this.DeleteCurrentEmployeeButton.Size = new System.Drawing.Size(157, 20);
            this.DeleteCurrentEmployeeButton.TabIndex = 41;
            this.DeleteCurrentEmployeeButton.Text = "Delete Current Employee";
            this.DeleteCurrentEmployeeButton.UseVisualStyleBackColor = true;
            this.DeleteCurrentEmployeeButton.Click += new System.EventHandler(this.DeleteCurrentEmployeeButton_Click);
            // 
            // SetShiftDay
            // 
            this.SetShiftDay.Location = new System.Drawing.Point(228, 163);
            this.SetShiftDay.Name = "SetShiftDay";
            this.SetShiftDay.Size = new System.Drawing.Size(109, 21);
            this.SetShiftDay.TabIndex = 40;
            this.SetShiftDay.Text = "Set Shift";
            this.SetShiftDay.UseVisualStyleBackColor = true;
            this.SetShiftDay.Click += new System.EventHandler(this.SetShiftDay_Click);
            // 
            // ShiftDayIndexField
            // 
            this.ShiftDayIndexField.Location = new System.Drawing.Point(126, 164);
            this.ShiftDayIndexField.Name = "ShiftDayIndexField";
            this.ShiftDayIndexField.Size = new System.Drawing.Size(86, 20);
            this.ShiftDayIndexField.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Set Shift (Day Index)";
            // 
            // EmployeeNameLabel
            // 
            this.EmployeeNameLabel.AutoSize = true;
            this.EmployeeNameLabel.Location = new System.Drawing.Point(29, 21);
            this.EmployeeNameLabel.Name = "EmployeeNameLabel";
            this.EmployeeNameLabel.Size = new System.Drawing.Size(0, 13);
            this.EmployeeNameLabel.TabIndex = 37;
            // 
            // ChangeGMCButton
            // 
            this.ChangeGMCButton.Location = new System.Drawing.Point(228, 137);
            this.ChangeGMCButton.Name = "ChangeGMCButton";
            this.ChangeGMCButton.Size = new System.Drawing.Size(109, 21);
            this.ChangeGMCButton.TabIndex = 36;
            this.ChangeGMCButton.Text = "Change GMC";
            this.ChangeGMCButton.UseVisualStyleBackColor = true;
            this.ChangeGMCButton.Click += new System.EventHandler(this.ChangeGMCButton_Click);
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.Location = new System.Drawing.Point(228, 115);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(109, 21);
            this.ChangePasswordButton.TabIndex = 35;
            this.ChangePasswordButton.Text = "Change Password";
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // ChangeUsernameButton
            // 
            this.ChangeUsernameButton.Location = new System.Drawing.Point(228, 93);
            this.ChangeUsernameButton.Name = "ChangeUsernameButton";
            this.ChangeUsernameButton.Size = new System.Drawing.Size(109, 21);
            this.ChangeUsernameButton.TabIndex = 34;
            this.ChangeUsernameButton.Text = "Change Username";
            this.ChangeUsernameButton.UseVisualStyleBackColor = true;
            this.ChangeUsernameButton.Click += new System.EventHandler(this.ChangeUsernameButton_Click);
            // 
            // ChangeSurnameButton
            // 
            this.ChangeSurnameButton.Location = new System.Drawing.Point(228, 68);
            this.ChangeSurnameButton.Name = "ChangeSurnameButton";
            this.ChangeSurnameButton.Size = new System.Drawing.Size(109, 21);
            this.ChangeSurnameButton.TabIndex = 33;
            this.ChangeSurnameButton.Text = "Change Surname";
            this.ChangeSurnameButton.UseVisualStyleBackColor = true;
            this.ChangeSurnameButton.Click += new System.EventHandler(this.ChangeSurnameButton_Click);
            // 
            // ChangeNameButton
            // 
            this.ChangeNameButton.Location = new System.Drawing.Point(228, 47);
            this.ChangeNameButton.Name = "ChangeNameButton";
            this.ChangeNameButton.Size = new System.Drawing.Size(109, 21);
            this.ChangeNameButton.TabIndex = 32;
            this.ChangeNameButton.Text = "Change Name";
            this.ChangeNameButton.UseVisualStyleBackColor = true;
            this.ChangeNameButton.Click += new System.EventHandler(this.ChangeNameButton_Click);
            // 
            // GMCField
            // 
            this.GMCField.Location = new System.Drawing.Point(126, 138);
            this.GMCField.Name = "GMCField";
            this.GMCField.Size = new System.Drawing.Size(86, 20);
            this.GMCField.TabIndex = 29;
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(126, 116);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(86, 20);
            this.PasswordField.TabIndex = 28;
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(126, 94);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(86, 20);
            this.UsernameField.TabIndex = 27;
            // 
            // SurnameField
            // 
            this.SurnameField.Location = new System.Drawing.Point(126, 69);
            this.SurnameField.Name = "SurnameField";
            this.SurnameField.Size = new System.Drawing.Size(86, 20);
            this.SurnameField.TabIndex = 25;
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(126, 47);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(86, 20);
            this.NameField.TabIndex = 24;
            // 
            // GMCLabel
            // 
            this.GMCLabel.AutoSize = true;
            this.GMCLabel.Location = new System.Drawing.Point(16, 145);
            this.GMCLabel.Name = "GMCLabel";
            this.GMCLabel.Size = new System.Drawing.Size(96, 13);
            this.GMCLabel.TabIndex = 23;
            this.GMCLabel.Text = "New GMC Number";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(16, 123);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(78, 13);
            this.PasswordLabel.TabIndex = 22;
            this.PasswordLabel.Text = "New Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(16, 101);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(80, 13);
            this.UsernameLabel.TabIndex = 21;
            this.UsernameLabel.Text = "New Username";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(16, 76);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(74, 13);
            this.SurnameLabel.TabIndex = 19;
            this.SurnameLabel.Text = "New Surname";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(16, 54);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(60, 13);
            this.NameLabel.TabIndex = 18;
            this.NameLabel.Text = "New Name";
            // 
            // EditEmployeeDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 265);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditEmployeeDataForm";
            this.Text = "Edit Employee Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button ChangeGMCButton;
        private System.Windows.Forms.Button ChangeNameButton;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Button ChangeSurnameButton;
        private System.Windows.Forms.Button ChangeUsernameButton;
        private System.Windows.Forms.Button DeleteCurrentEmployeeButton;
        private System.Windows.Forms.Label EmployeeNameLabel;
        private System.Windows.Forms.TextBox GMCField;
        private System.Windows.Forms.Label GMCLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button SetShiftDay;
        private System.Windows.Forms.TextBox ShiftDayIndexField;
        private System.Windows.Forms.TextBox SurnameField;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.Label UsernameLabel;

        #endregion
    }
}