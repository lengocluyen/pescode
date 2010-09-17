/****************************************************************************

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

-- Copyright 2009 Terence Tsang
-- admin@shinedraw.com
-- http://www.shinedraw.com
-- Your Flash vs Silverlight Repositry

****************************************************************************/



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
using System.Windows.Browser;
using MultiLanguages;
using ITBusSilverlight.PESServicesSession;
/*
*	A Fish Eye Menu in C#
*   from shinedraw.com
*   
*   MODIFY TO VERTICAL MENU BY HYUTARS
*/

namespace ITBusSilverlight
{
    public partial class FishEyeMenu : UserControl
    {

        Languages lang;
        PESServicesSessionSoapClient getSession = new PESServicesSessionSoapClient(); 
        private static String[] IMAGES = { "Images/home.png", "Images/calendar.png", "Images/blog.png" };    // images
        private static String[] IMAGENAMES = { "imgHome", "imgLessionGroup", "writing" };    // image's names
        private static double MARGIN = 30;			// Margin between images
        private static double IMAGE_WIDTH = 90;	// Image width
        private static double IMAGE_HEIGHT = 90;	// Image height
        private static double MAX_SCALE = 2.5;		// Max scale 
        private static double MULTIPLIER = 60;		// Control the effectiveness of the mouse

        private static MediaElement media_HomePage;
        private static MediaElement media_DSNhom;
        private static MediaElement media_HocVietChu;

        string webURL = ITBusSilverlightCommons.parameters["webURL"].ToString();

        private List<Image> _images = new List<Image>();		// Store the added images

        Page _root;

        public FishEyeMenu(Page root)
        {
            _root = root;
            InitializeComponent();
            this.Width = IMAGE_WIDTH;
            this.Height = IMAGE_HEIGHT * IMAGES.Length;

            getSession.GetLanguageStateCompleted += new EventHandler<GetLanguageStateCompletedEventArgs>(getSession_GetLanguageStateCompleted);
            getSession.GetLanguageStateAsync();
            

            // start the mouse event handler
            this.LayoutRoot.MouseMove += new MouseEventHandler(FishEyeMenu_MouseMove);
            this.LayoutRoot.MouseLeave += new MouseEventHandler(LayoutRoot_MouseLeave);
        }

        void getSession_GetLanguageStateCompleted(object sender, GetLanguageStateCompletedEventArgs e)
        {
            //if (e.Result == 0)
                lang = new Languages(EnumLanguages.Vietnamese);
            //else
              //lang = new Languages(EnumLanguages.English);

            //add media to play sound
            addMedia();

            // add the images to the stage
            addImages();
        }

        /////////////////////////////////////////////////////        
        // Handlers 
        /////////////////////////////////////////////////////	

