using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PhuThuyDuaThu.Codes
{
    public class Commons
    {
        static Random rd = new Random();
        private static List<int> allMailBoxNumber = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

        public static int GetRandomNumberMailBox(int from, int to)
        {           
            getrd:
            int returnResult = rd.Next(from, to + 1);
            for (int i = 0; i < Constants.ArrRandomNumber.Count; i++)
            {
                if (Constants.ArrRandomNumber[i] == returnResult)
                    goto getrd;
            }

            Constants.ArrRandomNumber.Add(returnResult);
            Constants.ArrayCurrentIndex++;
            if (returnResult == to + 1)
                return to;
            return returnResult;
        }

        public static int GetRandomNumber(int from, int to)
        {
            int returnResult = rd.Next(from, to);            
            if (returnResult == to)
                return to - 1;
            return returnResult;
        }

        public static int GetSecondTimeOutByLevel(int level)
        {
            int result = 0;
            switch (level)
            {
                case 1:
                    result = Constants.TimeOutLevel1;
                    break;
                case 2:
                    result = Constants.TimeOutLevel2;
                    break;
                case 3:
                    result = Constants.TimeOutLevel3;
                    break;
                case 4:
                    result = Constants.TimeOutLevel4;
                    break;
                case 5:
                    result = Constants.TimeOutLevel5;
                    break;
                case 6:
                    result = Constants.TimeOutLevel6;
                    break;
            }

            return result;
        }

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
            }
            return result;
        }

        public static void AddToMailBoxListNumber(int number)
        {
            allMailBoxNumber.Add(number);
        }

        public static void RemoveItemFromMailBoxListNumber(int number)
        {
            for (int i = 0; i < allMailBoxNumber.Count; i++)
            {
                if (allMailBoxNumber[i] == number)
                {
                    allMailBoxNumber.RemoveAt(i);
                    break;
                }
            }
        }
    }
}