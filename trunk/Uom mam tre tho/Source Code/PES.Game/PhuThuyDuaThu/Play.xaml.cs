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
using PhuThuyDuaThu.Controls;
using PhuThuyDuaThu.Codes;

namespace PhuThuyDuaThu
{
    public partial class Play : UserControl
    {
        //Number Control
        MapNumbersToImages numberLevel;
        MapNumbersToImages numberMailBox;
        MapNumbersToImages numberTotalTask;
        MapNumbersToImages numberCompletedTask;
        MapNumbersToImages numberPoint;

        MapNumbersToImages ctrlMailBoxNumber01;
        MapNumbersToImages ctrlMailBoxNumber02;
        MapNumbersToImages ctrlMailBoxNumber03;
        MapNumbersToImages ctrlMailBoxNumber04;
        MapNumbersToImages ctrlMailBoxNumber05;
        MapNumbersToImages ctrlMailBoxNumber06;
        MapNumbersToImages ctrlMailBoxNumber07;
        MapNumbersToImages ctrlMailBoxNumber08;
        MapNumbersToImages ctrlMailBoxNumber09;
        MapNumbersToImages ctrlMailBoxNumber10;
        MapNumbersToImages ctrlMailBoxNumber11;
        MapNumbersToImages ctrlMailBoxNumber12;

        HyperlinkButton hplClick;

        private int completedTask;
        private int totalTask;
        private bool isMute;
        private bool isTimeOut;
        private bool isAction;
        private bool isAction01;
        private int itemMailBoxResult;
        private int currentQuestion;

        private double imgMailCanvasLeft;
        private double imgMailCanvasTop;

