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
using System.Text;
using System.Windows.Browser;
using System.Windows.Media.Imaging;
using PrimaryEducationSystem.Study.Lessons.PESServices;
using PrimaryEducationSystem.Study.Lessons.PESServicesSession;

namespace PrimaryEducationSystem.Study.Lessons
{
    public class ListLesson
    {
        string stt;

        public string Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        string list;

        public string List
        {
            get { return list; }
            set { list = value; }
        }
        public ListLesson(string length, string i)
        {
            this.stt = length;
            this.list = i;
        }
    }

    public partial class MainPage : UserControl
    {
        private static IList<Part> partList;
        private static IList<Lesson> lessonList;
        string webURL = PESCommons.parameters["webURL"];
        private static int partIndex = -1;

        int partID = -1;

        LearningServicesClient learningServices = new LearningServicesClient();
        PESServicesSessionSoapClient getSession = new PESServicesSessionSoapClient();

        bool a = false;


        public MainPage()
        {
            InitializeComponent();

            getSession.GetUserLoginIDCompleted += new EventHandler<GetUserLoginIDCompletedEventArgs>(getSession_GetUserLoginIDCompleted);
            getSession.GetUserLoginIDAsync();

            learningServices.SubjectGetByNameCompleted += new EventHandler<SubjectGetByNameCompletedEventArgs>(learningServices_SubjectGetByNameCompleted);
            learningServices.PartGetAllWithSubjectCompleted += new EventHandler<PartGetAllWithSubjectCompletedEventArgs>(learningServices_PartGetAllWithSubjectCompleted);
            learningServices.LessonGetAllWithPartCompleted += new EventHandler<LessonGetAllWithPartCompletedEventArgs>(learningServices_LessonGetAllWithPartCompleted);
        }

        private void AddPart(double top, double left, string id, string text, string partNum, string img)
        {
            PartList pl = new PartList();
            pl.Id = id;
            pl.PartName = text;
            pl._image.Source = new BitmapImage(new Uri("../Images/Studying/Data/OneClass/" + img, UriKind.RelativeOrAbsolute));
            pl.TextBolock_PartNum.Text = partNum;

            pl.SetValue(Canvas.TopProperty, top);
            pl.SetValue(Canvas.LeftProperty, left);

            this.PartCanvas.Children.Add(pl);
            pl.MouseLeftButtonDown += new MouseButtonEventHandler(pl_MouseLeftButtonDown);
            pl.MouseEnter += new MouseEventHandler(pl_MouseEnter);
            pl.MouseLeave += new MouseEventHandler(pl_MouseLeave);
            pl.MouseMove += new MouseEventHandler(pl_MouseMove);
        }

        void pl_MouseMove(object sender, MouseEventArgs e)
        {

            PartList pl = sender as PartList;
            Canvas cv = (Canvas)pl.Parent;

            Point p = e.GetPosition(cv);
            
            this.TextBlock_PartName.SetValue(Canvas.LeftProperty, p.X);
            this.TextBlock_PartName.SetValue(Canvas.TopProperty, p.Y);
        }

        void pl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.TextBlock_PartName.Text = "";
        }

        void pl_MouseEnter(object sender, MouseEventArgs e)
        {
            PartList pl = sender as PartList;
            this.TextBlock_PartName.Text = pl.PartName;
        }

        void pl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PartList pl = sender as PartList;
            learningServices.LessonGetAllWithPartAsync(int.Parse(pl.Id));
        }

        void learningServices_LessonGetAllWithPartCompleted(object sender, LessonGetAllWithPartCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                List<ListLesson> list = new List<ListLesson>();
                for (int i = 0; i < e.Result.Count; i++)
                {
                    int k = i + 1;
                    ListLesson ls = new ListLesson("Bài " + k, e.Result[i].LessonName);
                    list.Add(ls);
                }
                lessonList = e.Result;
                ListBox_Lesson.ItemsSource = list;
            }
            else
                return;
        }

        //Get all part by sibject
        void learningServices_PartGetAllWithSubjectCompleted(object sender, PartGetAllWithSubjectCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                partList = e.Result;
                double top = 5;
                double left = 5;
                int i = 1;
                foreach (Part p in partList)
                {
                    if (i == 4)
                    {
                        i = 1;
                        top += 110;
                        left = 5;
                    }
                    AddPart(top, left, p.PartID.ToString(), p.PartName, p.PartNum, p.PartImg);
                    i++;
                    left += 110;
                }
            }
            else
                return;
        }
        //Get subject
        void learningServices_SubjectGetByNameCompleted(object sender, SubjectGetByNameCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                learningServices.PartGetAllWithSubjectAsync(e.Result.SubjectID);
            }
            else
                return;
        }

        //Session
        void getSession_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            try
            {
                if (e.Result != -1)
                {
                    learningServices.SubjectGetByNameAsync("Toan");
                    this.TaiHuou.Begin();
                }
                else
                {
                    HtmlPage.Window.Navigate(new Uri(webURL));
                }
            }
            catch { }
        }


        #region Animations
        //private void FormatTextBlock()
        //{
        //    this.TextBolock_PartID.Text = "";
        //    this.TextBlock_partName.Text = "";
        //    this.TextBolock_PartContent.Text = "";
        //}

        private void home_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Home_ST.Begin();
        }

        private void home_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Home_ST.Stop();
        }

        private void PageLoad_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Sun_ST.Begin();
            May_ST.Begin();
            media.Play();
        }

        private void link_Home_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_home.Play();
        }

        private void link_Home_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            media_home.Stop();
        }

        private void loa_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            note_ST.Begin();
        }

        private void loa_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            note_ST.Stop();
        }

        private void Img_Tests_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StoryboardTests.Stop();
            media_test.Stop();
        }

        private void Img_Tests_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StoryboardTests.Begin();
            media_test.Play();
        }
        #endregion


        private void loa_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapImage img = new BitmapImage(new Uri("../Images/LessonBackGround/note_dis.png", UriKind.RelativeOrAbsolute));
            if (media.IsMuted)
            {
                this.loa.Source = new BitmapImage(new Uri("../Images/LessonBackGround/note_en.png", UriKind.RelativeOrAbsolute));
                media.IsMuted = false;
            }
            else
            {
                this.loa.Source = img;
                media.IsMuted = true;
            }

            //loa.Source = new bit"";
        }

        private void link_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Learning.aspx", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private string GetLessonName(string str)
        {
            int ido = str.IndexOf(" ") + 1;
            return str.Substring(ido, str.Length - ido);
        }

        //Part listBox
        private void ListBox_Lesson_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            List<string> lstr = new List<string>();
            foreach (var v in lessonList)
            {
                lstr.Add(v.LessonName);
            }
            ListLesson s = (ListLesson)ListBox_Lesson.SelectedItem;
            string stt = s.Stt;

            PrimaryEducationSystem.Study.Lessons.PartOne.MainPartOne.lessonIndex = GetLessonName(stt);
            PrimaryEducationSystem.Study.Lessons.PartOne.MainPartOne.listLessonName = lstr;

            MainPage rootPage = Application.Current.RootVisual as MainPage;
            rootPage.LayoutRoot.Children.Add(new PrimaryEducationSystem.Study.Lessons.PartOne.MainPartOne());
        }
        //Testting

        private void image_Test_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Testing.aspx", UriKind.RelativeOrAbsolute));
        }


    }
}
