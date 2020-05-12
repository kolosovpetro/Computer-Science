using System;
using System.Windows.Forms;
using HospitalLibrary.Doctors;
using HospitalLibrary.Employee;
using HospitalLibrary.Exceptions;

namespace HospitalControlPanel.Forms
{
    public partial class EditEmployeeDataForm : Form
    {
        private AdminForm AdminForm { get; }
        private Employee EmployeeToEdit { get; }
        public EditEmployeeDataForm(AdminForm adminForm, Employee newEmployeeToEdit)
        {
            InitializeComponent();
            EmployeeToEdit = newEmployeeToEdit;
            this.AdminForm = adminForm;
            EmployeeNameLabel.Text = $@"Edit employee with ID: {adminForm.EditId}, Name: {EmployeeToEdit.Name}, Surname: {EmployeeToEdit.Surname}";
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangeName(NameField.Text);
            MessageBox.Show(@"Success.");
        }

        private void ChangeSurnameButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangeSurname(SurnameField.Text);
            MessageBox.Show(@"Success.");
        }

        private void ChangeUsernameButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangeUsername(UsernameField.Text);
            MessageBox.Show(@"Success.");
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            EmployeeToEdit.ChangePassword(PasswordField.Text);
            MessageBox.Show(@"Success.");
        }

        private void ChangeGMCButton_Click(object sender, EventArgs e)
        {
            if (EmployeeToEdit is Doctor newDoctor)
            {
                newDoctor.ChangeGmcNumber(GMCField.Text);
                MessageBox.Show(@"Success.");
            }

            else
            {
                MessageBox.Show(@"GMC number exist for Doctors only.");
            }
        }

        private void SetShiftDay_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var employee in AdminForm.LoginForm.NewHospital.Employees)
                {
                    if (employee.GetType() == EmployeeToEdit.GetType() 
                        && employee.Duties[int.Parse(ShiftDayIndexField.Text)])
                    {
                        throw new EmployeeScheduleException("Improper schedule. There can be only 1 doctor of each type on sing shift.");
                    }
                }

                EmployeeToEdit.AddDuty(int.Parse(ShiftDayIndexField.Text));
                MessageBox.Show(@"Success.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteCurrentEmployeeButton_Click(object sender, EventArgs e)
        {
            var index = AdminForm.LoginForm.NewHospital.Employees.IndexOf(EmployeeToEdit);
            AdminForm.LoginForm.NewHospital.Employees.RemoveAt(index);
            MessageBox.Show(@"Successfully deleted.");
            Close();
        }
    }
}