        public Play()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Play_Loaded);
        }

        private void StartUp()
        {
            this.SetStartUpNumber();
            this.StopAllSound();
            this.StopAllStoryboard();

            //--> Set header number;
            this.SetLevel(GlobalVarialble.Level);
            this.AddPoints(Commons.GetPointAddedWhenLevelUp(GlobalVarialble.Level));
            this.SetCompletedTask(completedTask);
            this.SetTotalTask(totalTask);

            this.SetRandomMailBoxNumber();
            //<--            

            //--> Set question
            this.SetQuestion();
            //<--

            stbShowMailBoxes.Begin();
            this.stbShowMailBoxes.Completed += new EventHandler(stbShowMailBoxes_Completed);

            this.StatUpSound();

            imgMailCanvasLeft = Convert.ToDouble(imgMail.GetValue(Canvas.LeftProperty));
            imgMailCanvasTop = Convert.ToDouble(imgMail.GetValue(Canvas.TopProperty));
        }

        private void SetStartUpNumber()
        {
            this.completedTask = 0;
            this.totalTask = 12;
            this.isMute = false;
            this.isAction = false;
            this.isTimeOut = false;
            this.currentQuestion = 0;
            Constants.ArrRandomNumber.Clear();
        }

        private void StopAllStoryboard()
        {
            stbHideMailBox.Stop();
            stbSendMail.Stop();
            stbShowMailBoxes.Stop();
            stbTimeOut.Stop();
            stbTimeUp.Stop();
        }

        private void StopAllSound()
        {
            meBGMusic.Stop();
            meEnd.Stop();
            meFail.Stop();
            meLevelUp.Stop();
            meNoSound.Stop();
            meOK.Stop();
            mePost.Stop();
            meSendMail.Stop();
            meThankyou.Stop();
        }

        #region All Events
        void Play_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartUp();
        }

        void stbShowMailBoxes_Completed(object sender, EventArgs e)
        {
            easingDKFTimeUp01.KeyTime = new TimeSpan(0, 0, Commons.GetSecondTimeOutByLevel(GlobalVarialble.Level));
            easingDKFTimeUp02.KeyTime = new TimeSpan(0, 0, Commons.GetSecondTimeOutByLevel(GlobalVarialble.Level));
            stbTimeUp.Begin();
            stbTimeUp.Completed += new EventHandler(stbTimeUp_Completed);
        }

        void stbTimeUp_Completed(object sender, EventArgs e)
        {
            //Het gio
            this.stbTimeOut.Begin();
            this.stbTimeOut.Completed += new EventHandler(stbTimeOut_Completed);
        }

        void stbTimeOut_Completed(object sender, EventArgs e)
        {
            this.meBGMusic.Stop();
            this.canvasPlay.Children.Clear();
            this.canvasPlay.Children.Add(new GameOver());
        }

        private void hplMute_Click(object sender, RoutedEventArgs e)
        {
            if (imgMute.Visibility == Visibility.Collapsed)
            {
                this.imgMute.Visibility = Visibility.Visible;
                this.imgSound.Visibility = Visibility.Collapsed;
                this.isMute = true;
                this.MuteMusic();
            }
            else
            {
                this.imgMute.Visibility = Visibility.Collapsed;
                this.imgSound.Visibility = Visibility.Visible;
                this.isMute = false;
                this.PlayMusic();
            }
        }

        void meBGMusic_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (meBGMusic.CurrentState == MediaElementState.Paused && isMute == false)
            {
                meBGMusic.Play();
            }
        }

        private void hplMailBox_Click(object sender, RoutedEventArgs e)
        {
            hplClick = (HyperlinkButton)sender;

            double hplClickCanvasLeft = Convert.ToDouble(hplClick.GetValue(Canvas.LeftProperty));
            double hplClickCanvasTop = Convert.ToDouble(hplClick.GetValue(Canvas.TopProperty));

            Point poPA = new Point(hplClickCanvasLeft - 10, hplClickCanvasTop - 30);
            Point poSM = new Point(hplClickCanvasLeft, hplClickCanvasTop);

            this.MovePointAnimationToCurrentPosition(poPA);
            this.SetPointToSendMailStoryBoard(poSM);
            this.isAction = true;
            this.isAction01 = true;
        }

        void stbSendMail_Completed(object sender, EventArgs e)
        {
            if (isAction == true)
            {
                stbHideMailBox.Stop();
                string comparing = itemMailBoxResult.ToString();
                if (itemMailBoxResult <= 9)
                    comparing = "0" + itemMailBoxResult.ToString();
                if (hplClick.Name.IndexOf(comparing) >= 1)
                {
                    ctrlAddPoints.CallAnimation();                    
                    meOK.Play();
                    meOK.CurrentStateChanged += new RoutedEventHandler(meOK_CurrentStateChanged);

                    string _imgMailBoxName = "imgMailBox" + comparing;
                    daHideMail_MailBox01.SetValue(Storyboard.TargetNameProperty, _imgMailBoxName);
                    daHideMail_MailBox02.SetValue(Storyboard.TargetNameProperty, _imgMailBoxName);
                    daHideMail_hplMailBox03.SetValue(Storyboard.TargetNameProperty, hplClick.Name);

                    string _ctrlMailBoxName = "ctrlMailBoxNumber" + comparing;
                    daHideMail_MailBoxNumber01.SetValue(Storyboard.TargetNameProperty, _ctrlMailBoxName);
                    daHideMail_MailBoxNumber02.SetValue(Storyboard.TargetNameProperty, _ctrlMailBoxName);
                    daHideMail_MailBoxNumber03.SetValue(Storyboard.TargetNameProperty, _ctrlMailBoxName);
                    daHideMail_MailBoxNumber04.SetValue(Storyboard.TargetNameProperty, _ctrlMailBoxName);

                    //Hide MailBox                    
                    this.stbHideMailBox.Begin();
                    switch (_imgMailBoxName)
                    {
                        case "imgMailBox01":
                            imgMailBox01.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox02":
                            imgMailBox02.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox03":
                            imgMailBox03.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox04":
                            imgMailBox04.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox05":
                            imgMailBox05.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox06":
                            imgMailBox06.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox07":
                            imgMailBox07.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox08":
                            imgMailBox08.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox09":
                            imgMailBox09.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox10":
                            imgMailBox10.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox11":
                            imgMailBox11.Visibility = Visibility.Collapsed;
                            break;
                        case "imgMailBox12":
                            imgMailBox12.Visibility = Visibility.Collapsed;
                            break;
                    }
                    hplClick.Visibility = Visibility.Collapsed;
                    switch (_ctrlMailBoxName)
                    {
                        case "ctrlMailBoxNumber01":
                            ctrlMailBoxNumber01.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber02":
                            ctrlMailBoxNumber02.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber03":
                            ctrlMailBoxNumber03.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber04":
                            ctrlMailBoxNumber04.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber05":
                            ctrlMailBoxNumber05.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber06":
                            ctrlMailBoxNumber06.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber07":
                            ctrlMailBoxNumber07.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber08":
                            ctrlMailBoxNumber08.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber09":
                            ctrlMailBoxNumber09.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber10":
                            ctrlMailBoxNumber10.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber11":
                            ctrlMailBoxNumber11.Visibility = Visibility.Collapsed;
                            break;
                        case "ctrlMailBoxNumber12":
                            ctrlMailBoxNumber12.Visibility = Visibility.Collapsed;
                            break;
                    }

                    completedTask++;
                    this.SetCompletedTask(completedTask);
                    this.AddPoints(Constants.PointAdded);
                    int itemIndex = Convert.ToInt32(comparing) - 1;
                    Constants.ArrRandomNumber[itemIndex] = 0;

                    if (completedTask != totalTask)
                        this.SetQuestion();
                    //else
                    //{
                    //    GlobalVarialble.Level++;
                    //    this.stbLevelUp.Begin();
                    //    this.stbLevelUp.Completed += new EventHandler(stbLevelUp_Completed);
                    //}                    
                }
                else
                {
                    ctrlEliminatePoints.CallAnimation();

                    meFail.Stop();
                    meFail.Play();

                    this.EliminatePoints(Constants.PointEliminated);
                }

                stbSendMail.Stop();
                isAction = false;                
            }
        }

        void meOK_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (meOK.CurrentState == MediaElementState.Paused)
            {
                if (isAction01 == true)
                {
                    meOK.Stop();
                    if (completedTask == totalTask)
                    {
                        this.stbTimeUp.Pause();
                        this.LevelUp();
                    }
                    isAction01 = false;
                }
            }
        }

        private void LevelUp()
        {
            meLevelUp.Play();
            stbLevelUp.Stop();
            stbLevelUp.Begin();
            stbLevelUp.Completed += new EventHandler(stbLevelUp_Completed);            
        }

        void stbLevelUp_Completed(object sender, EventArgs e)
        {
            GlobalVarialble.Level++;
            this.LayoutRoot.Children.Clear();
            this.LayoutRoot.Children.Add(new Play());
        }
        #endregion

        #region Private Function
        private void MovePointAnimationToCurrentPosition(Point pt)
        {
            ctrlAddPoints.SetValue(Canvas.LeftProperty, pt.X);
            ctrlAddPoints.SetValue(Canvas.TopProperty, pt.Y);

            ctrlEliminatePoints.SetValue(Canvas.LeftProperty, pt.X);
            ctrlEliminatePoints.SetValue(Canvas.TopProperty, pt.Y);
        }

        private void SetPointToSendMailStoryBoard(Point pt)
        {
            edkfSendMailX01.Value = pt.X - imgMailCanvasLeft;
            edkfSendMailX02.Value = edkfSendMailX01.Value + 1;

            edkfSendMailY01.Value = pt.Y - imgMailCanvasTop;
            edkfSendMailY02.Value = pt.Y - imgMailCanvasTop;

            stbSendMail.Begin();
            stbSendMail.Completed += new EventHandler(stbSendMail_Completed);
        }

        private void AddPoints(int pointsAdded)
        {
            GlobalVarialble.Points += pointsAdded;
            SetPointAsImage(GlobalVarialble.Points);
        }

        private void EliminatePoints(int pointsEliminated)
        {
            GlobalVarialble.Points = GlobalVarialble.Points - pointsEliminated;
            if (GlobalVarialble.Points < 0)
                GlobalVarialble.Points = 0;
            SetPointAsImage(GlobalVarialble.Points);
        }

        private void SetPointAsImage(int _points)
        {
            if (canvasPlay.Children.Contains(numberPoint) == true)
                canvasPlay.Children.Remove(numberPoint);
            numberPoint = new MapNumbersToImages(_points, Constants.BoldYellowNumber, 17, 17, true);
            numberPoint.SetValue(Canvas.LeftProperty, (double)456);
            numberPoint.SetValue(Canvas.TopProperty, (double)16);
            canvasPlay.Children.Add(numberPoint);
        }

        private void StatUpSound()
        {
            mePost.Play();
        }

        private void MuteMusic()
        {
            meBGMusic.Stop();
        }

        private void PlayMusic()
        {
            meBGMusic.Stop();
            meBGMusic.Play();
        }


        #region SetNumber
        private void SetLevel(int _level)
        {
            if (canvasPlay.Children.Contains(numberLevel) == true)
                canvasPlay.Children.Remove(numberLevel);
            numberLevel = new MapNumbersToImages(_level, Constants.YellowNumber, 20, 20, true);
            numberLevel.SetValue(Canvas.LeftProperty, (double)98);
            numberLevel.SetValue(Canvas.TopProperty, (double)15);
            canvasPlay.Children.Add(numberLevel);
        }

        private void SetNumberOfQuestion(int _numberOfMailBox)
        {
            if (canvasPlay.Children.Contains(numberMailBox) == true)
                canvasPlay.Children.Remove(numberMailBox);
            numberMailBox = new MapNumbersToImages(_numberOfMailBox, Constants.YellowNumber, 23, 23, false);
            numberMailBox.SetValue(Canvas.LeftProperty, (double)113);
            numberMailBox.SetValue(Canvas.TopProperty, (double)433);
            canvasPlay.Children.Add(numberMailBox);
        }

        private void SetCompletedTask(int _numberDone)
        {
            if (canvasPlay.Children.Contains(numberCompletedTask) == true)
                canvasPlay.Children.Remove(numberCompletedTask);
            numberCompletedTask = new MapNumbersToImages(_numberDone, Constants.PinkNumber, 20, 20, true);
            numberCompletedTask.SetValue(Canvas.LeftProperty, (double)264);
            numberCompletedTask.SetValue(Canvas.TopProperty, (double)15);
            canvasPlay.Children.Add(numberCompletedTask);
        }

        private void SetTotalTask(int _totalTask)
        {
            if (canvasPlay.Children.Contains(numberTotalTask) == true)
                canvasPlay.Children.Remove(numberTotalTask);
            numberTotalTask = new MapNumbersToImages(_totalTask, Constants.GreenNumber, 20, 20, true);
            numberTotalTask.SetValue(Canvas.LeftProperty, (double)315);
            numberTotalTask.SetValue(Canvas.TopProperty, (double)15);
            canvasPlay.Children.Add(numberTotalTask);
        }

        private void SetRandomMailBoxNumber()
        {
            TransformGroup tranformGr = new TransformGroup();
            ScaleTransform scaleTf = new ScaleTransform();
            SkewTransform skewTf = new SkewTransform();
            RotateTransform rotateTf = new RotateTransform();
            TranslateTransform translateTf = new TranslateTransform();

            tranformGr.Children.Add(scaleTf);
            tranformGr.Children.Add(skewTf);
            tranformGr.Children.Add(rotateTf);
            tranformGr.Children.Add(translateTf);

            //Remove all exists ctrlMailBoxNumber before Add
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber01) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber01);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber02) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber02);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber03) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber03);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber04) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber04);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber05) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber05);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber06) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber06);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber07) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber07);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber08) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber08);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber09) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber09);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber10) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber10);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber11) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber11);
            if (canvasMailBoxNumber.Children.Contains(ctrlMailBoxNumber12) == true)
                canvasMailBoxNumber.Children.Remove(ctrlMailBoxNumber12);
            //END

            int numBox01 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox01);
            ctrlMailBoxNumber01 = new MapNumbersToImages(numBox01, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber01.Name = "ctrlMailBoxNumber01";
            ctrlMailBoxNumber01.RenderTransform = tranformGr;
            ctrlMailBoxNumber01.SetValue(Canvas.LeftProperty, (double)66);
            ctrlMailBoxNumber01.SetValue(Canvas.TopProperty, (double)527);
            ctrlMailBoxNumber01.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox02 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox02);
            ctrlMailBoxNumber02 = new MapNumbersToImages(numBox02, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber02.Name = "ctrlMailBoxNumber02";
            ctrlMailBoxNumber02.RenderTransform = tranformGr;
            ctrlMailBoxNumber02.SetValue(Canvas.LeftProperty, (double)206);
            ctrlMailBoxNumber02.SetValue(Canvas.TopProperty, (double)527);
            ctrlMailBoxNumber02.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox03 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox03);
            ctrlMailBoxNumber03 = new MapNumbersToImages(numBox03, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber03.Name = "ctrlMailBoxNumber03";
            ctrlMailBoxNumber03.RenderTransform = tranformGr;
            ctrlMailBoxNumber03.SetValue(Canvas.LeftProperty, (double)350);
            ctrlMailBoxNumber03.SetValue(Canvas.TopProperty, (double)527);
            ctrlMailBoxNumber03.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox04 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox04);
            ctrlMailBoxNumber04 = new MapNumbersToImages(numBox04, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber04.Name = "ctrlMailBoxNumber04";
            ctrlMailBoxNumber04.RenderTransform = tranformGr;
            ctrlMailBoxNumber04.SetValue(Canvas.LeftProperty, (double)491);
            ctrlMailBoxNumber04.SetValue(Canvas.TopProperty, (double)527);
            ctrlMailBoxNumber04.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox05 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox05);
            ctrlMailBoxNumber05 = new MapNumbersToImages(numBox05, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber05.Name = "ctrlMailBoxNumber05";
            ctrlMailBoxNumber05.RenderTransform = tranformGr;
            ctrlMailBoxNumber05.SetValue(Canvas.LeftProperty, (double)66);
            ctrlMailBoxNumber05.SetValue(Canvas.TopProperty, (double)639);
            ctrlMailBoxNumber05.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox06 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox06);
            ctrlMailBoxNumber06 = new MapNumbersToImages(numBox06, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber06.Name = "ctrlMailBoxNumber06";
            ctrlMailBoxNumber06.RenderTransform = tranformGr;
            ctrlMailBoxNumber06.SetValue(Canvas.LeftProperty, (double)206);
            ctrlMailBoxNumber06.SetValue(Canvas.TopProperty, (double)639);
            ctrlMailBoxNumber06.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox07 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox07);
            ctrlMailBoxNumber07 = new MapNumbersToImages(numBox07, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber07.Name = "ctrlMailBoxNumber07";
            ctrlMailBoxNumber07.RenderTransform = tranformGr;
            ctrlMailBoxNumber07.SetValue(Canvas.LeftProperty, (double)350);
            ctrlMailBoxNumber07.SetValue(Canvas.TopProperty, (double)639);
            ctrlMailBoxNumber07.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox08 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox08);
            ctrlMailBoxNumber08 = new MapNumbersToImages(numBox08, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber08.Name = "ctrlMailBoxNumber08";
            ctrlMailBoxNumber08.RenderTransform = tranformGr;
            ctrlMailBoxNumber08.SetValue(Canvas.LeftProperty, (double)491);
            ctrlMailBoxNumber08.SetValue(Canvas.TopProperty, (double)639);
            ctrlMailBoxNumber08.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox09 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox09);
            ctrlMailBoxNumber09 = new MapNumbersToImages(numBox09, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber09.Name = "ctrlMailBoxNumber09";
            ctrlMailBoxNumber09.RenderTransform = tranformGr;
            ctrlMailBoxNumber09.SetValue(Canvas.LeftProperty, (double)66);
            ctrlMailBoxNumber09.SetValue(Canvas.TopProperty, (double)746);
            ctrlMailBoxNumber09.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox10 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox10);
            ctrlMailBoxNumber10 = new MapNumbersToImages(numBox10, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber10.Name = "ctrlMailBoxNumber10";
            ctrlMailBoxNumber10.RenderTransform = tranformGr;
            ctrlMailBoxNumber10.SetValue(Canvas.LeftProperty, (double)208);
            ctrlMailBoxNumber10.SetValue(Canvas.TopProperty, (double)746);
            ctrlMailBoxNumber10.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox11 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox11);
            ctrlMailBoxNumber11 = new MapNumbersToImages(numBox11, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber11.Name = "ctrlMailBoxNumber11";
            ctrlMailBoxNumber11.RenderTransform = tranformGr;
            ctrlMailBoxNumber11.SetValue(Canvas.LeftProperty, (double)350);
            ctrlMailBoxNumber11.SetValue(Canvas.TopProperty, (double)746);
            ctrlMailBoxNumber11.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            int numBox12 = Commons.GetRandomNumberMailBox(Constants.Mailbox_Number_From, Constants.Mailbox_Number_To);
            Commons.AddToMailBoxListNumber(numBox12);
            ctrlMailBoxNumber12 = new MapNumbersToImages(numBox12, Constants.BoldYellowNumber, 15, 15, false);
            ctrlMailBoxNumber12.Name = "ctrlMailBoxNumber12";
            ctrlMailBoxNumber12.RenderTransform = tranformGr;
            ctrlMailBoxNumber12.SetValue(Canvas.LeftProperty, (double)491);
            ctrlMailBoxNumber12.SetValue(Canvas.TopProperty, (double)746);
            ctrlMailBoxNumber12.SetValue(RenderTransformOriginProperty, new Point(0.5, 0.5));

            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber01);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber02);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber03);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber04);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber05);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber06);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber07);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber08);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber09);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber10);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber11);
            canvasMailBoxNumber.Children.Add(ctrlMailBoxNumber12);
        }
        #endregion

        private void SetQuestion()
        {
            setqs:
            try
            {
                itemMailBoxResult = Commons.GetRandomNumber(0, totalTask);
                if (Constants.ArrRandomNumber[itemMailBoxResult] != 0)
                    currentQuestion = Constants.ArrRandomNumber[itemMailBoxResult];
                else
                    goto setqs;
                this.SetNumberOfQuestion(currentQuestion);
                itemMailBoxResult++;
            }
            catch
            {
                goto setqs;
            }
        }
        #endregion

        private void meBGMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (isMute == false)
            {
                this.meBGMusic.Stop();
                this.meBGMusic.Position = TimeSpan.FromSeconds(0.3);
                this.meBGMusic.Play();
            }
        }
    }
}