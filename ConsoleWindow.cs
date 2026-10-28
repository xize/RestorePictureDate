using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestorePictureDate
{
    public partial class ConsoleWindow : Form
    {
        public ConsoleWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public bool IsMetadatable
        {
            get;set;
        }

        private void ConsoleWindow_Load(object sender, EventArgs e)
        {
            if(IsMetadatable) {
                panel1.Visible = true;
                meta.Visible = true;
            } else
            {
                panel1.Visible = false;
                meta.Visible = false;
                this.Height = richTextBox1.Height + 60;
            }
        }
    }
}
