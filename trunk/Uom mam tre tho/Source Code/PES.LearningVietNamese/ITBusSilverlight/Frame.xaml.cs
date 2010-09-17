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
using System.Windows.Media.Imaging;

namespace ITBusSilverlight
{
    public partial class Frame : UserControl
    {
        public Frame()
        {
            InitializeComponent();

            Image image = new Image();
            
            image.Name = "imgKhungx";
            image.Source = new BitmapImage(new Uri("Images/home.png", UriKind.Relative));



            double width = Application.Current.Host.Content.ActualWidth;
            double height = Application.Current.Host.Content.ActualHeight;

            image.Width = width / 1.6;
            image.Height = height / 1.15;
            image.Stretch = Stretch.Fill;

            double left, top;
            left = width / 1.15 - image.Width;
            top = (height - image.Height) / 3;

            Canvas.SetLeft(image, left);
            Canvas.SetTop(image, top);

            this.LayoutRoot.Children.Add(image);
        }

        TransformGroup GetDefaultTransformGroup()
        {
            ScaleTransform scale = new ScaleTransform();
            SkewTransform skew = new SkewTransform();
            RotateTransform rotate = new RotateTransform();
            TranslateTransform translate = new TranslateTransform();

            TransformGroup tg = new TransformGroup();
            tg.Children.Add(scale);
            tg.Children.Add(skew);
            tg.Children.Add(rotate);
            tg.Children.Add(translate);

            return tg;
        }
    }
}
