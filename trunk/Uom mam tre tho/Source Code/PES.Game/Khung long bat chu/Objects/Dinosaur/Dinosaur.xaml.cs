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

namespace Khung_long_bat_chu.Objects
{
    public partial class Dinosaur : UserControl
    {
        ScaleTransform _scaleTransfrom = new ScaleTransform();
        DispatcherTimer _timer = new DispatcherTimer();
        private bool _isRunRight = true;
        bool _isRunning = false;

        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }

        public bool IsRunRight
        {
            get { return _isRunRight; }
            set { _isRunRight = value; }
        }

        public Dinosaur()
        {
            InitializeComponent();

            _scaleTransfrom.CenterX = this.LayoutRoot.Width / 2;
            _scaleTransfrom.CenterY = this.LayoutRoot.Height / 2;
            this.RenderTransform = _scaleTransfrom;

            // Event
            this.stbHit.Completed += new EventHandler(stbHit_Completed);
        }

        public void Run(bool isRunRight)
        {
            IsRunRight = isRunRight;
            IsRunning = true;

            this.imgHand.Visibility = Visibility.Visible;
            this.imgSot.Visibility = Visibility.Visible;
            this.imgSot.Opacity = 1;

            this.imgCharStand.Visibility = Visibility.Collapsed;

            if (this.imgCharRun1.Visibility == Visibility.Collapsed)
            {
                this.imgCharRun1.Visibility = Visibility.Visible;
                this.imgCharRun2.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.imgCharRun1.Visibility = Visibility.Collapsed;
                this.imgCharRun2.Visibility = Visibility.Visible;
            }

            if (!IsRunRight)
                _scaleTransfrom.ScaleX = -1;
            else
                _scaleTransfrom.ScaleX = 1;

            this.stbRunRight.Begin();
        }

        public void Stand()
        {
            IsRunning = false;

            this.imgCharRun1.Visibility = Visibility.Collapsed;
            this.imgCharRun2.Visibility = Visibility.Collapsed;
            this.imgHand.Visibility = Visibility.Collapsed;
            this.imgSot.Visibility = Visibility.Collapsed;

            this.imgCharStand.Visibility = Visibility.Visible;

            this.stbRunRight.Stop();
        }

        public void Hit()
        {
            this._effectSound.Source = new Uri("/Sound/hit.mp3", UriKind.Relative);

            Run(IsRunRight);
            this.imgSot2.Visibility = Visibility.Visible;
            this.stbHit.Begin();
        }

        void stbHit_Completed(object sender, EventArgs e)
        {
            this.imgSot2.Visibility = Visibility.Collapsed;
        }
    }
}
