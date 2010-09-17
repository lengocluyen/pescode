using System;
using System.Collections;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace PhuThuyDuaThu.Codes
{
    public class Constants
    {
        #region List number image
        public static string[] YellowNumber = new string[] { "Images/ZeroYellow.png", "Images/OneYellow.png", "Images/TwoYellow.png", "Images/ThreeYellow.png", "Images/FourYellow.png", "Images/FiveYellow.png", "Images/SixYellow.png", "Images/SevenYellow.png", "Images/EightYellow.png", "Images/NineYellow.png" };
        public static string[] BoldYellowNumber = new string[] { "Images/ZeroBYellow.png", "Images/OneBYellow.png", "Images/TwoBYellow.png", "Images/ThreeBYellow.png", "Images/FourBYellow.png", "Images/FiveBYellow.png", "Images/SixBYellow.png", "Images/SevenBYellow.png", "Images/EightBYellow.png", "Images/NineBYellow.png" };
        public static string[] GreenNumber = new string[] { "Images/ZeroGreen.png", "Images/OneGreen.png", "Images/TwoGreen.png", "Images/ThreeGreen.png", "Images/FourGreen.png", "Images/FiveGreen.png", "Images/SixGreen.png", "Images/SevenGreen.png", "Images/EightGreen.png", "Images/NineGreen.png" };
        public static string[] PinkNumber = new string[] { "Images/ZeroPink.png", "Images/OnePink.png", "Images/TwoPink.png", "Images/ThreePink.png", "Images/FourPink.png", "Images/FivePink.png", "Images/SixPink.png", "Images/SevenPink.png", "Images/EightPink.png", "Images/NinePink.png" };
        #endregion

        public static int Mailbox_Number_From = 100;
        public static int Mailbox_Number_To = 999;

        public static int ArrayCurrentIndex = 0;
        public static List<int> ArrRandomNumber = new List<int>();

        public static int TimeOutLevel1 = 60;
        public static int TimeOutLevel2 = 50;
        public static int TimeOutLevel3 = 30;
        public static int TimeOutLevel4 = 15;
        public static int TimeOutLevel5 = 10;
        public static int TimeOutLevel6 = 5;

        public static int PointLevelUp1 = 0;
        public static int PointLevelUp2 = 500;
        public static int PointLevelUp3 = 2000;
        public static int PointLevelUp4 = 5000;
        public static int PointLevelUp5 = 10000;
        public static int PointLevelUp6 = 20000;      

        public static int PointAdded = 100;
        public static int PointEliminated = 50;

        public static UserControl PlayConstant;

        //public static double 
    }
}