        // mouse event handler
        void FishEyeMenu_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < _images.Count; i++)
            {
                Image image = _images[i];


                // compute the scale of each image according to the mouse position
                double imageScale = MAX_SCALE - Math.Min(MAX_SCALE - 1, Math.Abs(e.GetPosition(this).Y - ((double)image.GetValue(Canvas.TopProperty) + image.Width / 2)) / MULTIPLIER);
                // resize the image
                resizeImage(image, IMAGE_WIDTH * imageScale, IMAGE_HEIGHT * imageScale, i, IMAGES.Length);

                // sort the children according to the scale
                image.SetValue(Canvas.ZIndexProperty, (int)Math.Round(IMAGE_HEIGHT * imageScale));
            }
        }

        /////////////////////////////////////////////////////        
        // Public Methods 
        /////////////////////////////////////////////////////	

        /////////////////////////////////////////////////////        
        // Private Methods 
        /////////////////////////////////////////////////////	

        //add the mediaElement to this menu
        private void addMedia()
        {
            media_HomePage = new MediaElement();
            media_HomePage.Source = new Uri("Sounds/Link_GoHomepage.mp3", UriKind.Relative);
            media_HomePage.AutoPlay = false;
            LayoutRoot.Children.Add(media_HomePage);

            media_HocVietChu = new MediaElement();
            media_HocVietChu.Source = new Uri("Sounds/Link_HocVietChu.mp3", UriKind.Relative);
            media_HocVietChu.AutoPlay = false;
            LayoutRoot.Children.Add(media_HocVietChu);

            media_DSNhom = new MediaElement();
            string abc = "Sounds/Link_DSNhomBH.mp3";
            media_DSNhom.Source = new Uri(abc, UriKind.Relative);
            media_DSNhom.AutoPlay = false;
            LayoutRoot.Children.Add(media_DSNhom);
        }

        // add the images to the stage
        private void addImages()
        {
            double top = 0;
            double left = 0;
            for (int i = 0; i < IMAGES.Length; i++)
            {
                string url = IMAGES[i];
                string name = IMAGENAMES[i];

                Image image = new Image();
                image.Source = new BitmapImage(new Uri(url, UriKind.Relative));

                // resize the image
                resizeImage(image, IMAGE_WIDTH, IMAGE_HEIGHT, i, IMAGES.Length);
                image.SetValue(Canvas.TopProperty, top);
                image.SetValue(Canvas.LeftProperty, left);

                image.Name = name;
                //image.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip(GetNameBaseOnID(name)));

                image.MouseEnter += new MouseEventHandler(image_MouseEnter);
                image.MouseLeave += new MouseEventHandler(image_MouseLeave);
                image.MouseLeftButtonUp += new MouseButtonEventHandler(image_MouseLeftButtonUp);


                top += image.Height + MARGIN;

                LayoutRoot.Children.Add(image);
                _images.Add(image);
            }
        }

        string GetNameBaseOnID(string id)
        {
            switch (id)
            {
                case "imgHome":
                    return "Trang chủ";
                case "imgLessionGroup":
                    return "Danh sách nhóm bài học";
                case "writing":
                    return "Học cách viết chữ";
                default:
                    return "";
            }
        }

        void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            switch (img.Name)
            {
                case "imgHome":
                    HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Learning.aspx",UriKind.RelativeOrAbsolute));
                    break;
                case "imgLessionGroup":
                    _root.LayoutRoot.Children.Clear();
                    ITBusSilverlightCommons.parameters.Remove("group");
                    _root.LayoutRoot.Children.Add(new Lessions(_root));
                    break;
                case "writing":
                    HtmlPage.Window.Navigate(new Uri(webURL + "LearningVietNamese/writing.htm",UriKind.RelativeOrAbsolute));
                    break;
                default:
                    break;
            }
        }

        void image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            //string abc = media_HomePage.CurrentState.ToString();
            //MessageBox.Show(abc);
        }

        void image_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Image getImage = (Image)sender;
            CallSoud(getImage.Name);
        }

        // resize the image
        private void resizeImage(Image image, double imageWidth, double imageHeight, int index, int total)
        {
            image.Width = imageWidth;
            image.Height = imageHeight;

            //image.SetValue(Canvas.LeftProperty, image.Width / 5);
            //image.SetValue(Canvas.TopProperty, Height / 2 + (index - (total - 1) / 2) * (MARGIN + IMAGE_HEIGHT) - image.Height / 2);
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            this.LayoutRoot.Children.Clear();
            _images.Clear();
            addMedia();
            addImages();
            this.LayoutRoot.MouseMove += new MouseEventHandler(FishEyeMenu_MouseMove);
        }

        private void CallSoud(string xNameImage)
        {
            if (xNameImage == IMAGENAMES[0])
            {
                media_DSNhom.Stop();
                media_HocVietChu.Stop();

                media_HomePage.Stop();
                media_HomePage.Play(); 
            }

            if (xNameImage == IMAGENAMES[1])
            {
                media_HomePage.Stop();
                media_HocVietChu.Stop();

                media_DSNhom.Stop();
                media_DSNhom.Play(); 
            }

            if (xNameImage == IMAGENAMES[2])
            {
                media_DSNhom.Stop();
                media_HomePage.Stop();

                media_HocVietChu.Stop();
                media_HocVietChu.Play();                 
            }
        }

        private void btn_Click_Click(object sender, RoutedEventArgs e)
        {                       
        }
    }
}
