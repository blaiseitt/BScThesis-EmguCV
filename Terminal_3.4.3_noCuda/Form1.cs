using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.XFeatures2D;
using Emgu.CV.UI;
using Emgu.CV.Cuda;
using System.Net.Sockets;
using System.Threading;

namespace Terminal_3._4._3_noCuda
{

    public partial class Form1 : Form
    {
        #region Fieldss
        VideoCapture capture;
        
        bool grabeInProcess = false;
        bool matchLines = false;
        bool keyPoints = false;
        
        Image<Bgr, byte> imgCameraCapOrginal;

        double hessianThresh = 300;

        Image<Bgr, byte> imgEvent1Buffer, imgEvent2Buffer, imgEvent3Buffer;

        Mat event1Mat, event2Mat, event3Mat;

        VectorOfKeyPoint event1Vector, event2Vector, event3Vector;              //wektory oraz deskryptory zdarzeń które mają zostać znalezione
        UMat model1_Descriptors, model2_Descriptors, model3_Descriptors;

        bool ev1Detected, ev2Detected, ev3Detected;
        bool ev1Fed, ev2Fed, ev3Fed;
        bool ev1Exist, ev2Exist, ev3Exist;
        double blueMin, blueMax, greenMin, greenMax, redMin, redMax;

        bool shape1Found, shape2Found, shape3Found, shape4Found;
        bool shape1FeedFound, shape2FeedFound, shape3FeedFound, shape4FeedFound;
        byte shapeInFeeder;
        bool feedReached, allShapesFound;
        string shape1Name = "";
        string shape2Name = "";
        string shape3Name = "";
        string shape4Name = "";

        string event1Name, event2Name, event3Name;

        Mat OrginalCap = new Mat();

        Image<Bgr, byte> fileWithFeature;

        public enum Shapes
        {
            Triangle = 3,
            Rectangle = 4,
            Square = 44,
            Pentagon = 5,
            Hexagon = 6,
            Octagon =8,
            Circle = 0,
            Undefined = 99
        }
        int shape1=99, shape2=99, shape3=99, shape4=99, shapeFeed=99;
        
        public Shapes ShapeToFind(ComboBox cb, ref string shapeName)
        {
            switch (cb.Text)
            {
                case "Trójkąt":
                    shapeName = "Trojkat";
                    return Shapes.Triangle;
                case "Kwadrat":
                    shapeName = "Kwadrat";
                    return Shapes.Square;
                case "Prostokąt":
                    shapeName = "Prostokat";
                    return Shapes.Rectangle;
                case "Pięciokąt":
                    shapeName = "Pieciokat";
                    return Shapes.Pentagon;
                case "Sześciokąt":
                    shapeName = "Szesciokat";
                    return Shapes.Hexagon;
                case "Ośmiokąt":
                    shapeName = "Osmiokat";
                    return Shapes.Octagon;
                case "Koło":
                    shapeName = "Kolo";
                    return Shapes.Circle;
                default:
                    return Shapes.Undefined;
            }
        }

        public struct SizeAndPosition
        {
            public int Www, Hhh, Xxx, Yyy;
            public string Name;
            public MCvScalar Colo;

            public SizeAndPosition(int w, int h, int x, int y, string Nam, MCvScalar c)
            {
                Www = w;
                Hhh = h;
                Xxx = x;
                Yyy = y;
                Name = Nam;
                Colo = c;
            }
        } 

        public struct cameraSettings
        {
            public int Bri, Con, Sha;
            public bool Gra, Neg, Flip;
        }

        SizeAndPosition event1Coordinates, event2Coordinates, event3Coordinates, feedCoordinates, shape1Coordinates, shape2Coordinates, shape3Coordinates, shape4Coordinates, shapeFeedCoordinates;
        cameraSettings cameraSet;

        Rectangle ROI1, ROI2, ROI3, ROIfeed, RectShape1, RectShape2, RectShape3, RectShape4, RectShapeFeed;
        MCvScalar eventFoundColor, eventNotFoundColor;

        byte eventInFeeder;
        #endregion

        public Form1()
        {
            InitializeComponent();

            imgCameraCapOrginal = new Image<Bgr, byte>(ibCameraCap.Size); //scena

            imgEvent1Buffer = new Image<Bgr, byte>(ibFeature1.Size);    //zdarzenie 1
            imgEvent2Buffer = new Image<Bgr, byte>(ibFeature1.Size);    //zdarzenie 2
            imgEvent3Buffer = new Image<Bgr, byte>(ibFeature1.Size);    //zdarzenie 3

            event1Coordinates.Colo = new MCvScalar((double)0x1a, (double)0xf0, (double)0xff);
            event2Coordinates.Colo = new MCvScalar((double)0x1a, (double)0xf0, (double)0xff);
            event3Coordinates.Colo = new MCvScalar((double)0x1a, (double)0xf0, (double)0xff);
            feedCoordinates.Colo = new MCvScalar((double)0x1a, (double)0xf0, (double)0xff);
            eventFoundColor = new MCvScalar(0, 255, 0);
            eventNotFoundColor = new MCvScalar(0, 0, 255);

            cameraSet.Bri = 75;
            cameraSet.Con = 25;
            cameraSet.Sha = 20;
            cameraSet.Gra = false;
            cameraSet.Neg = false;
			//initialROIValues();
			//initialROIShapes();
            blueMin = (double)numBlueMin.Value;
            blueMax = (double)numBlueMax.Value;
            greenMin = (double)numGreenMin.Value;
            greenMax = (double)numGreenMax.Value;
            redMin = (double)numRedMin.Value;
            redMax = (double)numRedMax.Value;
        }

		private void initialROIShapes()
		{
			shape1Coordinates.Xxx = 0;
			shape1Coordinates.Yyy = 225;
			shape1Coordinates.Www = 133;
			shape1Coordinates.Hhh = 100;

			shape2Coordinates.Xxx = 150;
			shape2Coordinates.Yyy = 243;
			shape2Coordinates.Www = 145;
			shape2Coordinates.Hhh = 105;

			shape3Coordinates.Xxx = 310;
			shape3Coordinates.Yyy = 222;
			shape3Coordinates.Www = 140;
			shape3Coordinates.Hhh = 105;

			shape4Coordinates.Xxx = 471;
			shape4Coordinates.Yyy = 220;
			shape4Coordinates.Www = 141;
			shape4Coordinates.Hhh = 104;

			shapeFeedCoordinates.Xxx = 265;
			shapeFeedCoordinates.Yyy = 40;
			shapeFeedCoordinates.Www = 130;
			shapeFeedCoordinates.Hhh = 100;
		}

		private void initialROIValues()
        {
            event1Coordinates.Xxx = 5;
            event1Coordinates.Yyy = 5;
            event1Coordinates.Www = 280;
            event1Coordinates.Hhh = 180;

            event2Coordinates.Xxx = 310;
            event2Coordinates.Yyy = 5;
            event2Coordinates.Www = 280;
            event2Coordinates.Hhh = 180;

            event3Coordinates.Xxx = 5;
            event3Coordinates.Yyy = 210;
            event3Coordinates.Www = 280;
            event3Coordinates.Hhh = 180;

            feedCoordinates.Xxx = 310;
            feedCoordinates.Yyy = 210;
            feedCoordinates.Www = 280;
            feedCoordinates.Hhh = 180;
        }

        private void ROIeventsZero()
        {
            event1Coordinates.Xxx = 0;
            event1Coordinates.Yyy = 0;
            event1Coordinates.Www = 0;
            event1Coordinates.Hhh = 0;

            event2Coordinates.Xxx = 0;
            event2Coordinates.Yyy = 0;
            event2Coordinates.Www = 0;
            event2Coordinates.Hhh = 0;

            event3Coordinates.Xxx = 0;
            event3Coordinates.Yyy = 0;
            event3Coordinates.Www = 0;
            event3Coordinates.Hhh = 0;

            feedCoordinates.Xxx = 0;
            feedCoordinates.Yyy = 0;
            feedCoordinates.Www = 0;
            feedCoordinates.Hhh = 0;
        }

        private void ROIshapesZero()
        {
            shape1Coordinates.Xxx = 0;
            shape1Coordinates.Yyy = 0;
            shape1Coordinates.Www = 0;
            shape1Coordinates.Hhh = 0;

            shape2Coordinates.Xxx = 0;
            shape2Coordinates.Yyy = 0;
            shape2Coordinates.Www = 0;
            shape2Coordinates.Hhh = 0;

            shape3Coordinates.Xxx = 0;
            shape3Coordinates.Yyy = 0;
            shape3Coordinates.Www = 0;
            shape3Coordinates.Hhh = 0;

            shape4Coordinates.Xxx = 0;
            shape4Coordinates.Yyy = 0;
            shape4Coordinates.Www = 0;
            shape4Coordinates.Hhh = 0;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (grabeInProcess == true)
            {
                Application.Idle -= new EventHandler(this.DisplayFrames);
                fileWithFeature = OrginalCap.ToImage<Bgr, byte>();

                btnSave.Enabled = true;
                grabeInProcess = false;
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (grabeInProcess == true)
            {
                MessageBox.Show("Zatrzymaj przechwytywanie obrazu,\n przed wyczyszczeniem bufora");
                return;
            }
            else
            {
                ibCameraCap.Image = null;
            }
        }

        private void cbCharacteristicPoints_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCharacteristicPoints.Checked == true)
            {
                cbMatchLines.Enabled = true;
                keyPoints = true;
            }
            else
            {
                cbCharacteristicPoints.Checked = false;
                cbMatchLines.Checked = false;
                cbMatchLines.Enabled = false;
                matchLines = false;
                keyPoints = false;
            }
        }

