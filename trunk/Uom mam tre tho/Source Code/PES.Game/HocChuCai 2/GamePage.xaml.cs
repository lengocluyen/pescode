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
using System.Windows.Threading;
using System.Threading;
using HocChuCai_2.Objects;
using System.Windows.Browser;

namespace HocChuCai_2
{
    public partial class GamePage : UserControl
    {
        #region FIELDS

        DispatcherTimer _timer;
        int _totalTime = 0;
        int _timerSpan = 10;

        List<Butt> _lstButt = new List<Butt>();
        Hand _hand = new Hand();

        Number _score = new Number(true);
        Number _level = new Number(true);
        int _levelTime = 5000;
        int _levelNumButt = 2;
        int _lives = 3;

        bool _isTwoCharForm = false;
        #endregion


        public GamePage()
        {
            InitializeComponent();

            this.SizeChanged += new SizeChangedEventHandler(GamePage_SizeChanged);
            this.Loaded += new RoutedEventHandler(GamePage_Loaded);

            // Tutorial
            Tutorial tut = new Tutorial();
            tut.SetValue(Canvas.LeftProperty, (this.LayoutRoot.Width - tut.Width) / 2);
            tut.SetValue(Canvas.TopProperty, (this.LayoutRoot.Height - tut.Height) / 2);
            tut.SetValue(Canvas.ZIndexProperty, 5);
            tut.dlgStartGame = new Tutorial.DelegateStartGame(StartGame);

            this.LayoutRoot.Children.Add(tut);

            this.canvasBottom.Visibility = Visibility.Collapsed;
        }

        void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            HtmlPage.Plugin.Focus();
        }

        void GamePage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PageScale.ScaleX = 1;
            PageScale.ScaleY = 1;

            // if the plugin is bigger than the minimum values set,
            // scale the contents of the silverlight application

            // get the ratios of plugin height/width to design-time height/width
            double heightRatio = e.NewSize.Height / this.LayoutRoot.Height;
            double widthRatio = e.NewSize.Width / this.LayoutRoot.Width;

