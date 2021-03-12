
namespace DatabasForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.listContainer = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmbSelect
            // 
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "Elever",
            "Vårdnadshavare",
            "Kurser",
            "Lärare",
            "Klasser"});
            this.cmbSelect.Location = new System.Drawing.Point(104, 47);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(121, 23);
            this.cmbSelect.TabIndex = 0;
            this.cmbSelect.Tag = "cmbSelect";
            this.cmbSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listContainer
            // 
            this.listContainer.FormattingEnabled = true;
            this.listContainer.ItemHeight = 15;
            this.listContainer.Items.AddRange(new object[] {
            "Please select element ",
            "in the dropdown ",
            "above."});
            this.listContainer.Location = new System.Drawing.Point(104, 116);
            this.listContainer.Name = "listContainer";
            this.listContainer.Size = new System.Drawing.Size(121, 94);
            this.listContainer.TabIndex = 1;
            this.listContainer.Tag = "lstContainer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listContainer);
            this.Controls.Add(this.cmbSelect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.ListBox listContainer;
    }
}

