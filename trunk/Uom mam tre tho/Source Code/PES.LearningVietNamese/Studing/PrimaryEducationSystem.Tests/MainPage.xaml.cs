using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;
using PrimaryEducationSystem.Tests.LearningServices;
using PrimaryEducationSystem.Tests.PESServicesSession;
using System.Collections.Generic;
using System.Windows.Browser;
using Liquid;
using System.Windows.Media.Imaging;


namespace PrimaryEducationSystem.Tests
{
 public partial class MainPage : UserControl
    {
        #region Global Variables

        IList<T_Question> questions;    // Dung de luu tru tat ca cac cau hoi theo Level.
        List<string> answerActive = new List<string>();    // Dung de luu tru ID tat ca cac cau tra loi da duoc active.
        List<string> questionsActiveTrue = new List<string>(); // Dung de luu tru ID cua cac cau hoi da duoc tra loi dung.
        List<string> answerSounds = new List<string>(); //Dùng để lưu trữ danh sách các file âm thanh của câu hỏi hiện tại nếu có.
        List<string> resultView = new List<string>();   //Dùng để lưu trữ kết quả trả lời các câu hỏi và xuất cho người dùng xem khi nộp bài hoặc hết giờ.
        List<string> questionIDs = new List<string>();
        Account user;
        Boolean loadQuestion = true;
        Boolean isShowButtonStart = true;
        Boolean isShowCanvasSave = true;
        Boolean isPlayAnswerSound = true;
        Boolean isUpLevel = false;
        string currentQuestionName = "";
        int currentQuestionID = 0;
        int UserID = 0;
        int levelID = 0;
        int questionsNumber = 0;   //Số lượng câu hỏi cho mỗi bài Test
        double questionMark = 0;
        double totalMark = 0;
        double markResult = 0;
        LearningServicesClient web = new LearningServicesClient();
        PESServicesSessionSoapClient getSession = new PESServicesSessionSoapClient();
        string webURL = PESCommons.parameters["webURL"];

        //Timer
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int seconds = 0, minutes = 0;  //Thời gian làm 1 bài test

        #endregion
        
        public MainPage()
        {
            // Required to initialize variables
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (PESCommons.parameters["levelID"] != null)
            {
                try
                {
                    levelID = int.Parse(PESCommons.parameters["levelID"].ToString());
                    questionsNumber = int.Parse(PESCommons.parameters["questionsNumber"].ToString());
                    minutes = int.Parse(PESCommons.parameters["timeExpire"].ToString()) - 1;
                    seconds = 60;


                    getSession.GetUserLoginIDCompleted +=new EventHandler<GetUserLoginIDCompletedEventArgs>(getSession_GetUserLoginIDCompleted);
                    getSession.GetUserLoginIDAsync();

                    ShowButtonStart();

                    this.CloudAnimation.Begin();
                    this.ChildrenAnimation.Begin();
                    this.BalloonAnimation.Begin();

                    LoadGuide();

                }
                catch
                {
                    HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Math.aspx"));
                }
            }
            else
                HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Math.aspx"));

        }

        void getSession_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            UserID = e.Result;

            if (UserID > 0)
            {
                
                web.GetProfileByAccountIDCompleted += new EventHandler<GetProfileByAccountIDCompletedEventArgs>(web_GetProfileByAccountIDCompleted);
                web.GetPupilByIDCompleted += new EventHandler<GetPupilByIDCompletedEventArgs>(web_GetUserByIDCompleted);
                web.GetPupilByIDAsync(UserID);
            }
            else
            {
                //Chưa đăng nhập thì quay lại trang đăng nhập
                HtmlPage.Window.Navigate(new Uri(webURL + "/Home.asxp"));
            }
        }

