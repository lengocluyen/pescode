using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace PesHome
{
    public partial class ParkUC : UserControl
    {
        public ParkUC()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        #region Animation
        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            EnteringST.Begin();
        }

        private void image_MouseLeave(object sender, MouseEventArgs e)
        {
            EnteringST.Stop();
        }
        #endregion

    }
}