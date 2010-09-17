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

namespace Khung_long_bat_chu.Objects
{
    public partial class TutBoard : UserControl
    {
        public delegate void DelegateStartGame();
        public DelegateStartGame dlgStartGame;

        public TutBoard()
        {
            InitializeComponent();
        }

        private void imgStart_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void imgStart_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void imgStart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            dlgStartGame();
        }

        public void PlayAnimation()
        {
            this.stbAppear.Begin();
        }
    }
}
