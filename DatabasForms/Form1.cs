using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabasForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = cmbSelect.Text.ToLower();

            if(cmbSelect.Text != null)
            {
                string[] elever = { "Paco", "Zynyx", "Mini Fruit", "Shonen" };
                listContainer.Items.Clear();

                foreach(string s in elever)
                {
                    if(select == "elever")
                    {
                        listContainer.Items.Add(s);
                    }
                }
            }
        }
    }
}
