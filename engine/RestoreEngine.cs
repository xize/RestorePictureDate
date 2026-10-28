using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestorePictureDate.engine
{
    public class RestoreEngine : Engine
    {

        public string Name { get => "RestoreEngine"; }

        public async Task AsyncRun(Window win)
        {
            await Task.Run(() =>
            {
            win.Invoke(new MethodInvoker(() =>
            {
                win.Cursor = Cursors.WaitCursor;
                win.groupBox2.Enabled = false;
                win.groupBox3.Enabled = false;
                win.groupBox2.Update();
                win.groupBox3.Update();
            }));

            RestoreScanner scanner = new RestoreScanner(win.rtargettext.Text, win);
            try
            {
                scanner.ScanAndCopyFiles();
            } catch (UnauthorizedAccessException e)
            {
                win.Invoke(new MethodInvoker(() =>
                {
                    ConsoleWindow cwin = scanner.GetConsole();
                    cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "Unable to enter directory " + win.rtargettext.Text + " the windows user has no permissions to read this folder.\n\n");
                    cwin.richTextBox1.Update();
                }));
                win.isCancel = true;
            /*} catch (ArgumentException e)
            {
                win.Invoke(new MethodInvoker(() =>
                {
                    scanner.metaerr++;
                    ConsoleWindow cwin = scanner.GetConsole();
                    cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "unable to find metadata for file " + scanner.LastFilePath + ", skipping" + "\n\n");
                    cwin.richTextBox1.Update();
                }));
            */
            } catch (AggregateException e)
            {
                win.Invoke(new MethodInvoker(() => {
                    ConsoleWindow cwin = scanner.GetConsole();
                    cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "cannot read file " + scanner.LastFilePath + " the Windows user has not enough rights to read this file.\n\n");
                    cwin.richTextBox1.Update();
                }));
                    
            } catch(Exception e)
            {
                    win.Invoke(new MethodInvoker(() =>
                    {
                        ConsoleWindow cwin = scanner.GetConsole();
                        cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "Unknown error happened: " + e.ToString() + "\n\n");
                        cwin.richTextBox1.Update();
                    }));
            }

                win.Invoke(new MethodInvoker(() =>
                {
                    ConsoleWindow cwin = scanner.GetConsole();
                    win.Cursor = Cursors.Default;
                    win.groupBox2.Enabled = true;
                    win.groupBox2.Update();
                    win.groupBox3.Enabled = true;
                    win.groupBox3.Update();
                    win.progressBar1.Value = scanner.MAX_COUNT;
                    win.progressBar1.Update();
                    cwin.meta.Text = String.Format(cwin.meta.Text, scanner.GetMetaErrno());
                    if(String.IsNullOrEmpty(cwin.richTextBox1.Text))
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
