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

namespace PrimaryEducationSystem.Study.Lessons.PartOne
{
    public partial class Lession_4 : UserControl
    {
        int index;
        public Lession_4()
        {
            InitializeComponent();
        }
        private void HyperlinkButton_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            book_ST.Begin();
        }

        private void down_link_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void up_link_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void btap_link_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btap_ST.Begin();
        }

        private void link_music_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            music_ST.Begin();
        }

        private void book_link_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            book_ST.Stop();
        }

        private void btap_link_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btap_ST.Stop();
        }

        private void link_music_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            music_ST.Stop();
        }

        private void link_music_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BitmapImage imag_mute = new BitmapImage(new Uri("../Images/Lessons/loa_mute.png", UriKind.RelativeOrAbsolute));
            //image_m = image_music.Source;
            if (!audio1.IsMuted)
            {
                audio1.IsMuted = true;
                image_music.Source = imag_mute;
            }
            else
            {
                audio1.IsMuted = false;
                image_music.Source = new BitmapImage(new Uri("../Images/Lessons/loa.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void down_link_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (index == 1)
            {

                index = 2;
                lession4_ST.Stop();
                lession4_ST2.Begin();
                up_link.Visibility = Visibility.Visible;
                down_link.Visibility = Visibility.Visible;
                audio1.Stop();
                audio1.Source = new Uri(@"../Sounds/Lesson/Audio/Lession4/So2.mp3", UriKind.Relative);
                audio1.Play();
            }
            else
            {
                if (index == 2)
                {
                    index = 3;
                    // phan 3 cua bai
                    lession4_ST2.Stop();
                    lession4_ST3.Begin();
                    up_link.Visibility = Visibility.Visible;
                    down_link.Visibility = Visibility.Collapsed;
                    audio1.Stop();
                    audio1.Source = new Uri(@"../Sounds/Lesson/Audio/Lession4/So3.mp3", UriKind.Relative);
                    audio1.Play();
                }
                else
                {
                    up_link.Visibility = Visibility.Collapsed;
                    down_link.Visibility = Visibility.Visible;
                    audio1.Stop();
                    audio1.Source = new Uri(@"../Sounds/Lesson/Audio/Lession4/So1.mp3", UriKind.Relative);
                    audio1.Play();
                }
            }
        }

        private void up_link_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (index == 3)
            {

                index = 2;
                //phan 2 cua
                lession4_ST3.Stop();
                lession4_ST2.Begin();
                up_link.Visibility = Visibility.Visible;
                down_link.Visibility = Visibility.Visible;
                audio1.Stop();
                audio1.Source = new Uri(@"../Sounds/Lesson/Audio/Lession4/So2.mp3", UriKind.Relative);
                audio1.Play();
            }
            else
            {
                if (index == 2)
                {

                    index = 1;
                    // phan 1 cua bai
                    lession4_ST2.Stop();
                    lession4_ST.Begin();
                    up_link.Visibility = Visibility.Collapsed;
                    down_link.Visibility = Visibility.Visible;
                    audio1.Stop();
                    audio1.Source = new Uri(@"../Sounds/Lesson/Audio/Lession4/So1.mp3", UriKind.Relative);
                    audio1.Play();
                }
                else
                {
                    up_link.Visibility = Visibility.Visible;
                    down_link.Visibility = Visibility.Collapsed;
                    audio1.Stop();
                    audio1.Source = new Uri(@"../Sounds/Lesson/Audio/Lession4/So3.mp3", UriKind.Relative);
                    audio1.Play();

                }
            }
        }

        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            up_ST.Begin();
            down_ST.Begin();
            index = 1;
            //start_ST.Begin();
            up_link.Visibility = Visibility.Collapsed;
            down_link.Visibility = Visibility.Visible;
            lession4_ST.Begin();
            audio1.Play();
        }

        private void up_link_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_up.Play();
        }

        private void up_link_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_up.Stop();
        }

        private void down_link_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_down.Play();
        }

        private void down_link_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_down.Stop();
        }

        //private void link_start_Click(object sender, System.Windows.RoutedEventArgs e)
        //{

        //    //up_link.Visibility = Visibility.Visible;
        //    down_link.Visibility = Visibility.Visible;
        //}
    }
}
