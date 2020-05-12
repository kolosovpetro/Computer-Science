using System;
using System.Linq;
using System.Windows.Forms;

namespace CarSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "C:/Users/Arslan/source/repos/WindowsFormsApp1/CarIcon.png"; //path to image
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car newCar = new Car(textBox2.Text, textBox3.Text,
                new Engine(double.Parse(textBox4.Text), double.Parse(textBox5.Text)));
            newCar.Go(double.Parse(textBox1.Text), pictureBox1, label3, label14);
            label14.Text = label14.Text.ToString().Replace('.', ',');
            textBox5.Text = label14.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Contains('.')) textBox5.Text = textBox5.Text.Replace('.', ',');
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',') e.KeyChar = '.';
            if (e.KeyChar == '.' && textBox1.Text.IndexOf('.') != -1) e.Handled = true;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.') e.Handled = true;
        }
    }
}
