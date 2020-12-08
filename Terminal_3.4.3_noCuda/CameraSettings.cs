using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal_3._4._3_noCuda
{
    public delegate void CameraSettingsSenderHandler(int brightness, int contrast, int sharpness, bool negative, bool grayScale, bool flipMode);

    public partial class CameraSettings : Form
    {
        public event CameraSettingsSenderHandler CameraSettingsSender;

        int brightness = 75;
        int contrast = 25;
        int sharpness = 20;
        bool grayScale, negative, flipMode;
        bool FirstTime;

        public CameraSettings()
        {
            InitializeComponent();
        }

        public CameraSettings(int bright, int contr, int sharp, bool negat, bool graY, bool fliP)
        {
            brightness = bright;
            contrast = contr;
            sharpness = sharp;
            negative = negat;
            grayScale = graY;
			flipMode = fliP;
            InitializeComponent();
            FirstTime = false;
            
            lblBrightness.Text = brightness.ToString();
            lblContrast.Text = contrast.ToString();
            lblSharpness.Text = sharpness.ToString();
            if (brightness == 75 && contrast == 25 && sharpness == 20 && grayScale == false && negative == false)
            {
                FirstTime = true;
            }
            else FirstTime = false;
            SetInterface();
        }

        private void SetInterface()
        {
            tbBrightness.Value = brightness;
            tbContrast.Value = contrast;
            tbSharpness.Value = sharpness;
            cbNegativ.Checked = negative;
            cbGray.Checked = grayScale;
			cbFlip.Checked = flipMode;
            FirstTime = true;
        }

        private void tbBrightness_ValueChanged(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                brightness = tbBrightness.Value;
                lblBrightness.Text = brightness.ToString();
                this.CameraSettingsSender(brightness, contrast, sharpness, negative, grayScale, flipMode);
            }
        }

        private void tbContrast_ValueChanged(object sender, EventArgs e)
        {
            if(FirstTime == true)
            {
                contrast = tbContrast.Value;
                lblContrast.Text = contrast.ToString();
                this.CameraSettingsSender(brightness, contrast, sharpness, negative, grayScale, flipMode);
            }
        }

        private void tbSharpness_ValueChanged(object sender, EventArgs e)
        {
            if(FirstTime == true)
            {
                sharpness = tbSharpness.Value;
                lblSharpness.Text = sharpness.ToString();
                this.CameraSettingsSender(brightness, contrast, sharpness, negative, grayScale, flipMode);
            }
        }
		
		private void cbGray_CheckedChanged(object sender, EventArgs e)
        {
            if(FirstTime == true)
            {
                grayScale = cbGray.Checked;
                this.CameraSettingsSender(brightness, contrast, sharpness, negative, grayScale, flipMode);
            }
        }

		private void cbNegativ_CheckedChanged(object sender, EventArgs e)
        {
            if (FirstTime == true)
            {
                negative = cbNegativ.Checked;
                this.CameraSettingsSender(brightness, contrast, sharpness, negative, grayScale, flipMode);
            }
        }
		
		private void cbFlip_CheckedChanged(object sender, EventArgs e)
		{
			if (FirstTime == true)
			{
				flipMode = cbFlip.Checked;
				this.CameraSettingsSender(brightness, contrast, sharpness, negative, grayScale, flipMode);
			}
		}
	}
}