            // if the height ratio is smaller than the width ratio
            if (heightRatio < widthRatio)
            {
                // set scale the content based on the height ratio
                PageScale.ScaleX = heightRatio;
                PageScale.ScaleY = heightRatio;
            }
            // if not, set scale based on the width ratio
            else
            {
                PageScale.ScaleX = widthRatio;
                PageScale.ScaleY = widthRatio;
            }
            // scale the content
            this.LayoutRoot.RenderTransform = PageScale;            
        }

        void Play()
        {
            Grid parent = this.Parent as Grid;
            parent.Children.Clear();
            parent.Children.Add(new GamePage());
        }

        private void StartGame()
        {
            this.canvasBottom.Visibility = Visibility.Visible;

            _lstButt.AddRange(new Butt[] { this.Butt1, this.Butt2, this.Butt3, this.Butt4, this.Butt5, this.Butt6 });


            // Game-loop
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(_timerSpan);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();

            // Hand
            this.Cursor = Cursors.None;
            this.LayoutRoot.Children.Add(_hand);
            _hand.SetValue(Canvas.ZIndexProperty, 9);
            this.MouseMove += new MouseEventHandler(MainPage_MouseMove);

            // Set number position
            _score.SetValue(Canvas.LeftProperty, (double)this.imgScore.GetValue(Canvas.LeftProperty) + this.imgScore.Width + 10);
            _score.SetValue(Canvas.TopProperty, (double)this.imgScore.GetValue(Canvas.TopProperty) + 7);
            _score.SetValue(Canvas.ZIndexProperty, 5);
            this.LayoutRoot.Children.Add(_score);
            _score.Data = String.Format("{0:00000}", 0);

            _level.SetValue(Canvas.LeftProperty, (double)this.imgLevel.GetValue(Canvas.LeftProperty) + this.imgLevel.Width + 10);
            _level.SetValue(Canvas.TopProperty, (double)this.imgLevel.GetValue(Canvas.TopProperty) + 7);
            _level.SetValue(Canvas.ZIndexProperty, 5);
            this.LayoutRoot.Children.Add(_level);
            _level.Data = "1";
        }

        void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            _hand.SetValue(Canvas.LeftProperty, e.GetPosition(null).X + 1.0);
            _hand.SetValue(Canvas.TopProperty, e.GetPosition(null).Y + 1.0);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _totalTime += _timerSpan;

            if (_totalTime % _levelTime == 0)
            {
                CloseButt();
                Fail();
                _isReadyToNextTurn = true;
            }

            if (_isReadyToNextTurn)
            {
                OpenButt(_levelNumButt);
                _isReadyToNextTurn = false;
                _totalTime = 0;
            }
        }



        #region BUTT(s)

        bool _isReadyToNextTurn = true;
        private void Butt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_lives > 0)
            {
                Butt butt = sender as Butt;
                if (butt.Character == _choosenChar)
                {
                    _effectSound.Source = new Uri("/Sound/ya.mp3", UriKind.Relative);

                    // Number
                    Number _number = new Number(false);
                    this.LayoutRoot.Children.Add(_number);
                    _number.SetValue(Canvas.LeftProperty, (double)butt.GetValue(Canvas.LeftProperty) + butt.Width / 2);
                    _number.SetValue(Canvas.TopProperty, (double)butt.GetValue(Canvas.TopProperty) + 50);
                    _number.SetValue(Canvas.ZIndexProperty, 10);
                    _number.Data = "50";

                    int score = int.Parse(_score.Data) + 50;
                    _score.Data = String.Format("{0:00000}", score);
                    CheckLevelUp(score);
                }
                else
                    Fail();

                foreach (Butt b in _lstButt)
                    if (b.ButtState == ButtState.Open)
                        b.CloseHead();

                _isReadyToNextTurn = true;
            }

        }

        private void CheckLevelUp(int score)
        {
            if (score % 500 == 0) // Level up
            {
                _timer.Tick -= _timer_Tick;

                if (_levelNumButt < 6)
                    _levelNumButt++;
                else
                {
                    if (_isTwoCharForm)
                        _levelTime /= 2;
                    else
                        _isTwoCharForm = true;
                }

                this.stbLevelUp.Begin();
                this._effectSound.Source = new Uri("/Sound/levelup.mp3", UriKind.Relative);
                _level.Data = (int.Parse(_level.Data) + 1).ToString();
            }
        }

        void stbLevelUp_Completed(object sender, EventArgs e)
        {
            _timer.Tick += _timer_Tick;
        }

        void Fail()
        {
            _effectSound.Source = new Uri("/Sound/wrong.mp3", UriKind.Relative);

            _lives--;
            this.stackLive.Children.RemoveAt(this.stackLive.Children.Count - 1);
            if (_lives == 0) // Game over
            {
                this._backgroundSound.Stop();
                _timer.Tick -= _timer_Tick;

                //this.Opacity = 0.3;

                GameOver gameOver = new GameOver(int.Parse(_score.Data));
                gameOver.SetValue(Canvas.LeftProperty, (this.LayoutRoot.Width - gameOver.Width) / 2);
                gameOver.SetValue(Canvas.TopProperty, (this.LayoutRoot.Height - gameOver.Height) / 2);
                gameOver.SetValue(Canvas.ZIndexProperty, 5);
                gameOver.dlgPlayAgain = new GameOver.DelegatePlayAgain(Play);

                this.LayoutRoot.Children.Add(gameOver);
            }
        }

        void GetRandomButt(int numButtOpen)
        {
            List<int> lstRannum = Common.GetRandomInt(0, 6, numButtOpen);

            // Get open butt(s)
            for (int i = 0; i < _lstButt.Count; i++)
            {
                if (lstRannum.Contains(i))
                    _lstButt[i].ButtState = ButtState.Open;
                else
                    _lstButt[i].ButtState = ButtState.Close;
            }
        }

        string _choosenChar = "";
        void OpenButt(int numButtOpen)
        {
            string[] arrChars = new string[] { "a", "ù", "ê", "b", "c", "d", "à", "e", "ï", "g", "h", "i", "k", "l", "m", "n", "o", "ö", "ú",
                                                "p", "q", "r", "s", "t", "u", "û", "v", "x", "y"};
            string[] arrCharsCapital = new string[] { "A", "Ù", "Ê", "B", "C", "D", "À", "E", "Ï", "G", "H", "I", "K", "L", "M", "N", "O", "Ö", "Ú",
                                                "P", "Q", "R", "S", "T", "U", "Û", "V", "X", "Y"};
            string[] arrCharsSound = new string[] { "a.mp3", "aw.mp3", "aa.mp3", "b.mp3", "c.mp3", "d.mp3", "dd.mp3", "e.mp3", "ee.mp3", "g.mp3",
                                                    "h.mp3", "i.mp3", "k.mp3", "l.mp3", "m.mp3", "n.mp3", "o.mp3", "oo.mp3", "ow.mp3", "p.mp3",
                                                    "q.mp3", "r.mp3", "s.mp3", "t.mp3", "u.mp3", "uw.mp3", "v.mp3", "x.mp3", "y.mp3" };

            // Get random chars
            List<string> lstRanchar = new List<string>();
            List<int> lstRannum = Common.GetRandomInt(0, 29, numButtOpen);

            List<int> lstRannumForCharForm = new List<int>();
            int totalNum = lstRannum.Count;
            if (_isTwoCharForm)
                lstRannumForCharForm = Common.GetRandomInt(0, 100, totalNum);

            for (int i = 0; i < totalNum; i++)
            {
                if (_isTwoCharForm)
                {
                    if (lstRannumForCharForm[i] % 2 == 0)
                        lstRanchar.Add(arrChars[lstRannum[i]]);
                    else
                        lstRanchar.Add(arrCharsCapital[lstRannum[i]]);
                }
                else
                    lstRanchar.Add(arrChars[lstRannum[i]]);
            }

            // Char sound
            int chooseCharIndex = Common.GetRandomInt(0, numButtOpen, 1)[0];
            this._chooseCharSound.Source = new Uri("/Sound/BangChuCai/" + arrCharsSound[lstRannum[chooseCharIndex]], UriKind.Relative);
            _choosenChar = lstRanchar[chooseCharIndex];


            // Assign chars to open butt(s)
            int charIndex = 0;
            GetRandomButt(numButtOpen);
            foreach (Butt butt in _lstButt)
                if (butt.ButtState == ButtState.Open)
                {
                    butt.Character = lstRanchar[charIndex++];
                    butt.OpenHead();
                }
        }

        void CloseButt()
        {
            foreach (Butt butt in _lstButt)
                if (butt.ButtState == ButtState.Open)
                    butt.CloseHead();
        }

        #endregion


        #region SOUNDS

        private void _backgroundSound_MediaEnded(object sender, RoutedEventArgs e)
        {
            this._backgroundSound.Position = TimeSpan.FromSeconds(0);
            this._backgroundSound.Play();
        }

        #endregion

    }
}
