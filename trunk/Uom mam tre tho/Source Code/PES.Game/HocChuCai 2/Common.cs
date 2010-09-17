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
using System.Collections.Generic;

namespace HocChuCai_2
{
    public class Common
    {
        public static int gameID = 0;

        public static int globalSeed = 0;

        public static List<int> GetRandomInt(int incMin, int excMax, int num)
        {
            List<int> lstRannum = new List<int>();
            for (int i = 0; i < num; i++)
            {
                Random rand = new Random(globalSeed);
                int randNum = 0;
                do
                {
                    randNum = rand.Next(incMin, excMax);
                } while (lstRannum.Contains(randNum));

                lstRannum.Add(randNum);
                globalSeed++;
            }

            return lstRannum;
        }
    }
}
