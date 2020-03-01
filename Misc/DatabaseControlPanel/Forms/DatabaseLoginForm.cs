using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseControlPanel.Forms
{
    public partial class DatabaseLoginForm : Form
    {
        public DBConnect Database { get; private set; }
        public DatabaseLoginForm()
        {
            InitializeComponent();
        }

        private void CloseLabel_MouseEnter(object sender, EventArgs e)
        {
            CloseLabel.BackColor = Color.Red;
        }

        private void CloseLabel_MouseLeave(object sender, EventArgs e)
        {
            CloseLabel.BackColor = default;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Database = new DBConnect(HostField.Text, UsernameField.Text, PasswordField.Text, DatabaseField.Text);
                this.Hide();
                new DatabaseControlPanel(this).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
