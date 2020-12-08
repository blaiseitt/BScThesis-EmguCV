namespace Terminal_3._4._3_noCuda
{
    partial class CameraSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tbBrightness = new System.Windows.Forms.TrackBar();
			this.tbContrast = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSharpness = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.cbGray = new System.Windows.Forms.CheckBox();
			this.cbNegativ = new System.Windows.Forms.CheckBox();
			this.lblSharpness = new System.Windows.Forms.Label();
			this.lblContrast = new System.Windows.Forms.Label();
			this.lblBrightness = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.cbFlip = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSharpness)).BeginInit();
			this.SuspendLayout();
			// 
			// tbBrightness
			// 
			this.tbBrightness.Location = new System.Drawing.Point(116, 55);
			this.tbBrightness.Maximum = 100;
			this.tbBrightness.Name = "tbBrightness";
			this.tbBrightness.Size = new System.Drawing.Size(397, 45);
			this.tbBrightness.TabIndex = 0;
			this.tbBrightness.Value = 75;
			this.tbBrightness.ValueChanged += new System.EventHandler(this.tbBrightness_ValueChanged);
			// 
			// tbContrast
			// 
			this.tbContrast.Location = new System.Drawing.Point(116, 132);
			this.tbContrast.Maximum = 100;
			this.tbContrast.Name = "tbContrast";
			this.tbContrast.Size = new System.Drawing.Size(397, 45);
			this.tbContrast.TabIndex = 1;
			this.tbContrast.Value = 25;
			this.tbContrast.ValueChanged += new System.EventHandler(this.tbContrast_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(52, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Jasność";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(52, 132);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Kontrast";
			// 
			// tbSharpness
			// 
			this.tbSharpness.Location = new System.Drawing.Point(116, 209);
			this.tbSharpness.Maximum = 20;
			this.tbSharpness.Name = "tbSharpness";
			this.tbSharpness.Size = new System.Drawing.Size(397, 45);
			this.tbSharpness.TabIndex = 4;
			this.tbSharpness.Value = 20;
			this.tbSharpness.ValueChanged += new System.EventHandler(this.tbSharpness_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(52, 209);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Ostrość";
			// 
			// cbGray
			// 
			this.cbGray.AutoSize = true;
			this.cbGray.Location = new System.Drawing.Point(55, 274);
			this.cbGray.Name = "cbGray";
			this.cbGray.Size = new System.Drawing.Size(94, 17);
			this.cbGray.TabIndex = 6;
			this.cbGray.Text = "Skala szarości";
			this.cbGray.UseVisualStyleBackColor = true;
			this.cbGray.CheckedChanged += new System.EventHandler(this.cbGray_CheckedChanged);
			// 
			// cbNegativ
			// 
			this.cbNegativ.AutoSize = true;
			this.cbNegativ.Location = new System.Drawing.Point(208, 274);
			this.cbNegativ.Name = "cbNegativ";
			this.cbNegativ.Size = new System.Drawing.Size(68, 17);
			this.cbNegativ.TabIndex = 7;
			this.cbNegativ.Text = "Negatyw";
			this.cbNegativ.UseVisualStyleBackColor = true;
			this.cbNegativ.CheckedChanged += new System.EventHandler(this.cbNegativ_CheckedChanged);
			// 
			// lblSharpness
			// 
			this.lblSharpness.AutoSize = true;
			this.lblSharpness.Location = new System.Drawing.Point(298, 193);
			this.lblSharpness.Name = "lblSharpness";
			this.lblSharpness.Size = new System.Drawing.Size(35, 13);
			this.lblSharpness.TabIndex = 10;
			this.lblSharpness.Text = "label6";
			// 
			// lblContrast
			// 
			this.lblContrast.AutoSize = true;
			this.lblContrast.Location = new System.Drawing.Point(298, 116);
			this.lblContrast.Name = "lblContrast";
			this.lblContrast.Size = new System.Drawing.Size(35, 13);
			this.lblContrast.TabIndex = 9;
			this.lblContrast.Text = "label5";
			// 
			// lblBrightness
			// 
			this.lblBrightness.AutoSize = true;
			this.lblBrightness.Location = new System.Drawing.Point(298, 40);
			this.lblBrightness.Name = "lblBrightness";
			this.lblBrightness.Size = new System.Drawing.Size(35, 13);
			this.lblBrightness.TabIndex = 8;
			this.lblBrightness.Text = "label4";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(456, 306);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(78, 46);
			this.button1.TabIndex = 11;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// cbFlip
			// 
			this.cbFlip.AutoSize = true;
			this.cbFlip.Location = new System.Drawing.Point(341, 274);
			this.cbFlip.Name = "cbFlip";
			this.cbFlip.Size = new System.Drawing.Size(107, 17);
			this.cbFlip.TabIndex = 12;
			this.cbFlip.Text = "Obrót w poziomie";
			this.cbFlip.UseVisualStyleBackColor = true;
			this.cbFlip.CheckedChanged += new System.EventHandler(this.cbFlip_CheckedChanged);
			// 
			// CameraSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 364);
			this.Controls.Add(this.cbFlip);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lblSharpness);
			this.Controls.Add(this.lblContrast);
			this.Controls.Add(this.lblBrightness);
			this.Controls.Add(this.cbNegativ);
			this.Controls.Add(this.cbGray);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbSharpness);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbContrast);
			this.Controls.Add(this.tbBrightness);
			this.Name = "CameraSettings";
			this.Text = "CameraSettings";
			((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSharpness)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbSharpness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbGray;
        private System.Windows.Forms.CheckBox cbNegativ;
        private System.Windows.Forms.Label lblSharpness;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox cbFlip;
	}
}