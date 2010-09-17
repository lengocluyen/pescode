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
    public class Commons
    {
        static Random rd = new Random();
        public static int GetRandomNumber(int from, int to)
        {
            int returnResult = rd.Next(from, to + 1);
            if (returnResult == to + 1)
                return to;
            return returnResult;
        }   

        /// <summary>
        /// Function to get ramdom calculation. If any calculations be added. Change value of _to and add more case to switch - case.
        /// </summary>
        /// <returns></returns>
        public static AppEnum.Calculation GetRandomCalculation()
        {
            int _from = Convert.ToInt32(AppEnum.Calculation.mathAdd);
            int _to = Convert.ToInt32(AppEnum.Calculation.mathdEliminate);
            int randomResult;
            AppEnum.Calculation calculationResult = AppEnum.Calculation.mathAdd;

            randomResult = GetRandomNumber(_from, _to);

            switch (randomResult)
            {
                case 1:
                    calculationResult = AppEnum.Calculation.mathAdd;
                    break;
                case 2:
                    calculationResult = AppEnum.Calculation.mathdEliminate;
                    break;
            }

            return calculationResult;
        }

        public static double GetHeightToDrop(AppEnum.Level _level)
        {
            double result = 0;
            switch (_level)
            {
                case AppEnum.Level.level1:
                    result = AppConstant.Level1_Height_ToDrop;
                    break;
                case AppEnum.Level.level2:
                    result = AppConstant.Level2_Height_ToDrop;
                    break;
                case AppEnum.Level.level3:
                    result = AppConstant.Level3_Height_ToDrop;
                    break;
            }

            return result;
        }

        public static int GetPointsToAdd(AppEnum.Level _level)
        {
            int result = 0;
            switch (_level)
            {
                case AppEnum.Level.level1:
                    result = 100;
                    break;
                case AppEnum.Level.level2:
                    result = 250;
                    break;
                case AppEnum.Level.level3:
                    result = 500;
                    break;
            }

            return result;
        }

        public static int GetPointsToEliminate(AppEnum.Level _level)
        {
            int result = 0;
            switch (_level)
            {
                case AppEnum.Level.level1:
                    result = 60;
                    break;
                case AppEnum.Level.level2:
                    result = 100;
                    break;
                case AppEnum.Level.level3:
                    result = 200;
                    break;
            }

            return result;
        }

    } 
}
