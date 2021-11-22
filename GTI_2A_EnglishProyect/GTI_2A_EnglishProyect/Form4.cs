using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTI_2A_EnglishProyect
{
    public partial class Form4 : Form
    {

        private readonly string mainFileOfProducts = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\data\dataProducts.json";
        public Form4()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // cogemos todos los datos
                string name = textBoxName.Text;
                string platform = textBoxPlatform.Text;
                string manufacturer = textBoxManofacturer.Text;
                string stock = textBoxStock.Text;
                string price = textBoxPriece.Text;
                string description = textBoxDescription.Text;

                Product newProduct;

                newProduct = new Product(name,platform,manufacturer,description,price,stock);

                Form2.productEditable = newProduct;
                clearFormProduct();
                this.Close();
            }
            catch(ArgumentException error)
            {
                Tools.dialogError("Error",error.Message);
                Form2.productEditable = null;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form2.productEditable =  null;
            clearFormProduct();
            this.Close();

        }

        private void clearFormProduct()
        {
            textBoxName.Text = "";
            textBoxManofacturer.Text = "";
            textBoxDescription.Text = "";
            textBoxPriece.Text = "";
            textBoxStock.Text = "";
            textBoxPlatform.Text = "";
        }
    }
}
