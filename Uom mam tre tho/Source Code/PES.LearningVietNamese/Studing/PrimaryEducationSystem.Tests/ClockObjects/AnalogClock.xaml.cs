using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TracNghiem
{
    public partial class AnalogClock : UserControl
    {
        private const string DigitalDisplayFormat = "{0} : {1}";

        public AnalogClock()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        private void SecondsHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.SecondsHandStoryboard.Begin();
            this.SecondsHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }

        private void MinutesHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinutesHandStoryboard.Begin();
            this.MinutesHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }

        private void HoursHandCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.HoursHandStoryboard.Begin();
            this.HoursHandStoryboard.Seek(DateTime.Now.TimeOfDay);
        }

        // Fires every 1 second while the DispatcherTimer is active.
        public void Each_Tick(object o, EventArgs sender)
        {
            digital.Text = String.Format("{0} : {1}", DateTime.Now.Hour.ToString("00"),DateTime.Now.Minute.ToString("00"));
        }

        private void StartTimer(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            myDispatcherTimer.Start();
        }
    }
}