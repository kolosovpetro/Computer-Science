using HospitalLibrary;
using System;
using System.Windows.Forms;

namespace HospitalControlPanel
{
    public partial class StaffForm : Form
    {
        public LoginForm LoginForm { get; private set; }
        public StaffForm(LoginForm newLoginForm)
        {
            InitializeComponent();
            LoginForm = newLoginForm;
            YourAccountLabel.Text = $"Welcome, {LoginForm.CurrentUser.Name}, {LoginForm.CurrentUser.Surname}. Current username: {LoginForm.CurrentUser.Username}. ";
        }

        private void UpdateEmpListButton_Click(object sender, EventArgs e)
        {
            EmployeesList.Clear();
            EmployeeCount.Text = $"Current Employee Count: {LoginForm.NewHospital.Employees.Count}";
            foreach (Employee employee in LoginForm.NewHospital.Employees)
            {
                EmployeesList.AppendText("\n" + employee.EmployeeInfo());
            }
        }
    }
}
