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
using PhuThuyDuaThu.Codes;

namespace PhuThuyDuaThu.Controls
{
    public partial class MapNumbersToImages : UserControl
    {
        public MapNumbersToImages()
        {
            InitializeComponent();
        }

        public MapNumbersToImages(int numbers, string[] listNumberImage, double imgHeight, double imgWidth, bool isTen)
        {
            InitializeComponent();
            
            string strNumber = numbers.ToString();
            if (isTen == true)
            {
                if (numbers < 10)
                    strNumber = "0" + numbers.ToString();
            }           
            int countChar = strNumber.Length;

            for (int i = 0; i < strNumber.Length; i++)
            {
                int num = int.Parse(strNumber.Substring(i, 1));
                ExportImage(num, listNumberImage, imgHeight, imgWidth);
            }
        }

        private void ExportImage(int number, string[] listNumberImage, double imgHeight, double imgWidth)
        {
            Image img = new Image();
            switch (number)
            {
                case 0:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[0].ToString(), UriKind.Relative));
                    break;
                case 1:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[1].ToString(), UriKind.Relative));
                    break;
                case 2:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[2].ToString(), UriKind.Relative));
                    break;
                case 3:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[3].ToString(), UriKind.Relative));
                    break;
                case 4:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[4].ToString(), UriKind.Relative));
                    break;
                case 5:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[5].ToString(), UriKind.Relative));
                    break;
                case 6:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[6].ToString(), UriKind.Relative));
                    break;
                case 7:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[7].ToString(), UriKind.Relative));
                    break;
                case 8:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[8].ToString(), UriKind.Relative));
                    break;
                case 9:
                    img.Source = new BitmapImage(new Uri("../" + listNumberImage[9].ToString(), UriKind.Relative));
                    break;
            }
            img.Height = imgHeight;
            img.Width = imgWidth;
            spMain.Children.Add(img);            
        }
    }
}