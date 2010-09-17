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
    public class GlobalVariables
    {
        private static int _gameID = 0;

        private static int _level = 1;
        private static int _points = 0;
        private static bool _isMute = false;
        private static int _heart = 3;
        private static int _guide = 3;

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

        public static int Heart
        {
            get { return _heart; }
            set { _heart = value; }
        }

        public static int Guide
        {
            get { return _guide; }
            set { _guide = value; }
        }

        public static bool IsMute
        {
            get { return _isMute; }
            set { _isMute = value; }
        }

        public static int GameID
        {
            get { return _gameID; }
            set { _gameID = value; }
        }
    }
}
