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
using System.Xml.Linq;
using Newtonsoft.Json;

namespace GTI_2A_EnglishProyect
{
    public partial class exportForm : Form
    {
        private readonly string mainFileOfProducts = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\data\dataProducts.json";
        ProductList productList;
        String jsonPlainContent;
        public exportForm()
        {
            InitializeComponent();
            jsonPlainContent = Tools.readFile(mainFileOfProducts);
            productList = JsonConvert.DeserializeObject<ProductList>(jsonPlainContent);
        }

        private void textBoxPreview_TextChanged(object sender, EventArgs e)
        {
            textBoxPreview.ScrollBars = ScrollBars.Vertical;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                 if (dataXML.Checked)
                {
                    saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.AddExtension = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        string text = saveFileDialog1.FileName;
                        StreamWriter saveText = File.CreateText(text);
                        saveText.Write(textBoxPreview.Text);
                        saveText.Close();
                        this.Close();

                    }
                }
                else if (dataCSV.Checked)
                {
                    saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.AddExtension = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        string text = saveFileDialog1.FileName;
                        StreamWriter saveText = File.CreateText(text);
                        saveText.Write(textBoxPreview.Text);
                        saveText.Close();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("You must select a format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("An error has occurred", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dataXML_CheckedChanged(object sender, EventArgs e)
        {
            XNode node = JsonConvert.DeserializeXNode(jsonPlainContent, "products");
            StringBuilder write = new StringBuilder();
            write.Append(node);
            textBoxPreview.Text = write.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataCSV_CheckedChanged(object sender, EventArgs e)
        {
            StringBuilder write = new StringBuilder();
            foreach (Product product in productList.product)
            {
                write.AppendLine("Id: " + product.ID);
                write.AppendLine("Name: " + product.NAME);
                write.AppendLine("Plataform: " + product.PLATFORM);
                write.AppendLine("Manufacturer: " + product.MANUFACTURER);
                write.AppendLine("Stock: " + product.STOCK);
                write.AppendLine("Price €: " + product.PRICE);
                write.AppendLine("Description: " + product.DESCRIPTION);
                write.AppendLine();
            }

            textBoxPreview.Text = write.ToString();
        }
    }
}
