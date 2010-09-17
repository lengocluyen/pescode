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
using System.Threading;
using Studying.LearningServices;
using Studying.PesSessionServices;
using System.Windows.Browser;
using System.Windows.Media.Imaging;

namespace Studying
{
    public partial class Learning : UserControl
    {
        LearningServicesClient learningService = new LearningServicesClient();
        PESServicesSessionSoapClient sessionService = new PESServicesSessionSoapClient();
        protected Account account;
        private List<StudyProgramming> programmingList;
        private List<StudyLevel> levelList;
        private List<Subject> subjectList;

        private StudyProgramming programming;
        private StudyLevel level;
        private Subject subject;

        private string proName;
        private string levelName;
        private string subjectName;
        string webURL = PESCommons.parameters["webURL"];
        public Learning()
        {
            InitializeComponent();
            this.Storyboard_Down.Begin();

            sessionService.GetUserLoginIDCompleted += new EventHandler<GetUserLoginIDCompletedEventArgs>(sessionService_GetUserLoginIDCompleted);
            sessionService.GetUserLoginIDAsync();

            learningService.AccountGetByIDCompleted += new EventHandler<AccountGetByIDCompletedEventArgs>(learningService_AccountGetByIDCompleted);
            learningService.PupilGetByAccountIDCompleted += new EventHandler<PupilGetByAccountIDCompletedEventArgs>(learningService_PupilGetByAccountIDCompleted);
            learningService.StudyingProgrammingGetAllCompleted += new EventHandler<StudyingProgrammingGetAllCompletedEventArgs>(learningService_StudyingProgrammingGetAllCompleted);
            learningService.StudyingLevelGetCompleted += new EventHandler<StudyingLevelGetCompletedEventArgs>(learningService_StudyingLevelGetCompleted);
            learningService.SubjectGetAllWithLevelCompleted += new EventHandler<SubjectGetAllWithLevelCompletedEventArgs>(learningService_SubjectGetAllWithLevelCompleted);
        }
        //Get Subject
        void learningService_SubjectGetAllWithLevelCompleted(object sender, SubjectGetAllWithLevelCompletedEventArgs e)
        {
            try
            {
                this.SubjectTextBlock.Text = "Danh sách môn học:";
                subjectList = new List<Subject>();
                if (e.Error == null)
                {
                    SubjectStaccPanel.Children.Clear();
                    foreach (Subject subject in e.Result)
                    {
                        subjectList.Add(subject);
                        AddProgramming("../Images/Studying/Data/" + subject.SubjectImg, subject.SubjectID, "subject", SubjectStaccPanel);
                    }
                    WaittingService(true);
                }
                else
                    return;
            }
            catch
            {
                return;
            }

        }
        //Get level
        void learningService_StudyingLevelGetCompleted(object sender, StudyingLevelGetCompletedEventArgs e)
        {
            try
            {
                this.LevelTextBlock.Text = "Danh sách các bậc học:";
                levelList = new List<StudyLevel>();
                if (e.Error == null)
                {
                    this.LevelStackPanel.Children.Clear();
                    foreach (StudyLevel level in e.Result)
                    {
                        levelList.Add(level);
                        AddProgramming("../Images/Studying/Data/" + level.StudyLevelImg, level.StudyLevelID, "level", LevelStackPanel);
                    }
                    WaittingService(true);
                }
                else
                    return;
            }
            catch
            {
                return;
            }

        }
        //Get PRogrmming
        void learningService_StudyingProgrammingGetAllCompleted(object sender, StudyingProgrammingGetAllCompletedEventArgs e)
        {
            try
            {
                this.ProgrammingTextBlock.Text = "Chọn chương trình học:";
                programmingList = new List<StudyProgramming>();
                if (e.Error == null)
                {
                    foreach (StudyProgramming programming in e.Result)
                    {
                        programmingList.Add(programming);
                        AddProgramming("../Images/Studying/Data/" + programming.ProgrammingImg, programming.ProgrammingID, "programming", ProgrammingStackPanel);
                    }
                    WaittingService(true);

                }
                else
                    return;
            }
            catch
            {
                return;
            }

        }
        //Get Pupil
        void learningService_PupilGetByAccountIDCompleted(object sender, PupilGetByAccountIDCompletedEventArgs e)
        {
            if (e.Error == null)
            {

            }
            else
                return;
        }
        //Get Acount
        void learningService_AccountGetByIDCompleted(object sender, AccountGetByIDCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                account = e.Result;
                AvartaImage.Source = new BitmapImage(new Uri(webURL + "images/profileavatar/profileimage.aspx?AccountID=" + e.Result.AccountID, UriKind.RelativeOrAbsolute));
            }

