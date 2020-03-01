using Npgsql;
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
    public partial class DatabaseControlPanel : Form
    {
        public DatabaseLoginForm LoginForm { get; private set; }

        public DatabaseControlPanel(DatabaseLoginForm newLoginForm)
        {
            InitializeComponent();
            this.LoginForm = newLoginForm;
            this.DatabaseConnectedLabel.Text = $"Connected to DB: {LoginForm.Database.Host} / {LoginForm.Database.Database}";
        }

        private void ExecuteQueryButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                var Connection = this.LoginForm.Database.Connection;
                Connection.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(QueryField.Text, Connection);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
