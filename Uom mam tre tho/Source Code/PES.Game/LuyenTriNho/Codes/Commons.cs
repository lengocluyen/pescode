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
    public class Commons
    {
        static Random rd = new Random();

        public static int GetRandomNumber(int from, int to)
        {
            int returnResult = rd.Next(from, to);
            if (returnResult == to)
                return to - 1;
            return returnResult;
        }

        /// <summary>
        /// Điểm thưởng khi vượt qua một Level
        /// </summary>
        /// <param name="level">Level hiện tại</param>
        /// <returns></returns>
        public static int GetPointAddedWhenLevelUp(int level)
        {
            int result = 0;
            switch (level)
            {
                case 1:
                    result = Constants.PointLevelUp1;
                    break;
                case 2:
                    result = Constants.PointLevelUp2;
                    break;
                case 3:
                    result = Constants.PointLevelUp3;
                    break;
                case 4:
                    result = Constants.PointLevelUp4;
                    break;
                case 5:
                    result = Constants.PointLevelUp5;
                    break;
                case 6:
                    result = Constants.PointLevelUp6;
                    break;
                case 7:
                    result = Constants.PointLevelUp7;
                    break;
            }
            return result;
        }

        public static int GetTimeLineWhenLevelUp(int level)
        {
            int result = 0;
            switch (level)
            {
                case 1:
                    result = Constants.TimeLineLevel1;
                    break;
                case 2:
                    result = Constants.TimeLineLevel2;
                    break;
                case 3:
                    result = Constants.TimeLineLevel3;
                    break;
                case 4:
                    result = Constants.TimeLineLevel4;
                    break;
                case 5:
                    result = Constants.TimeLineLevel5;
                    break;
                case 6:
                    result = Constants.TimeLineLevel6;
                    break;
                case 7:
                    result = Constants.TimeLineLevel7;
                    break;
            }
            return result;
        }

        public static int GetNumOfQuestionPerLevel(int level)
        {
            int result = 0;
            switch (level)
            {
                case 1:
                    result = Constants.QuestionNumLevel1;
                    break;
                case 2:
                    result = Constants.QuestionNumLevel2;
                    break;
                case 3:
                    result = Constants.QuestionNumLevel3;
                    break;
                case 4:
                    result = Constants.QuestionNumLevel4;
                    break;
                case 5:
                    result = Constants.QuestionNumLevel5;
                    break;
                case 6:
                    result = Constants.QuestionNumLevel6;
                    break;
                case 7:
                    result = Constants.QuestionNumLevel7;
                    break;
            }
            return result;
        }

        public static int GetTimeToGuideByLevel(int level)
        {
            int result = 0;
            switch (level)
            {
                case 1:
                    result = Constants.TimeWatchGuideLevel1;
                    break;
                case 2:
                    result = Constants.TimeWatchGuideLevel2;
                    break;
                case 3:
                    result = Constants.TimeWatchGuideLevel3;
                    break;
                case 4:
                    result = Constants.TimeWatchGuideLevel4;
                    break;
                case 5:
                    result = Constants.TimeWatchGuideLevel5;
                    break;
                case 6:
                    result = Constants.TimeWatchGuideLevel6;
                    break;
                case 7:
                    result = Constants.TimeWatchGuideLevel7;
                    break;
            }
            return result;
        }
    }
}
