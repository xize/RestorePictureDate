using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestorePictureDate
{
    public class CopyScanner
    {

        public int MAX_COUNT = 0;
        public static List<string> ImageExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
        private Window win;
        private String srcpath;
        private String dstpath; 
        private int metaerr = 0;

        private ConsoleWindow cwin;

        public CopyScanner(String srcpath, String dstpath, Window win)
        {
            this.srcpath = srcpath;
            this.dstpath = dstpath;
            this.win = win;
            this.cwin = new ConsoleWindow();
        }

        public void ScanAndCopyFiles()
        {
            ParallelOptions options = new ParallelOptions
            {
                // Limit the maximum number of concurrent tasks
                MaxDegreeOfParallelism = Math.Max(1, Environment.ProcessorCount / 2)
            };

            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFiles(this.srcpath + Path.DirectorySeparatorChar, "*.*", SearchOption.AllDirectories)
                    .Where(path => ImageExtensions.Contains(Path.GetExtension(path)));

                MAX_COUNT = files.Count();
            } catch (UnauthorizedAccessException e)
            {
                /*
                this.win.Invoke(new MethodInvoker(() =>
                {
                    this.cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "Unable to enter directory " + this.srcpath + " the windows user has no permissions to read this folder.\n\n");
                }));
                
                this.win.isCancel = true;
                */
                throw;
            }
            // set the progressbar to count.
            win.Invoke(new MethodInvoker(() =>
            {
                this.win.progressBar1.Maximum = this.MAX_COUNT;
                this.win.progressBar1.Value = 0;
                this.win.progressBar1.Update();
            }));

            Parallel.ForEach(files, options, filepath =>
               {
                   if (win.isCancel)
                   {
                       return;
                   }

                   bool ext = ImageExtensions.Contains(Path.GetExtension(filepath));

                   if (ext)
                   {
                       DateTime? date = null;

                       date = File.GetCreationTime(filepath);


                       win.Invoke(new MethodInvoker(() =>
                       {
                               this.win.currentfiletext.Text = filepath;
                               this.win.currentfiletext.Update();
                       }));

                       string dst = dstpath + Path.DirectorySeparatorChar + Path.GetFileName(filepath);

                       if(win.overwrite_copy)
                       {
                           File.Copy(filepath, dst,true);
                       } else
                       {
                           try
                           {
                               File.Copy(filepath, dst);
                           } catch(IOException e)
                           {
                               //supress.
                               throw;
                           }
                       }
                       
                       File.SetCreationTime(dst, date.Value);
                       File.SetLastWriteTime(dst, date.Value);
                   }
                   win.Invoke(new MethodInvoker(() =>
                   {
                       this.win.progressBar1.Value = this.win.progressBar1.Value + 1;
                       this.win.progressBar1.Update();
                   }));
               });
        }

        public int GetMetaErrno()
        {
            return this.metaerr;
        }

        public ConsoleWindow GetConsole()
        {
            return this.cwin;
        }
    }
}
