using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SystemWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //قفل کردن کامپیوتر   
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
        //خالی کردن سطل  ویندوز
        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath,
        RecycleFlags dwFlags);
         [DllImport("user32")]
        internal static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        internal static extern void ReleaseDC(IntPtr dc);
        public void PaintRectangleToScreen()
        {
                IntPtr deskDC = GetDC(IntPtr.Zero);
                Graphics g = Graphics.FromHdc(deskDC);
                Font font = new Font("Arial Black", 36);                
                DrawStringOnCenter(g, "Desktop Writing!", font, new Point(0, -25));
                font = new Font("Arial Black", 18);
                DrawStringOnCenter(g, "by: Ramzan", font, new Point(0, 25));
                Rectangle rect = new Rectangle(200, 300, 
                    Screen.PrimaryScreen.Bounds.Width - 400, 
                    Screen.PrimaryScreen.Bounds.Height - 600);
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DodgerBlue))
                    , rect);
                g.DrawRectangle(new Pen(Color.DodgerBlue, 3), rect);
                g.Dispose();
                ReleaseDC(deskDC);
            }
        private void DrawStringOnCenter(Graphics g, string str, Font font, Point offset)
        {
            SizeF size = g.MeasureString(str, font);
            g.DrawString(str, font, Brushes.White,
                      new PointF(
                                  (Screen.PrimaryScreen.Bounds.Width - size.Width) / 2 + offset.X,
                                  ( Screen.PrimaryScreen.Bounds.Height - size.Height) / 2 + offset.Y)
                                 );
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            uint result = SHEmptyRecycleBin(IntPtr.Zero, null, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //محاسبه زمان اجرای قسمتی برنامه 
            // Create an instance of the new StopWatch class
            Stopwatch myWatch = new Stopwatch();
            // Start the timer
            myWatch.Start();
            //Code Here...
            // Now we can stop the timer and display the elapsed time along
            for (int i = 1; i <= 10000; i++)
                for (int j = 1; j <= 100000; j++) ; 

            myWatch.Stop();
            MessageBox.Show( myWatch.ElapsedMilliseconds.ToString());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // ریست کردن برنامه کردن برنامه
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
               PaintRectangleToScreen();
         }

        private void button6_Click(object sender, EventArgs e)
        {
             
            label1.BackColor = Color.Transparent;
           
            label1.BackColor = Color.FromArgb(127, label1.BackColor);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ILIYA ON TOP ");
        }
    }
}
