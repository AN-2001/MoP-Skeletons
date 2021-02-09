using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUISphereCreateExportPlugin.Forms
{
    public partial class GUISphereCreateExportPluginForm : Form
    {
        private dynamic plugin = null;
        public GUISphereCreateExportPluginForm()
        {
            InitializeComponent();
            plugin = new SphereCreateExportPlugin.SphereCreateExportPluginObject();
        }


        private void textBoxFilterOnlyNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("You need to provide the shpere center and its radius!", "Wrong or missing data.");
                return;
            }
            double radius = Convert.ToDouble(textBox4.Text);
            if (radius <= 0.0)
            {
                MessageBox.Show("The radius has to be strictly positive!", "Wrong or missing data.");
                return;
            }
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double z = Convert.ToDouble(textBox3.Text);
            plugin.AddSphere(x, y, z, radius);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.DefaultExt = "stp";
            saveFileDialog1.Filter = "stp files (*.stp)|*.stp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if(textBox5.Text.Length == 0)
           // {
           //     return;
           // }
            plugin.saveSTP(textBox5.Text);
        }
    }
}
