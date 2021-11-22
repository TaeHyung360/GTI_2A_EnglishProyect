using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTI_2A_EnglishProyect
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {

                    MessageBox.Show("You must input a value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    double discount = Convert.ToDouble(textBox1.Text);
                    if (discount >= 100 || discount <= 0)
                    {
                        MessageBox.Show("The discount has to be greater than cero o smaller than a hundred", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Do you want to apply this discount?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            Form2 main = (Form2)this.Owner;
                            this.Hide();
                            main.GlobalDiscount(discount);
                            this.Close();
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
