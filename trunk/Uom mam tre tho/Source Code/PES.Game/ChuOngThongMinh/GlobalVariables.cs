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
    public class GlobalVariables
    {
        private static bool startState;
        private static int points;
        private static int _gameID;

        public static bool Start
        {
            get { return startState; }
            set { startState = value; }
        }

        public static int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static int GameID
        {
            get { return _gameID; }
            set { _gameID = value; }
        }
    }
}
