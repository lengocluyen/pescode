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
using LuyenTriNho.Codes;
using LuyenTriNho.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Browser;

namespace LuyenTriNho
{
    public partial class Play : UserControl
    {
        MapNumbersToImages ctrlNumberLevel;
        MapNumbersToImages ctrlNumberPoints;
        DispatcherTimer _timer;

        GameServices.GameServicesSoapClient service = new LuyenTriNho.GameServices.GameServicesSoapClient();

        #region Variable
        //Thời gian khoảng cách giữa các lần rơi viên gạch
        int _timeKhoangCachDropStone;

        //Thời gian đợi trước khi gọi lại StartUp
        int _timeKhoangCachXemGuide;

        int _timeOutSecond;

        int _currentNumOfStoneDropped;
        List<int> questionList;
        bool didIt = false;
        bool isTimeOutTick = false;
        bool isViewGuide = false;
        #endregion

        public Play()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Play_Loaded);
        }

        #region All Events
        void Play_Loaded(object sender, RoutedEventArgs e)
        {            
            this.StartUp();
        }

        private void hplBtnMute_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GlobalVariables.IsMute == true)
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
            }
        }

        private void hplBtnMute_MouseLeave(object sender, MouseEventArgs e)
        {
            if (GlobalVariables.IsMute == true)
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Visible;
            }
            else
            {
                this.imgBtnSound.Visibility = Visibility.Visible;
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
            }
        }

        private void hplBtnMute_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalVariables.IsMute == false)
            {
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Visible;
                GlobalVariables.IsMute = true;
                this.meBGMusic.Stop();
            }
            else
            {
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSound.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
                GlobalVariables.IsMute = false;
                this.meBGMusic.Play();
            }
        }

        private void meBGMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (GlobalVariables.IsMute == false)
            {
                this.meBGMusic.Stop();
                this.meBGMusic.Position = TimeSpan.FromSeconds(0.3);
                this.meBGMusic.Play();
            }
        }

        private void hplbtnQuestion00_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(0);
        }

        private void hplbtnQuestion01_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(1);
        }

        private void hplbtnQuestion02_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(2);
        }

        private void hplbtnQuestion03_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(3);
        }

        private void hplbtnQuestion04_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(4);
        }

        private void hplbtnQuestion05_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(5);
        }

        private void hplbtnQuestion06_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(6);
        }

        private void hplbtnQuestion07_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(7);
        }

        private void hplbtnQuestion08_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(8);
        }

        private void hplbtnQuestion09_Click(object sender, RoutedEventArgs e)
        {
            this.StoneClick(9);
        }

        void meOpenDoor_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (meOpenDoor.CurrentState == MediaElementState.Paused)
                this.meOpenDoor.Stop();
        }

        private void hplGuide_Click(object sender, RoutedEventArgs e)
        {
            this.isViewGuide = true;
            this._timeKhoangCachXemGuide = 0;
            GlobalVariables.Guide--;
            this.rtFillAllLink.Visibility = Visibility.Visible;
            this.ShowGuides(GlobalVariables.Guide);
            this.storyboardTimeRun.Pause();
            this.storyboardOpenDoor.Begin();
        }

        private void hplBtnReplay_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgBtnReplay.Visibility = Visibility.Collapsed;
            this.imgBtnReplaySelected.Visibility = Visibility.Visible;
        }

        private void hplBtnReplay_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgBtnReplay.Visibility = Visibility.Visible;
            this.imgBtnReplaySelected.Visibility = Visibility.Collapsed;
        }

        private void hplBtnSavePoint_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgBtnSavePoint.Visibility = Visibility.Collapsed;
            this.imgBtnSavePointSelected.Visibility = Visibility.Visible;
        }

        private void hplBtnSavePoint_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgBtnSavePoint.Visibility = Visibility.Visible;
            this.imgBtnSavePointSelected.Visibility = Visibility.Collapsed;
        }

        private void hplBtnReplay_Click(object sender, RoutedEventArgs e)
        {
            this.ReplayGame();
        }

        private void hplBtnSavePoint_Click(object sender, RoutedEventArgs e)
        {
            //Lưu điểm
            if (!_isSubmitting)
            {
                _isSubmitting = true;

                HtmlPage.Document.GetElementById("silverlightMask").SetStyleAttribute("display", "block");
                HtmlPage.Document.GetElementById("silverlightLoading").SetStyleAttribute("display", "block");

                service.GetChallengeIDAsync(GlobalVariables.GameID);
            }
        }
        #endregion

        #region Private Startup Function
        private void StartUp()
        {
            service.GetChallengeIDCompleted += new EventHandler<LuyenTriNho.GameServices.GetChallengeIDCompletedEventArgs>(service_GetChallengeIDCompleted);
            service.UpdateScoreCompleted += new EventHandler<LuyenTriNho.GameServices.UpdateScoreCompletedEventArgs>(service_UpdateScoreCompleted);

            this.rtFillAllLink.Visibility = Visibility.Visible;
            this.SetStartUpNumber();
            this.ShowLevel(GlobalVariables.Level);
            this.ShowPoints(GlobalVariables.Points);
            this.ShowHearts(GlobalVariables.Heart);
            this.ShowGuides(GlobalVariables.Guide);

            this.CallStoryBoard();
        }       

        private void SetStartUpNumber()
        {
            this.rectangleTimeLine.Width = 0.0;
            edkfTimeOut.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(Commons.GetTimeLineWhenLevelUp(GlobalVariables.Level)));
            this.isTimeOutTick = false;
            this.isViewGuide = false;
            this._timeOutSecond = 0;
            this.SetStartUpLevelNumber();
        }

        private void SetStartUpLevelNumber()
        {
            _currentNumOfStoneDropped = 0;
            questionList = new List<int>();
        }

        private void ShowLevel(int _level)
        {
            if (canvasMain.Children.Contains(ctrlNumberLevel) == true)
                canvasMain.Children.Remove(ctrlNumberLevel);
            ctrlNumberLevel = new MapNumbersToImages(_level, Constants.PinkNumber, 20, 20, true);
            ctrlNumberLevel.SetValue(Canvas.LeftProperty, (double)512);
            ctrlNumberLevel.SetValue(Canvas.TopProperty, (double)21);
            canvasMain.Children.Add(ctrlNumberLevel);
        }

        private void ShowPoints(int _points)
        {
            if (canvasMain.Children.Contains(ctrlNumberPoints) == true)
                canvasMain.Children.Remove(ctrlNumberPoints);
            ctrlNumberPoints = new MapNumbersToImages(_points, Constants.BoldYellowNumber, 15, 15, true);
            ctrlNumberPoints.SetValue(Canvas.LeftProperty, (double)460);
            ctrlNumberPoints.SetValue(Canvas.TopProperty, (double)454);
            canvasMain.Children.Add(ctrlNumberPoints);
        }

        private void ShowHearts(int _hearts)
        {
            switch (_hearts)
            {
                case 0:
                    this.imgHeart01.Visibility = Visibility.Collapsed;
                    this.imgHeart02.Visibility = Visibility.Collapsed;
                    this.imgHeart03.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    this.imgHeart01.Visibility = Visibility.Collapsed;
                    this.imgHeart02.Visibility = Visibility.Collapsed;
                    this.imgHeart03.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.imgHeart01.Visibility = Visibility.Collapsed;
                    this.imgHeart02.Visibility = Visibility.Visible;
                    this.imgHeart03.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.imgHeart01.Visibility = Visibility.Visible;
                    this.imgHeart02.Visibility = Visibility.Visible;
                    this.imgHeart03.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ShowGuides(int _guides)
        {
            switch (_guides)
            {
                case 0:
                    this.imgGuide01.Visibility = Visibility.Collapsed;
                    this.imgGuide02.Visibility = Visibility.Collapsed;
                    this.imgGuide03.Visibility = Visibility.Collapsed;

                    this.hplGuide01.Visibility = Visibility.Collapsed;
                    this.hplGuide02.Visibility = Visibility.Collapsed;
                    this.hplGuide03.Visibility = Visibility.Collapsed;
                    break;

                case 1:
                    this.imgGuide01.Visibility = Visibility.Collapsed;
                    this.imgGuide02.Visibility = Visibility.Collapsed;
                    this.imgGuide03.Visibility = Visibility.Visible;

                    this.hplGuide01.Visibility = Visibility.Collapsed;
                    this.hplGuide02.Visibility = Visibility.Collapsed;
                    this.hplGuide03.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.imgGuide01.Visibility = Visibility.Collapsed;
                    this.imgGuide02.Visibility = Visibility.Visible;
                    this.imgGuide03.Visibility = Visibility.Visible;

                    this.hplGuide01.Visibility = Visibility.Collapsed;
                    this.hplGuide02.Visibility = Visibility.Visible;
                    this.hplGuide03.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.imgGuide01.Visibility = Visibility.Visible;
                    this.imgGuide02.Visibility = Visibility.Visible;
                    this.imgGuide03.Visibility = Visibility.Visible;

                    this.hplGuide01.Visibility = Visibility.Visible;
                    this.hplGuide02.Visibility = Visibility.Visible;
                    this.hplGuide03.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void CallStoryBoard()
        {
            this.storyboardTimeRun.Stop();
            this.stbStart.Begin();
            this.stbStart.Completed += new EventHandler(stbStart_Completed);
        }

        private void CheckSound()
        {
            if (GlobalVariables.IsMute == true)
            {
                this.imgBtnSound.Visibility = Visibility.Collapsed;
                this.imgBtnSoundSelected.Visibility = Visibility.Collapsed;
                this.imgBtnSoundMute.Visibility = Visibility.Visible;
                this.meBGMusic.Stop();
            }
            else
            {
                this.imgBtnSound.Visibility = Visibility.Visible;
                this.imgBtnSoundSelected.Visibility = Visibility.Visible;
                this.imgBtnSoundMute.Visibility = Visibility.Collapsed;
                this.meBGMusic.Stop();
                this.meBGMusic.Play();
            }
        }
        #endregion

        #region Private Function
        /// <summary>
        /// Cộng điểm
        /// </summary>
        /// <param name="_pointAdded">Số điểm cộng thêm</param>
        private void AddPoint(int _pointAdded)
        {
            GlobalVariables.Points += _pointAdded;
            this.ShowPoints(GlobalVariables.Points);
        }

        /// <summary>
        /// Trừ điểm
        /// </summary>
        /// <param name="_pointEliminated">Số điểm trừ đi</param>
        private void EliminatePoint(int _pointEliminated)
        {
            GlobalVariables.Points -= _pointEliminated;
            if (GlobalVariables.Points < 0)
                GlobalVariables.Points = 0;
            this.ShowPoints(GlobalVariables.Points);
        }

        /// <summary>
        /// Sự kiện viên gạch rơi
        /// </summary>
        /// <param name="numberToQuestion">Chữ số mang trên viên gạch</param>
        /// <param name="theNum">Đây là viên gạch thứ mấy</param>
        /// <param name="canvasLeft">Toạ độ X của viên gạch</param>
        /// <param name="canvasTop">Toạ độ Y của viên gạch</param>
        /// <param name="isQuesion">True: Viên gạch sẽ rơi ở Ô Cửa Bí Mật | False: Viên gạch sẽ rơi ở Ô Cửa Của Bé</param>
        private void AddControlDropStone(int numberToQuestion, int theNum, double canvasLeft, double canvasTop, bool isQuesion)
        {
            ucStoryboadDropStone ctrlStone = new ucStoryboadDropStone();
            ctrlStone.SetValue(Canvas.LeftProperty, canvasLeft);
            ctrlStone.SetValue(Canvas.TopProperty, canvasTop);
            if (isQuesion == true)
                canvasCtrlQuestion.Children.Add(ctrlStone);
            else
                canvasCtrlAnser.Children.Add(ctrlStone);
            ctrlStone.StartDropStone(numberToQuestion, theNum);
        }

        private void SoundWhenDoorOpenOrClose()
        {
            this.meOpenDoor.Stop();
            this.meOpenDoor.Play();
            this.meOpenDoor.CurrentStateChanged += new RoutedEventHandler(meOpenDoor_CurrentStateChanged);
        }

        private void RepeatThisLevel()
        {
            this.rtFillAllLink.Visibility = Visibility.Collapsed;
            this.isTimeOutTick = false;
            this.storyboardTimeRun.Pause();

            if (GlobalVariables.Heart != 0)
            {
                this.canvasMain.Children.Clear();
                this.canvasMain.Children.Add(new Play());
            }
            else
            {
                this.ctrlNumberLevel.Visibility = Visibility.Collapsed;
                this.ctrlNumberPoints.Visibility = Visibility.Collapsed;
                meBGMusic.Stop();
                this.storyboardGameOver.Begin();
            }
        }

        /// <summary>
        /// Gọi storyboard cho cậu bé
        /// </summary>
        /// <param name="action">1: Trả lời đúng | 2: Trả lời sai | 3: Hết giờ</param>
        private void StoryboardBoy(int action)
        {
            this.tblNote.Visibility = Visibility.Visible;
            this.ellipse.Visibility = Visibility.Visible;
            this.rtFillAllLink.Visibility = Visibility.Visible;
            switch (action)
            {
                case 1:
                    this.stbBoyOK.Stop();
                    this.stbBoyCrying.Stop();
                    this.stbBoyNotOK.Stop();
                    this.tblNote.Text = "ĐÚNG RỒI!";

                    this.stbBoyOK.Begin();
                    this.storyboardTimeRun.Pause();
                    this.stbBoyOK.Completed += new EventHandler(stbBoyOK_Completed);
                    break;

                case 2:
                    this.stbBoyOK.Stop();
                    this.stbBoyCrying.Stop();
                    this.stbBoyNotOK.Stop();
                    this.tblNote.Text = "SAI RỒI!!!";

                    GlobalVariables.Heart--;
                    this.ShowHearts(GlobalVariables.Heart);
                    this.stbBoyNotOK.Begin();
                    this.storyboardTimeRun.Pause();
                    this.stbBoyNotOK.Completed += new EventHandler(stbBoyNotOK_Completed);
                    break;

                case 3:
                    this.stbBoyOK.Stop();
                    this.stbBoyCrying.Stop();
                    this.stbBoyNotOK.Stop();
                    this.tblNote.Text = "HẾT GIỜ!!!";

                    GlobalVariables.Heart--;
                    this.ShowHearts(GlobalVariables.Heart);
                    //this.storyboardTimeRun.Stop();
                    this.stbBoyCrying.Begin();
                    this.stbBoyCrying.Completed += new EventHandler(stbBoyCrying_Completed);
                    break;
            }
        }

        private void LevelUp()
        {
            this.rtFillAllLink.Visibility = Visibility.Collapsed;
            this.isTimeOutTick = false;
            this.storyboardTimeRun.Pause();
            this.AddPoint(Commons.GetPointAddedWhenLevelUp(GlobalVariables.Level));
            if (GlobalVariables.Level < Constants.MaximumLevel)
                GlobalVariables.Level++;

            this.StoryboardBoy(1);
        }

        /// <summary>
        /// Khi click vào viên đá
        /// </summary>
        /// <param name="numberAnswer">Mã số của viên đá</param>
        private void StoneClick(int numberAnswer)
        {
            try
            {
                this.AddControlDropStone(numberAnswer, _currentNumOfStoneDropped, 235, 150, false);
                if (questionList[_currentNumOfStoneDropped] != numberAnswer)
                {
                    this.StoryboardBoy(2);
                }
                else
                {
                    _currentNumOfStoneDropped++;
                    if (_currentNumOfStoneDropped == Commons.GetNumOfQuestionPerLevel(GlobalVariables.Level))
                        this.LevelUp();
                }
            }

            catch
            {
                return;
            }
        }

        /// <summary>
        /// Chơi lại Game
        /// </summary>
        private void ReplayGame()
        {
            this.canvasMain.Children.Clear();
            this.canvasMain.Children.Add(new Home());
        }
        #endregion

        #region Timer Tick
        private void TimerTickForCallQuestion()
        {
            if (this.isViewGuide == false)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(1000);
                _timeKhoangCachDropStone = 0;
                _timer.Tick += new EventHandler(_timer_Tick_CallQuestion);
                _timer.Start();
            }
        }

        private void _timer_Tick_CallQuestion(object sender, EventArgs e)
        {
            if (_timeKhoangCachDropStone < Commons.GetNumOfQuestionPerLevel(GlobalVariables.Level) && this.didIt == false)
            {
                int numberQuestion = Commons.GetRandomNumber(0, 9);
                questionList.Add(numberQuestion);
                this.AddControlDropStone(numberQuestion, _timeKhoangCachDropStone, 30, 150, true);
            }
            if (_timeKhoangCachDropStone >= Commons.GetNumOfQuestionPerLevel(GlobalVariables.Level))
                this.didIt = true;
            if (_timeKhoangCachDropStone == Commons.GetNumOfQuestionPerLevel(GlobalVariables.Level) + Commons.GetTimeToGuideByLevel(GlobalVariables.Level))
            {
                this.storyboardOpenDoor.Stop();
                this.SoundWhenDoorOpenOrClose();
                this.rtFillAllLink.Visibility = Visibility.Collapsed;
                TimeSpan abc = this.daukfTimeRun.BeginTime.Value;
                this.isTimeOutTick = true;
                this._timeOutSecond = 0;
                this.storyboardTimeRun.Begin();
            }
            this._timeKhoangCachDropStone++;

            if (this.isViewGuide == false)
            {
                if (this.isTimeOutTick == true)
                {
                    this.tblTestTimeOut.Text = _timeOutSecond.ToString();
                    if (_timeOutSecond == Commons.GetTimeLineWhenLevelUp(GlobalVariables.Level))
                    {
                        this.tblTestTimeOut.Text = _timeOutSecond.ToString() +" | "+ Commons.GetTimeLineWhenLevelUp(GlobalVariables.Level).ToString();
                        this.isTimeOutTick = false;
                        this.StoryboardBoy(3);
                    }
                    this._timeOutSecond++;
                    
                }                
            }

            else
            {
                if (this._timeKhoangCachXemGuide == Commons.GetTimeToGuideByLevel(GlobalVariables.Level))
                {
                    this.storyboardOpenDoor.Stop();
                    this.SoundWhenDoorOpenOrClose();
                    this.rtFillAllLink.Visibility = Visibility.Collapsed;
                    this.storyboardTimeRun.Resume();
                    this.isViewGuide = false;
                }
                this._timeKhoangCachXemGuide++;
            }
        }

        #endregion

        #region Storyboard Completed
        /// <summary>
        /// Sự kiện sau khi chạy xong hoạt ảnh khởi động
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stbStart_Completed(object sender, EventArgs e)
        {
            this.storyboardOpenDoor.Begin();
            this.storyboardOpenDoor.Completed += new EventHandler(storyboardOpenDoor_Completed);
        }

        /// <summary>
        /// Sự kiện sau khi Ô Cửa Bí Mật mở
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void storyboardOpenDoor_Completed(object sender, EventArgs e)
        {
            this.SoundWhenDoorOpenOrClose();
            this.TimerTickForCallQuestion();
        }

        /// <summary>
        /// Sự kiện sau khi chạy xong [hoạt ảnh trả lời đúng]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stbBoyOK_Completed(object sender, EventArgs e)
        {
            this.canvasMain.Children.Clear();
            this.canvasMain.Children.Add(new Play());
        }

        /// <summary>
        /// Sự kiện sau khi chạy xong [hoạt ảnh trả lời sai]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stbBoyNotOK_Completed(object sender, EventArgs e)
        {
            this.storyboardTimeRun.Resume();
            this.RepeatThisLevel();
        }

        /// <summary>
        /// Sự kiện sau khi chạy xong [hoạt ảnh hết giờ]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stbBoyCrying_Completed(object sender, EventArgs e)
        {
            this.RepeatThisLevel();
        }
        #endregion        

        #region Save Point
        string securityKey = "ahgnuocgnudgnouhpihncohcab";
        bool _isSubmitting = false;        

        void service_UpdateScoreCompleted(object sender, LuyenTriNho.GameServices.UpdateScoreCompletedEventArgs e)
        {
            int point = e.Result;
            if (point > -1)
                MessageBox.Show("Đã lưu điểm cao nhất của bạn! Bạn được thưởng " + point + " kẹo!");
            else
                MessageBox.Show("Có lỗi xảy ra!");

            _isSubmitting = false;
            HtmlPage.Document.GetElementById("silverlightLoading").SetStyleAttribute("display", "none");
            HtmlPage.Document.GetElementById("silverlightMask").SetStyleAttribute("display", "none");

            this.ReplayGame();
        }

        void service_GetChallengeIDCompleted(object sender, LuyenTriNho.GameServices.GetChallengeIDCompletedEventArgs e)
        {
                int challengeID = e.Result;
                string hash = CalculateHash(GlobalVariables.Points, securityKey);
                service.UpdateScoreAsync(hash, challengeID, GlobalVariables.Points);
        }

        string CalculateHash(int score, string securityKey)
        {
            string str = score + "Secux" + securityKey + "ite";

            SHA256Managed sha = new SHA256Managed();
            Encoding encoding = Encoding.UTF8;

            return Convert.ToBase64String(sha.ComputeHash(encoding.GetBytes(str)));
        }
        #endregion
    }
}