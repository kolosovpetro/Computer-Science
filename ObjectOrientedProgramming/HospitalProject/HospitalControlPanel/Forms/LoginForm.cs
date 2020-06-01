using System;
using System.Drawing;
using System.Windows.Forms;
using HospitalLibrary.Administrators;
using HospitalLibrary.Employee;
using HospitalLibrary.Hospital;

namespace HospitalControlPanel.Forms
{
    public partial class LoginForm : Form
    {
        public Hospital NewHospital { get; }
        public Employee CurrentUser { get; private set; }
        public LoginForm()
        {
            NewHospital = new Hospital("St Claire Hospital");
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Administrator admin = new Administrator("Andrey", "Ivanov", "1337", "admin", "admin");
            //NewHospital.AddEmployee(admin);

            if (!NewHospital.CreditsExist(UsernameField.Text, PasswordField.Text, out var newCurrentUser))
            {
                MessageBox.Show(@"No such employee. Try again");
                return;
            }

            foreach (var employee in NewHospital.Employees)
            {
                if (employee.Username == UsernameField.Text && employee.Password == PasswordField.Text && employee is Administrator)
                {
                    Hide();
                    CurrentUser = newCurrentUser;
                    new AdminForm(this).ShowDialog();
                    Close();
                }

                if (employee.Username != UsernameField.Text || employee.Password != PasswordField.Text || employee.GetType().Name.Equals("Administrator")) 
                    continue;
                Hide();
                CurrentUser = newCurrentUser;
                new StaffForm(this).ShowDialog();
                Close();
            }
        }

        private void QuitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuitLabel_MouseEnter(object sender, EventArgs e)
        {
            QuitLabel.BackColor = Color.Red;
        }

        private void QuitLabel_MouseLeave(object sender, EventArgs e)
        {
            QuitLabel.BackColor = DefaultBackColor;
        }
    }
}
