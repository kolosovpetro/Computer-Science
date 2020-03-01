using HospitalLibrary;
using System;
using System.Windows.Forms;

namespace HospitalControlPanel.Forms
{
    public partial class EditEmployeeDataForm : Form
    {
        public AdminForm AdminForm { get; private set; }
        public Employee EmployeeToEdit { get; private set; }
        public EditEmployeeDataForm(AdminForm AdminForm, Employee NewEmployeeToEdit)
        {
            InitializeComponent();
            EmployeeToEdit = NewEmployeeToEdit;
            this.AdminForm = AdminForm;
            EmployeeNameLabel.Text = $"Edit employee with ID: {AdminForm.EditId}, Name: {EmployeeToEdit.Name}, Surname: {EmployeeToEdit.Surname}";
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangeName(NameField.Text);
            MessageBox.Show("Success.");
        }

        private void ChangeSurnameButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangeSurname(SurnameField.Text);
            MessageBox.Show("Success.");
        }

        private void ChangeUsernameButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangeUsername(UsernameField.Text);
            MessageBox.Show("Success.");
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangePassword(PasswordField.Text);
            MessageBox.Show("Success.");
        }

        private void ChangeGMCButton_Click(object sender, EventArgs e)
        {
            if (EmployeeToEdit is Doctor)
            {
                Doctor NewDoctor = (Doctor)EmployeeToEdit;
                NewDoctor.ChangeGMCNumber(GMCField.Text);
                MessageBox.Show("Success.");
            }

            else
            {
                MessageBox.Show("GMC number exist for Doctors only.");
            }
        }

        private void SetShiftDay_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Employee employee in AdminForm.LoginForm.NewHospital.Employees)
                {
                    if (employee.GetType() == EmployeeToEdit.GetType() 
                        && employee.Duties[int.Parse(ShiftDayIndexField.Text)])
                    {
                        throw new EmployeeScheduleException("Improper schedule. There can be only 1 doctor of each type on sing shift.");
                    }
                }

                EmployeeToEdit.AddDuty(int.Parse(ShiftDayIndexField.Text));
                MessageBox.Show("Success.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteCurrentEmployeeButton_Click(object sender, EventArgs e)
        {
            int Index = AdminForm.LoginForm.NewHospital.Employees.IndexOf(EmployeeToEdit);
            AdminForm.LoginForm.NewHospital.Employees.RemoveAt(Index);
            MessageBox.Show("Succesfully deleted.");
            this.Close();
        }
    }
}
