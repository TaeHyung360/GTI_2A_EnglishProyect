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
    public partial class Form2 : Form
    {

        private bool editMode = false;

        private ProductList productList;
        // El path directory name pilla la ruta del .exe que esta donde el directory data
        private readonly string mainFileOfProducts = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\data\dataProducts.json";

        public Form2()
        {
            InitializeComponent();
            initListBoxListOfProducts();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 window2 = new Form3();
            window2.ShowDialog(this);
        }
        //===========================================================================================================
        private void initListBoxListOfProducts()
        //===========================================================================================================
        {
            try
            {
                String jsonPlainContent = Tools.readFile(mainFileOfProducts);
                productList = JsonConvert.DeserializeObject<ProductList>(jsonPlainContent);

                foreach (Product product in productList.product)
                {
                    listOfProducts.Items.Add(product); // podemos añadir directamente los objetos porque hemos sobreescrito
                                                      // el metodo to string del objeto que es lo que se muestra en la lista


                }
            }
            catch (IOException)
            {
                Tools.dialogError("Initializing ERROR", "Data to read was not found. The app are going to close");
                this.Close();
            }
            catch (ArgumentException error)
            {
                Tools.dialogError("Initializing ERROR", "Some values from the data are invalids: " + error.Message);
                this.Close();
            }
            catch (Exception)
            {
                Tools.dialogError("ERROR", "Unexpected error");
                this.Close();
            }


        }

        private void listOfProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product item = (Product)listOfProducts.SelectedItem;
            itemToInfoGroup(item);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            
        


        }
        private void itemToInfoGroup(Product item)
        {

            if (item != null)
            {
                listOfProducts.Visible = true;
                textBoxName.Text = item.NAME;
                textBoxManofacturer.Text = item.MANUFACTURER;
                textBoxDescription.Text = item.DESCRIPTION;
                textBoxPriece.Text = item.PRICE;
                textBoxStock.Text = item.STOCK;
                textBoxPlatform.Text = item.PLATFORM;
            }

        }
    }

}
