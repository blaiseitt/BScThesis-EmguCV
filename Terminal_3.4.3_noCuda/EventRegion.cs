using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

namespace Terminal_3._4._3_noCuda
{
    public delegate void RegionSenderHandler(int hHei, int wWei, int xX, int yY);

    public partial class EventRegion : Form
    {
        public event RegionSenderHandler RegionSender;

        int xXX;
        int yYY;
        int hhHeight;
        int wwWidth;
        bool FirstTime; //zmienna pomagająca w wyeliminowaniu błedu polegającego na tym że użytkownik nie mógł zmienić obszaru wcześniej ustalonego 

        //Point LeftUpper;

        int xMax, yMax, wMax, hMax;

        public EventRegion()
        {
            InitializeComponent();
        }

        public EventRegion(Size size, int iks, int igrek, int wid, int heg)
        {
            InitializeComponent();

            trackHeight.Maximum =       size.Height;
            trackWidth.Maximum =        size.Width;
            numericUpDown1.Maximum =    size.Width;
            numericUpDown2.Maximum =    size.Height;

            hMax = size.Height;
            yMax = size.Height;
            wMax = size.Width;
            xMax = size.Width;

            imageBox1.Size = size;

            xXX         = iks;
            yYY         = igrek;
            wwWidth     = wid;
            hhHeight    = heg;

            label4.Text = wwWidth.ToString();
            label3.Text = hhHeight.ToString();

            if (xXX == 0)
            {
                FirstTime = true;
            }
            else FirstTime = false;

            numericUpDown1.Value = xXX;
            numericUpDown2.Value = yYY;
            trackWidth.Value = wwWidth;
            trackHeight.Value = hhHeight;

            FirstTime = true;

            DrawRectangeOnIB();
            
            this.Text = "Wyznaczanie obszaru w którym znalezione ma zostać zdarzenie.";
        }

        private void trackWidth_Scroll(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                label4.Text = trackWidth.Value.ToString();
                trackWidth.Maximum = wMax - (xXX + 4);
                GetRectangleSizeAndPosition();
                this.RegionSender(hhHeight, wwWidth, xXX, yYY);
                DrawRectangeOnIB();
            }
        }

        private void trackHeight_Scroll(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                label3.Text = trackHeight.Value.ToString();
                trackHeight.Maximum = hMax - (yYY + 4);
                GetRectangleSizeAndPosition();
                this.RegionSender(hhHeight, wwWidth, xXX, yYY);
                DrawRectangeOnIB();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                numericUpDown1.Maximum = xMax - (wwWidth + 4);
                GetRectangleSizeAndPosition();
                this.RegionSender(hhHeight, wwWidth, xXX, yYY);
                DrawRectangeOnIB();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                numericUpDown2.Maximum = yMax - (hhHeight + 4);
                GetRectangleSizeAndPosition();
                this.RegionSender(hhHeight, wwWidth, xXX, yYY);
                DrawRectangeOnIB();
            }   
        }

        public void GetRectangleSizeAndPosition()
        {
            xXX = (int)numericUpDown1.Value;
            yYY = (int)numericUpDown2.Value;
            wwWidth = (int)trackWidth.Value;
            hhHeight = (int)trackHeight.Value;
        }

        private void DrawRectangeOnIB()
        {
            GetRectangleSizeAndPosition();
            //Mat tempMat = new Mat(imageBox2.Size, DepthType.Cv8U, 3);
            Mat tempMat;
            Image<Bgr, byte> tempIMG = new Image<Bgr, byte>(imageBox1.Size);
            tempMat = tempIMG.Mat;

            Rectangle Kwadrat = new Rectangle(xXX, yYY, wwWidth, hhHeight);
            CvInvoke.Rectangle(tempMat, Kwadrat, new MCvScalar(0, 255, 255), 3);
            //imageBox2.Image = tempIMG;
            imageBox1.Image = tempMat.ToImage<Bgr, byte>();
        }

    }
}
