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
using System.Reflection;
using System.Windows.Browser;
using PrimaryEducationSystem.Study.Lessons.PESServices;

namespace PrimaryEducationSystem.Study.Lessons.PartOne
{
    public partial class MainPartOne : UserControl
    {
        LearningServicesClient learningService = new LearningServicesClient();
        public static string lessonIndex;
        public static List<string> listLessonName;
        int i = int.Parse(lessonIndex);
        string webURL = PESCommons.parameters["webURL"];
        public MainPartOne()
        {
            InitializeComponent();

            learningService.WebURLCompleted += new EventHandler<WebURLCompletedEventArgs>(learningService_WebURLCompleted);
            learningService.WebURLAsync();
            idealPageSize = new Size(this.Width, this.Height);
        }

        void learningService_WebURLCompleted(object sender, WebURLCompletedEventArgs e)
        {
            if (e.Error == null)
                webURL = e.Result;
            else
                return;
        }

        private Size idealPageSize;

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Compare the current window to the ideal dimensions.
            double heightRatio = this.ActualHeight / idealPageSize.Height;
            double widthRatio = this.ActualWidth / idealPageSize.Width;

            // Create the transform.
            ScaleTransform scale = new ScaleTransform();

            // Determine the smallest dimension.
            // This preserves the aspect ratio.
            if (heightRatio < widthRatio)
            {
                scale.ScaleX = heightRatio;
                scale.ScaleY = heightRatio;
            }
            else
            {
                scale.ScaleX = widthRatio;
                scale.ScaleY = widthRatio;
            }

            // Apply the transform.
            this.RenderTransform = scale;
        }

        private void note_img_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            note_ST.Begin();
        }

        private void note_img_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            note_ST.Stop();
        }

        //------------------------------------------------
        private void Load_Control(string index)
        {
            this.TextBlock_Lessonname.Text = "";
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            UserControl newPage = (UserControl)(assembly.CreateInstance(
                type.Namespace + ".Lession_" + index));
            this.TextBlock_Lessonname.Text = "Bài " + (index + ": " + listLessonName[int.Parse(index) - 1].ToString());
            // Show the page.
            container.Child = newPage;
        }
        //-----------------------------------------------
        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Load_Control(lessonIndex);
        }

        private void Button_ChangeLesson_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.next_Button.Visibility = Visibility.Visible;
            this.prev_Button.Visibility = Visibility.Visible;
            int numMax = listLessonName.Count();
            if (next_Button.IsPressed == true)
            {
                if (i == numMax)
                {
                    this.next_Button.Visibility = Visibility.Collapsed;
                    return;
                }
                i++;
                Load_Control(i.ToString());
            }
            else
            {
                if (i == 1)
                {
                    this.prev_Button.Visibility = Visibility.Collapsed;
                    return;
                }
                i--;
                Load_Control(i.ToString());
            }
        }

        private void Button_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(webURL+"Learning/Maths.aspx", UriKind.RelativeOrAbsolute));
        }

        private void next_Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_next.Play();
        }

        private void next_Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_next.Stop();
        }

        private void prev_Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_prev.Play();
        }

        private void prev_Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_prev.Stop();
        }

        private void Button_Home_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_home.Play();
        }

        private void Button_Home_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_home.Stop();
        }

    }
}
