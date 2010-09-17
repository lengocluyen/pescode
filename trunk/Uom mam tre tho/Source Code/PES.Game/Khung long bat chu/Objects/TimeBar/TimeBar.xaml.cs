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
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Khung_long_bat_chu.Objects
{
    public partial class TimeBar : UserControl
    {
        public delegate void DelegateTimeUp();
        public DelegateTimeUp dlgTimeUp;

        DispatcherTimer _timer = new DispatcherTimer();
        ScaleTransform _scaleTransform = new ScaleTransform();        

        public TimeBar()
        {
            InitializeComponent();
            this.imgBarFill.RenderTransform = _scaleTransform;

            // Game-loop
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(200);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        bool _clockState = false;
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_clockState)
            {
                _clockState = false;
                this.imgClock.Source = new BitmapImage(new Uri("clock1.png", UriKind.Relative));
            }
            else
            {
                _clockState = true;
                this.imgClock.Source = new BitmapImage(new Uri("clock2.png", UriKind.Relative));
            }
        }

        public void Decrease(double delta)
        {
            _scaleTransform.ScaleX -= delta;
            if (_scaleTransform.ScaleX <= 0)
                dlgTimeUp();
        }

        public void Increase(double delta)
        {
            _scaleTransform.ScaleX += delta;
            if (_scaleTransform.ScaleX > 1)
                _scaleTransform.ScaleX = 1;
        }
    }
}
