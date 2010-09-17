using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ChuOngThongMinh
{
    public class AppConstant
    {
        public static int Storyboard_BeeMove_TimeSecond = 14;

        // --> Rank (Number Level)
        public static int Level1_Number_From = 0;
        public static int Level1_Number_To = 10;
        public static int Level2_Number_From = 10;
        public static int Level2_Number_To = 100;
        public static int Level3_Number_From = 100;
        public static int Level3_Number_To = 1000;

        // --> Height to Drop (per Level)
        public static double Level1_Height_ToDrop = 100;
        public static double Level2_Height_ToDrop = 105;
        public static double Level3_Height_ToDrop = 105;

        //--> Canvas top (per Level)
        public static double Level1_Canvas_Top = 0;
        public static double Level2_Canvas_Top = 0;
        public static double Level3_Canvas_Top = 0;

        //--> Canvas Rank
        public static double Distance_First = 9;
        public static double Distance_Second = 50;

        public static double Jar1_Area_From = 0;
        public static double Jar2_Area_From = 0;
        public static double Jar3_Area_From = 0;

        public static int timeDelayDropBall = 1;
        public static int timeDelayTired = 5;
    }
}
