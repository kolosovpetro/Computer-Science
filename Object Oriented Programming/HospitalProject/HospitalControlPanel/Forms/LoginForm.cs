using System;
using System.Drawing;
using System.Windows.Forms;
using HospitalControlPanel.Forms;
using HospitalLibrary;

namespace HospitalControlPanel
{
    public partial class LoginForm : Form
    {
        public Hospital NewHospital { get; private set; }
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

            if (!NewHospital.CreditsExist(UsernameField.Text, PasswordField.Text, out Employee NewCurrentUser))
            {
                MessageBox.Show("No such employee. Try again");
                return;
            }

            foreach (Employee employee in NewHospital.Employees)
            {
                if (employee.Username == UsernameField.Text && employee.Password == PasswordField.Text
                    && employee is Administrator)
                {
                    this.Hide();
                    this.CurrentUser = NewCurrentUser;
                    new AdminForm(this).ShowDialog();
                    this.Close();
                }

                if (employee.Username == UsernameField.Text && employee.Password == PasswordField.Text
                    && !employee.GetType().Name.Equals("Administrator"))
                {
                    this.Hide();
                    this.CurrentUser = NewCurrentUser;
                    new StaffForm(this).ShowDialog();
                    this.Close();
                }
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
