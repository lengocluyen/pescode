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
    public partial class UseGuide : UserControl
    {
        public UseGuide()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(UseGuide_Loaded);            
        }

        void UseGuide_Loaded(object sender, RoutedEventArgs e)
        {
            this.Startup();
        }

        private void Startup()
        {
            this.stbClould.RepeatBehavior = RepeatBehavior.Forever;
            this.stbClould.Begin();
        }
    }
}
