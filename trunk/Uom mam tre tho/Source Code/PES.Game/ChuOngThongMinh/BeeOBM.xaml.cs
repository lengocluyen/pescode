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

namespace ChuOngThongMinh
{
    public partial class BeeOBM : UserControl
    {
        
        public BeeOBM()
        {
            InitializeComponent();
            BeeFly();            
        }

        public void BeeFly()
        {
            StbFlying.RepeatBehavior = RepeatBehavior.Forever;
            StbFlying.Begin();
        }

        public void BeeTired()
        {
            StbTired.RepeatBehavior = RepeatBehavior.Forever;
            StbTired.Begin();
        }

        public void BeeStrong()
        {
            StbTired.Stop();            
        }
        /// <summary>
        /// Bee Drop Ball
        /// </summary>
        /// <param name="to">asign value "To" in DoubleAnimation</param>
        public void BeeDropBall(double toAsigned)
        {
            daDropballNumber.To = toAsigned;
            daDropballText.To = toAsigned;
            stbDropBall.Begin();
            stbDropBall.Completed += new EventHandler(stbDropBall_Completed);
        }

        public void BeeLostBall()
        {
            imgNumber.Visibility = Visibility.Collapsed;
            tblNumber.Visibility = Visibility.Collapsed;
        }

        public void BeeGetBall()
        {
            imgNumber.Visibility = Visibility.Visible;
            tblNumber.Visibility = Visibility.Visible;
        }

        void stbDropBall_Completed(object sender, EventArgs e)
        {            
            stbDropBall.Stop();
            this.BeeStrong();
        }

        public void AddNumberToBall(string _number)
        {
            tblNumber.Text = _number;
        }
    }
}