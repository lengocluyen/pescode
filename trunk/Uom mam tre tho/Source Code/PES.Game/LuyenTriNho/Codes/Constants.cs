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

namespace LuyenTriNho.Codes
{
    public class Constants
    {
        #region List number image
        public static string[] YellowNumber = new string[] { "Images/Numbers/ZeroYellow.png", "Images/Numbers/OneYellow.png", "Images/Numbers/TwoYellow.png", "Images/Numbers/ThreeYellow.png", "Images/Numbers/FourYellow.png", "Images/Numbers/FiveYellow.png", "Images/Numbers/SixYellow.png", "Images/Numbers/SevenYellow.png", "Images/Numbers/EightYellow.png", "Images/Numbers/NineYellow.png" };
        public static string[] BoldYellowNumber = new string[] { "Images/Numbers/ZeroBYellow.png", "Images/Numbers/OneBYellow.png", "Images/Numbers/TwoBYellow.png", "Images/Numbers/ThreeBYellow.png", "Images/Numbers/FourBYellow.png", "Images/Numbers/FiveBYellow.png", "Images/Numbers/SixBYellow.png", "Images/Numbers/SevenBYellow.png", "Images/Numbers/EightBYellow.png", "Images/Numbers/NineBYellow.png" };
        public static string[] GreenNumber = new string[] { "Images/Numbers/ZeroGreen.png", "Images/Numbers/OneGreen.png", "Images/Numbers/TwoGreen.png", "Images/Numbers/ThreeGreen.png", "Images/Numbers/FourGreen.png", "Images/Numbers/FiveGreen.png", "Images/Numbers/SixGreen.png", "Images/Numbers/SevenGreen.png", "Images/Numbers/EightGreen.png", "Images/Numbers/NineGreen.png" };
        public static string[] PinkNumber = new string[] { "Images/Numbers/ZeroPink.png", "Images/Numbers/OnePink.png", "Images/Numbers/TwoPink.png", "Images/Numbers/ThreePink.png", "Images/Numbers/FourPink.png", "Images/Numbers/FivePink.png", "Images/Numbers/SixPink.png", "Images/Numbers/SevenPink.png", "Images/Numbers/EightPink.png", "Images/Numbers/NinePink.png" };
        #endregion

        #region Diem thuong khi LevelUp
        public static int PointLevelUp1 = 500;
        public static int PointLevelUp2 = 1000;
        public static int PointLevelUp3 = 2000;
        public static int PointLevelUp4 = 5000;
        public static int PointLevelUp5 = 10000;
        public static int PointLevelUp6 = 20000;
        public static int PointLevelUp7 = 40000;
        #endregion

        #region Thời gian theo từng Level
        public static int TimeLineLevel1 = 50;
        public static int TimeLineLevel2 = 50;
        public static int TimeLineLevel3 = 40;
        public static int TimeLineLevel4 = 30;
        public static int TimeLineLevel5 = 20;
        public static int TimeLineLevel6 = 10;
        public static int TimeLineLevel7 = 10;
        #endregion

        #region Số chữ số tương ứng với mỗi Level
        public static int QuestionNumLevel1 = 1;
        public static int QuestionNumLevel2 = 2;
        public static int QuestionNumLevel3 = 3;
        public static int QuestionNumLevel4 = 5;
        public static int QuestionNumLevel5 = 5;
        public static int QuestionNumLevel6 = 6;
        public static int QuestionNumLevel7 = 7;
        #endregion

        //Thời gian để xem sau mỗi câu hỏi
        public static int TimeSecondToWatch = 2;        
        public static int MaximumLevel = 7;

        #region Thời gian xem hướng dẫn mỗi Level
        public static int TimeWatchGuideLevel1 = 2;
        public static int TimeWatchGuideLevel2 = 3;
        public static int TimeWatchGuideLevel3 = 4;
        public static int TimeWatchGuideLevel4 = 4;
        public static int TimeWatchGuideLevel5 = 4;
        public static int TimeWatchGuideLevel6 = 4;
        public static int TimeWatchGuideLevel7 = 4;
        #endregion
    }
}
