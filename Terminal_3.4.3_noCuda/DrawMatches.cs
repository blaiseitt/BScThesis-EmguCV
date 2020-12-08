using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.XFeatures2D;
using System.Diagnostics;
using System.Drawing;
//using System.Runtime.InteropServices;

namespace Terminal_3._4._3_noCuda
{
    class DrawMatches
    {
        public static void FindMatch(Mat modelImage, Mat observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints,
            out VectorOfKeyPoint observedKeyPoints, VectorOfVectorOfDMatch matches, out Mat mask, out Mat homography)
        {
            int k = 2;
            double uniquenessThreshold = 0.8;
            double hessianThresh = 300;

            Stopwatch watch;
            homography = null;

            modelKeyPoints = new VectorOfKeyPoint();
            observedKeyPoints = new VectorOfKeyPoint();

            UMat uModelImage = new UMat();     
            UMat uObservedImage = new UMat();  
            
            using (uModelImage = modelImage.GetUMat(AccessType.ReadWrite))
            using (uObservedImage = observedImage.GetUMat(AccessType.ReadWrite))
            {
                SURF surfCPU = new SURF(hessianThresh);
                //extract features from the object image
                UMat modelDescriptors = new UMat();
                surfCPU.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false);
                watch = Stopwatch.StartNew();
                // extract features from the observed image
                UMat observedDescriptors = new UMat();
                surfCPU.DetectAndCompute(uObservedImage, null, observedKeyPoints, observedDescriptors, false);

                BFMatcher matcher = new BFMatcher(DistanceType.L2);
                matcher.Add(modelDescriptors);
                matcher.KnnMatch(observedDescriptors, matches, k, null);
                mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));
                Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                int nonZeroCount = CvInvoke.CountNonZero(mask);

                if (nonZeroCount >= 10)
                {
                    nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, matches, mask, 1.5, 20);
                    if (nonZeroCount >= 10)
                        homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, matches, mask, 2);
                }
                watch.Stop();
            }
            matchTime = watch.ElapsedMilliseconds;
        }

        public static Mat Draw(Mat modelImage, Mat observedImage, out long matchTime, string eventName, bool kpDraw, bool mlDraw)
        {

            Mat homography;
            VectorOfKeyPoint modelKeyPoints;
            VectorOfKeyPoint observedKeyPoints;
            using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
            {
                Mat mask;
                FindMatch(modelImage, observedImage, out matchTime, out modelKeyPoints, out observedKeyPoints, 
                    matches, out mask, out homography);

                //Draw the matched keypoints
                Rectangle rectModel = new Rectangle(new Point(0, 0), new Size(modelImage.Width, observedImage.Height));
                Mat result = new Mat();
                Mat kpOnScene = new Mat();
                Mat kpOnModel = new Mat();
                Image<Bgr, byte> tempImgModel;
                Image<Bgr, byte> tempImgScene;

                //modelImage.CopyTo(kpOnModel);

                //CvInvoke.Rectangle(kpOnModel, rectModel, new MCvScalar(0, 0, 255), 5);

                if (kpDraw==true && mlDraw == true)
                {

                    Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
                       matches, result, new MCvScalar(0, 0, 255), new MCvScalar(255, 255, 255), mask);                          //linie dopasowania na czerwono;    punkty charakterystyczne na biało;

                }
                else if(kpDraw==true && mlDraw == false)
                {
                    Features2DToolbox.DrawKeypoints(observedImage, observedKeyPoints, kpOnScene, new Bgr(Color.Gold));             //punkty charakterystyczne na obrazie sceny
                    Features2DToolbox.DrawKeypoints(modelImage, modelKeyPoints, kpOnModel, new Bgr(Color.GreenYellow));

                    tempImgModel = kpOnModel.ToImage<Bgr, byte>();
                    tempImgScene = kpOnScene.ToImage<Bgr, byte>();

                    tempImgScene = tempImgScene.ConcateHorizontal(tempImgModel);
                    result = tempImgScene.Mat;
                }
                else
                {
                    tempImgModel = modelImage.ToImage<Bgr, byte>();
                    tempImgScene = observedImage.ToImage<Bgr, byte>();

                    tempImgScene = tempImgScene.ConcateHorizontal(tempImgModel);
                    result = tempImgScene.Mat;
                }
                #region draw the projected region on the image

                if (homography != null)
                {
                    //draw a rectangle along the projected model
                    Rectangle rect = new Rectangle(Point.Empty, modelImage.Size);
                    PointF[] pts = new PointF[]
                    {
                  new PointF(rect.Left, rect.Bottom),
                  new PointF(rect.Right, rect.Bottom),
                  new PointF(rect.Right, rect.Top),
                  new PointF(rect.Left, rect.Top)
                    };
                    pts = CvInvoke.PerspectiveTransform(pts, homography);

                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    using (VectorOfPoint vp = new VectorOfPoint(points))
                    {
                        CvInvoke.Polylines(result, vp, true, new MCvScalar(0, 255, 255, 255), 5);                                       //żółty kolor wokół znalezionego zdarzenia
                        CvInvoke.PutText(result, eventName, points[3], FontFace.HersheySimplex, 3.0, new MCvScalar(0, 255, 0), 3);

                    }
                    /////////////////////
                }

                #endregion

                return result;
            }
        }
    }
}
