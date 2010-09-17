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

namespace HocChuCai_2.Objects
{
    public partial class Number : UserControl
    {
        bool _isStatic = false;
        string _data = "0";

        public string Data
        {
            get { return _data; }
            set { _data = value; ShowNumber(_data); }
        }

        public Number(bool isStatic)
        {
            InitializeComponent();

            _isStatic = isStatic;
        }

        public void ShowNumber(string number)
        {
            // Sign
            if (!_isStatic)
            {
                try
                {
                    if (int.Parse(number) > 0)
                        this.LayoutRoot.Children.Add(GetNumberImage("plus"));
                    else
                        this.LayoutRoot.Children.Add(GetNumberImage("minus"));
                }
                catch { }
            }
            else
                ClearNumber();


            // Add number
            string num = number.ToString();
            for (int i = 0; i < num.Length; i++)
            {
                string c = num[i].ToString();
                LayoutRoot.Children.Add(GetNumberImage(c));
            }

            if (!_isStatic)
                this.stbAppear.Begin();
        }

        Image GetNumberImage(string c)
        {
            Image image = new Image();
            image.Width = 32;
            image.Height = 35;
            image.Source = new BitmapImage(new Uri(c + ".png", UriKind.Relative));
            image.Stretch = Stretch.Fill;

            return image;
        }

        private void stbAppear_Completed(object sender, EventArgs e)
        {
            (this.Parent as Canvas).Children.Remove(this);
        }

        void ClearNumber()
        {
            List<UIElement> lstUI = new List<UIElement>();
            foreach (UIElement ui in this.LayoutRoot.Children)
                if (ui is Image)
                    lstUI.Add(ui);

            foreach (UIElement ui in lstUI)
                this.LayoutRoot.Children.Remove(ui);
        }
    }
}
