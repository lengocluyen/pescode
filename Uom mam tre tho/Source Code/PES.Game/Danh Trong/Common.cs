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

namespace Danh_Trong
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

        public static string ConvertKeyToCharacter(Key key)
        {
            if (key == Key.A)
                return "a";
            else if (key == Key.B)
                return "b";
            else if (key == Key.C)
                return "c";
            else if (key == Key.D)
                return "d";
            else if (key == Key.E)
                return "e";
            else if (key == Key.F)
                return "f";
            else if (key == Key.G)
                return "g";
            else if (key == Key.H)
                return "h";
            else if (key == Key.I)
                return "i";
            else if (key == Key.J)
                return "j";
            else if (key == Key.K)
                return "k";
            else if (key == Key.L)
                return "l";
            else if (key == Key.M)
                return "m";
            else if (key == Key.N)
                return "n";
            else if (key == Key.O)
                return "o";
            else if (key == Key.P)
                return "p";
            else if (key == Key.Q)
                return "q";
            else if (key == Key.R)
                return "r";
            else if (key == Key.S)
                return "s";
            else if (key == Key.T)
                return "t";
            else if (key == Key.U)
                return "u";
            else if (key == Key.V)
                return "v";
            else if (key == Key.W)
                return "w";
            else if (key == Key.X)
                return "x";
            else if (key == Key.Y)
                return "y";
            else if (key == Key.Z)
                return "z";

            return "";
        }
    }
}