        Profile pfile;
        void web_GetProfileByAccountIDCompleted(object sender, GetProfileByAccountIDCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                pfile = e.Result;
                if (pfile.LevelOfExperienceTypeID < levelID)
                {
                    txt_MessageSave.Text = "Bạn chưa được phép làm bài kiểm tra thuộc cấp độ này!";
                    Canvas_Save.Visibility = Visibility.Visible;
                    isShowCanvasSave = false;

                    canvasLeft.Visibility = Visibility.Collapsed;
                    Grid_Content.Visibility = Visibility.Collapsed;
                    StarAnimation.Stop();

                    txt_Guide.Visibility = Visibility.Collapsed;
                    btn_Start.Visibility = Visibility.Collapsed;
                    StartHoverAnimation.Stop();
                }
            }
        }

        #region Question Actions
        void web_GetAllQuestionByTestLevelCompleted(object sender, GetAllQuestionByTestLevelCompletedEventArgs e)
        {
            questions = e.Result;
            if (questions != null)
            {
                if (questions.Count > 0)
                {
                    int questionOrder = 1;
                    int firstIndex = 0;
                    totalMark = 0;
                    StackQuestions.Children.Clear();

                    if (questions.Count <= questionsNumber)
                    {
                        foreach (T_Question ques in questions)
                        {
                            TextBlock questionText = new TextBlock();
                            questionText.Style = (Style)this.Resources["QuestionStyle"];
                            questionText.Name = "question_" + ques.QuestionID.ToString() + "_" + ques.Mark.ToString();
                            questionText.Text = "Câu hỏi " + questionOrder.ToString() + ":";
                            resultView.Add("Câu hỏi " + questionOrder.ToString() + ": Chưa trả lời");

                            //Events
                            questionText.MouseLeftButtonDown += new MouseButtonEventHandler(questionText_MouseLeftButtonDown);
                            questionText.MouseEnter += new MouseEventHandler(questionText_MouseEnter);
                            questionText.MouseLeave += new MouseEventHandler(questionText_MouseLeave);

                            StackQuestions.Children.Add(questionText);
                            questionIDs.Add(ques.QuestionID.ToString());
                            questionOrder++;
                            totalMark += (double)ques.Mark;
                        }
                    }
                    else
                    {
                        Random rand = new Random();
                        bool getFirst = true;
                        while (questionOrder <= questionsNumber)
                        {
                            int index = rand.Next(questions.Count);
                            if (getFirst)
                            {
                                firstIndex = index;
                                getFirst = false;
                            }
                            currentQuestionID = questions[index].QuestionID;
                            if (!TestQuestionIsActive())
                            {
                                TextBlock questionText = new TextBlock();
                                questionText.Style = (Style)this.Resources["QuestionStyle"];
                                questionText.Name = "question_" + questions[index].QuestionID.ToString() + "_" + questions[index].Mark.ToString();
                                questionText.Text = "Câu hỏi " + questionOrder.ToString() + ":";
                                resultView.Add("Câu hỏi " + questionOrder.ToString() + ": Chưa trả lời");

                                //Events
                                questionText.MouseLeftButtonDown += new MouseButtonEventHandler(questionText_MouseLeftButtonDown);
                                questionText.MouseEnter += new MouseEventHandler(questionText_MouseEnter);
                                questionText.MouseLeave += new MouseEventHandler(questionText_MouseLeave);

                                StackQuestions.Children.Add(questionText);
                                questionIDs.Add(questions[index].QuestionID.ToString());
                                questionOrder++;
                                totalMark += (double)questions[index].Mark;
                                questionsActiveTrue.Add(currentQuestionID.ToString());
                            }

                        }

                        questionsActiveTrue.Clear();    //Xoa danh sach de su dung cho su kien tra loi cau hoi.
                    }

                    //Load first question
                    currentQuestionName = "Câu hỏi 1:";
                    currentQuestionID = questions[firstIndex].QuestionID;
                    web.GetQuestionByIDCompleted += new EventHandler<GetQuestionByIDCompletedEventArgs>(web_GetQuestionByIDCompleted);
                    web.GetQuestionByIDAsync(currentQuestionID);

                    StarAnimation.Begin();

                    //Start Timer
                    StartTimer();

                }
            }
        }

        void questionText_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if (text.Text.CompareTo(currentQuestionName) != 0)
                text.Style = (Style)this.Resources["QuestionStyle"];
        }

        void questionText_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            text.Style = (Style)this.Resources["QuestionStyleHover"];
        }

        void questionText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            string[] list = text.Name.Split(new char[] { '_' });
            int id = int.Parse(list[1]);
            if (currentQuestionID != id)
            {
                currentQuestionName = text.Text;
                currentQuestionID = id;
                questionMark = double.Parse(list[2]);
                web.GetQuestionByIDCompleted += new EventHandler<GetQuestionByIDCompletedEventArgs>(web_GetQuestionByIDCompleted);
                web.GetQuestionByIDAsync(currentQuestionID);

                loadQuestion = true;

                StarAnimation.Begin();
            }
        }

        void web_GetQuestionByIDCompleted(object sender, GetQuestionByIDCompletedEventArgs e)
        {
            if (loadQuestion)
            {
                T_Question question = e.Result;
                questionMark = (double)question.Mark;

                web.GetAllAnswersByQuestionCompleted += new EventHandler<GetAllAnswersByQuestionCompletedEventArgs>(web_GetAllAnswersByQuestionCompleted);
                web.GetAllAnswersByQuestionAsync(question.QuestionID);

                //Display Question Content
                rt_Question.Clear();
                rt_Question.Load(Liquid.Format.HTML, "<h3>" + HttpUtility.HtmlDecode(question.QuestionContent) + "</h3>");


                //Sound Event
                QuestionSound.Source = new Uri(webURL + question.SoundFile, UriKind.Absolute);
                QuestionSound.Play();

                loadQuestion = false;

                TextBlock text = FindName("question_" + question.QuestionID.ToString() + "_" + question.Mark.ToString()) as TextBlock;
                text.Style = (Style)this.Resources["QuestionStyleHover"];
            }
        }

        #endregion

        #region Answer Actions
        void web_GetAllAnswersByQuestionCompleted(object sender, GetAllAnswersByQuestionCompletedEventArgs e)
        {
            IList<T_Answers> list = e.Result;
            if (list.Count > 0)
            {
                StackAnswers.Children.Clear();

                TextBlock text = new TextBlock();
                text.Name = "ChooseAnswer";
                text.Text = "Chọn đáp án đúng:";
                text.Style = (Style)this.Resources["ChooseAnswerStyle"];
                StackAnswers.Children.Add(text);
                answerSounds.Clear();
                isPlayAnswerSound = true;

                int stt = 1;
                foreach (T_Answers an in list)
                {
                    StackPanel stack = new StackPanel();
                    stack.Name = "answerStack_" + an.AnswersID.ToString();
                    stack.Orientation = Orientation.Horizontal;
                    stack.VerticalAlignment = VerticalAlignment.Center;

                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("Images/Test/answer_" + stt.ToString() + ".png", UriKind.Relative));
                    stack.Children.Add(img);

                    if ((bool)an.IsText)
                    {
                        TextBlock answerText = new TextBlock();
                        if (!TestAnswerIsActive(an.AnswersID.ToString()))
                            answerText.Style = (Style)this.Resources["AnswerStyle"];
                        else
                            answerText.Style = (Style)this.Resources["AnswerHoverStyle"];
                        answerText.Name = "answer_" + an.AnswersID.ToString() + "_" + an.IsTrue.ToString();
                        answerText.Text = an.AnswersContent;

                        //Events
                        answerText.MouseEnter += new MouseEventHandler(answerText_MouseEnter);
                        answerText.MouseLeave += new MouseEventHandler(answerText_MouseLeave);
                        answerText.MouseLeftButtonDown += new MouseButtonEventHandler(answerText_MouseLeftButtonDown);

                        stack.Children.Add(answerText);
                    }
                    else
                    {
                        Image answerImg = new Image();
                        answerImg.Name = "answer_" + an.AnswersID.ToString() + "_" + an.IsTrue.ToString();
                        answerImg.Source = new BitmapImage(new Uri(webURL + an.AnswersContent, UriKind.Absolute));
                        answerImg.Projection = new PlaneProjection();
                        answerImg.Style = (Style)this.Resources["AnswerImageStyle"];

                        answerImg.MouseLeftButtonDown += new MouseButtonEventHandler(answerImg_MouseLeftButtonDown);
                        answerImg.MouseEnter += new MouseEventHandler(answerImg_MouseEnter);
                        answerImg.MouseLeave += new MouseEventHandler(answerImg_MouseLeave);

                        stack.Children.Add(answerImg);
                    }

                    if (an.SoundFile != null)
                        answerSounds.Add(webURL + an.SoundFile);

                    StackAnswers.Children.Add(stack);
                    stt++;
                }

                SoundLoad.Source = new Uri("Sounds/Test/loadcontent.mp3", UriKind.Relative);
                SoundLoad.Play();

                SoundLoad.CurrentStateChanged += new RoutedEventHandler(SoundLoad_CurrentStateChanged);
            }

        }

        void SoundLoad_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            QuestionSound.CurrentStateChanged += new RoutedEventHandler(QuestionSound_CurrentStateChanged);
        }

        void QuestionSound_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            MediaElement media = sender as MediaElement;

        lap:
            if (media.CurrentState == MediaElementState.Paused && isPlayAnswerSound)
            {
                //Chạy âm thanh của từng câu trả lời
                if (answerSounds.Count > 0)
                {
                    media.Source = new Uri(answerSounds[0], UriKind.Absolute);
                    media.Play();

                    answerSounds.RemoveAt(0);

                    goto lap;
                }
            }
        }

        void answerImg_MouseLeave(object sender, MouseEventArgs e)
        {
            AnswerImageAnimation.Stop();
        }

        void answerImg_MouseEnter(object sender, MouseEventArgs e)
        {
            Image answerImg = sender as Image;
            AnswerImageAnimation.SetValue(Storyboard.TargetNameProperty, answerImg.Name);
            AnswerImageAnimation.Begin();
        }

        void answerImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image answerImg = sender as Image;

            Answer_MouseLeftButtonDown(answerImg.Name);
        }

        void answerText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;

            Answer_MouseLeftButtonDown(text.Name);
        }

        void answerText_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            string[] list = text.Name.Split(new char[] { '_' });
            if (!TestAnswerIsActive(list[1]))
                text.Style = (Style)this.Resources["AnswerStyle"];
        }

        void answerText_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            text.Style = (Style)this.Resources["AnswerHoverStyle"];

        }

        #endregion

        #region Count Up

        // Fires every 1 second while the DispatcherTimer is active.
        public void Each_Tick(object o, EventArgs sender)
        {
            seconds--;
            if (seconds == 0)
            {
                minutes--;
                seconds = 60;
            }
            if (minutes < 0)
            {
                myDispatcherTimer.Stop();
                btn_Submit.Visibility = Visibility.Collapsed;
                SoundLoad.Source = new Uri("Sounds/Test/AlarmClock.mp3", UriKind.Relative);
                SoundLoad.Play();
                Count_Up.Text = "Hết giờ làm bài! Bạn sẽ không được tính điểm nếu làm tiếp.";
                minutes = 0;
                seconds = 0;
                ShowPopup();
            }
            else
                Count_Up.Text = String.Format("Bạn chỉ còn: {0} phút {1} giây", minutes.ToString("00"), seconds.ToString("00"));
        }

        private void StartTimer()
        {
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            myDispatcherTimer.Start();
        }

        #endregion

        #region Other Actions
        private void btn_Start_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (levelID > 0)
                {
                    web.GetAllQuestionByTestLevelCompleted += new EventHandler<GetAllQuestionByTestLevelCompletedEventArgs>(web_GetAllQuestionByTestLevelCompleted);
                    web.GetAllQuestionByTestLevelAsync(levelID);

                    txt_Title.Text = "CẤP ĐỘ " + levelID.ToString();

                    SoundLoad.Stop();
                    StartClickAnimation.Begin();
                    isShowButtonStart = false;
                    ShowButtonStart();
                }
                else
                    HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Math.aspx"));
            }
            catch
            {
                HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Math.aspx"));
            }

        }

        private void img_GoHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Math.aspx"));
        }

        private void img_GoHome_MouseEnter(object sender, MouseEventArgs e)
        {
            HomePageAnimation.Begin();
            SoundGoHome.Source = new Uri("Sounds/Link_GoHomepage.mp3", UriKind.Relative);
            SoundGoHome.Play();
        }

        private void img_GoHome_MouseLeave(object sender, MouseEventArgs e)
        {
            HomePageAnimation.Stop();
            SoundGoHome.Stop();
        }

        private void btn_Start_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundGoHome.Source = new Uri("Sounds/Test/BatDauLamBai.mp3", UriKind.Relative);
            SoundGoHome.Play();
        }
        private void btn_Submit_MouseLeave(object sender, MouseEventArgs e)
        {
            SoundGoHome.Stop();
        }

        private void btn_Start_MouseLeave(object sender, MouseEventArgs e)
        {
            SoundGoHome.Stop();
        }
        private void btn_Submit_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundGoHome.Source = new Uri("Sounds/Test/NopBaiKiemTra.mp3", UriKind.Relative);
            SoundGoHome.Play();
        }
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            SoundLoad.Stop();
            QuestionSound.Stop();
            InsertTestResult();
            btn_Submit.Visibility = Visibility.Collapsed;
        }

        void web_InsertTestResultCompleted(object sender, InsertTestResultCompletedEventArgs e)
        {
            if (e.Result)
            {
                if (levelID == pfile.LevelOfExperienceTypeID)
                {
                    //Tang level cho hoc sinh
                    //web.CopyUserAsync(user);
                    //web.CopyUserCompleted += new EventHandler<CopyUserCompletedEventArgs>(web_CopyUserCompleted);

                    //Tang level cho hoc sinh
                    pfile.LevelOfExperienceTypeID = levelID + 1;

                    web.UpdateProFileCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(web_CopyUserCompleted);
                    web.UpdateProFileAsync(pfile);
                }
                else
                    ShowPopup();
            }
            else
                MessageBox.Show("Không thể lưu kết quả của bạn vì lỗi hệ thống!");
        }

        void web_CopyUserCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                //User originPupil = e.Result;

                pfile.LevelOfExperienceTypeID = levelID + 1;

                web.UpdateProFileAsync(pfile);
                web.UpdateProFileCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(web_UpdateUserCompleted);
            }
            catch { }
        }

        void web_UpdateUserCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            isUpLevel = true;
            ShowPopup();
        }

        Pupils pupil;
        void web_GetUserByIDCompleted(object sender, GetPupilByIDCompletedEventArgs e)
        {
            user = e.Result;
            web.GetProfileByAccountIDAsync(pupil.AccountID);

            if (pfile.LevelOfExperienceTypeID<= levelID)
            {
                txt_MessageSave.Text = "Bạn chưa được phép làm bài kiểm tra thuộc cấp độ này!";
                Canvas_Save.Visibility = Visibility.Visible;
                isShowCanvasSave = false;

                canvasLeft.Visibility = Visibility.Collapsed;
                Grid_Content.Visibility = Visibility.Collapsed;
                StarAnimation.Stop();

                txt_Guide.Visibility = Visibility.Collapsed;
                btn_Start.Visibility = Visibility.Collapsed;
                StartHoverAnimation.Stop();
            }
        }

        private void btn_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //HidePopup();
            HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Math.aspx"));
        }

        #endregion

        #region Private Methods
        private void LoadGuide()
        {
            txt_Title.Text = "HƯỚNG DẪN";
            txt_Guide.Text = "Hướng dẫn làm bài trắc nghiệm:\n\n";
            txt_Guide.Text += "\t -Đối với mỗi bài thi trắc nghiệm sẽ có " + questionsNumber.ToString() + " câu hỏi và thời gian làm bài là " + (minutes + 1).ToString() + " phút.\n";
            txt_Guide.Text += "\t -Với mỗi câu hỏi sẽ có các câu trả lời tương ứng, bạn hãy nhấp chuột vào câu trả lời nào bạn cho là đúng nhất.\n";
            txt_Guide.Text += "\t -Sau mỗi lần chọn câu trả lời, hệ thống sẽ tự động chuyển sang câu hỏi tiếp theo.\n";
            txt_Guide.Text += "\t -Nếu bạn đã hoàn thành tất cả các câu hỏi thì có thể nhấp chuột vào nút nộp bài để nộp bài kiểm tra của bạn. Hoặc bạn có thể quay lại các câu trả lời trước đó và có thể chọn lại đáp án.\n";
            txt_Guide.Text += "\t -Nếu hết thời gian làm bài mà bạn chưa xong và chưa nộp bài thì hệ thống sẽ tự động thông báo và dừng quá trình làm bài của bạn.\n";
            txt_Guide.Text += "\t -Sau khi hết thời gian làm bài hoặc bạn nhấn nút nộp bài thì hệ thống sẽ hiển thị kết quả làm bài chi tiết của bạn.\n";
            txt_Guide.Text += "\n\n\t Và bây giờ bạn hãy nhấn vào nút \"BẮT ĐẦU\" ở bên dưới để bắt đầu làm bài nào.\n";

            SoundLoad.Source = new Uri("Sounds/Test/HuongDanKiemTra.mp3", UriKind.Relative);
            SoundLoad.Play();
        }
        private void ShowButtonStart()
        {
            if (isShowButtonStart)
            {
                canvasLeft.Visibility = Visibility.Collapsed;
                Grid_Content.Visibility = Visibility.Collapsed;

                txt_Guide.Visibility = Visibility.Visible;
                btn_Start.Visibility = Visibility.Visible;
                StartHoverAnimation.SetValue(Storyboard.TargetNameProperty, btn_Start.Name);
                StartHoverAnimation.Begin();
            }
            else
            {
                canvasLeft.Visibility = Visibility.Visible;
                Grid_Content.Visibility = Visibility.Visible;

                txt_Guide.Visibility = Visibility.Collapsed;
                StartHoverAnimation.Stop();

                StartHoverAnimation.SetValue(Storyboard.TargetNameProperty, btn_Submit.Name);
                StartHoverAnimation.Begin();
            }
        }

        //Phuong thuc kiem tra xem cau hoi da duoc tra loi chua?
        private bool TestQuestionIsActive()
        {
            foreach (string id in questionsActiveTrue)
            {
                if (id.CompareTo(currentQuestionID.ToString()) == 0)
                    return true;
            }

            return false;
        }

        //Phuong thuc kiem tra xem cau tra loi da duoc chon lan nao chua
        private bool TestAnswerIsActive(string answerID)
        {
            foreach (string id in answerActive)
            {
                if (id.CompareTo(answerID) == 0)
                    return true;
            }

            return false;
        }

        private void UpdateResultView()
        {
            int stt = 0;
            string[] list2 = currentQuestionName.Split(new char[] { ':' });
            foreach (string name in resultView)
            {
                string[] list1 = name.Split(new char[] { ':' });
                if (list1[0].CompareTo(list2[0]) == 0)
                {
                    break;
                }
                stt++;
            }
            resultView[stt] = currentQuestionName;
            currentQuestionName = list2[0] + ":";
        }

        private void ShowPopup()
        {
            if (isShowCanvasSave)
            {
                string message = string.Empty;

                if (minutes == 0 && seconds == 0)
                    message = "Đã hết giờ làm bài.\n";
                double a = markResult / totalMark;
                if (a >= 0.9)
                {
                    message += "Bạn đạt được " + markResult.ToString() + " điểm. Bạn có thể làm nhà bác học rồi đó!";
                    if (isUpLevel)
                        message += "\nBạn đã được tăng thêm 1 cấp rồi đó.";
                }
                else
                    if (a >= 0.7)
                    {
                        message += "Bạn đạt được " + markResult.ToString() + " điểm. Bạn thật thông minh!";
                        if (isUpLevel)
                            message += "\nBạn đã được tăng thêm 1 cấp rồi đó.";
                    }
                    else message += "Bạn đạt được " + markResult.ToString() + " điểm. Bạn cần phải cố gắng hơn trong lần sau nhé!";

                ShowResultView();

                txt_MessageSave.Text = message;
                Canvas_Save.Visibility = Visibility.Visible;
                isShowCanvasSave = false;

                canvasLeft.Visibility = Visibility.Collapsed;
                Grid_Content.Visibility = Visibility.Collapsed;
                StarAnimation.Stop();

                StartHoverAnimation.Stop();
                StartHoverAnimation.SetValue(Storyboard.TargetNameProperty, btn_Close.Name);
                StartHoverAnimation.Begin();

            }

        }

        private void ShowResultView()
        {
            int index = 1;
            this.txt_ResultView.Text = "\nKết quả:\n";
            foreach (string result in resultView)
            {
                if (index != resultView.Count)
                    this.txt_ResultView.Text += result + "\t\t-\t\t";
                else
                    this.txt_ResultView.Text += result;

                index++;
            }
        }

        private void HidePopup()
        {

            Canvas_Save.Visibility = Visibility.Collapsed;
            canvasLeft.Visibility = Visibility.Visible;
            Grid_Content.Visibility = Visibility.Visible;
            StarAnimation.Begin();
        }

        private void Answer_MouseLeftButtonDown(string buttonName)
        {
            if (minutes >= 0 && seconds > 0)
            {
                string[] list = buttonName.Split(new char[] { '_' });
                QuestionSound.Stop();
                isPlayAnswerSound = false;

                Boolean isAnswerTrue = Boolean.Parse(list[2]);
                if (isAnswerTrue)
                {
                    markResult += questionMark;
                    questionsActiveTrue.Add(currentQuestionID.ToString());
                    currentQuestionName += " Đúng";
                }
                else
                {
                    if (TestQuestionIsActive())
                    {
                        markResult -= questionMark;
                        questionsActiveTrue.Remove(currentQuestionID.ToString());
                    }
                    currentQuestionName += " Sai";
                }

                if (!TestAnswerIsActive(list[1]))
                    answerActive.Add(list[1]);

                SoundLoad.Source = new Uri("Sounds/Test/Right.mp3", UriKind.Relative);
                SoundLoad.Play();

                StarAnimation.Begin();

                UpdateResultView();

                NextQuestion();
            }
            else
            {
                SoundLoad.Source = new Uri("Sounds/Test/fail.mp3", UriKind.Relative);
                SoundLoad.Play();
            }
        }

        private void NextQuestion()
        {
            int index = 0;
            foreach (string quesID in questionIDs)
            {
                if (quesID.CompareTo(currentQuestionID.ToString()) == 0)
                {
                    if (index < questionIDs.Count - 1)
                    {
                        TextBlock text = FindName("question_" + questionIDs[index] + "_" + questionMark.ToString()) as TextBlock;
                        text.Style = (Style)this.Resources["QuestionStyle"];

                        currentQuestionName = "Câu hỏi " + (index + 2) + ":";
                        currentQuestionID = int.Parse(questionIDs[index + 1]);
                        web.GetQuestionByIDCompleted += new EventHandler<GetQuestionByIDCompletedEventArgs>(web_GetQuestionByIDCompleted);
                        web.GetQuestionByIDAsync(currentQuestionID);
                        loadQuestion = true;
                        return;
                    }
                }
                index++;
            }
        }

        private void InsertTestResult()
        {
            try
            {
                double a = markResult / totalMark;

                if (a > 0.7)
                {
                    T_Test_Result testResult = new T_Test_Result();
                    testResult.Mark = markResult;
                    testResult.TestDate = DateTime.Now;
                    testResult.UserID = UserID;
                    testResult.Level = levelID;

                    web.InsertTestResultCompleted += new EventHandler<InsertTestResultCompletedEventArgs>(web_InsertTestResultCompleted);
                    web.InsertTestResultAsync(testResult);

                }
                else
                    ShowPopup();
            }
            catch { }
        }

        #endregion
    }
}