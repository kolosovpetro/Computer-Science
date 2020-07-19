using System;
using System.Windows.Forms;
using HospitalLibrary.Employee;

namespace HospitalControlPanel.Forms
{
    public partial class AdminForm : Form
    {
        public LoginForm LoginForm { get; }
        public string EditId { get; private set; }
        private Employee EmployeeToEdit { get; set; }
        public AdminForm(LoginForm newLoginForm)
        {
            InitializeComponent();
            LoginForm = newLoginForm;
            YourAccountLabel.Text = $@"Welcome, {LoginForm.CurrentUser.Name}, {LoginForm.CurrentUser.Surname}. Current username: {LoginForm.CurrentUser.Username}. ";
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            new AddEmployeeForm(this).Show();
        }

        private void UpdateEmpListButton_Click(object sender, EventArgs e)
        {
            EmployeesList.Clear();
            EmployeeCount.Text = $@"Current Employee Count: {LoginForm.NewHospital.Employees.Count}";
            foreach (Employee employee in LoginForm.NewHospital.Employees)
            {
                EmployeesList.AppendText("\n" + employee.EmployeeInfo());
            }
        }

        private void EditEmployeeButton_Click(object sender, EventArgs e)
        {
            if (LoginForm.NewHospital.EmployeeExist(EditEmployeeIDTextBox.Text, out var newEmployee))
            {
                EmployeeToEdit = newEmployee;
                EditId = EditEmployeeIDTextBox.Text;
                new EditEmployeeDataForm(this, EmployeeToEdit).Show();
            }

            else
            {
                MessageBox.Show(@"No Such Employee in the system");
            }
        }
    }
}
