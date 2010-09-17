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

namespace LuyenTriNho
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Home_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(Home_SizeChanged);
        }

        void Home_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PageScale.ScaleX = 1;
            PageScale.ScaleY = 1;

            // if the plugin is bigger than the minimum values set,
            // scale the contents of the silverlight application

            // get the ratios of plugin height/width to design-time height/width
            double heightRatio = e.NewSize.Height / this.canvasRoot.Height;
            double widthRatio = e.NewSize.Width / this.canvasRoot.Width;

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
            this.canvasRoot.RenderTransform = PageScale;
        }

        void Home_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetStartupNumber();
            this.PageStartUp();
            this.meHomePage.Play();
        }

        private void SetStartupNumber()
        {
            GlobalVariables.Guide = 3;
            GlobalVariables.Heart = 3;
            GlobalVariables.Level = 1;
            GlobalVariables.Points = 0;
        }

        private void PageStartUp()
        {
            this.storyboardDropText.Begin();
        }

        private void hplBtnPlay_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgBtnPlay.Visibility = Visibility.Collapsed;
            this.imgBtnPlaySeleted.Visibility = Visibility.Visible;
        }

        private void hplBtnUseGuide_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgBtnUseGuide.Visibility = Visibility.Collapsed;
            this.imgBtnUseGuideSelected.Visibility = Visibility.Visible;
        }

        private void hplBtnUseGuide_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgBtnUseGuide.Visibility = Visibility.Visible;
            this.imgBtnUseGuideSelected.Visibility = Visibility.Collapsed;
        }

        private void hplBtnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgCloseSelected.Visibility = Visibility.Visible;
            this.imgClose.Visibility = Visibility.Collapsed;
        }

        private void hplBtnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgCloseSelected.Visibility = Visibility.Collapsed;
            this.imgClose.Visibility = Visibility.Visible;
        }

        private void hplBtnUseGuide_Click(object sender, RoutedEventArgs e)
        {
            storyboardShowGuide.Begin();
            meOpenGuide.Play();
        }

        private void hplBtnClose_Click(object sender, RoutedEventArgs e)
        {
            storyboardShowGuide.Stop();
        }

        private void hplBtnPlay_Click(object sender, RoutedEventArgs e)
        {
            canvasRoot.Children.Clear();
            canvasRoot.Children.Add(new Play());
        }
        
        private void hplBtnPlay_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgBtnPlay.Visibility = Visibility.Visible;
            this.imgBtnPlaySeleted.Visibility = Visibility.Collapsed;
        }

        private void hplBtnMute_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GlobalVariables.IsMute == true)
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
            }
        }

        private void hplBtnMute_MouseLeave(object sender, MouseEventArgs e)
        {
            if (GlobalVariables.IsMute == true)
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Visible;
            }
            else
            {
                this.imgBtnSound.Visibility = Visibility.Visible;
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
            }
        }

        

        private void hplBtnMute_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalVariables.IsMute == false)
            {
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Visible;
                GlobalVariables.IsMute = true;
            }
            else
            {
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSound.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
                GlobalVariables.IsMute = false;
            }
        }
    }
}
