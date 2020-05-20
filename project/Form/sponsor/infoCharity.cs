using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using project.Properties;

namespace project
{
    public partial class infoCharity : MetroFramework.Forms.MetroForm
    {
        public infoCharity()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            this.Text = variables.gCharityName;
            richTextBox1.Text = variables.gCharityDescription;
            pictureBox1.Load("resources//charity//" + variables.gCharityImage);
        }

        private void infoCharity_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
