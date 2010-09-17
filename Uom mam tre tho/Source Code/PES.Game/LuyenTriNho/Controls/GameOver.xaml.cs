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
using LuyenTriNho.Codes;

namespace LuyenTriNho.Controls
{
    public partial class GameOver : UserControl
    {
        MapNumbersToImages ctrlNumberPoints;
        public GameOver()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(GameOver_Loaded);
        }

        void GameOver_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowPoints();
        }

        private void ShowPoints()
        {
            if (canvasMain.Children.Contains(ctrlNumberPoints) == true)
                canvasMain.Children.Remove(ctrlNumberPoints);
            ctrlNumberPoints = new MapNumbersToImages(GlobalVariables.Points, Constants.YellowNumber, 30, 30, true);
            ctrlNumberPoints.SetValue(Canvas.LeftProperty, (double)176);
            ctrlNumberPoints.SetValue(Canvas.TopProperty, (double)257);
            canvasMain.Children.Add(ctrlNumberPoints);
        }
    }
}
