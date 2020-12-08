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

namespace Terminal_3._4._3_noCuda
{
    class DrawMatchesFromData
    {
        public static double hessianThresh = 300;
        /*
        public static void Find1(Mat observedImage, VectorOfKeyPoint vkp1, VectorOfKeyPoint vkp2, VectorOfKeyPoint vkp3, out VectorOfKeyPoint observedKeyPoints, 
            UMat model1Descriptor, UMat model2Descriptor, UMat model3Descriptor, string event1Name, string event2Name, string event3Name,
            VectorOfVectorOfDMatch matches, out Mat mask, out Mat homography)
        {
            int k = 2;
            double uniquenessThreshold = 0.8;
            double hessianThresh = 300;
            homography = null;

            SURF surfDetect3 = new SURF(hessianThresh);

            BFMatcher matcher = new BFMatcher(DistanceType.L2);

            if (vkp1 != null)
            {
                ///coś się wykonuje co ma prawo się wykonywać tylko i wyłącznie wtedy gdy pierwsze zdarzenie jest wgrane
                observedKeyPoints = new VectorOfKeyPoint();
                if(vkp2 != null)
                {
                    ///coś co ma prawo się wykonać jeżeli zarówno pierwsze jak i drugie zdarzenie zostały wgrane

                    if(vkp3 != null)
                    {
                        ///coś co się wykonuje gdy wgrane są wszystkie zdarzenia


                    }
                }
            }
        }
        */
        //wyzmaczenie wektora punktów kluczowych oraz deskryptora dla obrazu pobieranego na bierząco z kamery/
        /*
        public static VectorOfKeyPoint FindObservedKeypointsAndDescriptors(Mat observedImage)
        {
            VectorOfKeyPoint vkpObservedImage = new VectorOfKeyPoint();
            //Mat tempMat = new Mat();
            //observedImage.CopyTo(tempMat);

            SURF surfScene = new SURF(hessianThresh);
            surfScene.DetectRaw(observedImage, vkpObservedImage);

            return vkpObservedImage;
        }

        public static UMat ComputeDescriptor(VectorOfKeyPoint vkp)
        {
            UMat uDescriptor = new UMat();
            SURF surfDesc = new SURF(hessianThresh);
            //surfSceneDesc.Compute;

            return uDescriptor;
        }
        */
        public static VectorOfVectorOfDMatch ComputeVectorOfVectorOfMatches(UMat modelDescriptor, UMat sceneDescriptor)         //żeby obliczyć wektor dopasowań potrzebne są deskryptory sceny oraz modelu, nalezy utworzyć instancje BFMatcher'a, maske służącą do ...., oraz macierz homograficzną służącą do ....
        {
            VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

            BFMatcher matcher = new BFMatcher(DistanceType.L2);
            matcher.Add(modelDescriptor);
            matcher.KnnMatch(sceneDescriptor, matches, 2, null);
            
            return matches;
        }

        public static void VectorOfKPAndDescriptor(Mat sceneImage, ref UMat sceneDescriptor, ref VectorOfKeyPoint sceneVector)      //oblicza wektor oraz deskryptor na podstawie obrazu, wyniki zapisuje w referencji
        {
            Mat temp = new Mat();
            sceneImage.CopyTo(temp);
            UMat uSceneImage = new UMat();
            uSceneImage = temp.GetUMat(AccessType.ReadWrite);

            sceneVector = new VectorOfKeyPoint();
            sceneDescriptor = new UMat();

            SURF surfScene = new SURF(hessianThresh);
            surfScene.DetectAndCompute(uSceneImage, null, sceneVector, sceneDescriptor, false);
        }

    }
}
