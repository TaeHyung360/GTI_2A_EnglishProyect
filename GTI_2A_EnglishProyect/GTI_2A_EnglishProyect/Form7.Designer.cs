
namespace GTI_2A_EnglishProyect
{
    partial class exportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPreview = new System.Windows.Forms.TextBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataXML = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataCSV = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.Location = new System.Drawing.Point(8, 35);
            this.textBoxPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPreview.Multiline = true;
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.Size = new System.Drawing.Size(519, 211);
            this.textBoxPreview.TabIndex = 0;
            this.textBoxPreview.TextChanged += new System.EventHandler(this.textBoxPreview_TextChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(347, 257);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(88, 23);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(439, 257);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Content of the exported file";
            // 
            // dataXML
            // 
            this.dataXML.AutoSize = true;
            this.dataXML.Location = new System.Drawing.Point(11, 260);
            this.dataXML.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataXML.Name = "dataXML";
            this.dataXML.Size = new System.Drawing.Size(83, 17);
            this.dataXML.TabIndex = 4;
            this.dataXML.TabStop = true;
            this.dataXML.Text = "data to XML";
            this.dataXML.UseVisualStyleBackColor = true;
            this.dataXML.CheckedChanged += new System.EventHandler(this.dataXML_CheckedChanged);
            // 
            // dataCSV
            // 
            this.dataCSV.AutoSize = true;
            this.dataCSV.Location = new System.Drawing.Point(97, 259);
            this.dataCSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataCSV.Name = "dataCSV";
            this.dataCSV.Size = new System.Drawing.Size(82, 17);
            this.dataCSV.TabIndex = 5;
            this.dataCSV.TabStop = true;
            this.dataCSV.Text = "data to CSV";
            this.dataCSV.UseVisualStyleBackColor = true;
            this.dataCSV.CheckedChanged += new System.EventHandler(this.dataCSV_CheckedChanged);
            // 
            // exportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.dataCSV);
            this.Controls.Add(this.dataXML);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxPreview);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "exportForm";
            this.Text = "exportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPreview;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton dataXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton dataCSV;
    }
}