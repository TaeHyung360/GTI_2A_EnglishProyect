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

        public ProductList productList;
        // El path directory name pilla la ruta del .exe que esta donde el directory data
        private readonly string mainFileOfProducts = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\data\dataProducts.json";
        public static Product productEditable = null;

        public Form2()
        {
            InitializeComponent();
            initListBoxListOfProducts();
        }
        //===========================================================================================================
        //Open about
        //===========================================================================================================
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 window2 = new Form3();
            window2.ShowDialog(this);
        }
        //===========================================================================================================
        //Open add product
        //===========================================================================================================
        private void createNewProduct_Click(object sender, EventArgs e)
        {
            Form4 createWindow = new Form4();
            createWindow.ShowDialog(this);
            if (productEditable != null)
            {
                productList.product.Add(productEditable);
                string jsonData = JsonConvert.SerializeObject(productList);
                File.WriteAllText(mainFileOfProducts, jsonData);
                listOfProducts.Items.Add(productEditable);
            }
        }
        //===========================================================================================================
        //initListBoxListOfProducts()
        //===========================================================================================================
        private void initListBoxListOfProducts()
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
        //===========================================================================================================
        //listOfProducts_SelectedIndexChanged()
        //===========================================================================================================
        private void listOfProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product item = (Product)listOfProducts.SelectedItem;
            itemToTextBox(item);
        }
        //===========================================================================================================
        //clearDataFromTextBox()
        //===========================================================================================================
        private void clearDataFromTextBox()
        {
            textBoxName.Text = "";
            textBoxManofacturer.Text = "";
            textBoxDescription.Text = "";
            textBoxPriece.Text = "";
            textBoxStock.Text = "";
            textBoxPlatform.Text = "";
        }
        //===========================================================================================================
        //itemToTextBox()
        //===========================================================================================================
        private void itemToTextBox(Product item)
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
        //===========================================================================================================
        //removeGameFromJson
        //===========================================================================================================
        private void removeGameFromJson(Product product)
        {
            productList.product.Remove(product);
            string jsonData = JsonConvert.SerializeObject(productList);
            File.WriteAllText(mainFileOfProducts, jsonData);
            listOfProducts.Items.Remove(product);
            clearDataFromTextBox();
        }
        //===========================================================================================================
        //deleteProduct_Click
        //===========================================================================================================
        private void deleteProduct_Click(object sender, EventArgs e)
        {
            if (listOfProducts.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Do you want to delete the file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Product item = (Product)listOfProducts.SelectedItem;

                    removeGameFromJson(item);
                }

            }
            else
            {
                MessageBox.Show("You must select a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //===========================================================================================================
        //add
        //===========================================================================================================
        private void editProduct_Click(object sender, EventArgs e)
        {
            if (listOfProducts.SelectedItem != null)
            {
                String item = listOfProducts.SelectedItem.ToString();

                int i;

                for (i = 0; i < productList.product.Count; i++)
                {
                    if (item == productList.product[i].NAME)
                    {
                        productEditable = productList.product[i];
                        break;
                    }

                }
                Form5 createWindow = new Form5();
                createWindow.ShowDialog(this);
                if (productEditable != null)
                {
                    productList.product[i] = productEditable;
                    string jsonData = JsonConvert.SerializeObject(productList);
                    File.WriteAllText(mainFileOfProducts, jsonData);
                    listOfProducts.Items[i] = productEditable;
                }
                productEditable = null;
            }
            else
            {
                MessageBox.Show("You must select a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void applyDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 applyDiscount = new Form6();

            applyDiscount.ShowDialog(this);
        }
        public void globalDiscount(double discount)
        {

            foreach (Product product in productList.product)
            {

                double price = Convert.ToDouble(product.PRICE);
                double discountApplied = (price * discount) / 100;
                double priceWithDiscount = price - discountApplied;

                product.PRICE = priceWithDiscount.ToString();
                listOfProducts.Items.Remove(product);
            }
            clearDataFromTextBox();
            string jsonData = JsonConvert.SerializeObject(productList);
            File.WriteAllText(mainFileOfProducts, jsonData);
            initListBoxListOfProducts();
        }

        private void exportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportForm exportFileWindows = new exportForm();
            exportFileWindows.ShowDialog();
        }
    }
}


