namespace Terminal_3._4._3_noCuda
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.ibCameraCap = new Emgu.CV.UI.ImageBox();
			this.ibFeature1 = new Emgu.CV.UI.ImageBox();
			this.ibFeature2 = new Emgu.CV.UI.ImageBox();
			this.ibFeature3 = new Emgu.CV.UI.ImageBox();
			this.gbWorkMode = new System.Windows.Forms.GroupBox();
			this.rbTrackObiect = new System.Windows.Forms.RadioButton();
			this.rbUploadFeature = new System.Windows.Forms.RadioButton();
			this.rbDetectInRois = new System.Windows.Forms.RadioButton();
			this.cbMatchLines = new System.Windows.Forms.CheckBox();
			this.tbFeature1 = new System.Windows.Forms.TextBox();
			this.btnLoad1 = new System.Windows.Forms.Button();
			this.btnLoad2 = new System.Windows.Forms.Button();
			this.tbFeature2 = new System.Windows.Forms.TextBox();
			this.btnLoad3 = new System.Windows.Forms.Button();
			this.tbFeature3 = new System.Windows.Forms.TextBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCapture = new System.Windows.Forms.Button();
			this.cbCharacteristicPoints = new System.Windows.Forms.CheckBox();
			this.lblEvent1 = new System.Windows.Forms.Label();
			this.lblEvent2 = new System.Windows.Forms.Label();
			this.lblEvent3 = new System.Windows.Forms.Label();
			this.btnDetectFeature = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnStartCapture = new System.Windows.Forms.Button();
			this.btnStopDetection = new System.Windows.Forms.Button();
			this.cbKP1 = new System.Windows.Forms.CheckBox();
			this.cbKP2 = new System.Windows.Forms.CheckBox();
			this.cbKP3 = new System.Windows.Forms.CheckBox();
			this.btnSetSize1 = new System.Windows.Forms.Button();
			this.btnSetSize2 = new System.Windows.Forms.Button();
			this.btnSetSize3 = new System.Windows.Forms.Button();
			this.btnDetectMultiple = new System.Windows.Forms.Button();
			this.txtHostName = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ibFeeder = new Emgu.CV.UI.ImageBox();
			this.btnFeed = new System.Windows.Forms.Button();
			this.gbFeed = new System.Windows.Forms.GroupBox();
			this.rbEve3 = new System.Windows.Forms.RadioButton();
			this.rbEve1 = new System.Windows.Forms.RadioButton();
			this.rbEve2 = new System.Windows.Forms.RadioButton();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lblEv1 = new System.Windows.Forms.Label();
			this.lblEv2 = new System.Windows.Forms.Label();
			this.lblEv3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbFeederr = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblFeedEv2 = new System.Windows.Forms.Label();
			this.lblFeedEv1 = new System.Windows.Forms.Label();
			this.lblFeedEv3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.cBoxShapes1 = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbAdvanced = new System.Windows.Forms.RadioButton();
			this.rbSimple = new System.Windows.Forms.RadioButton();
			this.lblShape1 = new System.Windows.Forms.Label();
			this.lblShape2 = new System.Windows.Forms.Label();
			this.cBoxShapes2 = new System.Windows.Forms.ComboBox();
			this.lblShape3 = new System.Windows.Forms.Label();
			this.cBoxShapes3 = new System.Windows.Forms.ComboBox();
			this.lblShape4 = new System.Windows.Forms.Label();
			this.cBoxShapes4 = new System.Windows.Forms.ComboBox();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnDefaultCameraSet = new System.Windows.Forms.Button();
			this.numBlueMin = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.numGreenMin = new System.Windows.Forms.NumericUpDown();
			this.numRedMin = new System.Windows.Forms.NumericUpDown();
			this.numRedMax = new System.Windows.Forms.NumericUpDown();
			this.numGreenMax = new System.Windows.Forms.NumericUpDown();
			this.numBlueMax = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.btnShapeFeeder = new System.Windows.Forms.Button();
			this.btnShapeDetection = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbModifiedImage = new System.Windows.Forms.RadioButton();
			this.rbOrginalImage = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnStopShapeDetection = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.lblShape4Status = new System.Windows.Forms.Label();
			this.lblShape3Status = new System.Windows.Forms.Label();
			this.lblShape2Status = new System.Windows.Forms.Label();
			this.lblShape1Status = new System.Windows.Forms.Label();
			this.txtOutcome = new System.Windows.Forms.TextBox();
			this.btnContinue = new System.Windows.Forms.Button();
			this.btnHold = new System.Windows.Forms.Button();
			this.gbDetectionRegions = new System.Windows.Forms.GroupBox();
			this.rbCheckPixelValue = new System.Windows.Forms.RadioButton();
			this.rbRegionShapeFeed = new System.Windows.Forms.RadioButton();
			this.rbRegionShape4 = new System.Windows.Forms.RadioButton();
			this.rbRegionShape3 = new System.Windows.Forms.RadioButton();
			this.rbRegionShape2 = new System.Windows.Forms.RadioButton();
			this.rbRegionShape1 = new System.Windows.Forms.RadioButton();
			this.gbShapeMode = new System.Windows.Forms.GroupBox();
			this.rbDisorder = new System.Windows.Forms.RadioButton();
			this.rbOrder = new System.Windows.Forms.RadioButton();
			this.rbNoFeedback = new System.Windows.Forms.RadioButton();
			this.lblError = new System.Windows.Forms.Label();
			this.gbPixelValue = new System.Windows.Forms.GroupBox();
			this.lblRedVal = new System.Windows.Forms.Label();
			this.lblGreenVal = new System.Windows.Forms.Label();
			this.lblBlueVal = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.gbCycleMode = new System.Windows.Forms.GroupBox();
			this.rbMultiCycle = new System.Windows.Forms.RadioButton();
			this.rbSingleCycle = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.ibCameraCap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ibFeature1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ibFeature2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ibFeature3)).BeginInit();
			this.gbWorkMode.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ibFeeder)).BeginInit();
			this.gbFeed.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBlueMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreenMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRedMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRedMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreenMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBlueMax)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.gbDetectionRegions.SuspendLayout();
			this.gbShapeMode.SuspendLayout();
			this.gbPixelValue.SuspendLayout();
			this.gbCycleMode.SuspendLayout();
			this.SuspendLayout();
			// 
			// ibCameraCap
			// 
			this.ibCameraCap.BackColor = System.Drawing.SystemColors.Window;
			this.ibCameraCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ibCameraCap.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
			this.ibCameraCap.Location = new System.Drawing.Point(407, 86);
			this.ibCameraCap.Name = "ibCameraCap";
			this.ibCameraCap.Size = new System.Drawing.Size(640, 480);
			this.ibCameraCap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ibCameraCap.TabIndex = 2;
			this.ibCameraCap.TabStop = false;
			this.ibCameraCap.Paint += new System.Windows.Forms.PaintEventHandler(this.ibCameraCap_Paint);
			this.ibCameraCap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ibCameraCap_MouseClick);
			this.ibCameraCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ibCameraCap_MouseDown);
			this.ibCameraCap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ibCameraCap_MouseMove);
			this.ibCameraCap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ibCameraCap_MouseUp);
			// 
			// ibFeature1
			// 
			this.ibFeature1.BackColor = System.Drawing.SystemColors.Window;
			this.ibFeature1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ibFeature1.Location = new System.Drawing.Point(22, 86);
			this.ibFeature1.Name = "ibFeature1";
			this.ibFeature1.Size = new System.Drawing.Size(280, 210);
			this.ibFeature1.TabIndex = 2;
			this.ibFeature1.TabStop = false;
			this.ibFeature1.Visible = false;
			// 
			// ibFeature2
			// 
			this.ibFeature2.BackColor = System.Drawing.SystemColors.Window;
			this.ibFeature2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ibFeature2.Location = new System.Drawing.Point(22, 344);
			this.ibFeature2.Name = "ibFeature2";
			this.ibFeature2.Size = new System.Drawing.Size(280, 210);
			this.ibFeature2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ibFeature2.TabIndex = 3;
			this.ibFeature2.TabStop = false;
			this.ibFeature2.Visible = false;
			// 
			// ibFeature3
			// 
			this.ibFeature3.BackColor = System.Drawing.SystemColors.Window;
			this.ibFeature3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ibFeature3.Location = new System.Drawing.Point(22, 623);
			this.ibFeature3.Name = "ibFeature3";
			this.ibFeature3.Size = new System.Drawing.Size(280, 210);
			this.ibFeature3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ibFeature3.TabIndex = 4;
			this.ibFeature3.TabStop = false;
			this.ibFeature3.Visible = false;
			// 
			// gbWorkMode
			// 
			this.gbWorkMode.Controls.Add(this.rbTrackObiect);
			this.gbWorkMode.Controls.Add(this.rbUploadFeature);
			this.gbWorkMode.Controls.Add(this.rbDetectInRois);
			this.gbWorkMode.Location = new System.Drawing.Point(12, 3);
			this.gbWorkMode.Name = "gbWorkMode";
			this.gbWorkMode.Size = new System.Drawing.Size(378, 56);
			this.gbWorkMode.TabIndex = 5;
			this.gbWorkMode.TabStop = false;
			this.gbWorkMode.Text = "Tryb pracy";
			this.gbWorkMode.Visible = false;
			// 
			// rbTrackObiect
			// 
			this.rbTrackObiect.AutoSize = true;
			this.rbTrackObiect.Location = new System.Drawing.Point(139, 24);
			this.rbTrackObiect.Name = "rbTrackObiect";
			this.rbTrackObiect.Size = new System.Drawing.Size(107, 17);
			this.rbTrackObiect.TabIndex = 39;
			this.rbTrackObiect.TabStop = true;
			this.rbTrackObiect.Text = "śledzenie obiektu";
			this.rbTrackObiect.UseVisualStyleBackColor = true;
			this.rbTrackObiect.CheckedChanged += new System.EventHandler(this.rbTrackObiect_CheckedChanged);
			// 
			// rbUploadFeature
			// 
			this.rbUploadFeature.AutoSize = true;
			this.rbUploadFeature.Checked = true;
			this.rbUploadFeature.Location = new System.Drawing.Point(18, 24);
			this.rbUploadFeature.Name = "rbUploadFeature";
			this.rbUploadFeature.Size = new System.Drawing.Size(115, 17);
			this.rbUploadFeature.TabIndex = 6;
			this.rbUploadFeature.TabStop = true;
			this.rbUploadFeature.Text = "wgrywanie zdarzeń";
			this.rbUploadFeature.UseVisualStyleBackColor = true;
			this.rbUploadFeature.CheckedChanged += new System.EventHandler(this.rbUploadFeature_CheckedChanged);
			// 
			// rbDetectInRois
			// 
			this.rbDetectInRois.AutoSize = true;
			this.rbDetectInRois.Location = new System.Drawing.Point(249, 24);
			this.rbDetectInRois.Name = "rbDetectInRois";
			this.rbDetectInRois.Size = new System.Drawing.Size(120, 17);
			this.rbDetectInRois.TabIndex = 7;
			this.rbDetectInRois.Text = "wykrywanie zdarzeń";
			this.rbDetectInRois.UseVisualStyleBackColor = true;
			this.rbDetectInRois.CheckedChanged += new System.EventHandler(this.rbDetectInRois_CheckedChanged);
			// 
			// cbMatchLines
			// 
			this.cbMatchLines.AutoSize = true;
			this.cbMatchLines.Enabled = false;
			this.cbMatchLines.Location = new System.Drawing.Point(560, 63);
			this.cbMatchLines.Name = "cbMatchLines";
			this.cbMatchLines.Size = new System.Drawing.Size(110, 17);
			this.cbMatchLines.TabIndex = 1;
			this.cbMatchLines.Text = "linie dopasowania";
			this.cbMatchLines.UseVisualStyleBackColor = true;
			this.cbMatchLines.Visible = false;
			this.cbMatchLines.CheckedChanged += new System.EventHandler(this.cbMatchLines_CheckedChanged);
			// 
			// tbFeature1
			// 
			this.tbFeature1.Location = new System.Drawing.Point(22, 302);
			this.tbFeature1.Name = "tbFeature1";
			this.tbFeature1.ReadOnly = true;
			this.tbFeature1.Size = new System.Drawing.Size(257, 20);
			this.tbFeature1.TabIndex = 8;
			this.tbFeature1.Visible = false;
			// 
			// btnLoad1
			// 
			this.btnLoad1.Location = new System.Drawing.Point(285, 302);
			this.btnLoad1.Name = "btnLoad1";
			this.btnLoad1.Size = new System.Drawing.Size(26, 19);
			this.btnLoad1.TabIndex = 9;
			this.btnLoad1.Text = "...";
			this.btnLoad1.UseVisualStyleBackColor = true;
			this.btnLoad1.Visible = false;
			this.btnLoad1.Click += new System.EventHandler(this.btnLoad1_Click);
			// 
			// btnLoad2
			// 
			this.btnLoad2.Enabled = false;
			this.btnLoad2.Location = new System.Drawing.Point(285, 560);
			this.btnLoad2.Name = "btnLoad2";
			this.btnLoad2.Size = new System.Drawing.Size(26, 19);
			this.btnLoad2.TabIndex = 11;
			this.btnLoad2.Text = "...";
			this.btnLoad2.UseVisualStyleBackColor = true;
			this.btnLoad2.Visible = false;
			this.btnLoad2.Click += new System.EventHandler(this.btnLoad2_Click);
			// 
			// tbFeature2
			// 
			this.tbFeature2.Location = new System.Drawing.Point(22, 560);
			this.tbFeature2.Name = "tbFeature2";
			this.tbFeature2.ReadOnly = true;
			this.tbFeature2.Size = new System.Drawing.Size(257, 20);
			this.tbFeature2.TabIndex = 10;
			this.tbFeature2.Visible = false;
			// 
			// btnLoad3
			// 
			this.btnLoad3.Enabled = false;
			this.btnLoad3.Location = new System.Drawing.Point(285, 840);
			this.btnLoad3.Name = "btnLoad3";
			this.btnLoad3.Size = new System.Drawing.Size(26, 19);
			this.btnLoad3.TabIndex = 13;
			this.btnLoad3.Text = "...";
			this.btnLoad3.UseVisualStyleBackColor = true;
			this.btnLoad3.Visible = false;
			this.btnLoad3.Click += new System.EventHandler(this.btnLoad3_Click);
			// 
			// tbFeature3
			// 
			this.tbFeature3.Location = new System.Drawing.Point(22, 839);
			this.tbFeature3.Name = "tbFeature3";
			this.tbFeature3.ReadOnly = true;
			this.tbFeature3.Size = new System.Drawing.Size(257, 20);
			this.tbFeature3.TabIndex = 12;
			this.tbFeature3.Visible = false;
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(661, 577);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(96, 46);
			this.btnStop.TabIndex = 15;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(789, 576);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(96, 46);
			this.btnSave.TabIndex = 16;
			this.btnSave.Text = "Zapisz";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Visible = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCapture
			// 
			this.btnCapture.Enabled = false;
			this.btnCapture.Location = new System.Drawing.Point(536, 576);
			this.btnCapture.Name = "btnCapture";
			this.btnCapture.Size = new System.Drawing.Size(96, 46);
			this.btnCapture.TabIndex = 17;
			this.btnCapture.Text = "Przechwyć";
			this.btnCapture.UseVisualStyleBackColor = true;
			this.btnCapture.Visible = false;
			this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
			// 
			// cbCharacteristicPoints
			// 
			this.cbCharacteristicPoints.AutoSize = true;
			this.cbCharacteristicPoints.Location = new System.Drawing.Point(407, 64);
			this.cbCharacteristicPoints.Name = "cbCharacteristicPoints";
			this.cbCharacteristicPoints.Size = new System.Drawing.Size(147, 17);
			this.cbCharacteristicPoints.TabIndex = 0;
			this.cbCharacteristicPoints.Text = "punkty charakterystyczne";
			this.cbCharacteristicPoints.UseVisualStyleBackColor = true;
			this.cbCharacteristicPoints.Visible = false;
			this.cbCharacteristicPoints.CheckedChanged += new System.EventHandler(this.cbCharacteristicPoints_CheckedChanged);
			// 
			// lblEvent1
			// 
			this.lblEvent1.AutoSize = true;
			this.lblEvent1.Location = new System.Drawing.Point(118, 70);
			this.lblEvent1.Name = "lblEvent1";
			this.lblEvent1.Size = new System.Drawing.Size(63, 13);
			this.lblEvent1.TabIndex = 18;
			this.lblEvent1.Text = "Zdarzenie 1";
			this.lblEvent1.Visible = false;
			// 
			// lblEvent2
			// 
			this.lblEvent2.AutoSize = true;
			this.lblEvent2.Location = new System.Drawing.Point(118, 328);
			this.lblEvent2.Name = "lblEvent2";
			this.lblEvent2.Size = new System.Drawing.Size(63, 13);
			this.lblEvent2.TabIndex = 19;
			this.lblEvent2.Text = "Zdarzenie 2";
			this.lblEvent2.Visible = false;
			// 
			// lblEvent3
			// 
			this.lblEvent3.AutoSize = true;
			this.lblEvent3.Location = new System.Drawing.Point(118, 607);
			this.lblEvent3.Name = "lblEvent3";
			this.lblEvent3.Size = new System.Drawing.Size(63, 13);
			this.lblEvent3.TabIndex = 20;
			this.lblEvent3.Text = "Zdarzenie 3";
			this.lblEvent3.Visible = false;
			// 
			// btnDetectFeature
			// 
			this.btnDetectFeature.Enabled = false;
			this.btnDetectFeature.Location = new System.Drawing.Point(536, 640);
			this.btnDetectFeature.Name = "btnDetectFeature";
			this.btnDetectFeature.Size = new System.Drawing.Size(96, 46);
			this.btnDetectFeature.TabIndex = 21;
			this.btnDetectFeature.Text = "Śledź obiekt";
			this.btnDetectFeature.UseVisualStyleBackColor = true;
			this.btnDetectFeature.Visible = false;
			this.btnDetectFeature.Click += new System.EventHandler(this.btnDetectFeature_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(907, 576);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(98, 46);
			this.btnClear.TabIndex = 22;
			this.btnClear.Text = "Czyść ↑";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Visible = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(1053, 528);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(114, 44);
			this.btnClose.TabIndex = 23;
			this.btnClose.Text = "ZAKMNIJ";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnStartCapture
			// 
			this.btnStartCapture.Location = new System.Drawing.Point(407, 576);
			this.btnStartCapture.Name = "btnStartCapture";
			this.btnStartCapture.Size = new System.Drawing.Size(96, 45);
			this.btnStartCapture.TabIndex = 24;
			this.btnStartCapture.Text = "Obraz z kamery";
			this.btnStartCapture.UseVisualStyleBackColor = true;
			this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
			// 
			// btnStopDetection
			// 
			this.btnStopDetection.Enabled = false;
			this.btnStopDetection.Location = new System.Drawing.Point(661, 640);
			this.btnStopDetection.Name = "btnStopDetection";
			this.btnStopDetection.Size = new System.Drawing.Size(96, 46);
			this.btnStopDetection.TabIndex = 26;
			this.btnStopDetection.Text = "Zakończ wykrywanie";
			this.btnStopDetection.UseVisualStyleBackColor = true;
			this.btnStopDetection.Visible = false;
			this.btnStopDetection.Click += new System.EventHandler(this.btnStopDetection_Click);
			// 
			// cbKP1
			// 
			this.cbKP1.AutoSize = true;
			this.cbKP1.Location = new System.Drawing.Point(195, 66);
			this.cbKP1.Name = "cbKP1";
			this.cbKP1.Size = new System.Drawing.Size(107, 17);
			this.cbKP1.TabIndex = 30;
			this.cbKP1.Text = "Punkty kluczowe";
			this.cbKP1.UseVisualStyleBackColor = true;
			this.cbKP1.Visible = false;
			this.cbKP1.CheckedChanged += new System.EventHandler(this.cbKP1_CheckedChanged);
			// 
			// cbKP2
			// 
			this.cbKP2.AutoSize = true;
			this.cbKP2.Location = new System.Drawing.Point(195, 324);
			this.cbKP2.Name = "cbKP2";
			this.cbKP2.Size = new System.Drawing.Size(107, 17);
			this.cbKP2.TabIndex = 31;
			this.cbKP2.Text = "Punkty kluczowe";
			this.cbKP2.UseVisualStyleBackColor = true;
			this.cbKP2.Visible = false;
			this.cbKP2.CheckedChanged += new System.EventHandler(this.cbKP2_CheckedChanged);
			// 
			// cbKP3
			// 
			this.cbKP3.AutoSize = true;
			this.cbKP3.Location = new System.Drawing.Point(195, 605);
			this.cbKP3.Name = "cbKP3";
			this.cbKP3.Size = new System.Drawing.Size(107, 17);
			this.cbKP3.TabIndex = 32;
			this.cbKP3.Text = "Punkty kluczowe";
			this.cbKP3.UseVisualStyleBackColor = true;
			this.cbKP3.Visible = false;
			this.cbKP3.CheckedChanged += new System.EventHandler(this.cbKP3_CheckedChanged);
			// 
			// btnSetSize1
			// 
			this.btnSetSize1.Location = new System.Drawing.Point(308, 86);
			this.btnSetSize1.Name = "btnSetSize1";
			this.btnSetSize1.Size = new System.Drawing.Size(73, 44);
			this.btnSetSize1.TabIndex = 35;
			this.btnSetSize1.Text = "Określ obszar 1";
			this.btnSetSize1.UseVisualStyleBackColor = true;
			this.btnSetSize1.Visible = false;
			this.btnSetSize1.Click += new System.EventHandler(this.btnSetSize1_Click);
			// 
			// btnSetSize2
			// 
			this.btnSetSize2.Location = new System.Drawing.Point(308, 344);
			this.btnSetSize2.Name = "btnSetSize2";
			this.btnSetSize2.Size = new System.Drawing.Size(73, 44);
			this.btnSetSize2.TabIndex = 37;
			this.btnSetSize2.Text = "Określ obszar 2";
			this.btnSetSize2.UseVisualStyleBackColor = true;
			this.btnSetSize2.Visible = false;
			this.btnSetSize2.Click += new System.EventHandler(this.btnSetSize2_Click);
			// 
			// btnSetSize3
			// 
			this.btnSetSize3.Location = new System.Drawing.Point(308, 623);
			this.btnSetSize3.Name = "btnSetSize3";
			this.btnSetSize3.Size = new System.Drawing.Size(73, 44);
			this.btnSetSize3.TabIndex = 38;
			this.btnSetSize3.Text = "Określ obszar 3";
			this.btnSetSize3.UseVisualStyleBackColor = true;
			this.btnSetSize3.Visible = false;
			this.btnSetSize3.Click += new System.EventHandler(this.btnSetSize3_Click);
			// 
			// btnDetectMultiple
			// 
			this.btnDetectMultiple.Enabled = false;
			this.btnDetectMultiple.Location = new System.Drawing.Point(407, 640);
			this.btnDetectMultiple.Name = "btnDetectMultiple";
			this.btnDetectMultiple.Size = new System.Drawing.Size(96, 46);
			this.btnDetectMultiple.TabIndex = 39;
			this.btnDetectMultiple.Text = "Wykrywaj zdarzenia";
			this.btnDetectMultiple.UseVisualStyleBackColor = true;
			this.btnDetectMultiple.Visible = false;
			this.btnDetectMultiple.Click += new System.EventHandler(this.btnDetectMultiple_Click);
			// 
			// txtHostName
			// 
			this.txtHostName.Location = new System.Drawing.Point(1252, 26);
			this.txtHostName.Name = "txtHostName";
			this.txtHostName.Size = new System.Drawing.Size(223, 20);
			this.txtHostName.TabIndex = 40;
			this.txtHostName.Text = "192.168.1.155";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(1252, 62);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(87, 20);
			this.txtPort.TabIndex = 41;
			this.txtPort.Text = "23";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(1481, 19);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(100, 27);
			this.btnConnect.TabIndex = 42;
			this.btnConnect.Text = "Połącz";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(1481, 62);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(100, 27);
			this.btnDisconnect.TabIndex = 43;
			this.btnDisconnect.Text = "Rozłącz";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnSend
			// 
			this.btnSend.Enabled = false;
			this.btnSend.Location = new System.Drawing.Point(1473, 650);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(100, 27);
			this.btnSend.TabIndex = 44;
			this.btnSend.Text = "Wyślij";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtSend
			// 
			this.txtSend.BackColor = System.Drawing.Color.Turquoise;
			this.txtSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtSend.Location = new System.Drawing.Point(1207, 610);
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(366, 30);
			this.txtSend.TabIndex = 45;
			this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1204, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 47;
			this.label1.Text = "Host:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1204, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 48;
			this.label2.Text = "Port:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1204, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 13);
			this.label3.TabIndex = 49;
			this.label3.Text = "Komunikacja:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1204, 592);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 50;
			this.label4.Text = "Wiadomość:";
			// 
			// ibFeeder
			// 
			this.ibFeeder.BackColor = System.Drawing.SystemColors.Window;
			this.ibFeeder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ibFeeder.Location = new System.Drawing.Point(789, 640);
			this.ibFeeder.Name = "ibFeeder";
			this.ibFeeder.Size = new System.Drawing.Size(280, 210);
			this.ibFeeder.TabIndex = 51;
			this.ibFeeder.TabStop = false;
			this.ibFeeder.Visible = false;
			// 
			// btnFeed
			// 
			this.btnFeed.Location = new System.Drawing.Point(1075, 640);
			this.btnFeed.Name = "btnFeed";
			this.btnFeed.Size = new System.Drawing.Size(73, 54);
			this.btnFeed.TabIndex = 52;
			this.btnFeed.Text = "Określ obszar dozownika";
			this.btnFeed.UseVisualStyleBackColor = true;
			this.btnFeed.Visible = false;
			this.btnFeed.Click += new System.EventHandler(this.btnFeed_Click);
			// 
			// gbFeed
			// 
			this.gbFeed.Controls.Add(this.rbEve3);
			this.gbFeed.Controls.Add(this.rbEve1);
			this.gbFeed.Controls.Add(this.rbEve2);
			this.gbFeed.Location = new System.Drawing.Point(1075, 717);
			this.gbFeed.Name = "gbFeed";
			this.gbFeed.Size = new System.Drawing.Size(109, 97);
			this.gbFeed.TabIndex = 53;
			this.gbFeed.TabStop = false;
			this.gbFeed.Text = "ZDARZENIE W DOZOWNIKU";
			this.gbFeed.Visible = false;
			// 
			// rbEve3
			// 
			this.rbEve3.AutoSize = true;
			this.rbEve3.Location = new System.Drawing.Point(6, 70);
			this.rbEve3.Name = "rbEve3";
			this.rbEve3.Size = new System.Drawing.Size(81, 17);
			this.rbEve3.TabIndex = 2;
			this.rbEve3.Text = "Zdarzenie 3";
			this.rbEve3.UseVisualStyleBackColor = true;
			this.rbEve3.CheckedChanged += new System.EventHandler(this.rbEve3_CheckedChanged);
			// 
			// rbEve1
			// 
			this.rbEve1.AutoSize = true;
			this.rbEve1.Location = new System.Drawing.Point(6, 30);
			this.rbEve1.Name = "rbEve1";
			this.rbEve1.Size = new System.Drawing.Size(81, 17);
			this.rbEve1.TabIndex = 0;
			this.rbEve1.Text = "Zdarzenie 1";
			this.rbEve1.UseVisualStyleBackColor = true;
			this.rbEve1.CheckedChanged += new System.EventHandler(this.rbEve1_CheckedChanged);
			// 
			// rbEve2
			// 
			this.rbEve2.AutoSize = true;
			this.rbEve2.Location = new System.Drawing.Point(6, 50);
			this.rbEve2.Name = "rbEve2";
			this.rbEve2.Size = new System.Drawing.Size(81, 17);
			this.rbEve2.TabIndex = 1;
			this.rbEve2.Text = "Zdarzenie 2";
			this.rbEve2.UseVisualStyleBackColor = true;
			this.rbEve2.CheckedChanged += new System.EventHandler(this.rbEve2_CheckedChanged);
			// 
			// progressBar1
			// 
			this.progressBar1.ForeColor = System.Drawing.Color.Lime;
			this.progressBar1.Location = new System.Drawing.Point(1053, 86);
			this.progressBar1.Maximum = 3;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(131, 33);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 54;
			this.progressBar1.Visible = false;
			// 
			// lblEv1
			// 
			this.lblEv1.AutoSize = true;
			this.lblEv1.ForeColor = System.Drawing.Color.Red;
			this.lblEv1.Location = new System.Drawing.Point(6, 20);
			this.lblEv1.Name = "lblEv1";
			this.lblEv1.Size = new System.Drawing.Size(119, 13);
			this.lblEv1.TabIndex = 56;
			this.lblEv1.Text = "Zdarzenie 1: niewykryte";
			// 
			// lblEv2
			// 
			this.lblEv2.AutoSize = true;
			this.lblEv2.ForeColor = System.Drawing.Color.Red;
			this.lblEv2.Location = new System.Drawing.Point(6, 40);
			this.lblEv2.Name = "lblEv2";
			this.lblEv2.Size = new System.Drawing.Size(119, 13);
			this.lblEv2.TabIndex = 57;
			this.lblEv2.Text = "Zdarzenie 2: niewykryte";
			// 
			// lblEv3
			// 
			this.lblEv3.AutoSize = true;
			this.lblEv3.ForeColor = System.Drawing.Color.Red;
			this.lblEv3.Location = new System.Drawing.Point(6, 60);
			this.lblEv3.Name = "lblEv3";
			this.lblEv3.Size = new System.Drawing.Size(119, 13);
			this.lblEv3.TabIndex = 58;
			this.lblEv3.Text = "Zdarzenie 3: niewykryte";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblEv2);
			this.groupBox2.Controls.Add(this.lblEv1);
			this.groupBox2.Controls.Add(this.lblEv3);
			this.groupBox2.Location = new System.Drawing.Point(1053, 123);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(148, 82);
			this.groupBox2.TabIndex = 60;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Wykryte zdarzenia:";
			this.groupBox2.Visible = false;
			// 
			// cbFeederr
			// 
			this.cbFeederr.AutoSize = true;
			this.cbFeederr.Location = new System.Drawing.Point(676, 65);
			this.cbFeederr.Name = "cbFeederr";
			this.cbFeederr.Size = new System.Drawing.Size(142, 17);
			this.cbFeederr.TabIndex = 61;
			this.cbFeederr.Text = "Korzystanie z dozownika";
			this.cbFeederr.UseVisualStyleBackColor = true;
			this.cbFeederr.Visible = false;
			this.cbFeederr.CheckedChanged += new System.EventHandler(this.cbFeederr_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblFeedEv2);
			this.groupBox1.Controls.Add(this.lblFeedEv1);
			this.groupBox1.Controls.Add(this.lblFeedEv3);
			this.groupBox1.Location = new System.Drawing.Point(1053, 211);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(147, 99);
			this.groupBox1.TabIndex = 61;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Zdarzenia wykryte wewnątrz dozownika:";
			this.groupBox1.Visible = false;
			// 
			// lblFeedEv2
			// 
			this.lblFeedEv2.AutoSize = true;
			this.lblFeedEv2.ForeColor = System.Drawing.Color.Red;
			this.lblFeedEv2.Location = new System.Drawing.Point(6, 57);
			this.lblFeedEv2.Name = "lblFeedEv2";
			this.lblFeedEv2.Size = new System.Drawing.Size(119, 13);
			this.lblFeedEv2.TabIndex = 57;
			this.lblFeedEv2.Text = "Zdarzenie 2: niewykryte";
			// 
			// lblFeedEv1
			// 
			this.lblFeedEv1.AutoSize = true;
			this.lblFeedEv1.ForeColor = System.Drawing.Color.Red;
			this.lblFeedEv1.Location = new System.Drawing.Point(6, 37);
			this.lblFeedEv1.Name = "lblFeedEv1";
			this.lblFeedEv1.Size = new System.Drawing.Size(119, 13);
			this.lblFeedEv1.TabIndex = 56;
			this.lblFeedEv1.Text = "Zdarzenie 1: niewykryte";
			// 
			// lblFeedEv3
			// 
			this.lblFeedEv3.AutoSize = true;
			this.lblFeedEv3.ForeColor = System.Drawing.Color.Red;
			this.lblFeedEv3.Location = new System.Drawing.Point(6, 77);
			this.lblFeedEv3.Name = "lblFeedEv3";
			this.lblFeedEv3.Size = new System.Drawing.Size(119, 13);
			this.lblFeedEv3.TabIndex = 58;
			this.lblFeedEv3.Text = "Zdarzenie 3: niewykryte";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(1356, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 62;
			this.label5.Text = "Status:";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.ForeColor = System.Drawing.Color.Red;
			this.lblStatus.Location = new System.Drawing.Point(1397, 93);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(75, 13);
			this.lblStatus.TabIndex = 63;
			this.lblStatus.Text = "nie połączono";
			// 
			// cBoxShapes1
			// 
			this.cBoxShapes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cBoxShapes1.FormattingEnabled = true;
			this.cBoxShapes1.Items.AddRange(new object[] {
            "Koło",
            "Kwadrat",
            "Ośmiokąt",
            "Pięciokąt",
            "Prostokąt",
            "Sześciokąt",
            "Trójkąt"});
			this.cBoxShapes1.Location = new System.Drawing.Point(23, 164);
			this.cBoxShapes1.Name = "cBoxShapes1";
			this.cBoxShapes1.Size = new System.Drawing.Size(162, 21);
			this.cBoxShapes1.TabIndex = 64;
			this.cBoxShapes1.TextChanged += new System.EventHandler(this.cBoxShapes1_TextChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbAdvanced);
			this.groupBox3.Controls.Add(this.rbSimple);
			this.groupBox3.Location = new System.Drawing.Point(407, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(253, 56);
			this.groupBox3.TabIndex = 65;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tryb wykrywania zdarzeń";
			// 
			// rbAdvanced
			// 
			this.rbAdvanced.AutoSize = true;
			this.rbAdvanced.Location = new System.Drawing.Point(109, 24);
			this.rbAdvanced.Name = "rbAdvanced";
			this.rbAdvanced.Size = new System.Drawing.Size(142, 17);
			this.rbAdvanced.TabIndex = 1;
			this.rbAdvanced.Text = "obrazy(zaakwansowane)";
			this.rbAdvanced.UseVisualStyleBackColor = true;
			this.rbAdvanced.CheckedChanged += new System.EventHandler(this.rbAdvanced_CheckedChanged);
			// 
			// rbSimple
			// 
			this.rbSimple.AutoSize = true;
			this.rbSimple.Checked = true;
			this.rbSimple.Location = new System.Drawing.Point(6, 24);
			this.rbSimple.Name = "rbSimple";
			this.rbSimple.Size = new System.Drawing.Size(97, 17);
			this.rbSimple.TabIndex = 0;
			this.rbSimple.TabStop = true;
			this.rbSimple.Text = "kształty(proste)";
			this.rbSimple.UseVisualStyleBackColor = true;
			this.rbSimple.CheckedChanged += new System.EventHandler(this.rbSimple_CheckedChanged);
			// 
			// lblShape1
			// 
			this.lblShape1.AutoSize = true;
			this.lblShape1.Location = new System.Drawing.Point(23, 148);
			this.lblShape1.Name = "lblShape1";
			this.lblShape1.Size = new System.Drawing.Size(49, 13);
			this.lblShape1.TabIndex = 66;
			this.lblShape1.Text = "Kształt 1";
			// 
			// lblShape2
			// 
			this.lblShape2.AutoSize = true;
			this.lblShape2.Location = new System.Drawing.Point(23, 233);
			this.lblShape2.Name = "lblShape2";
			this.lblShape2.Size = new System.Drawing.Size(49, 13);
			this.lblShape2.TabIndex = 68;
			this.lblShape2.Text = "Kształt 2";
			// 
			// cBoxShapes2
			// 
			this.cBoxShapes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cBoxShapes2.FormattingEnabled = true;
			this.cBoxShapes2.Items.AddRange(new object[] {
            "Koło",
            "Kwadrat",
            "Ośmiokąt",
            "Pięciokąt",
            "Prostokąt",
            "Sześciokąt",
            "Trójkąt"});
			this.cBoxShapes2.Location = new System.Drawing.Point(23, 249);
			this.cBoxShapes2.Name = "cBoxShapes2";
			this.cBoxShapes2.Size = new System.Drawing.Size(162, 21);
			this.cBoxShapes2.TabIndex = 67;
			this.cBoxShapes2.TextChanged += new System.EventHandler(this.cBoxShapes2_TextChanged);
			// 
			// lblShape3
			// 
			this.lblShape3.AutoSize = true;
			this.lblShape3.Location = new System.Drawing.Point(20, 312);
			this.lblShape3.Name = "lblShape3";
			this.lblShape3.Size = new System.Drawing.Size(49, 13);
			this.lblShape3.TabIndex = 70;
			this.lblShape3.Text = "Kształt 3";
			// 
			// cBoxShapes3
			// 
			this.cBoxShapes3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cBoxShapes3.FormattingEnabled = true;
			this.cBoxShapes3.Items.AddRange(new object[] {
            "Koło",
            "Kwadrat",
            "Ośmiokąt",
            "Pięciokąt",
            "Prostokąt",
            "Sześciokąt",
            "Trójkąt"});
			this.cBoxShapes3.Location = new System.Drawing.Point(23, 328);
			this.cBoxShapes3.Name = "cBoxShapes3";
			this.cBoxShapes3.Size = new System.Drawing.Size(162, 21);
			this.cBoxShapes3.TabIndex = 69;
			this.cBoxShapes3.TextChanged += new System.EventHandler(this.cBoxShapes3_TextChanged);
			// 
			// lblShape4
			// 
			this.lblShape4.AutoSize = true;
			this.lblShape4.Location = new System.Drawing.Point(20, 391);
			this.lblShape4.Name = "lblShape4";
			this.lblShape4.Size = new System.Drawing.Size(49, 13);
			this.lblShape4.TabIndex = 72;
			this.lblShape4.Text = "Kształt 4";
			// 
			// cBoxShapes4
			// 
			this.cBoxShapes4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cBoxShapes4.FormattingEnabled = true;
			this.cBoxShapes4.Items.AddRange(new object[] {
            "Koło",
            "Kwadrat",
            "Ośmiokąt",
            "Pięciokąt",
            "Prostokąt",
            "Sześciokąt",
            "Trójkąt"});
			this.cBoxShapes4.Location = new System.Drawing.Point(23, 407);
			this.cBoxShapes4.Name = "cBoxShapes4";
			this.cBoxShapes4.Size = new System.Drawing.Size(162, 21);
			this.cBoxShapes4.TabIndex = 71;
			this.cBoxShapes4.TextChanged += new System.EventHandler(this.cBoxShapes4_TextChanged);
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(1053, 316);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(101, 46);
			this.btnSettings.TabIndex = 77;
			this.btnSettings.Text = "Ustawienia obrazu";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// btnDefaultCameraSet
			// 
			this.btnDefaultCameraSet.Location = new System.Drawing.Point(1053, 368);
			this.btnDefaultCameraSet.Name = "btnDefaultCameraSet";
			this.btnDefaultCameraSet.Size = new System.Drawing.Size(101, 46);
			this.btnDefaultCameraSet.TabIndex = 78;
			this.btnDefaultCameraSet.Text = "Ustawienia domyślne";
			this.btnDefaultCameraSet.UseVisualStyleBackColor = true;
			this.btnDefaultCameraSet.Click += new System.EventHandler(this.btnDefaultCameraSet_Click);
			// 
			// numBlueMin
			// 
			this.numBlueMin.Location = new System.Drawing.Point(72, 47);
			this.numBlueMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numBlueMin.Name = "numBlueMin";
			this.numBlueMin.Size = new System.Drawing.Size(65, 20);
			this.numBlueMin.TabIndex = 80;
			this.numBlueMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numBlueMin.ValueChanged += new System.EventHandler(this.numBlueMin_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(74, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 81;
			this.label6.Text = "Niebieski";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(156, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 82;
			this.label7.Text = "Zielony";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(235, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 83;
			this.label8.Text = "Czerwony";
			// 
			// numGreenMin
			// 
			this.numGreenMin.Location = new System.Drawing.Point(154, 47);
			this.numGreenMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numGreenMin.Name = "numGreenMin";
			this.numGreenMin.Size = new System.Drawing.Size(65, 20);
			this.numGreenMin.TabIndex = 84;
			this.numGreenMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numGreenMin.ValueChanged += new System.EventHandler(this.numGreenMin_ValueChanged);
			// 
			// numRedMin
			// 
			this.numRedMin.Location = new System.Drawing.Point(238, 47);
			this.numRedMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numRedMin.Name = "numRedMin";
			this.numRedMin.Size = new System.Drawing.Size(65, 20);
			this.numRedMin.TabIndex = 85;
			this.numRedMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numRedMin.ValueChanged += new System.EventHandler(this.numRedMin_ValueChanged);
			// 
			// numRedMax
			// 
			this.numRedMax.Location = new System.Drawing.Point(238, 81);
			this.numRedMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numRedMax.Name = "numRedMax";
			this.numRedMax.Size = new System.Drawing.Size(65, 20);
			this.numRedMax.TabIndex = 88;
			this.numRedMax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numRedMax.ValueChanged += new System.EventHandler(this.numRedMax_ValueChanged);
			// 
			// numGreenMax
			// 
			this.numGreenMax.Location = new System.Drawing.Point(154, 81);
			this.numGreenMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numGreenMax.Name = "numGreenMax";
			this.numGreenMax.Size = new System.Drawing.Size(65, 20);
			this.numGreenMax.TabIndex = 87;
			this.numGreenMax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numGreenMax.ValueChanged += new System.EventHandler(this.numGreenMax_ValueChanged);
			// 
			// numBlueMax
			// 
			this.numBlueMax.Location = new System.Drawing.Point(72, 81);
			this.numBlueMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numBlueMax.Name = "numBlueMax";
			this.numBlueMax.Size = new System.Drawing.Size(65, 20);
			this.numBlueMax.TabIndex = 86;
			this.numBlueMax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numBlueMax.ValueChanged += new System.EventHandler(this.numBlueMax_ValueChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 54);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(57, 13);
			this.label9.TabIndex = 89;
			this.label9.Text = "Min(0-255)";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 83);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(60, 13);
			this.label10.TabIndex = 90;
			this.label10.Text = "Max(0-255)";
			// 
			// btnShapeFeeder
			// 
			this.btnShapeFeeder.Location = new System.Drawing.Point(23, 434);
			this.btnShapeFeeder.Name = "btnShapeFeeder";
			this.btnShapeFeeder.Size = new System.Drawing.Size(315, 45);
			this.btnShapeFeeder.TabIndex = 93;
			this.btnShapeFeeder.Text = "Obszar podajnika";
			this.btnShapeFeeder.UseVisualStyleBackColor = true;
			this.btnShapeFeeder.Click += new System.EventHandler(this.btnShapeFeeder_Click);
			// 
			// btnShapeDetection
			// 
			this.btnShapeDetection.Location = new System.Drawing.Point(407, 704);
			this.btnShapeDetection.Name = "btnShapeDetection";
			this.btnShapeDetection.Size = new System.Drawing.Size(97, 46);
			this.btnShapeDetection.TabIndex = 94;
			this.btnShapeDetection.Text = "Wykrywaj kształty";
			this.btnShapeDetection.UseVisualStyleBackColor = true;
			this.btnShapeDetection.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbModifiedImage);
			this.groupBox4.Controls.Add(this.rbOrginalImage);
			this.groupBox4.Location = new System.Drawing.Point(676, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(195, 56);
			this.groupBox4.TabIndex = 95;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Rodzaj obrazu";
			// 
			// rbModifiedImage
			// 
			this.rbModifiedImage.AutoSize = true;
			this.rbModifiedImage.Location = new System.Drawing.Point(97, 24);
			this.rbModifiedImage.Name = "rbModifiedImage";
			this.rbModifiedImage.Size = new System.Drawing.Size(87, 17);
			this.rbModifiedImage.TabIndex = 1;
			this.rbModifiedImage.Text = "przetworzony";
			this.rbModifiedImage.UseVisualStyleBackColor = true;
			this.rbModifiedImage.CheckedChanged += new System.EventHandler(this.rbModifiedImage_CheckedChanged);
			// 
			// rbOrginalImage
			// 
			this.rbOrginalImage.AutoSize = true;
			this.rbOrginalImage.Checked = true;
			this.rbOrginalImage.Location = new System.Drawing.Point(6, 24);
			this.rbOrginalImage.Name = "rbOrginalImage";
			this.rbOrginalImage.Size = new System.Drawing.Size(67, 17);
			this.rbOrginalImage.TabIndex = 0;
			this.rbOrginalImage.TabStop = true;
			this.rbOrginalImage.Text = "orginalny";
			this.rbOrginalImage.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.numBlueMin);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.label8);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.numGreenMin);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.numRedMin);
			this.groupBox5.Controls.Add(this.numRedMax);
			this.groupBox5.Controls.Add(this.numBlueMax);
			this.groupBox5.Controls.Add(this.numGreenMax);
			this.groupBox5.Location = new System.Drawing.Point(23, 504);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(312, 116);
			this.groupBox5.TabIndex = 96;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Filtrowanie kolorów";
			// 
			// btnStopShapeDetection
			// 
			this.btnStopShapeDetection.Enabled = false;
			this.btnStopShapeDetection.Location = new System.Drawing.Point(661, 704);
			this.btnStopShapeDetection.Name = "btnStopShapeDetection";
			this.btnStopShapeDetection.Size = new System.Drawing.Size(97, 46);
			this.btnStopShapeDetection.TabIndex = 97;
			this.btnStopShapeDetection.Text = "Zakończ wykrywanie";
			this.btnStopShapeDetection.UseVisualStyleBackColor = true;
			this.btnStopShapeDetection.Click += new System.EventHandler(this.btnStopShapeDetection_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.lblShape4Status);
			this.groupBox6.Controls.Add(this.lblShape3Status);
			this.groupBox6.Controls.Add(this.lblShape2Status);
			this.groupBox6.Controls.Add(this.lblShape1Status);
			this.groupBox6.Location = new System.Drawing.Point(1053, 420);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(131, 102);
			this.groupBox6.TabIndex = 98;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Wykryte kształty";
			// 
			// lblShape4Status
			// 
			this.lblShape4Status.AutoSize = true;
			this.lblShape4Status.ForeColor = System.Drawing.Color.Red;
			this.lblShape4Status.Location = new System.Drawing.Point(15, 78);
			this.lblShape4Status.Name = "lblShape4Status";
			this.lblShape4Status.Size = new System.Drawing.Size(104, 13);
			this.lblShape4Status.TabIndex = 3;
			this.lblShape4Status.Text = "Kształt 4: niewykryty";
			// 
			// lblShape3Status
			// 
			this.lblShape3Status.AutoSize = true;
			this.lblShape3Status.ForeColor = System.Drawing.Color.Red;
			this.lblShape3Status.Location = new System.Drawing.Point(15, 58);
			this.lblShape3Status.Name = "lblShape3Status";
			this.lblShape3Status.Size = new System.Drawing.Size(104, 13);
			this.lblShape3Status.TabIndex = 2;
			this.lblShape3Status.Text = "Kształt 3: niewykryty";
			// 
			// lblShape2Status
			// 
			this.lblShape2Status.AutoSize = true;
			this.lblShape2Status.ForeColor = System.Drawing.Color.Red;
			this.lblShape2Status.Location = new System.Drawing.Point(15, 38);
			this.lblShape2Status.Name = "lblShape2Status";
			this.lblShape2Status.Size = new System.Drawing.Size(104, 13);
			this.lblShape2Status.TabIndex = 1;
			this.lblShape2Status.Text = "Kształt 2: niewykryty";
			// 
			// lblShape1Status
			// 
			this.lblShape1Status.AutoSize = true;
			this.lblShape1Status.ForeColor = System.Drawing.Color.Red;
			this.lblShape1Status.Location = new System.Drawing.Point(15, 18);
			this.lblShape1Status.Name = "lblShape1Status";
			this.lblShape1Status.Size = new System.Drawing.Size(104, 13);
			this.lblShape1Status.TabIndex = 0;
			this.lblShape1Status.Text = "Kształt 1: niewykryty";
			// 
			// txtOutcome
			// 
			this.txtOutcome.BackColor = System.Drawing.Color.NavajoWhite;
			this.txtOutcome.Location = new System.Drawing.Point(1207, 123);
			this.txtOutcome.Multiline = true;
			this.txtOutcome.Name = "txtOutcome";
			this.txtOutcome.ReadOnly = true;
			this.txtOutcome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutcome.Size = new System.Drawing.Size(366, 456);
			this.txtOutcome.TabIndex = 99;
			// 
			// btnContinue
			// 
			this.btnContinue.Enabled = false;
			this.btnContinue.Location = new System.Drawing.Point(1207, 650);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(100, 27);
			this.btnContinue.TabIndex = 100;
			this.btnContinue.Text = "Continue";
			this.btnContinue.UseVisualStyleBackColor = true;
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// btnHold
			// 
			this.btnHold.Enabled = false;
			this.btnHold.Location = new System.Drawing.Point(1313, 650);
			this.btnHold.Name = "btnHold";
			this.btnHold.Size = new System.Drawing.Size(100, 27);
			this.btnHold.TabIndex = 101;
			this.btnHold.Text = "Hold";
			this.btnHold.UseVisualStyleBackColor = true;
			this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
			// 
			// gbDetectionRegions
			// 
			this.gbDetectionRegions.Controls.Add(this.rbCheckPixelValue);
			this.gbDetectionRegions.Controls.Add(this.rbRegionShapeFeed);
			this.gbDetectionRegions.Controls.Add(this.rbRegionShape4);
			this.gbDetectionRegions.Controls.Add(this.rbRegionShape3);
			this.gbDetectionRegions.Controls.Add(this.rbRegionShape2);
			this.gbDetectionRegions.Controls.Add(this.rbRegionShape1);
			this.gbDetectionRegions.Location = new System.Drawing.Point(12, 62);
			this.gbDetectionRegions.Name = "gbDetectionRegions";
			this.gbDetectionRegions.Size = new System.Drawing.Size(361, 68);
			this.gbDetectionRegions.TabIndex = 103;
			this.gbDetectionRegions.TabStop = false;
			this.gbDetectionRegions.Text = "Rysowanie obszarów detekcji i sprawdzenie koloru piksela";
			// 
			// rbCheckPixelValue
			// 
			this.rbCheckPixelValue.AutoSize = true;
			this.rbCheckPixelValue.Checked = true;
			this.rbCheckPixelValue.Location = new System.Drawing.Point(10, 17);
			this.rbCheckPixelValue.Name = "rbCheckPixelValue";
			this.rbCheckPixelValue.Size = new System.Drawing.Size(154, 17);
			this.rbCheckPixelValue.TabIndex = 5;
			this.rbCheckPixelValue.TabStop = true;
			this.rbCheckPixelValue.Text = "Sprawdzenie koloru piksela";
			this.rbCheckPixelValue.UseVisualStyleBackColor = true;
			// 
			// rbRegionShapeFeed
			// 
			this.rbRegionShapeFeed.AutoSize = true;
			this.rbRegionShapeFeed.Location = new System.Drawing.Point(291, 40);
			this.rbRegionShapeFeed.Name = "rbRegionShapeFeed";
			this.rbRegionShapeFeed.Size = new System.Drawing.Size(66, 17);
			this.rbRegionShapeFeed.TabIndex = 4;
			this.rbRegionShapeFeed.Text = "Podajnik";
			this.rbRegionShapeFeed.UseVisualStyleBackColor = true;
			// 
			// rbRegionShape4
			// 
			this.rbRegionShape4.AutoSize = true;
			this.rbRegionShape4.Location = new System.Drawing.Point(220, 40);
			this.rbRegionShape4.Name = "rbRegionShape4";
			this.rbRegionShape4.Size = new System.Drawing.Size(65, 17);
			this.rbRegionShape4.TabIndex = 3;
			this.rbRegionShape4.Text = "Ksztalt 4";
			this.rbRegionShape4.UseVisualStyleBackColor = true;
			// 
			// rbRegionShape3
			// 
			this.rbRegionShape3.AutoSize = true;
			this.rbRegionShape3.Location = new System.Drawing.Point(149, 40);
			this.rbRegionShape3.Name = "rbRegionShape3";
			this.rbRegionShape3.Size = new System.Drawing.Size(65, 17);
			this.rbRegionShape3.TabIndex = 2;
			this.rbRegionShape3.Text = "Ksztalt 3";
			this.rbRegionShape3.UseVisualStyleBackColor = true;
			// 
			// rbRegionShape2
			// 
			this.rbRegionShape2.AutoSize = true;
			this.rbRegionShape2.Location = new System.Drawing.Point(81, 40);
			this.rbRegionShape2.Name = "rbRegionShape2";
			this.rbRegionShape2.Size = new System.Drawing.Size(65, 17);
			this.rbRegionShape2.TabIndex = 1;
			this.rbRegionShape2.Text = "Ksztalt 2";
			this.rbRegionShape2.UseVisualStyleBackColor = true;
			// 
			// rbRegionShape1
			// 
			this.rbRegionShape1.AutoSize = true;
			this.rbRegionShape1.Location = new System.Drawing.Point(10, 40);
			this.rbRegionShape1.Name = "rbRegionShape1";
			this.rbRegionShape1.Size = new System.Drawing.Size(65, 17);
			this.rbRegionShape1.TabIndex = 0;
			this.rbRegionShape1.Text = "Ksztalt 1";
			this.rbRegionShape1.UseVisualStyleBackColor = true;
			// 
			// gbShapeMode
			// 
			this.gbShapeMode.Controls.Add(this.rbDisorder);
			this.gbShapeMode.Controls.Add(this.rbOrder);
			this.gbShapeMode.Controls.Add(this.rbNoFeedback);
			this.gbShapeMode.Location = new System.Drawing.Point(886, 10);
			this.gbShapeMode.Name = "gbShapeMode";
			this.gbShapeMode.Size = new System.Drawing.Size(298, 49);
			this.gbShapeMode.TabIndex = 104;
			this.gbShapeMode.TabStop = false;
			this.gbShapeMode.Text = "Tryb wykrywania kształtów";
			// 
			// rbDisorder
			// 
			this.rbDisorder.AutoSize = true;
			this.rbDisorder.Location = new System.Drawing.Point(207, 26);
			this.rbDisorder.Name = "rbDisorder";
			this.rbDisorder.Size = new System.Drawing.Size(79, 17);
			this.rbDisorder.TabIndex = 2;
			this.rbDisorder.Text = "Segregacja";
			this.rbDisorder.UseVisualStyleBackColor = true;
			// 
			// rbOrder
			// 
			this.rbOrder.AutoSize = true;
			this.rbOrder.Location = new System.Drawing.Point(123, 26);
			this.rbOrder.Name = "rbOrder";
			this.rbOrder.Size = new System.Drawing.Size(60, 17);
			this.rbOrder.TabIndex = 1;
			this.rbOrder.Text = "Montaż";
			this.rbOrder.UseVisualStyleBackColor = true;
			// 
			// rbNoFeedback
			// 
			this.rbNoFeedback.AutoSize = true;
			this.rbNoFeedback.Checked = true;
			this.rbNoFeedback.Location = new System.Drawing.Point(6, 26);
			this.rbNoFeedback.Name = "rbNoFeedback";
			this.rbNoFeedback.Size = new System.Drawing.Size(98, 17);
			this.rbNoFeedback.TabIndex = 0;
			this.rbNoFeedback.TabStop = true;
			this.rbNoFeedback.Text = "Tylko komputer";
			this.rbNoFeedback.UseVisualStyleBackColor = true;
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(406, 765);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(152, 39);
			this.lblError.TabIndex = 105;
			this.lblError.Text = "errorMsg";
			this.lblError.Visible = false;
			// 
			// gbPixelValue
			// 
			this.gbPixelValue.Controls.Add(this.lblRedVal);
			this.gbPixelValue.Controls.Add(this.lblGreenVal);
			this.gbPixelValue.Controls.Add(this.lblBlueVal);
			this.gbPixelValue.Controls.Add(this.label13);
			this.gbPixelValue.Controls.Add(this.label12);
			this.gbPixelValue.Controls.Add(this.label11);
			this.gbPixelValue.Location = new System.Drawing.Point(26, 628);
			this.gbPixelValue.Name = "gbPixelValue";
			this.gbPixelValue.Size = new System.Drawing.Size(311, 66);
			this.gbPixelValue.TabIndex = 107;
			this.gbPixelValue.TabStop = false;
			this.gbPixelValue.Text = "Kolor wybranego piksela";
			// 
			// lblRedVal
			// 
			this.lblRedVal.AutoSize = true;
			this.lblRedVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblRedVal.Location = new System.Drawing.Point(254, 27);
			this.lblRedVal.Name = "lblRedVal";
			this.lblRedVal.Size = new System.Drawing.Size(19, 25);
			this.lblRedVal.TabIndex = 87;
			this.lblRedVal.Text = "-";
			// 
			// lblGreenVal
			// 
			this.lblGreenVal.AutoSize = true;
			this.lblGreenVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblGreenVal.Location = new System.Drawing.Point(151, 27);
			this.lblGreenVal.Name = "lblGreenVal";
			this.lblGreenVal.Size = new System.Drawing.Size(19, 25);
			this.lblGreenVal.TabIndex = 86;
			this.lblGreenVal.Text = "-";
			// 
			// lblBlueVal
			// 
			this.lblBlueVal.AutoSize = true;
			this.lblBlueVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblBlueVal.Location = new System.Drawing.Point(60, 27);
			this.lblBlueVal.Name = "lblBlueVal";
			this.lblBlueVal.Size = new System.Drawing.Size(19, 25);
			this.lblBlueVal.TabIndex = 85;
			this.lblBlueVal.Text = "-";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(197, 36);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 13);
			this.label13.TabIndex = 84;
			this.label13.Text = "Czerwony:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(111, 36);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 13);
			this.label12.TabIndex = 1;
			this.label12.Text = "Zielony:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 36);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "Niebieski:";
			// 
			// gbCycleMode
			// 
			this.gbCycleMode.Controls.Add(this.rbMultiCycle);
			this.gbCycleMode.Controls.Add(this.rbSingleCycle);
			this.gbCycleMode.Location = new System.Drawing.Point(1053, 206);
			this.gbCycleMode.Name = "gbCycleMode";
			this.gbCycleMode.Size = new System.Drawing.Size(121, 79);
			this.gbCycleMode.TabIndex = 108;
			this.gbCycleMode.TabStop = false;
			this.gbCycleMode.Text = "Tryb pracy robota";
			// 
			// rbMultiCycle
			// 
			this.rbMultiCycle.AutoSize = true;
			this.rbMultiCycle.Location = new System.Drawing.Point(8, 52);
			this.rbMultiCycle.Name = "rbMultiCycle";
			this.rbMultiCycle.Size = new System.Drawing.Size(76, 17);
			this.rbMultiCycle.TabIndex = 1;
			this.rbMultiCycle.Text = "Wiele cykli";
			this.rbMultiCycle.UseVisualStyleBackColor = true;
			// 
			// rbSingleCycle
			// 
			this.rbSingleCycle.AutoSize = true;
			this.rbSingleCycle.Checked = true;
			this.rbSingleCycle.Location = new System.Drawing.Point(8, 26);
			this.rbSingleCycle.Name = "rbSingleCycle";
			this.rbSingleCycle.Size = new System.Drawing.Size(101, 17);
			this.rbSingleCycle.TabIndex = 0;
			this.rbSingleCycle.TabStop = true;
			this.rbSingleCycle.Text = "Pojedynczy cykl";
			this.rbSingleCycle.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1584, 862);
			this.Controls.Add(this.gbCycleMode);
			this.Controls.Add(this.gbPixelValue);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.gbShapeMode);
			this.Controls.Add(this.gbDetectionRegions);
			this.Controls.Add(this.btnHold);
			this.Controls.Add(this.btnContinue);
			this.Controls.Add(this.txtOutcome);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.btnStopShapeDetection);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnShapeDetection);
			this.Controls.Add(this.btnShapeFeeder);
			this.Controls.Add(this.btnDefaultCameraSet);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.lblShape4);
			this.Controls.Add(this.cBoxShapes4);
			this.Controls.Add(this.lblShape3);
			this.Controls.Add(this.cBoxShapes3);
			this.Controls.Add(this.lblShape2);
			this.Controls.Add(this.cBoxShapes2);
			this.Controls.Add(this.lblShape1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.cBoxShapes1);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cbFeederr);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.gbFeed);
			this.Controls.Add(this.btnFeed);
			this.Controls.Add(this.ibFeeder);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSend);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtHostName);
			this.Controls.Add(this.btnDetectMultiple);
			this.Controls.Add(this.btnSetSize3);
			this.Controls.Add(this.btnSetSize2);
			this.Controls.Add(this.btnSetSize1);
			this.Controls.Add(this.cbKP3);
			this.Controls.Add(this.cbKP2);
			this.Controls.Add(this.cbKP1);
			this.Controls.Add(this.btnStopDetection);
			this.Controls.Add(this.btnStartCapture);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnDetectFeature);
			this.Controls.Add(this.lblEvent3);
			this.Controls.Add(this.lblEvent2);
			this.Controls.Add(this.lblEvent1);
			this.Controls.Add(this.cbCharacteristicPoints);
			this.Controls.Add(this.cbMatchLines);
			this.Controls.Add(this.btnCapture);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnLoad3);
			this.Controls.Add(this.tbFeature3);
			this.Controls.Add(this.btnLoad2);
			this.Controls.Add(this.tbFeature2);
			this.Controls.Add(this.btnLoad1);
			this.Controls.Add(this.tbFeature1);
			this.Controls.Add(this.gbWorkMode);
			this.Controls.Add(this.ibFeature3);
			this.Controls.Add(this.ibFeature2);
			this.Controls.Add(this.ibFeature1);
			this.Controls.Add(this.ibCameraCap);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Wykrywanie kształtów";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.ibCameraCap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ibFeature1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ibFeature2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ibFeature3)).EndInit();
			this.gbWorkMode.ResumeLayout(false);
			this.gbWorkMode.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ibFeeder)).EndInit();
			this.gbFeed.ResumeLayout(false);
			this.gbFeed.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBlueMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreenMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRedMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRedMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreenMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBlueMax)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.gbDetectionRegions.ResumeLayout(false);
			this.gbDetectionRegions.PerformLayout();
			this.gbShapeMode.ResumeLayout(false);
			this.gbShapeMode.PerformLayout();
			this.gbPixelValue.ResumeLayout(false);
			this.gbPixelValue.PerformLayout();
			this.gbCycleMode.ResumeLayout(false);
			this.gbCycleMode.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibCameraCap;
        private Emgu.CV.UI.ImageBox ibFeature1;
        private Emgu.CV.UI.ImageBox ibFeature2;
        private Emgu.CV.UI.ImageBox ibFeature3;
        private System.Windows.Forms.GroupBox gbWorkMode;
        private System.Windows.Forms.CheckBox cbMatchLines;
        private System.Windows.Forms.RadioButton rbUploadFeature;
        private System.Windows.Forms.RadioButton rbDetectInRois;
        private System.Windows.Forms.TextBox tbFeature1;
        private System.Windows.Forms.Button btnLoad1;
        private System.Windows.Forms.Button btnLoad2;
        private System.Windows.Forms.TextBox tbFeature2;
        private System.Windows.Forms.Button btnLoad3;
        private System.Windows.Forms.TextBox tbFeature3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.CheckBox cbCharacteristicPoints;
        private System.Windows.Forms.Label lblEvent1;
        private System.Windows.Forms.Label lblEvent2;
        private System.Windows.Forms.Label lblEvent3;
        private System.Windows.Forms.Button btnDetectFeature;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.Button btnStopDetection;
        private System.Windows.Forms.CheckBox cbKP1;
        private System.Windows.Forms.CheckBox cbKP2;
        private System.Windows.Forms.CheckBox cbKP3;
        private System.Windows.Forms.Button btnSetSize1;
        private System.Windows.Forms.Button btnSetSize2;
        private System.Windows.Forms.Button btnSetSize3;
        private System.Windows.Forms.RadioButton rbTrackObiect;
        private System.Windows.Forms.Button btnDetectMultiple;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox ibFeeder;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.GroupBox gbFeed;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblEv1;
        private System.Windows.Forms.Label lblEv2;
        private System.Windows.Forms.Label lblEv3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEve3;
        private System.Windows.Forms.RadioButton rbEve2;
        private System.Windows.Forms.RadioButton rbEve1;
        private System.Windows.Forms.CheckBox cbFeederr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFeedEv2;
        private System.Windows.Forms.Label lblFeedEv1;
        private System.Windows.Forms.Label lblFeedEv3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cBoxShapes1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbAdvanced;
        private System.Windows.Forms.RadioButton rbSimple;
        private System.Windows.Forms.Label lblShape1;
        private System.Windows.Forms.Label lblShape2;
        private System.Windows.Forms.ComboBox cBoxShapes2;
        private System.Windows.Forms.Label lblShape3;
        private System.Windows.Forms.ComboBox cBoxShapes3;
        private System.Windows.Forms.Label lblShape4;
        private System.Windows.Forms.ComboBox cBoxShapes4;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnDefaultCameraSet;
        private System.Windows.Forms.NumericUpDown numBlueMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numGreenMin;
        private System.Windows.Forms.NumericUpDown numRedMin;
        private System.Windows.Forms.NumericUpDown numRedMax;
        private System.Windows.Forms.NumericUpDown numGreenMax;
        private System.Windows.Forms.NumericUpDown numBlueMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnShapeFeeder;
        private System.Windows.Forms.Button btnShapeDetection;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbModifiedImage;
        private System.Windows.Forms.RadioButton rbOrginalImage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnStopShapeDetection;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblShape4Status;
        private System.Windows.Forms.Label lblShape3Status;
        private System.Windows.Forms.Label lblShape2Status;
        private System.Windows.Forms.Label lblShape1Status;
        private System.Windows.Forms.TextBox txtOutcome;
		private System.Windows.Forms.Button btnContinue;
		private System.Windows.Forms.Button btnHold;
		private System.Windows.Forms.GroupBox gbDetectionRegions;
		private System.Windows.Forms.RadioButton rbRegionShapeFeed;
		private System.Windows.Forms.RadioButton rbRegionShape4;
		private System.Windows.Forms.RadioButton rbRegionShape3;
		private System.Windows.Forms.RadioButton rbRegionShape2;
		private System.Windows.Forms.RadioButton rbRegionShape1;
		private System.Windows.Forms.GroupBox gbShapeMode;
		private System.Windows.Forms.RadioButton rbDisorder;
		private System.Windows.Forms.RadioButton rbOrder;
		private System.Windows.Forms.RadioButton rbNoFeedback;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.RadioButton rbCheckPixelValue;
		private System.Windows.Forms.GroupBox gbPixelValue;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lblRedVal;
		private System.Windows.Forms.Label lblGreenVal;
		private System.Windows.Forms.Label lblBlueVal;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox gbCycleMode;
		private System.Windows.Forms.RadioButton rbMultiCycle;
		private System.Windows.Forms.RadioButton rbSingleCycle;
	}
}

