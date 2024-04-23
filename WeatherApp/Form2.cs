using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Variables.cobmo_choose = comboBox1.SelectedItem.ToString();
            }
            else if (!string.IsNullOrEmpty(textBox1.Text)) 
            {
                Variables.cobmo_choose = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Please select or enter a city.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            switch (comboBox1.SelectedIndex.ToString())
            {
                case "Grodzisk Mazowiecki":Variables.cobmo_choose = "Grodzisk Mazowiecki";break;
                case "Warsaw":Variables.cobmo_choose = "Warsaw";break;
                case "Kyiv":Variables.cobmo_choose = "Kyiv";break;
                case "London":Variables.cobmo_choose = "London";break;
                case "Madrid":Variables.cobmo_choose = "Madrid";break;
                case "Berlin":Variables.cobmo_choose = "Berlin";break;
                case "Paris":Variables.cobmo_choose = "Paris";break;
                case "Stryi":Variables.cobmo_choose = "Stryi";break;
                case "New York":Variables.cobmo_choose = "New York";break;

            }
            if (!string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex == 0)
            {
                Variables.cobmo_choose = textBox1.Text;
            }
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
