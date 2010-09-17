using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Khung_long_bat_chu.Objects
{
    public partial class Balloon : UserControl
    {
        public delegate void DelegateClick(Balloon balloon);
        public DelegateClick dlgClick;
        public delegate void DelegateClickCompleted(Balloon balloon);
        public DelegateClickCompleted dlgClickCompleted;

        string[] arrBalloon = new string[] { "balloonBlue.png", "balloonBlue2.png", "balloonBrown.png", "balloonGreen.png",
                                    "balloonGreen.png", "balloonPink.png", "balloonWhite.png", "balloonYellow.png" };

        Color[] arrColors = new Color[] { Colors.Black, Colors.Blue, Colors.Brown, Colors.Cyan, Colors.DarkGray, Colors.Gray, Colors.Green,
                                        Colors.LightGray, Colors.Magenta, Colors.Orange, Colors.Purple, Colors.Red, Colors.White};

        int randBalloon, randColor;

        public Balloon(string character)
        {
            InitializeComponent();
            this.LayoutRoot.MouseEnter += new MouseEventHandler(LayoutRoot_MouseEnter);
            this.LayoutRoot.MouseLeave += new MouseEventHandler(LayoutRoot_MouseLeave);
            this.LayoutRoot.MouseLeftButtonUp += new MouseButtonEventHandler(LayoutRoot_MouseLeftButtonUp);

            randBalloon = Common.GetRandomInt(0, arrBalloon.Length, 1)[0];
            randColor = Common.GetRandomInt(0, arrColors.Length, 1)[0];

            this.imgBalloon.Source = new BitmapImage(new Uri(arrBalloon[randBalloon], UriKind.Relative));
            this.txtChar.Text = character;
            this.txtChar.Foreground = new SolidColorBrush(arrColors[randColor]);
            this.txtChar.SetValue(Canvas.LeftProperty, (this.LayoutRoot.Width - this.txtChar.ActualWidth) / 2);
            this.txtChar.SetValue(Canvas.TopProperty, (this.LayoutRoot.Height - this.txtChar.ActualHeight - 29) / 2);
        }

        void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dlgClick(this);           
        }

        void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        void LayoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        public void Boom()
        {
            this.txtChar.Visibility = Visibility.Collapsed;

            this._effectSound.Source = new Uri("/Sound/boom.mp3", UriKind.Relative);

            // Game-loop
            DispatcherTimer _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        int _boomIndex = 0;
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_boomIndex == 0)
                this.imgBalloon.Source = new BitmapImage(new Uri(arrBalloon[randBalloon].Replace(".png", "Boom.png"), UriKind.Relative));
            else if (_boomIndex == 1)
                this.imgBalloon.Source = new BitmapImage(new Uri("boom1.png", UriKind.Relative));
            else if (_boomIndex == 2)
                this.imgBalloon.Source = new BitmapImage(new Uri("boom2.png", UriKind.Relative));
            else if (_boomIndex == 3)
            {
                (this.Parent as Canvas).Children.Remove(this);
                dlgClickCompleted(this);
            }
            _boomIndex++;
        }
    }
}
