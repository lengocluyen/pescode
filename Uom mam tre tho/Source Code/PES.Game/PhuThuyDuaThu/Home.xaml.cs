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
using PhuThuyDuaThu.Codes;
using PhuThuyDuaThu.Controls;

namespace PhuThuyDuaThu
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(Home_SizeChanged);
        }

        void Home_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PageScale.ScaleX = 1;
            PageScale.ScaleY = 1;

            // if the plugin is bigger than the minimum values set,
            // scale the contents of the silverlight application

            // get the ratios of plugin height/width to design-time height/width
            double heightRatio = e.NewSize.Height / this.canvasMain.Height;
            double widthRatio = e.NewSize.Width / this.canvasMain.Width;

            // if the height ratio is smaller than the width ratio
            if (heightRatio < widthRatio)
            {
                // set scale the content based on the height ratio
                PageScale.ScaleX = heightRatio;
                PageScale.ScaleY = heightRatio;
            }
            // if not, set scale based on the width ratio
            else
            {
                PageScale.ScaleX = widthRatio;
                PageScale.ScaleY = widthRatio;
            }
            // scale the content
            this.canvasMain.RenderTransform = PageScale;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartUp();
        }

        private void StartUp()
        {
            this.stbTextShow.Begin();
        }

        private void hplPlay_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgPlay.Visibility = Visibility.Collapsed;
            this.imgPlaySelected.Visibility = Visibility.Visible;
        }

        private void hplPlay_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgPlaySelected.Visibility = Visibility.Collapsed;
            this.imgPlay.Visibility = Visibility.Visible;
        }

        private void hplUseGuide_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgUseGuide.Visibility = Visibility.Collapsed;
            this.imgUseGuideSelected.Visibility = Visibility.Visible;
        }

        private void hplUseGuide_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgUseGuide.Visibility = Visibility.Visible;
            this.imgUseGuideSelected.Visibility = Visibility.Collapsed;
        }

        private void hplUseGuide_Click(object sender, RoutedEventArgs e)
        {
            this.canvasSomeBtn.Visibility = Visibility.Collapsed;
            this.stbGuide.Begin();
        }

        private void hplPlay_Click(object sender, RoutedEventArgs e)
        {
            this.canvasMain.Children.Clear();
            this.canvasMain.Children.Add(new Play());
        }
    }
}