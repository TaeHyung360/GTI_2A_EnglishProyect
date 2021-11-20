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
    public partial class Form1 : Form
    {

        //Intentos para cerrar sesion

        private int attempts = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string valuePassword = textPassword.Text;

            if (valuePassword.Equals("admin"))
            {
                Form2 secondaryWindow = new Form2();

                //Oculta este formulario
                this.Hide();
                //Abre el Form2
                secondaryWindow.ShowDialog();
                //Cierra el formulario actual
                this.Close();

            }else if(valuePassword.Length == 0)
            {

                MessageBox.Show("The password field is required");

            }
            else
            {
                attempts--;

                if(attempts == 0)
                {

                    MessageBox.Show("You have exceeded 3 attempts, please try again later. ");

                    this.Close();

                }

                MessageBox.Show("The password is wrong\n" + "Your remaining attempts are: " + attempts.ToString());

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
