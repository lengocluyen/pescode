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

namespace PhuThuyDuaThu.Codes
{
    public class GlobalVarialble
    {
        private static int _level = 1;
        private static int _points = 0;
        private static int _gameID;

        public static int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public static int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public static int GameID
        {
            get { return _gameID; }
            set { _gameID = value; }
        }
    }
}
