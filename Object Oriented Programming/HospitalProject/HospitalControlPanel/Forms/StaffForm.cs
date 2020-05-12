using System;
using System.Windows.Forms;
using HospitalLibrary.Employee;

namespace HospitalControlPanel.Forms
{
    public partial class StaffForm : Form
    {
        private LoginForm LoginForm { get; }
        public StaffForm(LoginForm newLoginForm)
        {
            InitializeComponent();
            LoginForm = newLoginForm;
            YourAccountLabel.Text = $@"Welcome, {LoginForm.CurrentUser.Name}, {LoginForm.CurrentUser.Surname}. Current username: {LoginForm.CurrentUser.Username}. ";
        }

        private void UpdateEmpListButton_Click(object sender, EventArgs e)
        {
            EmployeesList.Clear();
            EmployeeCount.Text = $@"Current Employee Count: {LoginForm.NewHospital.Employees.Count}";
            
            foreach (var employee in LoginForm.NewHospital.Employees)
            {
                EmployeesList.AppendText("\n" + employee.EmployeeInfo());
            }
        }
    }
}