        private void cbMatchLines_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMatchLines.Checked == true)
            {
                matchLines = true;
            }
            else
            {
                matchLines = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            if (grabeInProcess == false)
            {
                Application.Idle += new EventHandler(this.DisplayFrames);
                grabeInProcess = true;
                cbFeederr.Enabled = false;
                btnCapture.Enabled = true;
                btnStop.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(this.DisplayFrames);
            fileWithFeature = OrginalCap.ToImage<Bgr, byte>();
            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }
            btnSave.Enabled = false;
            btnCapture.Enabled = false;
            btnStop.Enabled = false;
            cbFeederr.Enabled = true;
            grabeInProcess = false;
            ibCameraCap.Image = null;

        }

        private void cbFeederr_CheckedChanged(object sender, EventArgs e)
        {
            if(cbFeederr.Checked == true && event1Mat==null)
            {
                cbFeederr.Checked = false;
                MessageBox.Show("Należy wgrać zdarzenie numer 1");
            }
            else if(cbFeederr.Checked == true && event1Mat != null)
            {
                ibFeeder.Visible = true;
                btnFeed.Visible = true;
                gbFeed.Visible = true;
                groupBox1.Visible = true;
            }
            else
            {
                ibFeeder.Visible = false;
                btnFeed.Visible = false;
                gbFeed.Visible = false;
                groupBox1.Visible = false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Saving_Opening_Files_Drawing_Keypoints_On_Models                
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grabeInProcess == false)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                sfd.Title = "Zapisz zdarzenie do wykrycia jako plik";
                sfd.FileName = "Zdarzenie_"; //+"numZdarzenia"

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fileWithFeature.Save(sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Przed zapisaniem zdarzenia należy skorzystać z opcji \"Przechwyć\".");
            }
        }

        private void OpenAndLoadImage(Image<Bgr, byte> img, ImageBox ib, TextBox txt, Label lbl, ref Mat src)
        {

            string temp = lbl.Text;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = /*"JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";*/ "Image files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            ofd.Title = $"Wybierz {temp}";

            DialogResult dialogResult = ofd.ShowDialog();

            if((dialogResult == DialogResult.OK) | (dialogResult == DialogResult.Yes))
            {
                txt.Text = ofd.FileName;
            }
            else
                return;
            try
            {
                src = CvInvoke.Imread(txt.Text);
                src = Reeesize(src);
                img = src.ToImage<Bgr, byte>();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            ib.Image = img;
            txt.SelectionStart = txt.Text.Length;
            
        }
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private Mat Reeesize(Mat src)
        {
            Mat dst = new Mat();
            CvInvoke.Resize(src, dst, ibFeature1.Size, 0, 0, Inter.Cubic);
            return dst;
        }

        private string EventName(TextBox src)
        {
            string path = src.Text;
            string[] pathArr = path.Split('\\');
            string[] fileArr = pathArr.Last().Split('.');
            string fileName = fileArr.First().ToString();

            return fileName;
        }

        private void DetectAndComputeKPandDescriptor(Mat modelSrc, ref VectorOfKeyPoint vkpModel, ref UMat modelDescriptor)
        {
            if (modelSrc != null)
            {
                vkpModel = new VectorOfKeyPoint();
                modelDescriptor = new UMat();
                UMat uModelSrc = new UMat();

                Mat tempImg = new Mat();
                modelSrc.CopyTo(tempImg);

                uModelSrc = tempImg.GetUMat(AccessType.ReadWrite);

                SURF surfEvent = new SURF(hessianThresh);
                surfEvent.DetectAndCompute(uModelSrc, null, vkpModel, modelDescriptor, false);
                /*
                Features2DToolbox.DrawKeypoints(modelSrc, vkpModel, tempImg, new Bgr(Color.Violet));
                ib.Image = tempImg.ToImage<Bgr, byte>();
                */
            }
        }

        private void DrawKeypointsOnEvent(ImageBox ib, Mat modelSrc, VectorOfKeyPoint vkpModel)
        {
            Mat tempImg = new Mat();
            modelSrc.CopyTo(tempImg);

            Features2DToolbox.DrawKeypoints(modelSrc, vkpModel, tempImg, new Bgr(Color.Violet));
            ib.Image = tempImg.ToImage<Bgr, byte>();
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnLoad1_Click(object sender, EventArgs e)
        {
            btnLoad2.Enabled = true;
            OpenAndLoadImage(imgEvent1Buffer, ibFeature1, tbFeature1, lblEvent1, ref event1Mat);
            event1Name = EventName(tbFeature1);

            if (event1Mat != null && cbKP1.Checked == false)
            {
                DetectAndComputeKPandDescriptor(event1Mat, ref event1Vector, ref model1_Descriptors);
            }
            else if(event1Mat != null && cbKP1.Checked == true)
            {
                DetectAndComputeKPandDescriptor(event1Mat, ref event1Vector, ref model1_Descriptors);
                DrawKeypointsOnEvent(ibFeature1, event1Mat, event1Vector);
            }
        }

        private void btnLoad2_Click(object sender, EventArgs e)
        {
            btnLoad3.Enabled = true;
            OpenAndLoadImage(imgEvent2Buffer, ibFeature2, tbFeature2, lblEvent2, ref event2Mat);
            event2Name = EventName(tbFeature2);
            if (event2Mat != null && cbKP2.Checked == false)
            {
                DetectAndComputeKPandDescriptor(event2Mat, ref event2Vector, ref model2_Descriptors);
            }
            else if (event2Mat != null && cbKP2.Checked == true)
            {
                DetectAndComputeKPandDescriptor(event2Mat, ref event2Vector, ref model2_Descriptors);
                DrawKeypointsOnEvent(ibFeature2, event2Mat, event2Vector);
            }
        }

        private void btnLoad3_Click(object sender, EventArgs e)
        {
            OpenAndLoadImage(imgEvent3Buffer, ibFeature3, tbFeature3, lblEvent3, ref event3Mat);
            event3Name = EventName(tbFeature3);
            if (event3Mat != null && cbKP3.Checked == false)
            {
                DetectAndComputeKPandDescriptor(event3Mat, ref event3Vector, ref model3_Descriptors);
            }
            else if (event3Mat != null && cbKP3.Checked == true)
            {
                DetectAndComputeKPandDescriptor(event3Mat, ref event3Vector, ref model3_Descriptors);
                DrawKeypointsOnEvent(ibFeature3, event3Mat, event3Vector);
            }
        }

        private void cbKP1_CheckedChanged(object sender, EventArgs e)
        {
            if (event1Mat!=null && cbKP1.Checked == true)
            {
                DrawKeypointsOnEvent(ibFeature1, event1Mat, event1Vector);
            }
            else if(event1Mat != null && cbKP1.Checked == false)
            {
                ibFeature1.Image = event1Mat.ToImage<Bgr, byte>();
            }
        }

        private void cbKP2_CheckedChanged(object sender, EventArgs e)
        {
            if (event2Mat != null && cbKP2.Checked == true)
            {
                DrawKeypointsOnEvent(ibFeature2, event2Mat, event2Vector);
            }
            else if (event2Mat != null && cbKP2.Checked == false)
            {
                ibFeature2.Image = event2Mat.ToImage<Bgr, byte>();
            }
        }

        private void cbKP3_CheckedChanged(object sender, EventArgs e)
        {
            if (event3Mat != null && cbKP3.Checked == true)
            {
                DrawKeypointsOnEvent(ibFeature3, event3Mat, event3Vector);
            }
            else if (event3Mat != null && cbKP3.Checked == false)
            {
                ibFeature3.Image = event3Mat.ToImage<Bgr, byte>();
            }
        }

        #endregion                              //////////////////////////////////////////////////////////////////////////////////////////////////////////////////      /////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public Mat FramesFromCamera() //przechwytuje klatki  z kamery
        {
            Mat singleFrame = new Mat();
            if (capture == null)
            {
				capture = new VideoCapture(0);                           //za każdym razem tworzy się singleFrame który nie jest usuwany z pamięci
                capture.SetCaptureProperty(CapProp.Fps, 10);
            }
            else
            {
                //double bright = (double)cameraSet.Bri;//Convert.ToDouble(cameraSet.Bri);

                capture.SetCaptureProperty(CapProp.Brightness, (double)cameraSet.Bri*2);      //kontrast i jasność razy dwa
                capture.SetCaptureProperty(CapProp.Contrast, (double)cameraSet.Con*2);
            }
            try
            {
                singleFrame = capture.QueryFrame();
                Image<Bgr, byte> tempImgBgr = singleFrame.ToImage<Bgr, byte>();
                int tempSharp = (21 - cameraSet.Sha);
                tempImgBgr = tempImgBgr.SmoothBlur(tempSharp, tempSharp, true);
                if (cameraSet.Neg == true) tempImgBgr = tempImgBgr.Not();
                singleFrame = tempImgBgr.Mat;
                if (cameraSet.Gra == true)
                {
                    Image<Gray, byte> tempGray = singleFrame.ToImage<Gray, byte>();
                    singleFrame = tempGray.Mat;
                }
				if(cameraSet.Flip==true)
                CvInvoke.Flip(singleFrame, singleFrame, FlipType.Horizontal);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return singleFrame;
        }

        public void DisplayFrames(object sender, EventArgs e)
        {
            //FramesFromCamera();
            //ibCameraCap.Image = OrginalCap.ToImage<Bgr, byte>();

            OrginalCap = FramesFromCamera();
            //DrawRectOnIB(event1Coordinates, OrginalCap);
            //DrawRectOnIB(event2Coordinates, OrginalCap);
            //DrawRectOnIB(event3Coordinates, OrginalCap);
            ROI1 = RetrieveRectangle(event1Coordinates);
            ROI2 = RetrieveRectangle(event2Coordinates);
            ROI3 = RetrieveRectangle(event3Coordinates);
            ROIfeed = RetrieveRectangle(feedCoordinates);
            RectShape1 = RetrieveRectangle(shape1Coordinates);
            RectShape2 = RetrieveRectangle(shape2Coordinates);
            RectShape3 = RetrieveRectangle(shape3Coordinates);
            RectShape4 = RetrieveRectangle(shape4Coordinates);
            RectShapeFeed = RetrieveRectangle(shapeFeedCoordinates);
            if (OrginalCap != null)
            {
                if (rbAdvanced.Checked == true)
                {
                    CvInvoke.Rectangle(OrginalCap, ROI1, event1Coordinates.Colo, 2);
                    CvInvoke.Rectangle(OrginalCap, ROI2, event2Coordinates.Colo, 2);
                    CvInvoke.Rectangle(OrginalCap, ROI3, event3Coordinates.Colo, 2);

                    CvInvoke.PutText(OrginalCap, event1Coordinates.Name, new Point(event1Coordinates.Xxx + 2, event1Coordinates.Yyy + 10), FontFace.HersheyComplex, 1, event1Coordinates.Colo);
                    CvInvoke.PutText(OrginalCap, event2Coordinates.Name, new Point(event2Coordinates.Xxx + 2, event2Coordinates.Yyy + 10), FontFace.HersheyComplex, 1, event2Coordinates.Colo);
                    CvInvoke.PutText(OrginalCap, event3Coordinates.Name, new Point(event3Coordinates.Xxx + 2, event3Coordinates.Yyy + 10), FontFace.HersheyComplex, 1, event2Coordinates.Colo);

                    if (rbEve1.Checked == true) feedCoordinates.Name = event1Name;
                    else if (rbEve2.Checked == true) feedCoordinates.Name = event2Name;
                    else if (rbEve3.Checked == true) feedCoordinates.Name = event3Name;

                    if (cbFeederr.Checked == true)
                    {
                        CvInvoke.Rectangle(OrginalCap, ROIfeed, feedCoordinates.Colo, 2);
                        CvInvoke.PutText(OrginalCap, feedCoordinates.Name, new Point(feedCoordinates.Xxx + 2, feedCoordinates.Yyy + 10), FontFace.HersheyComplex, 1, feedCoordinates.Colo);
                    }
                }
                else
                {
                    if(shape1 != 99)
                    {
                        CvInvoke.Rectangle(OrginalCap, RectShape1, new MCvScalar(30, 255, 0), 2);
                        CvInvoke.PutText(OrginalCap, "Ksztalt 1", new Point(shape1Coordinates.Xxx+2, shape1Coordinates.Yyy-5), FontFace.HersheyComplex, 0.7, new MCvScalar(30, 255, 0));
                    }
                    if(shape2 != 99)
                    {
                        CvInvoke.Rectangle(OrginalCap, RectShape2, new MCvScalar(30, 255, 0), 2);
                        CvInvoke.PutText(OrginalCap, "Ksztalt 2", new Point(shape2Coordinates.Xxx + 2, shape2Coordinates.Yyy - 5), FontFace.HersheyComplex, 0.7, new MCvScalar(30, 255, 0));
                    }   
                    if(shape3 != 99)
                    {
                        CvInvoke.Rectangle(OrginalCap, RectShape3, new MCvScalar(30, 255, 0), 2);
                        CvInvoke.PutText(OrginalCap, "Ksztalt 3", new Point(shape3Coordinates.Xxx + 2, shape3Coordinates.Yyy - 5), FontFace.HersheyComplex, 0.7, new MCvScalar(30, 255, 0));
                    }
                    if(shape4 != 99)
                    {
                        CvInvoke.Rectangle(OrginalCap, RectShape4, new MCvScalar(30, 255, 0), 2);
                        CvInvoke.PutText(OrginalCap, "Ksztalt 4", new Point(shape4Coordinates.Xxx + 2, shape4Coordinates.Yyy - 5), FontFace.HersheyComplex, 0.7, new MCvScalar(30, 255, 0));
                    }
                    if(shapeFeedCoordinates.Www!=0 && shapeFeedCoordinates.Hhh != 0)
                    {
                        CvInvoke.Rectangle(OrginalCap, RectShapeFeed, new MCvScalar(30, 30, 255), 2);
                        CvInvoke.PutText(OrginalCap, "Podajnik", new Point(shapeFeedCoordinates.Xxx + 2, shapeFeedCoordinates.Yyy - 5), FontFace.HersheyComplex, 0.7, new MCvScalar(30, 30, 255));
                    }
                }
            }
            ///urywek obrazka, znajdujący się w kwadracie,  test czy działa - zaliczony
            ibCameraCap.Image = OrginalCap.ToImage<Bgr, byte>();
        }
        ///////////////Nadawanie rozmiaru poszczególnym podobszarą na których mają być wykrywane szczególne zdarzenia
        #region EventRegions
        private void btnSetSize1_Click(object sender, EventArgs e)
        {
            if (event1Mat != null)
            {
                    event1Coordinates.Name = event1Name;
                    EventRegion frm = new EventRegion(ibCameraCap.Size, event1Coordinates.Xxx, event1Coordinates.Yyy, event1Coordinates.Www, event1Coordinates.Hhh);
                    frm.RegionSender += Frm_RegionSender1;
                    frm.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Proszę wybrać zdarzenie przed określeniem jego położenia.");
            }
        }

        private void btnSetSize2_Click(object sender, EventArgs e)
        {
            if (event2Mat != null)
            {
                event2Coordinates.Name = event2Name;
                EventRegion frm = new EventRegion(ibCameraCap.Size, event2Coordinates.Xxx, event2Coordinates.Yyy, event2Coordinates.Www, event2Coordinates.Hhh);
                frm.RegionSender += Frm_RegionSender2;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę wybrać zdarzenie przed określeniem jego położenia.");
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            CameraSettings frm = new CameraSettings(cameraSet.Bri, cameraSet.Con, cameraSet.Sha, cameraSet.Neg, cameraSet.Gra, cameraSet.Flip);
            frm.CameraSettingsSender += Frm_CameraSettingsSender;
            frm.ShowDialog();
        }

        private void Frm_CameraSettingsSender(int brightness, int contrast, int sharpness, bool negative, bool grayScale, bool flipp)
        {
            cameraSet.Bri = brightness;
            cameraSet.Con = contrast;
            cameraSet.Sha = sharpness;
            cameraSet.Neg = negative;
            cameraSet.Gra = grayScale;
			cameraSet.Flip = flipp;
        }

        private void cBoxShapes1_TextChanged(object sender, EventArgs e)
        {
            shape1 = (int)ShapeToFind(cBoxShapes1, ref shape1Name);   
        }

        private void cBoxShapes2_TextChanged(object sender, EventArgs e)
        {
            shape2 = (int)ShapeToFind(cBoxShapes2, ref shape2Name);
        }

        private void cBoxShapes3_TextChanged(object sender, EventArgs e)
        {
            shape3 = (int)ShapeToFind(cBoxShapes3, ref shape3Name);
        }

        private void cBoxShapes4_TextChanged(object sender, EventArgs e)
        {
            shape4 = (int)ShapeToFind(cBoxShapes4, ref shape4Name);
        }

        private void btnShapeRegion1_Click(object sender, EventArgs e)
        {
            EventRegion frm = new EventRegion(ibCameraCap.Size, shape1Coordinates.Xxx, shape1Coordinates.Yyy, shape1Coordinates.Www, shape1Coordinates.Hhh);
            frm.RegionSender += Frm_ShapeSender1;
            frm.ShowDialog();
        }

        private void btnShapeRegion2_Click(object sender, EventArgs e)
        {
            EventRegion frm = new EventRegion(ibCameraCap.Size, shape2Coordinates.Xxx, shape2Coordinates.Yyy, shape2Coordinates.Www, shape2Coordinates.Hhh);
            frm.RegionSender += Frm_ShapeSender2;
            frm.ShowDialog();
        }

        private void btnShapeRegion3_Click(object sender, EventArgs e)
        {
            EventRegion frm = new EventRegion(ibCameraCap.Size, shape3Coordinates.Xxx, shape3Coordinates.Yyy, shape3Coordinates.Www, shape3Coordinates.Hhh);
            frm.RegionSender += Frm_ShapeSender3;
            frm.ShowDialog();
        }
        
        private void btnShapeRegion4_Click(object sender, EventArgs e)
        {
            EventRegion frm = new EventRegion(ibCameraCap.Size, shape4Coordinates.Xxx, shape4Coordinates.Yyy, shape4Coordinates.Www, shape4Coordinates.Hhh);
            frm.RegionSender += Frm_ShapeSender4;
            frm.ShowDialog();
        }

        private void Frm_ShapeSender1(int hHei, int wWei, int xX, int yY)
        {
            shape1Coordinates.Hhh = hHei;
            shape1Coordinates.Www = wWei;
            shape1Coordinates.Xxx = xX;
            shape1Coordinates.Yyy = yY;
        }

        private void Frm_ShapeSender2(int hHei, int wWei, int xX, int yY)
        {
            shape2Coordinates.Hhh = hHei;
            shape2Coordinates.Www = wWei;
            shape2Coordinates.Xxx = xX;
            shape2Coordinates.Yyy = yY;
        }

        private void numBlueMin_ValueChanged(object sender, EventArgs e)
        {
            blueMin = (double)numBlueMin.Value;
        }

        private void numBlueMax_ValueChanged(object sender, EventArgs e)
        {
            blueMax = (double)numBlueMax.Value;
        }

        private void numGreenMin_ValueChanged(object sender, EventArgs e)
        {
            greenMin = (double)numGreenMin.Value;
        }

        private void numGreenMax_ValueChanged(object sender, EventArgs e)
        {
            greenMax = (double)numGreenMax.Value;
        }

        private void numRedMin_ValueChanged(object sender, EventArgs e)
        {
            redMin = (double)numRedMin.Value;
        }

        private void numRedMax_ValueChanged(object sender, EventArgs e)
        {
            redMax = (double)numRedMax.Value;
        }

        private void btnShapeFeeder_Click(object sender, EventArgs e)
        {
            EventRegion frm = new EventRegion(ibCameraCap.Size, shapeFeedCoordinates.Xxx, shapeFeedCoordinates.Yyy, shapeFeedCoordinates.Www, shapeFeedCoordinates.Hhh);
            frm.RegionSender += Frm_FeedShapeSender;
            frm.ShowDialog();
        }

        private void Frm_FeedShapeSender(int hHei, int wWei, int xX, int yY)
        {
            shapeFeedCoordinates.Hhh = hHei;
            shapeFeedCoordinates.Www = wWei;
            shapeFeedCoordinates.Xxx = xX;
            shapeFeedCoordinates.Yyy = yY;
        }

        private void Frm_ShapeSender3(int hHei, int wWei, int xX, int yY)
        {
            shape3Coordinates.Hhh = hHei;
            shape3Coordinates.Www = wWei;
            shape3Coordinates.Xxx = xX;
            shape3Coordinates.Yyy = yY;
        }

        private void Frm_ShapeSender4(int hHei, int wWei, int xX, int yY)
        {
            shape4Coordinates.Hhh = hHei;
            shape4Coordinates.Www = wWei;
            shape4Coordinates.Xxx = xX;
            shape4Coordinates.Yyy = yY;
        }

        private void btnStopShapeDetection_Click(object sender, EventArgs e)
        {
			if (rbNoFeedback.Checked)
			{
				rbOrder.Enabled = true;
				rbDisorder.Enabled = true;
				Application.Idle -= new EventHandler(this.ShapeDetection);
			}
			if (rbOrder.Checked)
			{
				rbNoFeedback.Enabled = true;
				rbDisorder.Enabled = true;
				Application.Idle -= new EventHandler(this.ShapeDetection_With_Delivery);
			}
			if (rbDisorder.Checked)
			{
				rbOrder.Enabled = true;
				rbNoFeedback.Enabled = true;
				Application.Idle -= new EventHandler(this.ShapeDetection_Segregation);
			}


            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }
			#region MessageAboutFinalStatus
			switch (lblShape1Status.ForeColor == Color.Green)
			{
				case true:
					switch (lblShape2Status.ForeColor == Color.Green)
					{
						case true:
							switch (lblShape3Status.ForeColor == Color.Green)
							{
								case true:
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Wszystkie kształty w prawidłowym miejscu.");
											break;
										case false:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 4.");
											break;
									}
									break;
								case false:
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 3.");
											break;
										case false:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 3 i kształtu numer 4.");
											break;
									}
									break;
							}
							break;
						case false://1tak//2nie
							switch (lblShape3Status.ForeColor == Color.Green)
							{
								case true://3tak
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true://4tak
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 2.");
											break;
										case false://4nie
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 2 i kształtu numer 4.");
											break;
									}
									break;
								case false://3nie
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 2 i kształtu numer 3.");
											break;
										case false://4nie
											MessageBox.Show("Wszystkie kształty poza kształtem 1, uległy nieporządanemu przesunięciu.");
											break;
									}
									break;
							}
							break;
					}
					break;
				case false://1nie
					switch (lblShape2Status.ForeColor == Color.Green)
					{
						case true://2tak
							switch (lblShape3Status.ForeColor == Color.Green)
							{
								case true://3tak
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 1.");
											break;
										case false:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 1 kształtu numer 4.");
											break;
									}
									break;
								case false://3nie
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 1 i kształtu numer 3.");
											break;
										case false:
											MessageBox.Show("Wszystkie kształty poza kształtem 2, uległy nieporządanemu przesunięciu.");
											break;
									}
									break;
							}
							break;
						case false://2nie
							switch (lblShape3Status.ForeColor == Color.Green)
							{
								case true://3tak
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Nastąpiło nieporządane przesunięcie kształtu numer 1 i kształtu numer 2.");
											break;
										case false:
											MessageBox.Show("Wszystkie kształty poza kształtem 3, uległy nieporządanemu przesunięciu.");
											break;
									}
									break;
								case false://3nie
									switch (lblShape4Status.ForeColor == Color.Green)
									{
										case true:
											MessageBox.Show("Wszystkie kształty poza kształtem 4, uległy nieporządanemu przesunięciu.");
											break;
										case false:
											MessageBox.Show("Wszystkie kształty uległy nieporządanemu przesunięciu.");
											break;
									}
									break;
							}
							break;
					}
					break;
			}
			#endregion

			/////////zmiany wiadomości wyświetlanej po zakonczeniu operacji wykrywania kształtów

			//ibCameraCap.Image = null;
            cBoxShapes1.Enabled = true;
            cBoxShapes2.Enabled = true;
            cBoxShapes3.Enabled = true;
            cBoxShapes4.Enabled = true;
            btnShapeDetection.Enabled = true;
            btnStopShapeDetection.Enabled = false;
			rbAdvanced.Enabled = false;
        }

        private void btnSetSize3_Click(object sender, EventArgs e)
        {
            if (event3Mat != null)
            {
                event3Coordinates.Name = event3Name;
                EventRegion frm = new EventRegion(ibCameraCap.Size, event3Coordinates.Xxx, event3Coordinates.Yyy, event3Coordinates.Www, event3Coordinates.Hhh);
                frm.RegionSender += Frm_RegionSender3;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę wybrać zdarzenie przed określeniem jego położenia.");
            }
        }
		
		private void btnFeed_Click(object sender, EventArgs e)
        {
            event1Coordinates.Name = event1Name;
            EventRegion frm = new EventRegion(ibCameraCap.Size, feedCoordinates.Xxx, feedCoordinates.Yyy, feedCoordinates.Www, feedCoordinates.Hhh);
            frm.RegionSender += Frm_RegionSenderFeed;
            frm.ShowDialog();
        }

        private void btnDefaultCameraSet_Click(object sender, EventArgs e)
        {
            cameraSet.Bri = 75;
            cameraSet.Con = 25;
            cameraSet.Sha = 20;
            cameraSet.Gra = false;
            cameraSet.Neg = false;
			cameraSet.Flip = false;
        }

        private void rbSimple_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimple.Checked == true)
            {
				gbDetectionRegions.Visible = true;
				gbCycleMode.Visible = true;
				gbPixelValue.Visible = true;
				gbShapeMode.Visible = true;
				btnShapeFeeder.Visible = true;
                this.Text = "Wykrywanie kształtów";
                groupBox6.Visible = true;
                btnShapeDetection.Visible = true;
                btnStopShapeDetection.Visible = true;
                btnDetectMultiple.Visible = false;
                btnDetectFeature.Visible = false;
                btnStopDetection.Visible = false;

				btnStop_Click(new object(), new EventArgs());

				groupBox5.Visible = true;
                gbWorkMode.Visible = false;
                lblEv1.Visible = false;
                lblEv2.Visible = false;
                lblEv3.Visible = false;
                cbKP1.Visible = false;
                cbKP2.Visible = false;
                cbKP3.Visible = false;
                ibFeature1.Visible = false;
                ibFeature2.Visible = false;
                ibFeature3.Visible = false;

                groupBox1.Visible = false;
                groupBox2.Visible = false;
                gbFeed.Visible = false;
                ibFeeder.Visible = false;
                btnFeed.Visible = false;
                progressBar1.Visible = false;

                btnSave.Visible = false;
                btnCapture.Visible = false;
                tbFeature1.Visible = false;
                tbFeature2.Visible = false;
                tbFeature3.Visible = false;
                btnLoad1.Visible = false;
                btnLoad2.Visible = false;
                btnLoad3.Visible = false;
				
                lblShape1.Visible = true;
                lblShape2.Visible = true;
                lblShape3.Visible = true;
                lblShape4.Visible = true;
                cBoxShapes1.Visible = true;
                cBoxShapes2.Visible = true;
                cBoxShapes3.Visible = true;
                cBoxShapes4.Visible = true;
                btnSetSize1.Visible = false;
                btnSetSize2.Visible = false;
                btnSetSize3.Visible = false;
                groupBox4.Visible = true;
                cbCharacteristicPoints.Visible = false;
                cbMatchLines.Visible = false;
                cbFeederr.Visible = false;

                btnStop_Click(new object(), new EventArgs());
                //ROIeventsZero();
            }
        }

		bool isMouseDown = false;
		public Point leftMouseButtonDownLocation = Point.Empty;
		public Point currentMouseLocation = Point.Empty;

		private void ibCameraCap_MouseDown(object sender, MouseEventArgs e)
		{
			isMouseDown = true;
			leftMouseButtonDownLocation = currentMouseLocation = e.Location;
			//ibCameraCap.Invalidate();
		}

		private void ibCameraCap_MouseUp(object sender, MouseEventArgs e)
		{
			isMouseDown = false;
		}

		private void ibCameraCap_MouseMove(object sender, MouseEventArgs e)
		{
			if (isMouseDown)
			{
				currentMouseLocation = e.Location;
				//ibCameraCap.Invalidate();
			}
		}

		private void ibCameraCap_Paint(object sender, PaintEventArgs e)
		{
			if (isMouseDown)
			{
				int tempX, tempY, tempW, tempH;
				tempX = Math.Min(leftMouseButtonDownLocation.X, currentMouseLocation.X);
				tempY = Math.Min(leftMouseButtonDownLocation.Y, currentMouseLocation.Y);
				tempW = Math.Abs(leftMouseButtonDownLocation.X - currentMouseLocation.X);
				tempH = Math.Abs(leftMouseButtonDownLocation.Y - currentMouseLocation.Y);
                int tempThreshX = tempX + tempW;
                int tempThreshY = tempY + tempH;
                if (tempThreshX >= 640) return;
                if (tempThreshY >= 480) return;

				if (rbRegionShape1.Checked)
				{
					shape1Coordinates.Xxx = tempX;
					shape1Coordinates.Yyy = tempY;
					shape1Coordinates.Www = tempW;
					shape1Coordinates.Hhh = tempH;
				}
				else if (rbRegionShape2.Checked)
				{
					shape2Coordinates.Xxx = tempX;
					shape2Coordinates.Yyy = tempY;
					shape2Coordinates.Www = tempW;
					shape2Coordinates.Hhh = tempH;
				}
				else if (rbRegionShape3.Checked)
				{
					shape3Coordinates.Xxx = tempX;
					shape3Coordinates.Yyy = tempY;
					shape3Coordinates.Www = tempW;
					shape3Coordinates.Hhh = tempH;
				}
				else if (rbRegionShape4.Checked)
				{
					shape4Coordinates.Xxx = tempX;
					shape4Coordinates.Yyy = tempY;
					shape4Coordinates.Www = tempW;
					shape4Coordinates.Hhh = tempH;
				}
				else if (rbRegionShapeFeed.Checked)
				{
					shapeFeedCoordinates.Xxx = tempX;
					shapeFeedCoordinates.Yyy = tempY;
					shapeFeedCoordinates.Www = tempW;
					shapeFeedCoordinates.Hhh = tempH;
				}
			}		
		}

		private void rbAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if(rbAdvanced.Checked == true)
            {
                if (rbUploadFeature.Checked)
                {
                    this.Text = "Wgrywanie zdarzeń";
					cbCharacteristicPoints.Visible = false;
					cbMatchLines.Visible = false;
					cbFeederr.Visible = false;
				}
                else if (rbTrackObiect.Checked == true)
                {
                    this.Text = "Śledzenie zdarzeń";
					cbCharacteristicPoints.Visible = true;
					cbMatchLines.Visible = true;
					cbFeederr.Visible = false;
				}
                else
                {
                    this.Text = "Wykrywanie zdarzeń";
					cbCharacteristicPoints.Visible = false;
					cbMatchLines.Visible = false;
					cbFeederr.Visible = true;
					progressBar1.Visible = true;
					groupBox2.Visible = true;
				}
				gbCycleMode.Visible = false;
				gbDetectionRegions.Visible = false;
				gbShapeMode.Visible = false;
				btnShapeFeeder.Visible = false;
				groupBox6.Visible = false;
                btnShapeDetection.Visible = false;
                btnStopShapeDetection.Visible = false;
                btnDetectMultiple.Visible = true;
                btnDetectFeature.Visible = true;
                btnStopDetection.Visible = true;

				btnStop_Click(new object(), new EventArgs());
				gbPixelValue.Visible = false;
                groupBox5.Visible = false;
                gbWorkMode.Visible = true;
                lblEv1.Visible = true;
                lblEv2.Visible = true;
                lblEv3.Visible = true;
                cbKP1.Visible = true;
                cbKP2.Visible = true;
                cbKP3.Visible = true;
                ibFeature1.Visible = true;
                ibFeature2.Visible = true;
                ibFeature3.Visible = true;

                groupBox1.Visible = false;
                groupBox2.Visible = false;
                gbFeed.Visible = false;
                ibFeeder.Visible = false;
                btnFeed.Visible = false;
                progressBar1.Visible = false;

                btnSave.Visible = true;
                btnCapture.Visible = true;
                tbFeature1.Visible = true;
                tbFeature2.Visible = true;
                tbFeature3.Visible = true;
                btnLoad1.Visible = true;
                btnLoad2.Visible = true;
                btnLoad3.Visible = true;
				
                lblShape1.Visible = false;
                lblShape2.Visible = false;
                lblShape3.Visible = false;
                lblShape4.Visible = false;
                cBoxShapes1.Visible = false;
                cBoxShapes2.Visible = false;
                cBoxShapes3.Visible = false;
                cBoxShapes4.Visible = false;
                btnSetSize1.Visible = true;
                btnSetSize2.Visible = true;
                btnSetSize3.Visible = true;
                groupBox4.Visible = false;
                btnStop_Click(new object(), new EventArgs());
            }

        }

        private void Frm_RegionSender1(int hHei, int wWei, int xX, int yY)
        {
            event1Coordinates.Name = event1Name;
            event1Coordinates.Hhh = hHei;
            event1Coordinates.Www = wWei;
            event1Coordinates.Xxx = xX;
            event1Coordinates.Yyy = yY;

        }

		private void ibCameraCap_MouseClick(object sender, MouseEventArgs e)
		{
			if (rbCheckPixelValue.Checked && ibCameraCap.Image != null)
			{
				var temp = ibCameraCap.Image;
				Bitmap bmp;
				bmp = temp.Bitmap;
				//ibCameraCap.Image
				var color = bmp.GetPixel(e.X, e.Y);

				lblBlueVal.Text = color.B.ToString();
				lblRedVal.Text = color.R.ToString();
				lblGreenVal.Text = color.G.ToString();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void rbModifiedImage_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void Frm_RegionSender2(int hHei, int wWei, int xX, int yY)
        {
            event2Coordinates.Name = event2Name;
            event2Coordinates.Hhh = hHei;
            event2Coordinates.Www = wWei;
            event2Coordinates.Xxx = xX;
            event2Coordinates.Yyy = yY;
        }

        private void Frm_RegionSender3(int hHei, int wWei, int xX, int yY)
        {
            event3Coordinates.Name = event3Name;
            event3Coordinates.Hhh = hHei;
            event3Coordinates.Www = wWei;
            event3Coordinates.Xxx = xX;
            event3Coordinates.Yyy = yY;
        }
        
        private void Frm_RegionSenderFeed(int hHei, int wWei, int xX, int yY)
        {
            feedCoordinates.Name = "Zdarzenie 1";
            ///położenie niezmienne niezależnie od zdarzenia jakie ma zostać w nim wykryte
            ///
            feedCoordinates.Hhh = hHei;
            feedCoordinates.Www = wWei;
            feedCoordinates.Xxx = xX;
            feedCoordinates.Yyy = yY;
        }

        private Rectangle RetrieveRectangle(SizeAndPosition SAP)
        {
            Point LeftUpper = new Point(SAP.Xxx, SAP.Yyy);
            Rectangle rect = new Rectangle(LeftUpper, new Size(SAP.Www, SAP.Hhh));
            return rect;
        }

        #endregion

        public void PerformSURF_UpdateGUI(object sender, EventArgs e)
        {
            Mat framex1;
            Mat toIBMat;
            framex1 = FramesFromCamera();
            long onlyMatchTime;
            toIBMat = DrawMatches.Draw(event1Mat, framex1, out onlyMatchTime, event1Name, keyPoints, matchLines);
            
            ibCameraCap.Image = toIBMat.ToImage<Bgr, byte>();
        }

        private void btnDetectFeature_Click(object sender, EventArgs e)
        {
            if (grabeInProcess == false && event1Mat != null)
            {
                Application.Idle += new EventHandler(this.PerformSURF_UpdateGUI);
				rbSimple.Enabled = false;
                rbUploadFeature.Enabled = false;
                cbFeederr.Enabled = false;
                grabeInProcess = true;
            }
            else
            {
                MessageBox.Show("Wybierz zdarzenie do wykrycia przed przystąpieniem do wykrywania");
            }
        }
        
        private void btnDetectMultiple_Click(object sender, EventArgs e)
        {
            if(grabeInProcess == false)
            {
                btnStop_Click(new object(), new EventArgs());
				rbSimple.Enabled = false;
                cbFeederr.Enabled = false;
                rbUploadFeature.Enabled = false;
                if (event1Coordinates.Www != 0 && event1Coordinates.Hhh != 0 && (event2Coordinates.Www == 0 || event2Coordinates.Hhh == 0) && (event3Coordinates.Www == 0 || event3Coordinates.Hhh == 0) && cbFeederr.Checked == false)
                {
                    grabeInProcess = true;
                    Application.Idle += new EventHandler(this.PerformSURF_In_ROI);
                }
                else if (event1Coordinates.Www != 0 && event1Coordinates.Hhh != 0 && event2Coordinates.Www != 0 && event2Coordinates.Hhh != 0 && (event3Coordinates.Www == 0 || event3Coordinates.Hhh == 0) && cbFeederr.Checked == false)
                {
                    grabeInProcess = true;
                    Application.Idle += new EventHandler(this.PerformSurfFor2xROI);
                }
                else if (event1Coordinates.Www != 0 && event1Coordinates.Hhh != 0 && event2Coordinates.Www != 0 && event2Coordinates.Hhh != 0 && event3Coordinates.Www != 0 && event3Coordinates.Hhh != 0 && cbFeederr.Checked == false)
                {
                    grabeInProcess = true;
                    Application.Idle += new EventHandler(this.PerformSurfFor3xROI);
                }
                else if(event1Coordinates.Www != 0 && event1Coordinates.Hhh != 0 && event2Coordinates.Www != 0 && event2Coordinates.Hhh != 0 && event3Coordinates.Www != 0 && event3Coordinates.Hhh != 0 && cbFeederr.Checked == true && feedCoordinates.Www != 0 && feedCoordinates.Hhh != 0)
                {
                    if (rbEve1.Checked == false && rbEve2.Checked == false && rbEve3.Checked == false)
                    {
                        MessageBox.Show("Należy wybrać zdarzenie początkowe znajdujące się w dozowniku.");
                    }
                    else
                    {
                        grabeInProcess = true;
                        lblEv1.ForeColor = Color.Red;
                        lblEv1.Text = "Zdarzenie 1: niewykryte";
                        lblEv2.ForeColor = Color.Red;
                        lblEv2.Text = "Zdarzenie 2: niewykryte";
                        lblEv3.ForeColor = Color.Red;
                        lblEv3.Text = "Zdarzenie 3: niewykryte";
                        lblFeedEv1.ForeColor = Color.Red;
                        lblFeedEv1.Text = "Zdarzenie 1: niewykryte";
                        lblFeedEv2.ForeColor = Color.Red;
                        lblFeedEv2.Text = "Zdarzenie 2: niewykryte";
                        lblFeedEv3.ForeColor = Color.Red;
                        lblFeedEv3.Text = "Zdarzenie 3: niewykryte";
                        Application.Idle += new EventHandler(this.PerformSurfFor3xROIndFeeder);
                    }
                }
                else
                {
                    if(cbFeederr.Checked) MessageBox.Show("Żeby korzystać z opcji dozownika należy zadeklarować 3 podobszary zdarzeń.");
                    else MessageBox.Show("Przed wykrywaniem zdarzenia należy określić przynajmniej jeden podobszar wewnątrz którego ma ono zachodzić.");
                }
            }
            
        }

        private void btnStopDetection_Click(object sender, EventArgs e)
        {
            if (grabeInProcess == true)
            {
                if (cbFeederr.Checked == true)
                {
                    int pbVal = (int)progressBar1.Value;
                    int pbMax = (int)progressBar1.Maximum;
					rbSimple.Enabled = true;
                    MessageBox.Show($"Zostało wykryte {pbVal} zdarzeń z {pbMax} możliwych zdarzeń.");
                    //komunikat ile zdarzen w dozowniku zostało wykrytych i ile w ROI, ile powinno zostać wykrytych, czy zostały wykryte wszystkie, których konkretnie brakuje
                }

                ev1Detected = false;
                ev2Detected = false;
                ev3Detected = false;
                ev1Fed = false;
                ev2Fed = false;
                ev3Fed = false;
                ev1Exist = false;
                ev2Exist = false;
                ev3Exist = false;

                rbUploadFeature.Enabled = true;
                Application.Idle -= new EventHandler(this.PerformSURF_UpdateGUI);
                Application.Idle -= new EventHandler(this.PerformSURF_In_ROI);
                Application.Idle -= new EventHandler(this.PerformSurfFor2xROI);
                Application.Idle -= new EventHandler(this.PerformSurfFor3xROI);
                Application.Idle -= new EventHandler(this.PerformSurfFor3xROIndFeeder);
				rbSimple.Enabled = true;
                grabeInProcess = false;
                cbFeederr.Enabled = true;
            }
        }

        #region DetectingInsideRois



        ////////////////////////////ROI*1
        private void DetectEventInROI(VectorOfKeyPoint featureVkp, UMat uDescOfFeature)
        {
            Mat framex1;
            Mat mask;

            VectorOfKeyPoint sceneVector1 = new VectorOfKeyPoint();
            UMat sceneDescriptors1 = new UMat();
            VectorOfVectorOfDMatch ROIMatch;
            int nonZeroCount;

            framex1 = FramesFromCamera();
            ROI1 = RetrieveRectangle(event1Coordinates);
            Mat crop1 = new Mat(framex1, ROI1);
            SURF ROItest = new SURF(hessianThresh);
            ROItest.DetectAndCompute(crop1, null, sceneVector1, sceneDescriptors1, false);
            
            ROIMatch = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature, sceneDescriptors1);
            mask = new Mat(ROIMatch.Size, 1, DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(255));
            Features2DToolbox.VoteForUniqueness(ROIMatch, 0.8, mask);

            nonZeroCount = CvInvoke.CountNonZero(mask);
            if (nonZeroCount >= 20)
            {
                nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(featureVkp, sceneVector1,
                   ROIMatch, mask, 1.5, 20);
            }
            ///rysowanie
            ///

            CvInvoke.Rectangle(framex1, ROI1, new MCvScalar(255, 0, 0), 2);
            if (nonZeroCount >= 20)
            {
                CvInvoke.PutText(framex1, "Znalezione zdarzenie: " + event1Name, new Point(event1Coordinates.Xxx, event1Coordinates.Yyy+10), FontFace.HersheyComplex, 1, eventFoundColor);
            }

            ibCameraCap.Image = framex1.ToImage<Bgr, byte>();

        }
        
        public void PerformSURF_In_ROI(object sender, EventArgs e)
        {
            DetectEventInROI(event1Vector, model1_Descriptors);
        }

		/////////////////////////////////
		/////////////////////////////////ROI*2
		private void DetectEventIn2ROI(VectorOfKeyPoint featureVkp, UMat uDescOfFeature, VectorOfKeyPoint featureVkp2, UMat uDescOfFeature2)
		{
			progressBar1.Maximum = 2;
			Mat frameX1;
			Mat mask1;
			Mat mask2;

			VectorOfKeyPoint sceneVector1 = new VectorOfKeyPoint();
			UMat sceneDescriptors1 = new UMat();
			VectorOfVectorOfDMatch ROI1Match;

			VectorOfKeyPoint sceneVector2 = new VectorOfKeyPoint();
			UMat sceneDescriptors2 = new UMat();
			VectorOfVectorOfDMatch ROI2Match;
			int nonZeroCount1;
			int nonZeroCount2;

			frameX1 = FramesFromCamera();
			ROI1 = RetrieveRectangle(event1Coordinates);
			ROI2 = RetrieveRectangle(event2Coordinates);
			Mat crop1 = new Mat(frameX1, ROI1);
			Mat crop2 = new Mat(frameX1, ROI2);

			SURF ROI2test = new SURF(hessianThresh);
			ROI2test.DetectAndCompute(crop1, null, sceneVector1, sceneDescriptors1, false);
			ROI2test.DetectAndCompute(crop2, null, sceneVector2, sceneDescriptors2, false);

			ROI1Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature, sceneDescriptors1);
			mask1 = new Mat(ROI1Match.Size, 1, DepthType.Cv8U, 1);
			mask1.SetTo(new MCvScalar(255));

			ROI2Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature2, sceneDescriptors2);
			mask2 = new Mat(ROI2Match.Size, 1, DepthType.Cv8U, 1);
			mask2.SetTo(new MCvScalar(255));

			Features2DToolbox.VoteForUniqueness(ROI1Match, 0.8, mask1);
			nonZeroCount1 = CvInvoke.CountNonZero(mask1);
			if (nonZeroCount1 >= 20)
			{
				nonZeroCount1 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp, sceneVector1,
				   ROI1Match, mask1, 1.5, 20);
			}

			Features2DToolbox.VoteForUniqueness(ROI2Match, 0.8, mask2);
			nonZeroCount2 = CvInvoke.CountNonZero(mask2);
			if (nonZeroCount2 >= 20)
			{
				nonZeroCount2 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp2, sceneVector2,
				   ROI2Match, mask2, 1.5, 20);
			}

			CvInvoke.Rectangle(frameX1, ROI1, new MCvScalar(255, 0, 0), 2);
			CvInvoke.Rectangle(frameX1, ROI2, new MCvScalar(255, 0, 0), 2);

			if (nonZeroCount1 >= 20)
			{
				CvInvoke.PutText(frameX1, "Znalezione zdarzenie: " + event1Name, new Point(event1Coordinates.Xxx, event1Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.6, eventFoundColor);
				ev1Detected = true;
			}
			else ev2Detected = false;
			if (nonZeroCount2 >= 20)
			{
				CvInvoke.PutText(frameX1, "Znalezione zdarzenie: " + event2Name, new Point(event2Coordinates.Xxx, event2Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.6, eventFoundColor);
				ev2Detected = true;
			}
			else ev2Detected = false;

			if (ev1Detected == true && ev2Detected == true)
			{
				progressBar1.Value = 2;
				lblEv1.ForeColor = Color.Green;
				lblEv1.Text = "Zdarzenie 1: wykryte";
				lblEv2.ForeColor = Color.Red;
				lblEv2.Text = "Zdarzenie 2: wykryte";
			}
			else if (ev1Detected == true && ev2Detected == false)
			{
				progressBar1.Value = 1;
				lblEv1.ForeColor = Color.Green;
				lblEv1.Text = "Zdarzenie 1: wykryte";
				lblEv2.ForeColor = Color.Red;
				lblEv2.Text = "Zdarzenie 2: niewykryte";
			}
			else if (ev1Detected == false && ev2Detected == true)
			{
				progressBar1.Value = 1;
				lblEv1.ForeColor = Color.Red;
				lblEv1.Text = "Zdarzenie 1: niewykryte";
				lblEv2.ForeColor = Color.Green;
				lblEv2.Text = "Zdarzenie 2: wykryte";
			}
			else if (ev1Detected == false && ev2Detected == false)
			{
				progressBar1.Value = 0;
				lblEv1.ForeColor = Color.Red;
				lblEv1.Text = "Zdarzenie 1: niewykryte";
				lblEv2.ForeColor = Color.Red;
				lblEv2.Text = "Zdarzenie 2: niewykryte";
			}

			ibCameraCap.Image = frameX1.ToImage<Bgr, byte>();
		}

		public void PerformSurfFor2xROI(object sender, EventArgs e)
		{
			lblEv3.ForeColor = Color.Red;
			lblEv3.Text = "Zdarzenie 3: niedostarczone";
			DetectEventIn2ROI(event1Vector, model1_Descriptors, event2Vector, model2_Descriptors);
		}

		/////////////////////////////////
		////////////////////////////////////
		///ROI*3
		////////////////////////////////////
		///


		private void DetectEventIn3_ROI(VectorOfKeyPoint featureVkp, UMat uDescOfFeature, VectorOfKeyPoint featureVkp2, UMat uDescOfFeature2,
            VectorOfKeyPoint featureVkp3, UMat uDescOfFeature3)
        {
            progressBar1.Maximum = 3;
            Mat frameX1;
            Mat mask1;
            Mat mask2;
            Mat mask3;

            VectorOfKeyPoint sceneVector1 = new VectorOfKeyPoint();
            UMat sceneDescriptors1 = new UMat();
            VectorOfVectorOfDMatch ROI1Match;

            VectorOfKeyPoint sceneVector2 = new VectorOfKeyPoint();
            UMat sceneDescriptors2 = new UMat();
            VectorOfVectorOfDMatch ROI2Match;

            VectorOfKeyPoint sceneVector3 = new VectorOfKeyPoint();
            UMat sceneDescriptors3 = new UMat();
            VectorOfVectorOfDMatch ROI3Match;

            int nonZeroCount1, nonZeroCount2, nonZeroCount3;
            int nonZeroThresh = 20;

            frameX1 = FramesFromCamera();
            ROI1 = RetrieveRectangle(event1Coordinates);
            ROI2 = RetrieveRectangle(event2Coordinates);
            ROI3 = RetrieveRectangle(event3Coordinates);
            Mat crop1 = new Mat(frameX1, ROI1);
            Mat crop2 = new Mat(frameX1, ROI2);
            Mat crop3 = new Mat(frameX1, ROI3);

            SURF ROI3test = new SURF(hessianThresh);
            ROI3test.DetectAndCompute(crop1, null, sceneVector1, sceneDescriptors1, false);
            ROI3test.DetectAndCompute(crop2, null, sceneVector2, sceneDescriptors2, false);
            ROI3test.DetectAndCompute(crop3, null, sceneVector3, sceneDescriptors3, false);

            ROI1Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature, sceneDescriptors1);
            mask1 = new Mat(ROI1Match.Size, 1, DepthType.Cv8U, 1);
            mask1.SetTo(new MCvScalar(255));

            ROI2Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature2, sceneDescriptors2);
            mask2 = new Mat(ROI2Match.Size, 1, DepthType.Cv8U, 1);
            mask2.SetTo(new MCvScalar(255));

            ROI3Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature3, sceneDescriptors3);
            mask3 = new Mat(ROI3Match.Size, 1, DepthType.Cv8U, 1);
            mask3.SetTo(new MCvScalar(255));

            Features2DToolbox.VoteForUniqueness(ROI1Match, 0.8, mask1);
            nonZeroCount1 = CvInvoke.CountNonZero(mask1);
            if (nonZeroCount1 >= nonZeroThresh)
            {
                nonZeroCount1 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp, sceneVector1,
                   ROI1Match, mask1, 1.5, 20);
            }

            Features2DToolbox.VoteForUniqueness(ROI2Match, 0.8, mask2);
            nonZeroCount2 = CvInvoke.CountNonZero(mask2);
            if (nonZeroCount2 >= nonZeroThresh)
            {
                nonZeroCount2 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp2, sceneVector2,
                   ROI2Match, mask2, 1.5, 20);
            }

            Features2DToolbox.VoteForUniqueness(ROI3Match, 0.8, mask3);
            nonZeroCount3 = CvInvoke.CountNonZero(mask3);
            if (nonZeroCount3 >= nonZeroThresh)
            {
                nonZeroCount3 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp3, sceneVector3,
                   ROI3Match, mask3, 1.5, 20);
            }

            CvInvoke.Rectangle(frameX1, ROI1, new MCvScalar(255, 0, 0), 2);
            CvInvoke.Rectangle(frameX1, ROI2, new MCvScalar(255, 0, 0), 2);
            CvInvoke.Rectangle(frameX1, ROI3, new MCvScalar(255, 0, 0), 2);

            if (nonZeroCount1 >= 20)
            {
                CvInvoke.PutText(frameX1, event1Name + ":znaleziono.", new Point(event1Coordinates.Xxx, event1Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.8, eventFoundColor);
                ev1Detected = true;
            }
            else
            {
                CvInvoke.PutText(frameX1, event1Name + ":nie znaleziono.", new Point(event1Coordinates.Xxx, event1Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.8, eventNotFoundColor);
                ev1Detected = false;
            }

            if (nonZeroCount2 >= 20)
            {
                CvInvoke.PutText(frameX1, event2Name +":znaleziono.", new Point(event2Coordinates.Xxx, event2Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.8, eventFoundColor);
                ev2Detected = true;
            }
            else
            {
                CvInvoke.PutText(frameX1, event2Name + ":nie znaleziono.", new Point(event2Coordinates.Xxx, event2Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.8, eventNotFoundColor);
                ev2Detected = false;
            }

            if (nonZeroCount3 >= 20)
            {
                CvInvoke.PutText(frameX1, event3Name + ":znaleziono.", new Point(event3Coordinates.Xxx, event3Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.8, eventFoundColor);
                ev3Detected = true;
            }
            else
            {
                CvInvoke.PutText(frameX1, event3Name + ":nie znaleziono.", new Point(event3Coordinates.Xxx, event3Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.8, eventNotFoundColor);
                ev3Detected = false;
            }
            //progressBar, ilość wykrytych zdarzeń
            if(ev1Detected==false && ev2Detected==false && ev3Detected == false)
            {
                progressBar1.Value = 0;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if(ev1Detected==true && ev2Detected==false && ev3Detected == false)
            {
                progressBar1.Value = 1;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == false && ev2Detected == true && ev3Detected == false)
            {
                progressBar1.Value = 1;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == false && ev2Detected == false && ev3Detected == true)
            {
                progressBar1.Value = 1;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            else if (ev1Detected == true && ev2Detected == true && ev3Detected == false)
            {
                progressBar1.Value = 2;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == false && ev2Detected == true && ev3Detected == true)
            {
                progressBar1.Value = 2;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            else if (ev1Detected == true && ev2Detected == false && ev3Detected == true)
            {
                progressBar1.Value = 2;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            else
            {
                progressBar1.Value = 3;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            
            ibCameraCap.Image = frameX1.ToImage<Bgr, byte>();
        }

        public void PerformSurfFor3xROI(object sender, EventArgs e)
        {
            DetectEventIn3_ROI(event1Vector, model1_Descriptors, event2Vector, model2_Descriptors, event3Vector, model3_Descriptors);
        }

        //////////////////////////////////////////////////////////////////////////
        ///////////////3ROI i dozownik///////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        private void DetectEventIn3_ROI_and_Feed(VectorOfKeyPoint featureVkp, UMat uDescOfFeature, VectorOfKeyPoint featureVkp2, UMat uDescOfFeature2,
            VectorOfKeyPoint featureVkp3, UMat uDescOfFeature3, byte toBeFoundInFeeder)
        {
            Mat frameX1;
            Mat mask1, mask2, mask3, maskFeed;
            int nonZeroCount1, nonZeroCount2, nonZeroCount3, nonZeroCountFeed;
            int nonZeroThresh = 20;

            VectorOfKeyPoint sceneVector1 = new VectorOfKeyPoint();
            UMat sceneDescriptors1 = new UMat();

            VectorOfKeyPoint sceneVector2 = new VectorOfKeyPoint();
            UMat sceneDescriptors2 = new UMat();

            VectorOfKeyPoint sceneVector3 = new VectorOfKeyPoint();
            UMat sceneDescriptors3 = new UMat();

            VectorOfKeyPoint feedVector = new VectorOfKeyPoint();
            VectorOfKeyPoint toBeFoundInFeedVector = new VectorOfKeyPoint();
            UMat feedDescriptors = new UMat();
            UMat toBeFoundInFeedDescriptor = new UMat();
            ///odczytanie które zdarzenie ma być wykryte wewnątrz dozownika i przypisanie odpowiedniego wektora punktów kluczowych i deskryptora.
            if (ev1Exist && ev2Exist && ev3Exist) progressBar1.Maximum = 6;
            else if (ev1Exist && ev2Exist && !ev3Exist) progressBar1.Maximum = 5;
            else if (ev1Exist && !ev2Exist && ev3Exist) progressBar1.Maximum = 5;
            else if (!ev1Exist && ev2Exist && ev3Exist) progressBar1.Maximum = 5;
            else if (ev1Exist && !ev2Exist && !ev3Exist) progressBar1.Maximum = 4;
            else if (!ev1Exist && ev2Exist && !ev3Exist) progressBar1.Maximum = 4;
            else if (!ev1Exist && !ev2Exist && ev3Exist) progressBar1.Maximum = 4;
            else progressBar1.Maximum = 4;
            
            if (toBeFoundInFeeder == 1)
            {
                toBeFoundInFeedVector = featureVkp;
                toBeFoundInFeedDescriptor = uDescOfFeature;
                feedCoordinates.Name = event1Name;
            } else if(toBeFoundInFeeder == 2)
            {
                toBeFoundInFeedVector = featureVkp2;
                toBeFoundInFeedDescriptor = uDescOfFeature2;
                feedCoordinates.Name = event2Name;
            } else if(toBeFoundInFeeder == 3)
            {
                toBeFoundInFeedVector = featureVkp3;
                toBeFoundInFeedDescriptor = uDescOfFeature3;
                feedCoordinates.Name = event3Name;
            }

            VectorOfVectorOfDMatch ROI1Match, ROI2Match, ROI3Match, ROIFeedMatch;

            frameX1 = FramesFromCamera();
            ROI1 = RetrieveRectangle(event1Coordinates);
            ROI2 = RetrieveRectangle(event2Coordinates);
            ROI3 = RetrieveRectangle(event3Coordinates);
            ROIfeed = RetrieveRectangle(feedCoordinates);

            Mat crop1 = new Mat(frameX1, ROI1);
            Mat crop2 = new Mat(frameX1, ROI2);
            Mat crop3 = new Mat(frameX1, ROI3);
            Mat cropFeed = new Mat(frameX1, ROIfeed);

            SURF ROIx3ndFeed = new SURF(hessianThresh);
            ROIx3ndFeed.DetectAndCompute(crop1, null, sceneVector1, sceneDescriptors1, false);
            ROIx3ndFeed.DetectAndCompute(crop2, null, sceneVector2, sceneDescriptors2, false);
            ROIx3ndFeed.DetectAndCompute(crop3, null, sceneVector3, sceneDescriptors3, false);
            ROIx3ndFeed.DetectAndCompute(cropFeed, null, feedVector, feedDescriptors, false);

            ROI1Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature, sceneDescriptors1);
            mask1 = new Mat(ROI1Match.Size, 1, DepthType.Cv8U, 1);
            mask1.SetTo(new MCvScalar(255));

            ROI2Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature2, sceneDescriptors2);
            mask2 = new Mat(ROI2Match.Size, 1, DepthType.Cv8U, 1);
            mask2.SetTo(new MCvScalar(255));

            ROI3Match = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(uDescOfFeature3, sceneDescriptors3);
            mask3 = new Mat(ROI3Match.Size, 1, DepthType.Cv8U, 1);
            mask3.SetTo(new MCvScalar(255));
            
            ROIFeedMatch = DrawMatchesFromData.ComputeVectorOfVectorOfMatches(toBeFoundInFeedDescriptor, feedDescriptors);
            maskFeed = new Mat(ROIFeedMatch.Size, 1, DepthType.Cv8U, 1);
            mask3.SetTo(new MCvScalar(255));

            Features2DToolbox.VoteForUniqueness(ROI1Match, 0.8, mask1);
            nonZeroCount1 = CvInvoke.CountNonZero(mask1);
            if (nonZeroCount1 >= nonZeroThresh)
            {
                nonZeroCount1 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp, sceneVector1,
                   ROI1Match, mask1, 1.5, 20);
            }

            Features2DToolbox.VoteForUniqueness(ROI2Match, 0.8, mask2);
            nonZeroCount2 = CvInvoke.CountNonZero(mask2);
            if (nonZeroCount2 >= nonZeroThresh)
            {
                nonZeroCount2 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp2, sceneVector2,
                   ROI2Match, mask2, 1.5, 20);
            }

            Features2DToolbox.VoteForUniqueness(ROI3Match, 0.8, mask3);
            nonZeroCount3 = CvInvoke.CountNonZero(mask3);
            if (nonZeroCount3 >= nonZeroThresh)
            {
                nonZeroCount3 = Features2DToolbox.VoteForSizeAndOrientation(featureVkp3, sceneVector3,
                   ROI3Match, mask3, 1.5, 20);
            }

            Features2DToolbox.VoteForUniqueness(ROIFeedMatch, 0.8, maskFeed);
            nonZeroCountFeed = CvInvoke.CountNonZero(maskFeed);
            if (nonZeroCountFeed >= nonZeroThresh)
            {
                nonZeroCountFeed = Features2DToolbox.VoteForSizeAndOrientation(toBeFoundInFeedVector, feedVector,
                   ROIFeedMatch, maskFeed, 1.5, 20);
            }

            CvInvoke.Rectangle(frameX1, ROI1, new MCvScalar(255, 0, 0), 2);
            CvInvoke.Rectangle(frameX1, ROI2, new MCvScalar(255, 0, 0), 2);
            CvInvoke.Rectangle(frameX1, ROI3, new MCvScalar(255, 0, 0), 2);
            CvInvoke.Rectangle(frameX1, ROIfeed, new MCvScalar(255, 0, 0), 2);

            if (nonZeroCount1 >= nonZeroThresh)
            {
                CvInvoke.PutText(frameX1, event1Name + ":znaleziono.", new Point(event1Coordinates.Xxx, event1Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventFoundColor);
                ev1Detected = true;
            }
            else
            {
                CvInvoke.PutText(frameX1, event1Name + ":nie znaleziono.", new Point(event1Coordinates.Xxx, event1Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventNotFoundColor);
                ev1Detected = false;
            }

            if (nonZeroCount2 >= nonZeroThresh)
            {
                CvInvoke.PutText(frameX1, event2Name + ":znaleziono.", new Point(event2Coordinates.Xxx, event2Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventFoundColor);
                ev2Detected = true;
            }
            else
            {
                CvInvoke.PutText(frameX1, event2Name + ":nie znaleziono.", new Point(event2Coordinates.Xxx, event2Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventNotFoundColor);
                ev2Detected = false;
            }

            if (nonZeroCount3 >= nonZeroThresh)
            {
                CvInvoke.PutText(frameX1, event3Name + ":znaleziono.", new Point(event3Coordinates.Xxx, event3Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventFoundColor);
                ev3Detected = true;
            }
            else
            {
                CvInvoke.PutText(frameX1, event3Name + ":nie znaleziono.", new Point(event3Coordinates.Xxx, event3Coordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventNotFoundColor);
                ev3Detected = false;
            }

            if (nonZeroCountFeed >= nonZeroThresh)
            {
                //wystarczy jednokrotne wykrycie danego typu zdarzenia w dozowniku żeby uznać cel za osiągnięty
                if (toBeFoundInFeeder == 1)
                {
                    CvInvoke.PutText(frameX1,"Zdarzenie w dozowniku: "+ feedCoordinates.Name + ":", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventFoundColor);
                    CvInvoke.PutText(frameX1, "widziane.", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 14), FontFace.HersheyComplex, 0.5, eventFoundColor);
                    ev1Fed = true;
                }
                else if (toBeFoundInFeeder == 2)
                {
                    CvInvoke.PutText(frameX1, "Zdarzenie w dozowniku: " + feedCoordinates.Name + ":", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventFoundColor);
                    CvInvoke.PutText(frameX1, "widziane.", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 14), FontFace.HersheyComplex, 0.5, eventFoundColor);
                    ev2Fed = true;
                }
                else if (toBeFoundInFeeder == 3)
                {
                    CvInvoke.PutText(frameX1, "Zdarzenie w dozowniku: " + feedCoordinates.Name + "", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventFoundColor);
                    CvInvoke.PutText(frameX1, "widziane.", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 14), FontFace.HersheyComplex, 0.5, eventFoundColor);
                    ev3Fed = true;
                }
            }
            else
            {
                CvInvoke.PutText(frameX1, "Zdarzenie w dozowniku: " + feedCoordinates.Name +":", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 5), FontFace.HersheyComplex, 0.5, eventNotFoundColor);
                CvInvoke.PutText(frameX1, "nie widziane.", new Point(feedCoordinates.Xxx, feedCoordinates.Yyy + 14), FontFace.HersheyComplex, 0.5, eventNotFoundColor);
            }
            //progressBar, ilość wykrytych zdarzeń
            int fedAmount = 0;
            if (ev1Fed)
            {
                fedAmount++;
                lblFeedEv1.ForeColor = Color.Green;
                lblFeedEv1.Text = "Zdarzenie 1: wykryte";
            } 
            if (ev2Fed)
            {
                fedAmount++;
                lblFeedEv2.ForeColor = Color.Green;
                lblFeedEv2.Text = "Zdarzenie 2: wykryte";
            }
            if (ev3Fed)
            {
                fedAmount++;
                lblFeedEv3.ForeColor = Color.Green;
                lblFeedEv3.Text = "Zdarzenie 3: wykryte";
            }

            if (ev1Detected == false && ev2Detected == false && ev3Detected == false)
            {
                progressBar1.Value = 0+fedAmount;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == true && ev2Detected == false && ev3Detected == false)
            {
                progressBar1.Value = 1+fedAmount;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == false && ev2Detected == true && ev3Detected == false)
            {
                progressBar1.Value = 1+fedAmount;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == false && ev2Detected == false && ev3Detected == true)
            {
                progressBar1.Value = 1+fedAmount;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            else if (ev1Detected == true && ev2Detected == true && ev3Detected == false)
            {
                progressBar1.Value = 2+fedAmount;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Red;
                lblEv3.Text = "Zdarzenie 3: niewykryte";
            }
            else if (ev1Detected == false && ev2Detected == true && ev3Detected == true)
            {
                progressBar1.Value = 2+fedAmount;
                lblEv1.ForeColor = Color.Red;
                lblEv1.Text = "Zdarzenie 1: niewykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            else if (ev1Detected == true && ev2Detected == false && ev3Detected == true)
            {
                progressBar1.Value = 2+fedAmount;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Red;
                lblEv2.Text = "Zdarzenie 2: niewykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }
            else
            {
                progressBar1.Value = 3+fedAmount;
                lblEv1.ForeColor = Color.Green;
                lblEv1.Text = "Zdarzenie 1: wykryte";
                lblEv2.ForeColor = Color.Green;
                lblEv2.Text = "Zdarzenie 2: wykryte";
                lblEv3.ForeColor = Color.Green;
                lblEv3.Text = "Zdarzenie 3: wykryte";
            }

            ibCameraCap.Image = frameX1.ToImage<Bgr, byte>();
        }

        public void PerformSurfFor3xROIndFeeder(object sender, EventArgs e)
        {
            DetectEventIn3_ROI_and_Feed(event1Vector, model1_Descriptors, event2Vector, model2_Descriptors, event3Vector, model3_Descriptors, eventInFeeder);
        }

        #endregion

        private void rbTrackObiect_CheckedChanged(object sender, EventArgs e)
        {
            btnDetectFeature.Enabled = true;
            btnStopDetection.Enabled = true;
            btnDetectMultiple.Enabled = false;

            btnCapture.Enabled = false;
            btnStartCapture.Enabled = false;
            btnStop.Enabled = false;
            btnClear.Enabled = false;
            btnSave.Enabled = false;

            cbCharacteristicPoints.Checked = false;
            cbCharacteristicPoints.Checked = false;
            cbCharacteristicPoints.Visible = true;
            cbMatchLines.Visible = true;
            this.Text = "Śledzenie zdarzeń";
            btnStop_Click(new object(), new EventArgs());
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            progressBar1.Visible = false;
            cbFeederr.Visible = false;
        }

        private void rbDetectInRois_CheckedChanged(object sender, EventArgs e)
        {
            btnDetectMultiple.Enabled = true;
            btnDetectFeature.Enabled = false;
            btnStopDetection.Enabled = true;

            btnCapture.Enabled = false;
            btnStartCapture.Enabled = false;
            btnStop.Enabled = false;
            btnClear.Enabled = false;
            btnSave.Enabled = false;

            cbCharacteristicPoints.Visible = false;
            cbMatchLines.Visible = false;
            cbCharacteristicPoints.Checked = false;
            cbCharacteristicPoints.Checked = false;
            this.Text = "Wykrywanie zdarzeń";
            btnStop_Click(new object(), new EventArgs());
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            progressBar1.Visible = true;
            cbFeederr.Checked = false;
            cbFeederr.Visible = true;
        }

        private void rbUploadFeature_CheckedChanged(object sender, EventArgs e)
        {
            btnCapture.Enabled = false;
            btnStartCapture.Enabled = true;
            btnStop.Enabled = false;
            btnClear.Enabled = true;
            btnSave.Enabled = false;

            btnDetectFeature.Enabled = false;
            btnDetectMultiple.Enabled = false ;
            btnStopDetection.Enabled = false;

            cbCharacteristicPoints.Visible = false;
            cbMatchLines.Visible = false;
            cbCharacteristicPoints.Checked = false;
            cbCharacteristicPoints.Checked = false;
            this.Text = "Wgrywanie zdarzeń";

            groupBox2.Visible = false;
            groupBox1.Visible = false;
            progressBar1.Visible = false;
            cbFeederr.Visible = false;
        }

        private void rbEve1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEve1.Checked == true)
            {
                ibFeeder.Image = event1Mat.ToImage<Bgr, byte>();
                eventInFeeder = 1;
                if (!ev1Exist)
                {
                    ev1Exist = true;
                }
            }
            if (rbEve1.Checked == false && rbEve3.Checked==true && event3Mat == null)
            {
                rbEve1.Checked = true;
                MessageBox.Show("Należy wgrać zdarzenie numer 3");
            }
            else if(rbEve1.Checked == false && rbEve2.Checked == true && event2Mat == null)
            {
                rbEve1.Checked = true;
                MessageBox.Show("Należy wgrać zdarzenie numer 2");
            }
        }

        private void rbEve2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEve2.Checked == true && event2Mat != null)
            {
                ibFeeder.Image = event2Mat.ToImage<Bgr, byte>();
                eventInFeeder = 2;
                if (!ev2Exist)
                {
                    ev2Exist = true;
                }
            }
            if (rbEve2.Checked == false && rbEve3.Checked == true && event3Mat == null)
            {
                rbEve2.Checked = true;
                MessageBox.Show("Należy wgrać zdarzenie numer 3");
            }
        }

        private void rbEve3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEve3.Checked == true && event3Mat != null)
            {
                ibFeeder.Image = event3Mat.ToImage<Bgr, byte>();
                eventInFeeder = 3;
                if (!ev3Exist)
                {
                    ev3Exist = true;
                }
            } 
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////Komunikacja telnet obsługa////////////////////////////////////////////////////////////
        #region Komunikacja
        bool one, two, three;
        TcpClient clientSocket;
        NetworkStream serverStream = default(NetworkStream);
        string readdata = null;
        bool isConnected;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                clientSocket = new TcpClient();
                clientSocket.Connect(txtHostName.Text, Int32.Parse(txtPort.Text));
                isConnected = clientSocket.Connected;
                if (isConnected)
                {
					btnSend.Enabled = true;
					btnHold.Enabled = true;
					btnContinue.Enabled = true;
                    lblStatus.Text = "Połączono";
                    lblStatus.ForeColor = Color.Green;
                    Thread ctThread = new Thread(getMessage);
                    one = true;
                    ctThread.Start();
                }
            }
        }



        private void getMessage()
        {
            string returndata;
            while (isConnected)
            {
                serverStream = clientSocket.GetStream();
                var buffsize = clientSocket.ReceiveBufferSize;
                byte[] instream = new byte[buffsize];
                serverStream.Read(instream, 0, buffsize);
                if (instream[0] != 255)
                {
                    returndata = Encoding.ASCII.GetString(instream);

                    readdata = returndata;
                    msg();
                }

                if (three)
                {
                    Negotiations_Stage3(new object(), new EventArgs());
                    three = false;
                }
                if (two)
                {
                    Negotiations_Stage2(new object(), new EventArgs());
                    two = false;
                    three = true;
                }
                if (one)
                {
                    Negotiations_Stage1(new object(), new EventArgs());
                    two = true;
                    one = false;
                }
                if (isConnected == false)
                {
                    clientSocket.Close();
                    break;
                }
            }
        }

        private void msg()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                if (readdata != "")
                {
                    txtOutcome.Text += readdata;
					if (readdata.Contains("Ksztalt 1 status"))
					{
						deliveryOnTrack = false;
						if (shape1Found)
						{
							if (lblError.Text.Contains("numer 1"))
							{
								lblError.Visible = false;
							}
							txtSend.Text = "1";
							btnSend_Click(new object(), new EventArgs());
						}
						else
						{
							lblError.Text = "Błąd dostawy elementu numer 1";
							lblError.Visible = true;
							txtSend.Text = "0";
							btnSend_Click(new object(), new EventArgs());
							shape1FeedFound = false;
						}
					}
					else if(readdata.Contains("Ksztalt 2 status"))
					{
						deliveryOnTrack = false;
						if (shape2Found)
						{
							if (lblError.Text.Contains("numer 2"))
							{
								lblError.Visible = false;
							}
							txtSend.Text = "1";
							btnSend_Click(new object(), new EventArgs());
						}
						else
						{
							lblError.Text = "Błąd dostawy elementu numer 2";
							lblError.Visible = true;
							txtSend.Text = "0";
							btnSend_Click(new object(), new EventArgs());
							shape2FeedFound = false;
						}
					}
					else if (readdata.Contains("Ksztalt 3 status"))
					{
						deliveryOnTrack = false;
						if (shape3Found) //blad zly ksztalt byl sprawdzany :(
						{
							if (lblError.Text.Contains("numer 3"))
							{
								lblError.Visible = false;
							}
							txtSend.Text = "1";
							btnSend_Click(new object(), new EventArgs());
						}
						else
						{
							lblError.Text = "Błąd dostawy elementu numer 3";
							lblError.Visible = true;
							txtSend.Text = "0";
							btnSend_Click(new object(), new EventArgs());
							shape3FeedFound = false;
						}
					}
					else if (readdata.Contains("Ksztalt 4 status"))
					{
						deliveryOnTrack = false;
						if (shape4Found)
						{
							if(lblError.Text.Contains("numer 4"))
							{
								lblError.Visible = false;
							}
							txtSend.Text = "1";
							btnSend_Click(new object(), new EventArgs());
						}
						else
						{
							lblError.Text = "Błąd dostawy elementu numer 4";
							lblError.Visible = true;
							txtSend.Text = "0";
							btnSend_Click(new object(), new EventArgs());
							shape4FeedFound = false;
						}
					}
					txtOutcome.SelectionStart = txtOutcome.Text.Length;
                    txtOutcome.ScrollToCaret();
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            isConnected = false;
            lblStatus.Text = "Nie połączono";
            lblStatus.ForeColor = Color.Red;
			btnSend.Enabled = false;
			btnHold.Enabled = false;
			btnContinue.Enabled = false;
			//clientSocket.Close();
		}

        private void btnSend_Click(object sender, EventArgs e)
        {
            string komendaPlusEnter = SendMsg(txtSend.Text);
            byte[] outstream = Encoding.ASCII.GetBytes(komendaPlusEnter);
            //txtOutcome.Text += txtSend.Text;
            txtOutcome.SelectionStart = txtOutcome.Text.Length;
            txtOutcome.ScrollToCaret();
            serverStream.Write(outstream, 0, outstream.Length);

            serverStream.Flush();
            txtSend.Clear();
        }

        public string SendMsg(string cmd)
        {
            string zEnterem;
            zEnterem = cmd + "\r\n";

            return zEnterem;
        }

		private void btnContinue_Click(object sender, EventArgs e)
		{
			txtSend.Text = "continue";
			btnSend_Click(new object(), new EventArgs());
		}

		private void btnHold_Click(object sender, EventArgs e)
		{
			txtSend.Text = "hold";
			btnSend_Click(new object(), new EventArgs());
		}

		private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnSend_Click(new object(), new EventArgs());
            }
        }

        private void Negotiations_Stage1(object sender, EventArgs e)
        {
            byte[] kek = { 255, 254, 1, 255, 252, 24 };
            clientSocket.GetStream().Write(kek, 0, 6);
            //serverStream.Write(kek, 0, 3);
            serverStream.Flush();
        }

        private void Negotiations_Stage2(object sender, EventArgs e)
        {
            byte[] kek = { 255, 254, 1 };
            clientSocket.GetStream().Write(kek, 0, 3);
            //serverStream.Write(kek, 0, 3);
            serverStream.Flush();
        }

        private void Negotiations_Stage3(object sender, EventArgs e)
        {
            byte[] kek = { 255, 250, 24, 0, 86, 84, 50, 50, 48, 255, 240 };
            clientSocket.GetStream().Write(kek, 0, kek.Length);
            //serverStream.Write(kek, 0, 3);
            serverStream.Flush();
        }

        #endregion
        /// ////////////////////////////////////////////////////////////////////////////////

        public void ShapeDetection(object sender, EventArgs e)
        {
            Mat framex1;
            Mat grayModifiedMat;
            framex1 = FramesFromCamera();
            Image<Bgr, byte> orginalImage = framex1.ToImage<Bgr, byte>();
            string currentShape = "Ksztalt 1";

            var modifiedImage = orginalImage.Copy();
            modifiedImage = modifiedImage.PyrDown().PyrUp();
            modifiedImage._SmoothGaussian(3);
            Image<Gray, byte> tempGrayImage = modifiedImage.InRange(new Bgr(blueMin, greenMin, redMin), new Bgr(blueMax, greenMax, redMax));
            
            tempGrayImage = tempGrayImage.PyrDown().PyrUp();
            tempGrayImage = tempGrayImage.SmoothGaussian(3);
            //Canny edge detection
            tempGrayImage = tempGrayImage.Canny(160, 80);
            tempGrayImage._Dilate(1);
            grayModifiedMat = tempGrayImage.Mat;

            RectShape1 = RetrieveRectangle(shape1Coordinates);
            RectShape2 = RetrieveRectangle(shape2Coordinates);
            RectShape3 = RetrieveRectangle(shape3Coordinates);
            RectShape4 = RetrieveRectangle(shape4Coordinates);
            RectShapeFeed = RetrieveRectangle(shapeFeedCoordinates);

            Mat crop1 = new Mat(grayModifiedMat, RectShape1);
            Mat crop2 = new Mat(grayModifiedMat, RectShape2);
            Mat crop3 = new Mat(grayModifiedMat, RectShape3);
            Mat crop4 = new Mat(grayModifiedMat, RectShape4);
            Mat cropFeed = new Mat(grayModifiedMat, RectShapeFeed);
            var cropImage1 = crop1.ToImage<Gray, byte>();
            var cropImage2 = crop2.ToImage<Gray, byte>();
            var cropImage3 = crop3.ToImage<Gray, byte>();
            var cropImage4 = crop4.ToImage<Gray, byte>();
            var cropImageFeed = cropFeed.ToImage<Gray, byte>();
            //wszystkie ROI są już poddane odpowiedniej obróbce, można brać się za wykrywanie konturów w ich obrębie
            using (VectorOfVectorOfPoint contours1 = new VectorOfVectorOfPoint())
            using (VectorOfVectorOfPoint contours2 = new VectorOfVectorOfPoint())
            using (VectorOfVectorOfPoint contours3 = new VectorOfVectorOfPoint())
            using (VectorOfVectorOfPoint contours4 = new VectorOfVectorOfPoint())
            using (VectorOfVectorOfPoint contoursFeed = new VectorOfVectorOfPoint())
            {
                Mat hier1 = new Mat();
                Mat hier2 = new Mat();
                Mat hier3 = new Mat();
                Mat hier4 = new Mat();
                Mat hierFeed = new Mat();

                CvInvoke.FindContours(cropImage1, contours1, hier1, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                CvInvoke.FindContours(cropImage2, contours2, hier2, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                CvInvoke.FindContours(cropImage3, contours3, hier3, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                CvInvoke.FindContours(cropImage4, contours4, hier4, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                CvInvoke.FindContours(cropImageFeed, contoursFeed, hierFeed, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                //kontury wewnątrz wszystkich podobszarów wykryte, teraz znajdujemy największy kontur dla każdego podobszaru
                //a następnie stwierdzamy czy jego kształt jest Zgodny z tym czego oczekujemy
                //jeżeli jest to komunikowane jest to poprzez pojawienie się odpowiedniego napisu na obrazie
                // oraz zaznaczenie jego konturów jaskrawym  kolorem jeśli wybrana jest opcja orginalnego obrazu
                if (shapeInFeeder == 1)
                {
                    shapeFeed = shape1;
                    currentShape = "Ksztalt 1";
                }
                else if (shapeInFeeder == 2)
                {
                    shapeFeed = shape2;
                    currentShape = "Ksztalt 2";
                }
                else if (shapeInFeeder == 3)
                {
                    shapeFeed = shape3;
                    currentShape = "Ksztalt 3";
                }
                else if (shapeInFeeder == 4)
                {
                    shapeFeed = shape4;
                    currentShape = "Ksztalt 4";
                }
                VectorOfPoint apcntrFeed;
                VectorOfPoint apcntr1;
                VectorOfPoint apcntr2;
                VectorOfPoint apcntr3;
                VectorOfPoint apcntr4;
				////podajnik////////////////////////



				if (IsShapeInROI(contoursFeed, cropFeed, shapeFeed, RectShapeFeed, out apcntrFeed))
                {
                    CvInvoke.PutText(orginalImage, currentShape + ":podano", new Point(shapeFeedCoordinates.Xxx, shapeFeedCoordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    CvInvoke.Polylines(orginalImage, apcntrFeed, true, new MCvScalar(0, 255, 255), 2);
                    feedReached = true;
                    if (shapeInFeeder == 1) shape1FeedFound = true;
                    else if (shapeInFeeder == 2) shape2FeedFound = true;
                    else if (shapeInFeeder == 3) shape3FeedFound = true;
                    else if (shapeInFeeder == 4) shape4FeedFound = true;
                }
                else
                {
                    if (feedReached) CvInvoke.PutText(orginalImage, currentShape + ":trwa dostarczanie", new Point(shapeFeedCoordinates.Xxx, shapeFeedCoordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    else CvInvoke.PutText(orginalImage, currentShape + ":nie podano", new Point(shapeFeedCoordinates.Xxx, shapeFeedCoordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                }



                ///pozostałe podregiony////////////////////////
                ///1
                if (IsShapeInROI(contours1, crop1, shape1, RectShape1, out apcntr1))
                {
                    CvInvoke.PutText(orginalImage, shape1Name + ":znaleziono", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    CvInvoke.Polylines(orginalImage, apcntr1, true, new MCvScalar(0, 255, 255), 2);
                    if (shape1Found == false)
                    {
                        //shape1Found = true;
                        shapeInFeeder = 2;
                        feedReached = false;
                        //zmiana zdarzenia jakie ma zostać wykryte w podajniku
                    }
                    shape1Found = true;
                    lblShape1Status.ForeColor = Color.Green;
                    lblShape1Status.Text = "Kształt 1: wykryty";
                }
                else
                {
                    CvInvoke.PutText(orginalImage, shape1Name + ":nie znaleziono", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    if (shape1Found == true)
                    {
                        lblShape1Status.ForeColor = Color.Yellow;
                        lblShape1Status.Text = "Kształt 1: niewykryty";
                    }
                    //shape1Found = false;
                }
                ////2
                if (IsShapeInROI(contours2, crop2, shape2, RectShape2, out apcntr2))
                {
                    CvInvoke.PutText(orginalImage, shape2Name + ":znaleziono", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    CvInvoke.Polylines(orginalImage, apcntr2, true, new MCvScalar(0, 255, 255), 2);
                    if (shape2Found == false)
                    {
                        //shape1Found = true;
                        shapeInFeeder = 3;
                        feedReached = false;
                        //zmiana zdarzenia jakie ma zostać wykryte w podajniku
                    }
                    shape2Found = true;
                    lblShape2Status.ForeColor = Color.Green;
                    lblShape2Status.Text = "Kształt 2: wykryty";
                }
                else
                {
                    CvInvoke.PutText(orginalImage, shape2Name + ":nie znaleziono", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    if (shape2Found == true)
                    {
                        lblShape2Status.ForeColor = Color.Yellow;
                        lblShape2Status.Text = "Kształt 2: niewykryty";
                    }
                    //shape1Found = false;
                }
                ////3
                if (IsShapeInROI(contours3, crop3, shape3, RectShape3, out apcntr3))
                {
                    CvInvoke.PutText(orginalImage, shape3Name + ":znaleziono", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    CvInvoke.Polylines(orginalImage, apcntr3, true, new MCvScalar(0, 255, 255), 2);
                    if (shape3Found == false)
                    {
                        //shape1Found = true;
                        shapeInFeeder = 4;
                        feedReached = false;
                        //zmiana zdarzenia jakie ma zostać wykryte w podajniku
                    }
                    shape3Found = true;
                    lblShape3Status.ForeColor = Color.Green;
                    lblShape3Status.Text = "Kształt 3: wykryty";
                }
                else
                {
                    CvInvoke.PutText(orginalImage, shape3Name + ":nie znaleziono", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    if (shape3Found == true)
                    {
                        lblShape3Status.ForeColor = Color.Yellow;
                        lblShape3Status.Text = "Kształt 3: niewykryty";
                    }
                    //shape1Found = false;
                }
                ////4
                if (IsShapeInROI(contours4, crop4, shape4, RectShape4, out apcntr4))
                {
                    CvInvoke.PutText(orginalImage, shape4Name + ":znaleziono", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    CvInvoke.Polylines(orginalImage, apcntr4, true, new MCvScalar(0, 255, 255), 2);
                    if (shape4Found == false)
                    {
                        //shape1Found = true;
                        shapeInFeeder = 4;
                        feedReached = false;
                        //zmiana zdarzenia jakie ma zostać wykryte w podajniku
                    }
                    shape4Found = true;
                    lblShape4Status.ForeColor = Color.Green;
                    lblShape4Status.Text = "Kształt 4: wykryty";
                }
                else
                {
                    CvInvoke.PutText(orginalImage, shape4Name + ":nie znaleziono", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
                    if (shape4Found == true)
                    {
                        lblShape4Status.ForeColor = Color.Yellow;
                        lblShape4Status.Text = "Kształt 4: niewykryty";
                    }
                    //shape1Found = false;
                }
            }
            //wszystkie kształty zostały wykryte, komunikat wystosowany w kierunku użytkownika
            if (allShapesFound == false)
            {
                if (shape1Found && shape2Found && shape3Found && shape4Found)
                {
                    if(lblShape1Status.ForeColor==Color.Green&& lblShape2Status.ForeColor == Color.Green && lblShape3Status.ForeColor == Color.Green && lblShape4Status.ForeColor == Color.Green)
                    {
						allShapesFound = true;
						lblError.Visible = false;
						MessageBox.Show("Wszystkie kształty znajdują się w prawidłowym miejscu.");
                        #region MessageBoxAboutFeed
                        switch (shape1FeedFound)
                        {
                            case true:
                                switch (shape2FeedFound)
                                {
                                    case true:
                                        switch (shape3FeedFound)
                                        {
                                            case true:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Wszystkie kształty podane prawidłowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Ksztalt 4 wprowadzony neiprawidłowo do podajnika.");
                                                        break;
                                                }
                                                break;
                                            case false:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Kształt 3 wprowadzony nieprawidlowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Kztałt 3 i kształt 4 wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                }
                                                break;
                                        }
                                        break;
                                    case false:
                                        switch (shape3FeedFound)
                                        {
                                            case true:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Kształt 2 wprowadzony nieprawidłowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Kształt 2 i kształt 4 wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                }
                                                break;
                                            case false:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Kształt 2 i kształt 3 wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Tylko kształt numer 1 wprowadzony poprawnie do podajnika.");
                                                        break;
                                                }
                                                break;
                                        }
                                        break;
                                }
                                break;
                            case false:
                                switch (shape2FeedFound)
                                {
                                    case true:
                                        switch (shape3FeedFound)
                                        {
                                            case true:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Ksztalt 1 wprowadzony nieprawidłowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Kształt 1 i kształt 4 wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                }
                                                break;
                                            case false:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Kształt 1 i kształt 3 wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Tylko kształt numer 2 wprowadzony poprawnie do podajnika.");
                                                        break;
                                                }
                                                break;
                                        }
                                        break;
                                    case false:
                                        switch (shape3FeedFound)
                                        {
                                            case true:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Kztałt 1 i kształt 2 wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Tylko kształt numer 3 wprowadzony poprawnie do podajnika.");
                                                        break;
                                                }
                                                break;
                                            case false:
                                                switch (shape4FeedFound)
                                                {
                                                    case true:
                                                        MessageBox.Show("Tylko kształt numer 4 wprowadzony poprawnie do podajnika.");
                                                        break;
                                                    case false:
                                                        MessageBox.Show("Wszystkie kształty wprowadzone nieprawidłowo do podajnika.");
                                                        break;
                                                }
                                                break;
                                        }
                                        break;
                                }
                                break;
                        }
						#endregion
					}
                }
            }
            
            if (rbOrginalImage.Checked == true)
            {
                DrawRectanglesWithSignatures(orginalImage);
                ibCameraCap.Image = orginalImage;
            }
            else
            {
                DrawGrayRectanglesWithSignatures(tempGrayImage);
                ibCameraCap.Image = tempGrayImage;
            }
        }

		public void ShapeDetection_With_Delivery(object sender, EventArgs e)
		{
			Mat framex1;
			Mat grayModifiedMat;
			framex1 = FramesFromCamera();
			Image<Bgr, byte> orginalImage = framex1.ToImage<Bgr, byte>();

			var modifiedImage = orginalImage.Copy();
			modifiedImage = modifiedImage.PyrDown().PyrUp();
			modifiedImage._SmoothGaussian(3);
			Image<Gray, byte> tempGrayImage = modifiedImage.InRange(new Bgr(blueMin, greenMin, redMin), new Bgr(blueMax, greenMax, redMax));

			tempGrayImage = tempGrayImage.PyrDown().PyrUp();
			tempGrayImage = tempGrayImage.SmoothGaussian(3);
			//Canny edge detection
			tempGrayImage = tempGrayImage.Canny(160, 80);
			tempGrayImage._Dilate(1);
			grayModifiedMat = tempGrayImage.Mat;

			RectShape1 = RetrieveRectangle(shape1Coordinates);
			RectShape2 = RetrieveRectangle(shape2Coordinates);
			RectShape3 = RetrieveRectangle(shape3Coordinates);
			RectShape4 = RetrieveRectangle(shape4Coordinates);
			RectShapeFeed = RetrieveRectangle(shapeFeedCoordinates);

			Mat crop1 = new Mat(grayModifiedMat, RectShape1);
			Mat crop2 = new Mat(grayModifiedMat, RectShape2);
			Mat crop3 = new Mat(grayModifiedMat, RectShape3);
			Mat crop4 = new Mat(grayModifiedMat, RectShape4);
			Mat cropFeed = new Mat(grayModifiedMat, RectShapeFeed);
			var cropImage1 = crop1.ToImage<Gray, byte>();
			var cropImage2 = crop2.ToImage<Gray, byte>();
			var cropImage3 = crop3.ToImage<Gray, byte>();
			var cropImage4 = crop4.ToImage<Gray, byte>();
			var cropImageFeed = cropFeed.ToImage<Gray, byte>();
			//wszystkie ROI są już poddane odpowiedniej obróbce, można brać się za wykrywanie konturów w ich obrębie
			using (VectorOfVectorOfPoint contours1 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contours2 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contours3 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contours4 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contoursFeed = new VectorOfVectorOfPoint())
			{
				Mat hier1 = new Mat();
				Mat hier2 = new Mat();
				Mat hier3 = new Mat();
				Mat hier4 = new Mat();
				Mat hierFeed = new Mat();

				CvInvoke.FindContours(cropImage1, contours1, hier1, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImage2, contours2, hier2, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImage3, contours3, hier3, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImage4, contours4, hier4, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImageFeed, contoursFeed, hierFeed, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				//kontury wewnątrz wszystkich podobszarów wykryte, teraz znajdujemy największy kontur dla każdego podobszaru
				//a następnie stwierdzamy czy jego kształt jest Zgodny z tym czego oczekujemy
				//jeżeli jest to komunikowane jest to poprzez pojawienie się odpowiedniego napisu na obrazie
				// oraz zaznaczenie jego konturów jaskrawym  kolorem jeśli wybrana jest opcja orginalnego obrazu
				
				VectorOfPoint apcntrFeed;
				VectorOfPoint apcntr1;
				VectorOfPoint apcntr2;
				VectorOfPoint apcntr3;
				VectorOfPoint apcntr4;
				////podajnik////////////////////////

				if (contoursFeed.Size != 0)
				{
					double[] areaFeed = new double[contoursFeed.Size];
					for (int i = 0; i < contoursFeed.Size; i++)
					{
						areaFeed[i] = CvInvoke.ContourArea(contoursFeed[i]);
					}
					double maxValueFeed = areaFeed.Max();
					int maxIndexFeed = areaFeed.ToList().IndexOf(maxValueFeed);

					if (maxValueFeed > 0.03 * (cropFeed.Height * cropFeed.Width))
					{
						apcntrFeed = ApproxContour(contoursFeed, maxIndexFeed);
						Point[] ptsF = apcntrFeed.ToArray();

						for (int i = 0; i < apcntrFeed.Size; i++)
						{
							ptsF[i].X += RectShapeFeed.X;
							ptsF[i].Y += RectShapeFeed.Y;
						}
						VectorOfPoint VoP = new VectorOfPoint(ptsF);
						CvInvoke.Polylines(orginalImage, VoP, true, new MCvScalar(0, 255, 0), 2);
                        //odpowiednia kolejność
						if (!shape1FeedFound)		//kształt numer 1 nie został jeszcze znaleziony
						{
							if (shape1 == (int)TypeOfContour(apcntrFeed))	//&&(!shape1Found)
							{
                                if(readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
                                {
                                    shape1FeedFound = true;
                                    txtSend.Text = "1";
                                    btnSend_Click(new object(), new EventArgs());
                                }
							}
						}
						else if (!shape2FeedFound)
						{
							if (shape2 == (int)TypeOfContour(apcntrFeed))
							{
                                if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
                                {
                                    shape2FeedFound = true;
                                    txtSend.Text = "2";
                                    btnSend_Click(new object(), new EventArgs());
                                }
							}
						}
						else if (!shape3FeedFound)
						{
							if (shape3 == (int)TypeOfContour(apcntrFeed))
							{
                                if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
                                {
                                    shape3FeedFound = true;
                                    txtSend.Text = "3";
                                    btnSend_Click(new object(), new EventArgs());
                                }
							}
						}
						else if (!shape4FeedFound)
						{
							if (shape4 == (int)TypeOfContour(apcntrFeed))
							{
                                if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
                                {
                                    shape4FeedFound = true;
                                    txtSend.Text = "4";
                                    btnSend_Click(new object(), new EventArgs());
                                }
							}
						}


					}

				}

				///pozostałe podregiony////////////////////////
				///1
				if (IsShapeInROI(contours1, crop1, shape1, RectShape1, out apcntr1))
				{
					CvInvoke.PutText(orginalImage, shape1Name + ":znaleziono", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr1, true, new MCvScalar(0, 255, 255), 2);
					shape1Found = true;
					lblShape1Status.ForeColor = Color.Green;
					lblShape1Status.Text = "Kształt 1: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape1Name + ":nie znaleziono", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape1Found == true)
					{
						lblShape1Status.ForeColor = Color.Yellow;
						lblShape1Status.Text = "Kształt 1: niewykryty";
					}
					shape1Found = false;
				}
				////2
				if (IsShapeInROI(contours2, crop2, shape2, RectShape2, out apcntr2))
				{
					CvInvoke.PutText(orginalImage, shape2Name + ":znaleziono", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr2, true, new MCvScalar(0, 255, 255), 2);
					shape2Found = true;
					lblShape2Status.ForeColor = Color.Green;
					lblShape2Status.Text = "Kształt 2: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape2Name + ":nie znaleziono", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape2Found == true)
					{
						lblShape2Status.ForeColor = Color.Yellow;
						lblShape2Status.Text = "Kształt 2: niewykryty";
					}
					shape2Found = false;
				}
				////3
				if (IsShapeInROI(contours3, crop3, shape3, RectShape3, out apcntr3))
				{
					CvInvoke.PutText(orginalImage, shape3Name + ":znaleziono", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr3, true, new MCvScalar(0, 255, 255), 2);
					shape3Found = true;
					lblShape3Status.ForeColor = Color.Green;
					lblShape3Status.Text = "Kształt 3: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape3Name + ":nie znaleziono", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape3Found == true)
					{
						lblShape3Status.ForeColor = Color.Yellow;
						lblShape3Status.Text = "Kształt 3: niewykryty";
					}
					shape3Found = false;
				}
				////4
				if (IsShapeInROI(contours4, crop4, shape4, RectShape4, out apcntr4))
				{
					CvInvoke.PutText(orginalImage, shape4Name + ":znaleziono", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr4, true, new MCvScalar(0, 255, 255), 2);
					shape4Found = true;
					lblShape4Status.ForeColor = Color.Green;
					lblShape4Status.Text = "Kształt 4: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape4Name + ":nie znaleziono", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape4Found == true)
					{
						lblShape4Status.ForeColor = Color.Yellow;
						lblShape4Status.Text = "Kształt 4: niewykryty";
					}
					shape4Found = false;
				}
			}
			//wszystkie kształty zostały wykryte, komunikat wystosowany w kierunku użytkownika
			if (allShapesFound == false)
			{
				if (shape1Found && shape2Found && shape3Found && shape4Found)
				{
					if (lblShape1Status.ForeColor == Color.Green && lblShape2Status.ForeColor == Color.Green && lblShape3Status.ForeColor == Color.Green && lblShape4Status.ForeColor == Color.Green)
					{
						lblError.Visible = false;
						allShapesFound = true;
						//txtSend.Text = "3";
						//btnSend_Click(new object(), new EventArgs());
						MessageBox.Show("Wszystkie kształty znajdują się w prawidłowym miejscu.");
					}
				}
			}

			if (rbOrginalImage.Checked == true)
			{
				DrawRectanglesWithSignatures(orginalImage);
				ibCameraCap.Image = orginalImage;
			}
			else
			{
				DrawGrayRectanglesWithSignatures(tempGrayImage);
				ibCameraCap.Image = tempGrayImage;
			}
		}

		bool deliveryOnTrack = false;

		public void ShapeDetection_Segregation(object sender, EventArgs e)
		{
			Mat framex1;
			Mat grayModifiedMat;
			framex1 = FramesFromCamera();
			Image<Bgr, byte> orginalImage = framex1.ToImage<Bgr, byte>();

			var modifiedImage = orginalImage.Copy();
			modifiedImage = modifiedImage.PyrDown().PyrUp();
			modifiedImage._SmoothGaussian(3);
			Image<Gray, byte> tempGrayImage = modifiedImage.InRange(new Bgr(blueMin, greenMin, redMin), new Bgr(blueMax, greenMax, redMax));

			tempGrayImage = tempGrayImage.PyrDown().PyrUp();
			tempGrayImage = tempGrayImage.SmoothGaussian(3);
			//Canny edge detection
			tempGrayImage = tempGrayImage.Canny(160, 80);
			tempGrayImage._Dilate(1);
			grayModifiedMat = tempGrayImage.Mat;

			RectShape1 = RetrieveRectangle(shape1Coordinates);
			RectShape2 = RetrieveRectangle(shape2Coordinates);
			RectShape3 = RetrieveRectangle(shape3Coordinates);
			RectShape4 = RetrieveRectangle(shape4Coordinates);
			RectShapeFeed = RetrieveRectangle(shapeFeedCoordinates);

			Mat crop1 = new Mat(grayModifiedMat, RectShape1);
			Mat crop2 = new Mat(grayModifiedMat, RectShape2);
			Mat crop3 = new Mat(grayModifiedMat, RectShape3);
			Mat crop4 = new Mat(grayModifiedMat, RectShape4);
			Mat cropFeed = new Mat(grayModifiedMat, RectShapeFeed);
			var cropImage1 = crop1.ToImage<Gray, byte>();
			var cropImage2 = crop2.ToImage<Gray, byte>();
			var cropImage3 = crop3.ToImage<Gray, byte>();
			var cropImage4 = crop4.ToImage<Gray, byte>();
			var cropImageFeed = cropFeed.ToImage<Gray, byte>();
			//wszystkie ROI są już poddane odpowiedniej obróbce, można brać się za wykrywanie konturów w ich obrębie
			using (VectorOfVectorOfPoint contours1 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contours2 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contours3 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contours4 = new VectorOfVectorOfPoint())
			using (VectorOfVectorOfPoint contoursFeed = new VectorOfVectorOfPoint())
			{
				Mat hier1 = new Mat();
				Mat hier2 = new Mat();
				Mat hier3 = new Mat();
				Mat hier4 = new Mat();
				Mat hierFeed = new Mat();

				CvInvoke.FindContours(cropImage1, contours1, hier1, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImage2, contours2, hier2, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImage3, contours3, hier3, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImage4, contours4, hier4, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				CvInvoke.FindContours(cropImageFeed, contoursFeed, hierFeed, RetrType.External, ChainApproxMethod.ChainApproxSimple);
				//kontury wewnątrz wszystkich podobszarów wykryte, teraz znajdujemy największy kontur dla każdego podobszaru
				//a następnie stwierdzamy czy jego kształt jest Zgodny z tym czego oczekujemy
				//jeżeli jest to komunikowane jest to poprzez pojawienie się odpowiedniego napisu na obrazie
				// oraz zaznaczenie jego konturów jaskrawym  kolorem jeśli wybrana jest opcja orginalnego obrazu

				VectorOfPoint apcntrFeed;
				VectorOfPoint apcntr1;
				VectorOfPoint apcntr2;
				VectorOfPoint apcntr3;
				VectorOfPoint apcntr4;
				////podajnik////////////////////////
				#region podajnikSegregacja
				if (contoursFeed.Size != 0)
				{
					double[] areaFeed = new double[contoursFeed.Size];
					for (int i = 0; i < contoursFeed.Size; i++)
					{
						areaFeed[i] = CvInvoke.ContourArea(contoursFeed[i]);
					}
					double maxValueFeed = areaFeed.Max();
					int maxIndexFeed = areaFeed.ToList().IndexOf(maxValueFeed);

					if (maxValueFeed > 0.03 * (cropFeed.Height * cropFeed.Width))
					{
						apcntrFeed = ApproxContour(contoursFeed, maxIndexFeed);
						Point[] ptsF = apcntrFeed.ToArray();

						for (int i = 0; i < apcntrFeed.Size; i++)
						{
							ptsF[i].X += RectShapeFeed.X;
							ptsF[i].Y += RectShapeFeed.Y;
						}
						VectorOfPoint VoP = new VectorOfPoint(ptsF);
						CvInvoke.Polylines(orginalImage, VoP, true, new MCvScalar(0, 255, 0), 2);
						//odpowiednia kolejność
						//do tego miejsca bez zmian

						if (!deliveryOnTrack)		///te 3 warunki można sprowadzić do jednego
						{
							if (!shape1FeedFound)
							{
								if (shape1 == (int)TypeOfContour(apcntrFeed))
								{
									if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
									{
										deliveryOnTrack = true;
										shape1FeedFound = true;
										txtSend.Text = "1";
										btnSend_Click(new object(), new EventArgs());
									}
								}
							}
						}

						if (!deliveryOnTrack)
						{
							if (!shape2FeedFound)
							{
								if (shape2 == (int)TypeOfContour(apcntrFeed))
								{
									if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
									{
										shape2FeedFound = true;
										txtSend.Text = "2";
										btnSend_Click(new object(), new EventArgs());
									}
								}
							}
						}

						if (!deliveryOnTrack)
						{
							if (!shape3FeedFound)
							{
								if (shape3 == (int)TypeOfContour(apcntrFeed))
								{
									if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
									{
										shape3FeedFound = true;
										txtSend.Text = "3";
										btnSend_Click(new object(), new EventArgs());
									}
								}
							}
						}

						if (!deliveryOnTrack)
						{
							if (!shape4FeedFound)
							{
								if (shape4 == (int)TypeOfContour(apcntrFeed))
								{
									if (readdata.Contains("Oczekiwanie na ksztalt w podajniku"))
									{
										shape4FeedFound = true;
										txtSend.Text = "4";
										btnSend_Click(new object(), new EventArgs());
									}
								}
							}
						}

						
					}
				}
				#endregion
				///pozostałe podregiony////////////////////////
				///1
				if (IsShapeInROI(contours1, crop1, shape1, RectShape1, out apcntr1))
				{
					CvInvoke.PutText(orginalImage, shape1Name + ":znaleziono", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr1, true, new MCvScalar(0, 255, 255), 2);
					shape1Found = true;
					lblShape1Status.ForeColor = Color.Green;
					lblShape1Status.Text = "Kształt 1: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape1Name + ":nie znaleziono", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape1Found == true)
					{
						lblShape1Status.ForeColor = Color.Yellow;
						lblShape1Status.Text = "Kształt 1: niewykryty";
					}
					shape1Found = false;
				}
				////2
				if (IsShapeInROI(contours2, crop2, shape2, RectShape2, out apcntr2))
				{
					CvInvoke.PutText(orginalImage, shape2Name + ":znaleziono", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr2, true, new MCvScalar(0, 255, 255), 2);
					shape2Found = true;
					lblShape2Status.ForeColor = Color.Green;
					lblShape2Status.Text = "Kształt 2: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape2Name + ":nie znaleziono", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape2Found == true)
					{
						lblShape2Status.ForeColor = Color.Yellow;
						lblShape2Status.Text = "Kształt 2: niewykryty";
					}
					shape2Found = false;
				}
				////3
				if (IsShapeInROI(contours3, crop3, shape3, RectShape3, out apcntr3))
				{
					CvInvoke.PutText(orginalImage, shape3Name + ":znaleziono", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr3, true, new MCvScalar(0, 255, 255), 2);
					shape3Found = true;
					lblShape3Status.ForeColor = Color.Green;
					lblShape3Status.Text = "Kształt 3: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape3Name + ":nie znaleziono", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape3Found == true)
					{
						lblShape3Status.ForeColor = Color.Yellow;
						lblShape3Status.Text = "Kształt 3: niewykryty";
					}
					shape3Found = false;
				}
				////4
				if (IsShapeInROI(contours4, crop4, shape4, RectShape4, out apcntr4))
				{
					CvInvoke.PutText(orginalImage, shape4Name + ":znaleziono", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					CvInvoke.Polylines(orginalImage, apcntr4, true, new MCvScalar(0, 255, 255), 2);
					shape4Found = true;
					lblShape4Status.ForeColor = Color.Green;
					lblShape4Status.Text = "Kształt 4: wykryty";
				}
				else
				{
					CvInvoke.PutText(orginalImage, shape4Name + ":nie znaleziono", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.4, new MCvScalar(0, 0, 255));
					if (shape4Found == true)
					{
						lblShape4Status.ForeColor = Color.Yellow;
						lblShape4Status.Text = "Kształt 4: niewykryty";
					}
					shape4Found = false;
				}
			}
			//wszystkie kształty zostały wykryte, komunikat wystosowany w kierunku użytkownika
			if (allShapesFound == false)
			{
				if (shape1Found && shape2Found && shape3Found && shape4Found)
				{
					if (lblShape1Status.ForeColor == Color.Green && lblShape2Status.ForeColor == Color.Green && lblShape3Status.ForeColor == Color.Green && lblShape4Status.ForeColor == Color.Green)
					{
						lblError.Visible = false;
						allShapesFound = true;
						//txtSend.Text = "3";
						//btnSend_Click(new object(), new EventArgs());
						MessageBox.Show("Wszystkie kształty znajdują się w prawidłowym miejscu.");
					}
				}
			}

			if (rbOrginalImage.Checked == true)
			{
				DrawRectanglesWithSignatures(orginalImage);
				ibCameraCap.Image = orginalImage;
			}
			else
			{
				DrawGrayRectanglesWithSignatures(tempGrayImage);
				ibCameraCap.Image = tempGrayImage;
			}
		}

		private void button1_Click(object sender, EventArgs e)
        {
            if(shape1==99 || shape2==99|| shape3 == 99 || shape4 == 99)
            {
                MessageBox.Show("Należy wybrać 4 kształty wraz z obszarami przed przystąpieniem do operacji wykrywania.");
                return;
            }
			rbAdvanced.Enabled = false;
            shape1Found = false;
            shape2Found = false;
            shape3Found = false;
            shape4Found = false;
            shape1FeedFound = false;
            shape2FeedFound = false;
            shape3FeedFound = false;
            shape4FeedFound = false;
            shapeInFeeder = 1;
            feedReached = false;
            allShapesFound = false;
            lblShape1Status.Text = "Kształt 1: niewykryty";
            lblShape2Status.Text = "Kształt 2: niewykryty";
            lblShape3Status.Text = "Kształt 3: niewykryty";
            lblShape4Status.Text = "Kształt 4: niewykryty";
            lblShape1Status.ForeColor = Color.Red;
            lblShape2Status.ForeColor = Color.Red;
            lblShape3Status.ForeColor = Color.Red;
            lblShape4Status.ForeColor = Color.Red;
			cBoxShapes1.Enabled = false;
			cBoxShapes2.Enabled = false;
			cBoxShapes3.Enabled = false;
			cBoxShapes4.Enabled = false;
			btnShapeDetection.Enabled = false;
			btnStopShapeDetection.Enabled = true;
			deliveryOnTrack = false;

			if (rbNoFeedback.Checked == true)
			{
				rbOrder.Enabled = false;
				rbDisorder.Enabled = false;
				Application.Idle += new EventHandler(this.ShapeDetection);
			}
			if (rbOrder.Checked)
			{
				rbNoFeedback.Enabled = false;
				rbDisorder.Enabled = false;
				Application.Idle += new EventHandler(this.ShapeDetection_With_Delivery);
			}
			if (rbDisorder.Checked)
			{
				rbNoFeedback.Enabled = false;
				rbOrder.Enabled = false;
				Application.Idle += new EventHandler(this.ShapeDetection_Segregation);
			}
            
            
        }
        
        private void DrawRectanglesWithSignatures(Image<Bgr,byte> img)
        {
            CvInvoke.Rectangle(img, RectShape1, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShape2, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShape3, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShape4, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShapeFeed, new MCvScalar(255, 0, 255), 2);
        }

        private void DrawGrayRectanglesWithSignatures(Image<Gray, byte> img)
        {
            CvInvoke.Rectangle(img, RectShape1, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShape2, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShape3, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShape4, new MCvScalar(255, 0, 255), 2);
            CvInvoke.Rectangle(img, RectShapeFeed, new MCvScalar(255, 0, 255), 2);

            CvInvoke.PutText(img, "Ksztalt 1", new Point(shape1Coordinates.Xxx, shape1Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.5, new MCvScalar(255, 0, 255));
            CvInvoke.PutText(img, "Ksztalt 2", new Point(shape2Coordinates.Xxx, shape2Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.5, new MCvScalar(255, 0, 255));
            CvInvoke.PutText(img, "Ksztalt 3", new Point(shape3Coordinates.Xxx, shape3Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.5, new MCvScalar(255, 0, 255));
            CvInvoke.PutText(img, "Ksztalt 4", new Point(shape4Coordinates.Xxx, shape4Coordinates.Yyy - 3), FontFace.HersheyComplex, 0.5, new MCvScalar(255, 0, 255));

        }

        private bool IsShapeInROI(VectorOfVectorOfPoint contours, Mat crop, int shape, Rectangle roi, out VectorOfPoint approxContour)
        {
            approxContour = null;                                                                                                                                                           //new VectorOfPoint();
            if (contours.Size == 0) return false;                                                                                                               //jeśli żaden kontur nie został wykryty należy zakończyć działanie funkcji już w tym momencie

            double[] area = new double[contours.Size];                                                                                                       //zostały znalezione kontury, należy teraz obliczyć pole powierzchnii każdego konturu
            for (int i = 0; i < contours.Size; i++)
            {
                area[i] = CvInvoke.ContourArea(contours[i]);
            }
            double maxValue = area.Max();                                                                                                               //pole każdego konturu jest obliczone, teraz trzeba wziąć pod uwagę tylko i wyłącznie największy kontur
            int maxIndex = area.ToList().IndexOf(maxValue);                                                                                             //indeks konturu o największej powierzchnii
            if (maxValue > 0.04 * (crop.Height * crop.Width))                                                                                           //sprawdzenie czy największy kontur w danym podregionie jest wystarczająco duży
            {                                                                                                                                           //wymogi dotyczące rozmiaru konturu spełnione - można zacząć rozpoznawanie
                approxContour = ApproxContour(contours, maxIndex);
                if ((int)TypeOfContour(approxContour) == shape)
                {                                                                                                                                     //Point[] pts = approxContour.ToArray();
                    Point[] pts = approxContour.ToArray();                                                                                                //został wykryty prawidłowy kształt
                                                                                                                                                        //przesunięcie punktów tak aby były odpowiednio przesuniete w zależności od ROI
                    for (int i = 0; i < approxContour.Size; i++)
                    {
                        pts[i].X += roi.X;
                        pts[i].Y += roi.Y;
                    }
                    VectorOfPoint vp = new VectorOfPoint(pts);
                    approxContour = vp;
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private VectorOfPoint ApproxContour(VectorOfVectorOfPoint contour, int IndexOfMax)
        {
            VectorOfPoint approx = new VectorOfPoint();
			//double parameter = CvInvoke.ArcLength(contour[IndexOfMax], true);
			//CvInvoke.ApproxPolyDP(contour[IndexOfMax], approx, 0.02 * parameter, true);
			CvInvoke.ApproxPolyDP(contour[IndexOfMax], approx, 10.0, true);
			return approx;
        }

        //funkcja pobierająca największy kontur w danym podregionie i wyznającza z jaką figurą może zostać on utorzsamoiony
        private Shapes TypeOfContour(VectorOfPoint approx)
        {
            
            if (approx.Size == 3)
                return Shapes.Triangle;
            else if (approx.Size == 4)
            {
                //Rectangle rect = CvInvoke.BoundingRectangle(contour[IndexOfMax]);
                Rectangle rect = CvInvoke.BoundingRectangle(approx);
                double proportion = ((double)rect.Width / rect.Height);
                if (proportion >= 0.94 && proportion <= 1.06)
                {
                    return Shapes.Square;
                }
                else
                {
                    return Shapes.Rectangle;
                }
            }
            else if (approx.Size == 5)
                return Shapes.Pentagon;
            else if (approx.Size == 6)
                return Shapes.Hexagon;
            else if (approx.Size == 8)
                return Shapes.Octagon;
            else
                return Shapes.Circle;
        }
    }
}
