using RestorePictureDate.engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestorePictureDate
{
    public partial class Window : Form
    {

        public bool isCancel = false;
        public bool overwrite_copy = false;

        public Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rtargetbtn_Click(object sender, EventArgs e)
        {
            DialogResult r = this.rtargetdialog.ShowDialog();

            if(r == DialogResult.OK)
            {

                string path = Path.GetFullPath(this.rtargetdialog.SelectedPath);
                this.rtargettext.Text = path;
                this.rtargettext.Update();
            }
        }

        private async void restorebtn_ClickAsync(object sender, EventArgs e)
        {
            this.isCancel = false;
            string path = this.rtargettext.Text;
            if (String.IsNullOrEmpty(path)) {
                MessageBox.Show("The target path is empty", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            } else if(!Directory.Exists(path))
            {
                MessageBox.Show("The directory does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RestoreEngine en = new RestoreEngine();
            await en.AsyncRun(this);
            

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.isCancel = true;
        }

        private void copyimgsrcbtn_Click(object sender, EventArgs e)
        {
            DialogResult r = this.copysrcdialog.ShowDialog();
            if(r == DialogResult.OK)
            {
                string path = Path.GetFullPath(this.copysrcdialog.SelectedPath);
                this.copysrcfield.Text = path;
                this.copysrcfield.Update();
            }
        }

        private void copytargetbtn_Click(object sender, EventArgs e)
        {
            DialogResult r = this.copydstdialog.ShowDialog();
            if(r == DialogResult.OK)
            {
                this.copytargetfield.Text = Path.GetFullPath(this.copydstdialog.SelectedPath);
                this.copytargetfield.Update();
            }
            
        }

        private async void copypastebtn_Click(object sender, EventArgs e)
        {
            this.isCancel = false;
            this.overwrite_copy=false;
            if(String.IsNullOrEmpty(this.copysrcfield.Text) || String.IsNullOrEmpty(this.copytargetfield.Text))
            {
                MessageBox.Show("the fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(this.copysrcfield.Text.Equals(this.copytargetfield.Text))
            {
                MessageBox.Show("the fields cannot be identical.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = Path.GetFullPath(this.copydstdialog.SelectedPath);
            try
            {
                if (Directory.GetFiles(this.copydstdialog.SelectedPath).Length > 0)
                {
                    DialogResult yn = MessageBox.Show("there are files detected inside the destination directory, overwrite them? yes/no", "files or folders found inside destination directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yn == DialogResult.Yes)
                    {
                        this.overwrite_copy = true;
                    }
                }
            }
            catch (UnauthorizedAccessException e1)
            {
                MessageBox.Show("No permissions to read this folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException e1)
            {
                MessageBox.Show("Directory not found!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CopyEngine engine = new CopyEngine();
            await engine.AsyncRun(this);
        }
    }
}
 