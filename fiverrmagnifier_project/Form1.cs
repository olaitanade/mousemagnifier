using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fiverrmagnifier_project
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEYIN_ID = 1;
        const int MYACTION_HOTKEYOUT_ID = 2;
        const int MYACTION_HOTKEY_ID = 3;
        const int MYACTION_HOTKEY_SAVE = 4;

        public Form1()
        {
            InitializeComponent();
            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)Keys.F3);
            RegisterHotKey(this.Handle, MYACTION_HOTKEYIN_ID, 2, (int)Keys.F1);
            RegisterHotKey(this.Handle, MYACTION_HOTKEYOUT_ID, 2, (int)Keys.F2);
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_SAVE, 2, (int)Keys.F4);
        }

        Graphics g;//Graphics object that draws the image captured around the cursor

        Bitmap bmp;//Bitmap object that handles the pixels around the cursor

        int zoomFactor = 1;
        int zoompercentage = 0;

        bool tellhim = true;

        readonly object stateLock = new object();

        int x = 300;//initial size of the square around the cursor
        int y = 300;

        int newx=300;
        int newy=300;

        int screendiffwidth=0;
        int screendiffheight=0;
        int screendiffwidRatio = 0;
        int screendiffheightRatio = 0;
        //This method runs every 100miliseconds to create the images on the view box
        private void timer_eventhandler(object sender, EventArgs e)
        {
            

            if (zoomFactor == 1 || zoomFactor > 1)
            {
                this.DoubleBuffered = true;
                bmp = new Bitmap(x,y);//Setting the bitmap size to hold or contain pixels round the cursor
                

                g = this.CreateGraphics();//initializing the graphics object

                g = Graphics.FromImage(bmp);//creates graphics from the bitmap image

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //Copies the pixels around the cursor
                g.CopyFromScreen(MousePosition.X - (x / 2), MousePosition.Y - (y / 2), 0, 0, new Size(x, y));
                

                if (checkBox1.Checked == true)
                {
                    grayscale();
                    if (tellhim)
                    {
                        tellhim = false;
                        MessageBox.Show("Reduce the size of the display window to make it faster");
                        x = 100;
                        y = 100;
                        pictureBoxViewer.Size = new Size(x, y);
                        this.Size = new Size(x + 200, y + 150);

                        newx = x;
                        newy = y;

                    }

                    //if zoomfactor equals zero use the normal image copied directly from the screen
                    
                }

                if (zoomFactor == 1)
                {
                    pictureBoxViewer.Image = bmp;
                }
                else
                {
                    pictureBoxViewer.Image = new Bitmap(bmp, bmp.Width * zoomFactor, bmp.Height * zoomFactor);
                }
               
            }
            else if (zoomFactor < 1)
            {
                
                this.DoubleBuffered = true;
                
                bmp = new Bitmap(newx, newy);
                //bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);

                g = this.CreateGraphics();//initializing the graphics object

                g = Graphics.FromImage(bmp);//creates graphics from the bitmap image

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //Copies the pixels around the cursor

                g.CopyFromScreen(MousePosition.X - (newx / 2), MousePosition.Y - (newy / 2), 0, 0, new Size(newx, newy));
                //g.CopyFromScreen(0, 0, 0, 0, new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height));

                if (checkBox1.Checked == true)
                {
                    grayscale();
                    if (tellhim)
                    {
                        tellhim = false;
                        MessageBox.Show("Reduce the size of the display window to make it faster");
                        x = 100;
                        y = 100;
                        pictureBoxViewer.Size = new Size(x, y);
                        this.Size = new Size(x + 200, y + 150);
                        zoomFactor = 1;
                        zoompercentage = 0;
                        percentageLbl.Text = zoompercentage + "%";

                        newx = x;
                        newy = y;

                    }

                    //if zoomfactor equals zero use the normal image copied directly from the screen

                }
                pictureBoxViewer.Image = new Bitmap(bmp,x,y);
            }

           

           
            //view the captured pixels in the view box on the window
            
        }

        private void grayscale()
        {
            Color p;

            //GrayScale 
            
                for (int z = 0; z < bmp.Height; z++)
                {
                    for (int w = 0; w < bmp.Width; w++)
                    {
                        //get pixel value
                        
                        
                            p = bmp.GetPixel(w, z);

                            //extract pixel component argb
                            int a = p.A;
                            int r = p.R;
                            int gr = p.G;
                            int b = p.B;

                            //find average
                            int avg = (r + gr + b) / 3;

                            //set new pixel value

                            bmp.SetPixel(w, z, Color.FromArgb(a, avg, avg, avg));
                            pictureBoxViewer.Image = bmp;
                        
                    }
                }
            
            
        }

        //This method handles the changing of the rectangle size around the cursor
        private void click_eventhandler(object sender, EventArgs e)
        {
            string xvalue = size_txtbox.Text;
            string yvalue=y_txtbx.Text;
            
            if (!int.TryParse(xvalue, out x) || !int.TryParse(yvalue,out y) )
            {
                MessageBox.Show("Expects an integer or double");

            }
            else
            {
                pictureBoxViewer.Size = new Size(x, y);
                this.Size = new Size(x + 90, y + 150);
                newx = x;
                newy = y;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void size_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            if (zoomFactor < -1 && zoomFactor!=-1)
            {
                zoomFactor = zoomFactor + 1;
                zoompercentage = zoompercentage + 25;
                percentageLbl.Text = zoompercentage + "%";

                newx -= screendiffwidRatio;
                newy -= screendiffheightRatio;
            }
            else if (zoomFactor == -1)
            {
                zoomFactor = zoomFactor + 2;
                zoompercentage = zoompercentage + 25;
                percentageLbl.Text = zoompercentage + "%";
                newx = x;
                newy = y;
            }
            else if (zoomFactor > 0 && zoomFactor < 5)
            {
                zoomFactor = zoomFactor + 1;
                zoompercentage = zoompercentage + 25;
                percentageLbl.Text = zoompercentage + "%";
            }
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            if (zoomFactor != 1 && zoomFactor>1)
            {
                zoomFactor = zoomFactor - 1;
                zoompercentage = zoompercentage - 25;
                percentageLbl.Text = zoompercentage + "%";
            }
            else if (zoomFactor == 1)
            {
                zoomFactor = zoomFactor - 2;
                zoompercentage = zoompercentage - 25;
                percentageLbl.Text = zoompercentage + "%";

                screendiffwidth = SystemInformation.VirtualScreen.Width - x;
                screendiffheight = SystemInformation.VirtualScreen.Height - y;
                screendiffwidRatio = screendiffwidth / 16;
                screendiffheightRatio = screendiffheight / 16;
                newx += screendiffwidRatio;
                newy += screendiffheightRatio;
            }
            else if (zoomFactor < 0 && zoomFactor > -16)
            {
                zoomFactor = zoomFactor - 1;
                zoompercentage = zoompercentage - 25;
                percentageLbl.Text = zoompercentage + "%";

                newx += screendiffwidRatio;
                newy += screendiffheightRatio;
            }
        }

        private void Form1_keydown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode==Keys.F1)
            {
                if (zoomFactor < -1 && zoomFactor != -1)
                {
                    zoomFactor = zoomFactor + 1;
                    zoompercentage = zoompercentage + 25;
                    percentageLbl.Text = zoompercentage + "%";

                    newx -= screendiffwidRatio;
                    newy -= screendiffheightRatio;
                }
                else if (zoomFactor == -1)
                {
                    zoomFactor = zoomFactor + 2;
                    zoompercentage = zoompercentage + 25;
                    percentageLbl.Text = zoompercentage + "%";

                    newx = x;
                    newy = y;
                }
                else if (zoomFactor > 0 && zoomFactor < 5)
                {
                    zoomFactor = zoomFactor + 1;
                    zoompercentage = zoompercentage + 25;
                    percentageLbl.Text = zoompercentage + "%";
                }
            }

            if(e.Control && e.KeyCode==Keys.F2){
                if (zoomFactor != 1 && zoomFactor > 1)
                {
                    zoomFactor = zoomFactor - 1;
                    zoompercentage = zoompercentage - 25;
                    percentageLbl.Text = zoompercentage + "%";
                }
                else if (zoomFactor == 1)
                {
                    zoomFactor = zoomFactor - 2;
                    zoompercentage = zoompercentage - 25;
                    percentageLbl.Text = zoompercentage + "%";

                    screendiffwidth = SystemInformation.VirtualScreen.Width - x;
                    screendiffheight = SystemInformation.VirtualScreen.Height - y;
                    screendiffwidRatio = screendiffwidth / 16;
                    screendiffheightRatio = screendiffheight / 16;
                    newx += screendiffwidRatio;
                    newy += screendiffheightRatio;
                }
                else if (zoomFactor < 0 && zoomFactor > -16)
                {
                    zoomFactor = zoomFactor - 1;
                    zoompercentage = zoompercentage - 25;
                    percentageLbl.Text = zoompercentage + "%";

                    newx += screendiffwidRatio;
                    newy += screendiffheightRatio;
                }
            }
            if(e.Control && e.KeyCode==Keys.F3){
                zoomFactor = 1;
                zoompercentage = 0;
                percentageLbl.Text = zoompercentage + "%";
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                // My hotkey has been typed
                
                zoomFactor = 1;
                zoompercentage = 0;
                percentageLbl.Text = zoompercentage + "%";

                newx = x;
                newy = y;
                // Do what you want here
                // ...
            }
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEYIN_ID)
            {
                // My hotkey has been typed

                if (zoomFactor < -1 && zoomFactor != -1)
                {
                    zoomFactor = zoomFactor + 1;
                    zoompercentage = zoompercentage + 25;
                    percentageLbl.Text = zoompercentage + "%";

                    newx -= screendiffwidRatio;
                    newy -= screendiffheightRatio;
                }
                else if (zoomFactor == -1)
                {
                    zoomFactor = zoomFactor + 2;
                    zoompercentage = zoompercentage + 25;
                    percentageLbl.Text = zoompercentage + "%";

                    newx = x;
                    newy = y;
                }
                else if (zoomFactor > 0 && zoomFactor < 5)
                {
                    zoomFactor = zoomFactor + 1;
                    zoompercentage = zoompercentage + 25;
                    percentageLbl.Text = zoompercentage + "%";
                }
                // Do what you want here
                // ...
            }
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEYOUT_ID)
            {
                // My hotkey has been typed

                if (zoomFactor != 1 && zoomFactor > 1)
                {
                    zoomFactor = zoomFactor - 1;
                    zoompercentage = zoompercentage - 25;
                    percentageLbl.Text = zoompercentage + "%";
                }
                else if (zoomFactor == 1)
                {
                    zoomFactor = zoomFactor - 2;
                    zoompercentage = zoompercentage - 25;
                    percentageLbl.Text = zoompercentage + "%";

                    screendiffwidth = SystemInformation.VirtualScreen.Width - x;
                    screendiffheight = SystemInformation.VirtualScreen.Height - y;
                    screendiffwidRatio = screendiffwidth / 16;
                    screendiffheightRatio = screendiffheight / 16;
                    newx += screendiffwidRatio;
                    newy += screendiffheightRatio;
                }
                else if (zoomFactor < 0 && zoomFactor > -16)
                {
                    zoomFactor = zoomFactor - 1;
                    zoompercentage = zoompercentage - 25;
                    percentageLbl.Text = zoompercentage + "%";

                    newx += screendiffwidRatio;
                    newy += screendiffheightRatio;
                }
                // Do what you want here
                // ...
            }
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_SAVE)
            {
                saveImage();
            }
            base.WndProc(ref m);
        }

        private void saveImage()
        {
            
            try
            {
                byte[] imgbyte = new byte[0];
                using (MemoryStream m = new MemoryStream())
                {
                    Image im = (Image)bmp;
                    im.Save(m, ImageFormat.Png);
                    imgbyte = m.ToArray();
                    m.Close();
                }

                Random rd = new Random();
                string nwfilename = "MagnifierFile" + rd.Next(9000) + ".csv";
                string newfile = @"..\" + nwfilename;
                FileStream fs = new FileStream(newfile, FileMode.Create);

                using (StreamWriter sw = new StreamWriter(fs))
                {

                    Color p;
                    int count = 0;

                    //GrayScale 

                    for (int z = 0; z < bmp.Height; z++)
                    {
                        for (int w = 0; w < bmp.Width; w++)
                        {
                            //get pixel value


                            p = bmp.GetPixel(w, z);

                            //extract pixel component argb
                            int a = p.A;
                            int r = p.R;
                            int gr = p.G;
                            int b = p.B;

                            //find average
                            int avg = (r + gr + b) / 3;

                            //write average to the file
                            if (count < x)
                            {
                                if (count == x - 1)
                                {
                                    sw.Write(avg);
                                    sw.WriteLine();
                                    count = 0;
                                }
                                else
                                {
                                    sw.Write(avg + ",");
                                    count++;
                                }
                               
                            }
                           

                           

                        }
                    }
                    
                }

                FileInfo f_info = new FileInfo(newfile);
                MessageBox.Show("File saved information \n Name: " + nwfilename + "\n File path is: " + f_info.DirectoryName);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }
    }
}
