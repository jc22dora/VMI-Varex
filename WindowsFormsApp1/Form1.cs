using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using WindowsFormsApp1;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            // ofd.ShowDialog();
            //ofd.Filter = "VMI|.vmi";
            

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                textBox1.Text = ofd.FileName;
                textBox2.Text = ofd.SafeFileName;
                
            }
            Program obj = new Program();
            pictureBox1.Image = obj.convertProcess();
        }
    }
}
