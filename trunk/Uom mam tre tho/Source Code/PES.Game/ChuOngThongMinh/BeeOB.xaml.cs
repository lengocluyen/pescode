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
    public partial class BeeOB : UserControl
    {
        public BeeOB()
        {
            InitializeComponent();
            BeeFly();
        }

        public void BeeFly()
        {
            StbFlying.RepeatBehavior = RepeatBehavior.Forever;
            StbFlying.Begin();
            StbEyeClosed.RepeatBehavior = RepeatBehavior.Forever;
            StbEyeClosed.Begin();
        }
    }
}