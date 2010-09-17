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

namespace Danh_Trong.Objects
{
    public class Script
    {
        string _character;
        int _position, _time;

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public string Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public Script() { }

        public Script(string character, int position, int time)
        {
            this.Character = character;
            this.Position = position;
            this.Time = time;
        }
    }
}