            else
                return;
        }
       
        //Get User (Session)
        void sessionService_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            if (e.Result == -1)
            {
                HtmlPage.Window.Navigate(new Uri(webURL+"Learning/Defaults.aspx",UriKind.RelativeOrAbsolute));
            }
            else
            {
                learningService.AccountGetByIDAsync(e.Result);
                learningService.PupilGetByAccountIDAsync(e.Result);
                learningService.StudyingProgrammingGetAllAsync();
            }
        }

        #region Animation
        private void AnimationBack(bool _bool)
        {
            if (_bool == true)
            {
                this.Storyboard_Reverse.Begin();
                this.Storyboard_BackMenu.Begin();
                this.Storyboard_PageDown.Begin();
            }
            else
            {
                this.Storyboard_PageDown_Reverse.Begin();
                this.Storyboard_BackMenu_Reverse.Begin();
                this.Storyboard_Down.Begin();
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_bool">false if waitting else</param>
        private void WaittingService(bool _bool)
        {
            this.ProgrammingStackPanel.Visibility = Visibility.Visible;
        }

        public void AddProgramming(string _img, int _id, string _text, StackPanel _stack)
        {
            Icons ic = new Icons();
            ic.ImageIcons.Source = new BitmapImage(new Uri(_img, UriKind.RelativeOrAbsolute));
            ic.Id = _id;
            ic.Text = _text;
            ic.Margin = new Thickness(15, 0, 0, 0);
            ic.MouseLeftButtonDown += new MouseButtonEventHandler(ic_MouseLeftButtonDown);
            ic.MouseEnter += new MouseEventHandler(ic_MouseEnter);
            ic.MouseLeave += new MouseEventHandler(ic_MouseLeave);
            //Open design here
            _stack.Children.Add(ic);
        }

        void ic_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                this.ProgrammingNameTextBlock.Text = programming.ProgrammingName;
                this.LevelNameTextBlock.Text = level.StudyLevelName;
                this.SubjectNameTextBlock.Text = subject.SubjectName;
            }
            catch
            {
                return;
            }
            
        }

        void ic_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Icons ic = sender as Icons;
                int id = ic.Id;
                switch (ic.Text)
                {
                    case "programming":
                        StudyProgramming st = new StudyProgramming();
                        st = programmingList.Where(p => p.ProgrammingID == id).FirstOrDefault();
                        this.ProgrammingNameTextBlock.Text = st.ProgrammingName;
                        this.LevelNameTextBlock.Text = "";
                        break;
                    case "level":
                        StudyLevel lv = new StudyLevel();
                        lv = levelList.Where(l => l.StudyLevelID == id).FirstOrDefault();
                        this.LevelNameTextBlock.Text = lv.StudyLevelName;
                        this.SubjectNameTextBlock.Text = "";
                        break;
                    case "subject":
                        Subject sb = new Subject();
                        sb = subjectList.Where(s => s.SubjectID == id).FirstOrDefault();
                        this.SubjectNameTextBlock.Text = sb.SubjectName;
                        break;
                }
            }
            catch
            {
                return;
            }
        }

        void ic_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Icons ic = sender as Icons;
                int id = ic.Id;
                switch (ic.Text)
                {
                    case "programming":
                        learningService.StudyingLevelGetAsync(id);
                        programming = programmingList.Where(p => p.ProgrammingID == id).FirstOrDefault();
                        break;
                    case "level":
                        learningService.SubjectGetAllWithLevelAsync(id);
                        level = levelList.Where(l => l.StudyLevelID == id).FirstOrDefault();
                        break;
                    case "subject":
                        //Link here

                        subject = subjectList.Where(s => s.SubjectID == id).FirstOrDefault();
                        if (subject.SubjectName == "Tiengviet")
                        {
                            HtmlPage.Window.Navigate(new Uri(webURL+"learningVietnamese/PreView.aspx",UriKind.RelativeOrAbsolute));
                        }
                        if (subject.SubjectName == "Toan")
                        {
                            HtmlPage.Window.Navigate(new Uri(webURL + "Learning/maths.aspx", UriKind.RelativeOrAbsolute));
                        }
                        break;
                }
            }
            catch
            {
                return;
            }
        }

        #endregion

        #region Event

        private void image_Tools_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Đang xây dựng chức năng này");
        }

        private void Image_Books_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.TitleTextBlock.Text = "Chọn chương trình học!";
            this.ContentCanvas.Visibility = Visibility.Visible;
            this.ContainerCanvas.Visibility = Visibility.Collapsed;
            AnimationBack(true);
        }

        private void Image_Help_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ContentCanvas.Visibility = Visibility.Collapsed;
            this.ContainerCanvas.Visibility = Visibility.Collapsed;
            AnimationBack(true);
        }

        private void Image_Comeback_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Defaults.aspx", UriKind.RelativeOrAbsolute));
        }

        private void image_Contact_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.TitleTextBlock.Text = "Thông tin về nhóm phát triển!";
            this.ContentCanvas.Visibility = Visibility.Collapsed;
            this.ContainerCanvas.Visibility = Visibility.Visible;
            this.ContainerCanvas.Children.Add(new Contactxaml());
            AnimationBack(true);

        }

        private void Layer_1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Canvas parent = (Canvas)this.Image_Eye.Parent;
                Point p = e.GetPosition(parent);
                double X = p.X;
                double Y = p.Y;
                double radius = Canvas_Eye.Width / 2 - 0.5;
                double radian;
                double x = radius;
                double y = radius;
                if (X <= 0 && Y <= 0)
                {
                    radian = Math.Atan((Math.Abs(Y) + radius) / (Math.Abs(X) + radius));
                    x = radius - radius * Math.Cos(radian);
                    y = radius - radius * Math.Sin(radian);

                }
                else if (X >= 0 && Y <= 0)
                {
                    radian = Math.Atan((Math.Abs(Y) + radius) / (Math.Abs(X) - radius));
                    x = radius + radius * Math.Cos(radian);
                    y = radius - radius * Math.Sin(radian);
                }
                else if (X >= 0 && Y >= 0)
                {
                    radian = Math.Atan((Math.Abs(Y) - radius) / (Math.Abs(X) - radius));
                    x = radius + radius * Math.Cos(radian);
                    y = radius + radius * Math.Sin(radian);
                    if (X <= Canvas_Eye.Width && Y <= Canvas_Eye.Height)
                    {
                        x = X + 1;
                        y = Y + 1;
                    }
                }
                else if (X <= 0 && Y >= 0)
                {
                    radian = Math.Atan((Math.Abs(Y) - radius) / (Math.Abs(X) + radius));
                    x = radius - radius * Math.Cos(radian);
                    y = radius + radius * Math.Sin(radian);
                }
                this.Image_Eye.SetValue(Canvas.LeftProperty, x);
                this.Image_Eye.SetValue(Canvas.TopProperty, y);
            }
            catch
            {
                return;
            }

        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ContentCanvas.Visibility = Visibility.Collapsed;
            AnimationBack(false);
        }
        #endregion

        #region Animation
        private void image_Contact_MouseEnter(object sender, MouseEventArgs e)
        {
            ContactST.Begin();
        }

        private void image_Contact_MouseLeave(object sender, MouseEventArgs e)
        {
            ContactST.Stop();
        }

        private void image_Tools_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolsST.Begin();
        }

        private void image_Tools_MouseLeave(object sender, MouseEventArgs e)
        {
            ToolsST.Stop();
        }

        private void Image_Comeback_MouseEnter(object sender, MouseEventArgs e)
        {
            ContactST.Begin();
        }

        private void Image_Comeback_MouseLeave(object sender, MouseEventArgs e)
        {
            ContactST.Stop();
        }

        private void Image_Books_MouseEnter(object sender, MouseEventArgs e)
        {
            StudyST.Begin();
        }

        private void Image_Books_MouseLeave(object sender, MouseEventArgs e)
        {
            StudyST.Stop();
        }

        private void Image_Help_MouseEnter(object sender, MouseEventArgs e)
        {
            HelpST.Begin();
        }

        private void Image_Help_MouseLeave(object sender, MouseEventArgs e)
        {
            HelpST.Stop();
        }

        private void Image_Library_MouseEnter(object sender, MouseEventArgs e)
        {
            LibraryST.Begin();
        }

        private void Image_Library_MouseLeave(object sender, MouseEventArgs e)
        {
            LibraryST.Stop();
        }

        private void Image_Library_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	HtmlPage.Window.Navigate(new Uri(webURL +"Learning/Library.aspx",UriKind.RelativeOrAbsolute));
        }
        #endregion
    }
}
