using System;
using System.Collections.Generic;
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
    public class RestoreScanner
    {

        public int MAX_COUNT = 0;
        public static List<string> ImageExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
        private static Regex r = new Regex(":");
        private Window win;
        private String rootpath;
        public int metaerr = 0;

        private ConsoleWindow cwin;
         
        public RestoreScanner(String rootpath, Window win)
        {
            this.rootpath = rootpath;
            this.win = win;
            this.cwin = new ConsoleWindow();
            this.cwin.IsMetadatable = true;
        }

        public void ScanAndCopyFiles()
        {
            if(Directory.Exists(this.rootpath+ Path.DirectorySeparatorChar + "OUTPUT"))
            {
                Directory.Delete(this.rootpath+ Path.DirectorySeparatorChar + "OUTPUT", true);
            }

            Directory.CreateDirectory(rootpath+ Path.DirectorySeparatorChar + "OUTPUT");

            ParallelOptions options = new ParallelOptions
            {
                // Limit the maximum number of concurrent tasks
                MaxDegreeOfParallelism = Math.Max(1, Environment.ProcessorCount / 2)
            };

            IEnumerable<string> files = null;
            try
            {

                files = Directory.EnumerateFiles(this.rootpath + Path.DirectorySeparatorChar, "*.*", SearchOption.AllDirectories)
                    .Where(path => !path.Split(Path.DirectorySeparatorChar).Contains("OUTPUT"))
                    .Where(path => ImageExtensions.Contains(Path.GetExtension(path)));
                
                MAX_COUNT = files.Count();
            } catch(UnauthorizedAccessException e)
            {
                /*
                this.win.Invoke(new MethodInvoker(() =>
                {
                    this.cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "Unable to enter directory " + this.rootpath + " the windows user has no permissions to read this folder.\n\n");
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

                       LastFilePath = filepath;

                       if (win.isCancel)
                       {
                           return;
                       }

                       bool ext = ImageExtensions.Contains(Path.GetExtension(filepath));

                       if (ext)
                       {
                           DateTime? date = null;
                           try
                           {
                               using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                               using (Image myImage = Image.FromStream(fs, false, false))
                               {
                                   PropertyItem propItem = myImage.GetPropertyItem(36867);
                                   string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                                   date = DateTime.Parse(dateTaken);
                                   myImage.Dispose();
                                   fs.Flush();
                                   fs.Close();
                               }
                           }
                           catch (ArgumentException argumentex)
                           {
                               
                               this.metaerr++;
                               this.win.Invoke(new MethodInvoker(() =>
                               {
                                   cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "unable to find metadata for file " + filepath + ", skipping!" + "\n\n");
                                   cwin.richTextBox1.Update();
                               }));
                               //MessageBox.Show("This file: "+filepath+" does not have the proper metadata tag set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               
                               //throw argumentex;
                           }
                           catch (UnauthorizedAccessException uex)
                           {
                               /*
                               this.win.Invoke(new MethodInvoker(() =>
                               {
                                   this.cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "cannot read file " + filepath + " the Windows user has not enough rights to read this file.\n\n");
                               }));
                               */
                               throw;
                           }
                           catch (AggregateException ex)
                           {
                               /*
                               this.cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "cannot read file " + filepath + " the Windows user has not enough rights to read this file.\n\n");
                                */
                               throw;
                            }
                           catch (Exception e1)
                           {
                               /*
                               this.win.Invoke(new MethodInvoker(() =>
                               {
                                   this.cwin.richTextBox1.AppendText("[" + DateTime.Now.ToString("G") + "]: " + "Unknown error happened: " + e1.ToString() + "\n\n");
                               }));
                               */
                               throw;
                           }

                           if (date != null && date != DateTime.MinValue)
                           {
                               win.Invoke(new MethodInvoker(() =>
                               {
                                   this.win.currentfiletext.Text = filepath;
                                   this.win.currentfiletext.Update();
                               }));
                               string output_path;
                               try
                               {
                                   File.Copy(filepath, output_path = this.rootpath + Path.DirectorySeparatorChar + "OUTPUT" + Path.DirectorySeparatorChar + Path.GetFileName(filepath));
                                   File.SetCreationTime(output_path, date.Value);
                                   File.SetLastWriteTime(output_path, date.Value);
                               } catch(Exception e)
                               {
                                   throw;
                               }
                           }
                       }
                       win.Invoke(new MethodInvoker(() =>
                       {
                           this.win.progressBar1.Value = this.win.progressBar1.Value + 1;
                           this.win.progressBar1.Update();
                       }));
                   });
        }

        public string LastFilePath
        {
            get;set;
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
