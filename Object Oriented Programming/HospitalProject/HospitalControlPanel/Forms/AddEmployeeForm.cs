using System;
using System.Linq;
using System.Windows.Forms;
using HospitalLibrary.Administrators;
using HospitalLibrary.Doctors;
using HospitalLibrary.Employee;
using HospitalLibrary.Nurses;

namespace HospitalControlPanel.Forms
{
    public partial class AddEmployeeForm : Form
    {
        private AdminForm AdminForm { get; }

        public AddEmployeeForm(AdminForm newAdminForm)
        {
            InitializeComponent();
            AdminForm = newAdminForm;
        }

        private void RegisterNewEmployee_Click(object sender, EventArgs e)
        {
            RadioButton radioBtn = EmployeeDataGroupBox.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            switch (radioBtn?.Name)
            {
                case "NurseRadioButton":
                    try
                    {
                        Employee e1 = new Nurse(NameField.Text, SurnameField.Text, IdField.Text, UsernameField.Text,
                            PasswordField.Text);
                        AdminForm.LoginForm.NewHospital.AddEmployee(e1);
                        MessageBox.Show(@"Added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "CardiologistRadioButton":
                    try
                    {
                        Employee e2 = new Cardiologist(NameField.Text, SurnameField.Text, IdField.Text,
                            UsernameField.Text, PasswordField.Text, GMCField.Text);
                        AdminForm.LoginForm.NewHospital.AddEmployee(e2);
                        MessageBox.Show(@"Added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "UrologistRadioButton":
                    try
                    {
                        Employee e3 = new Urologist(NameField.Text, SurnameField.Text, IdField.Text, UsernameField.Text,
                            PasswordField.Text, GMCField.Text);
                        AdminForm.LoginForm.NewHospital.AddEmployee(e3);
                        MessageBox.Show(@"Added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "NeurologistRadioButton":
                    try
                    {
                        Employee e4 = new Neurologist(NameField.Text, SurnameField.Text, IdField.Text,
                            UsernameField.Text, PasswordField.Text, GMCField.Text);
                        AdminForm.LoginForm.NewHospital.AddEmployee(e4);
                        MessageBox.Show(@"Added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "LaryngologistRadioButton":
                    try
                    {
                        Employee e5 = new Laryngologist(NameField.Text, SurnameField.Text, IdField.Text,
                            UsernameField.Text, PasswordField.Text, GMCField.Text);
                        AdminForm.LoginForm.NewHospital.AddEmployee(e5);
                        MessageBox.Show(@"Added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "AdministratorRadioButton":
                    try
                    {
                        Employee e6 = new Administrator(NameField.Text, SurnameField.Text, IdField.Text,
                            UsernameField.Text, PasswordField.Text);
                        AdminForm.LoginForm.NewHospital.AddEmployee(e6);
                        MessageBox.Show(@"Added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
            }
        }
    }
}