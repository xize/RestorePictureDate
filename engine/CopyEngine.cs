using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestorePictureDate.engine
{
    public class CopyEngine : Engine
    {

        public string Name => "CopyEngine";

        public async Task AsyncRun(Window win)
        {
            await Task.Run(async () =>
            {
                win.Invoke(new MethodInvoker(() => {
                    win.Cursor = Cursors.WaitCursor;
                    win.groupBox2.Enabled = false;
                    win.groupBox3.Enabled = false;
                    win.groupBox2.Update();
                    win.groupBox3.Update();
                }));

                CopyScanner scanner = new CopyScanner(win.copysrcfield.Text, win.copytargetfield.Text, win);
                try
                {
                    scanner.ScanAndCopyFiles();
                } catch(UnauthorizedAccessException e)
                {
                    string offending_dir = win.copysrcfield.Text;
                    MessageBox.Show("The folder or a folder inside this folder has not the right permissions to be read!: "+offending_dir, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    win.isCancel = true;
                    
                } catch(IOException e)
                {
                    if (!win.overwrite_copy)
                    {
                        string offending_file = win.currentfiletext.Text;
                        MessageBox.Show("Unable to overwrite file!, you are lacking the proper permissions for file: "+offending_file, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        win.isCancel = true;
                    }
                    
                }

                win.Invoke(new MethodInvoker(() => {
                    ConsoleWindow cwin = scanner.GetConsole();
                    win.Cursor = Cursors.Default;
                    win.groupBox2.Enabled = true;
                    win.groupBox2.Update();
                    win.groupBox3.Enabled = true;
                    win.groupBox3.Update();
                    win.progressBar1.Value = scanner.MAX_COUNT;
                    win.progressBar1.Update();
                    cwin.meta.Text = String.Format(cwin.meta.Text, scanner.GetMetaErrno());
                    if (String.IsNullOrEmpty(cwin.richTextBox1.Text))
                    {
                        cwin.richTextBox1.Text = "No breaking errors found.";
                    }
                    DialogResult r = cwin.ShowDialog();
                    if (r == DialogResult.OK)
                    {
                        win.progressBar1.Value = 0;
                    }
                }));
            });
        }
    }
}
