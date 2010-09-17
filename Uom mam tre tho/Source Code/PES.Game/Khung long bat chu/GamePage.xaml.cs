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
using Khung_long_bat_chu.Objects;
using System.Windows.Browser;

namespace Khung_long_bat_chu
{
    public partial class GamePage : UserControl
    {
        TimeBar _timeBar = new TimeBar();
        int _timerSpan = 1000;
        DispatcherTimer _timer = new DispatcherTimer();
        DispatcherTimer _timerStand = new DispatcherTimer();
        DispatcherTimer _timerStop = new DispatcherTimer();

        Dinosaur _dinosaur = new Dinosaur();
        Number _score = new Number(true);

        int _indexArrText = 0;
        double _deltaTime = 0.05;

        // Ghi bằng mã "unicode dựng sẵn"
        string[] _arrText = new string[] { "ba", "mẹ", "cá", "con", "chó", "mèo", "nghĩ", "biết", "hươu", "con cá", "con trâu", "cái chai" };

        public GamePage()
        {
            InitializeComponent();
            this.SizeChanged += new SizeChangedEventHandler(GamePage_SizeChanged);
            this.Loaded += new RoutedEventHandler(GamePage_Loaded);

            // Time bar
            this.canvasTimeBar.Children.Add(_timeBar);

            // Dinosaur
            this.canvasDinosaur.Children.Add(_dinosaur);
            _oldXOfDinosaur = (double)this.canvasDinosaur.GetValue(Canvas.LeftProperty);

            // Set score position
            this.canvasScore.Children.Add(_score);
            _score.Data = String.Format("{0:00000}", 0);


            // Tutorial
            TutBoard tut = new TutBoard();
            this.canvasTutBoard.Children.Add(tut);
            tut.dlgStartGame = new TutBoard.DelegateStartGame(StartGame);
            tut.PlayAnimation();
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
            LayoutRoot.RenderTransform = PageScale;
        }

        private void StartGame()
        {
            // Game-loop
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(_timerSpan);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();

            // Event
            this.LayoutRoot.MouseMove += new MouseEventHandler(GamePage_MouseMove);
            _timeBar.dlgTimeUp = new TimeBar.DelegateTimeUp(TimeUp);

            GenerateBalloon();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timeBar.Decrease(_deltaTime);
        }

        void TimeUp()
        {
            GameOver gameOver = new GameOver(int.Parse(_score.Data));
            gameOver.SetValue(Canvas.LeftProperty, (this.LayoutRoot.Width - gameOver.Width) / 2);
            gameOver.SetValue(Canvas.TopProperty, (this.LayoutRoot.Height - gameOver.Height) / 2);
            gameOver.SetValue(Canvas.ZIndexProperty, 5);
            gameOver.dlgPlayAgain = new GameOver.DelegatePlayAgain(Play);

            this.LayoutRoot.Children.Add(gameOver);
            this.LayoutRoot.MouseMove -= GamePage_MouseMove;
            _timer.Stop();
            this.canvasDinosaur.Children.Clear();
            this.canvasBalloons.Children.Clear();

            _effectSound.Source = new Uri("/Sound/lose2.mp3", UriKind.Relative);
        }

        void Play()
        {
            Grid parent = this.Parent as Grid;
            parent.Children.Clear();
            parent.Children.Add(new GamePage());
        }



        #region DINOSAUR

        double _oldXOfDinosaur = 0;
        void GamePage_MouseMove(object sender, MouseEventArgs e)
        {
            _timerStand.Stop();
            _timerStand.Tick -= _timerStand_Tick;

            double newX = e.GetPosition(LayoutRoot).X - this.canvasDinosaur.Width / 2;
            if (newX > _oldXOfDinosaur) // Run to right
                _dinosaur.Run(true);
            else
                _dinosaur.Run(false);

            this.canvasDinosaur.SetValue(Canvas.LeftProperty, newX);
            _oldXOfDinosaur = newX;

            // Timer stand
            _timerStand.Interval = TimeSpan.FromMilliseconds(200);
            _timerStand.Tick += new EventHandler(_timerStand_Tick);
            _timerStand.Start();
        }

        void _timerStand_Tick(object sender, EventArgs e)
        {
            _dinosaur.Stand();
        }

        #endregion



        #region BALLOONS

        int _currCharIndex;
        void GenerateBalloon()
        {
            if (_indexArrText >= _arrText.Length)
                _indexArrText = 0;

            string text = _arrText[_indexArrText++];
            List<Point> suspendedRegion = new List<Point>();
            suspendedRegion.Add(new Point(0, 0));

            this.txtText.Text = FontHandle.TranslateUnicodeTextToBKHCM2(text);

            for (int i = 0; i < text.Length; i++)
            {
                string character = text[i].ToString();
                character = FontHandle.TranslateUnicodeCharToBKHCM2(character);

                Balloon balloon = new Balloon(character);
                balloon.dlgClick = new Balloon.DelegateClick(BalloonClick);
                balloon.dlgClickCompleted = new Balloon.DelegateClickCompleted(BalloonClickCompleted);

                // Get position
                Point position = GetPositionNotInSuspendedRegion(suspendedRegion, this.canvasBalloons, balloon.LayoutRoot.Width, balloon.LayoutRoot.Height);
                balloon.SetValue(Canvas.LeftProperty, position.X);
                balloon.SetValue(Canvas.TopProperty, position.Y);
                this.canvasBalloons.Children.Add(balloon);
                suspendedRegion.Add(position);
            }

            _currCharIndex = 0;
        }

        void BalloonClick(Balloon balloon)
        {
            try
            {
                _dinosaur.Hit();

                if (balloon.txtChar.Text != FontHandle.TranslateUnicodeCharToBKHCM2(_arrText[_indexArrText - 1][_currCharIndex].ToString())) // Wrong
                {
                    this._effectSound.Source = new Uri("/Sound/wrong.mp3", UriKind.Relative);
                    _timeBar.Decrease(_deltaTime * 3);
                }
                else
                {
                    balloon.Boom();

                    // Number
                    Number _number = new Number(false);
                    this.LayoutRoot.Children.Add(_number);
                    _number.SetValue(Canvas.LeftProperty, (double)balloon.GetValue(Canvas.LeftProperty));
                    _number.SetValue(Canvas.TopProperty, (double)balloon.GetValue(Canvas.TopProperty) + 50);
                    _number.SetValue(Canvas.ZIndexProperty, 10);
                    _number.Data = "50";

                    int score = int.Parse(_score.Data) + 50;
                    _score.Data = String.Format("{0:00000}", score);

                    _currCharIndex++;
                }
            }
            catch { }
        }

        void BalloonClickCompleted(Balloon balloon)
        {
            if (this.canvasBalloons.Children.Count == 0)
            {
                this._effectSound.Source = new Uri("/Sound/win1.mp3", UriKind.Relative);
                
                // Stop game
                this.LayoutRoot.MouseMove -= GamePage_MouseMove;
                _timer.Stop();

                _timeBar.Increase(_deltaTime * 3);

                // Timer stop   
                _timerStop = new DispatcherTimer();
                _timerStop.Interval = TimeSpan.FromMilliseconds(1000);
                _timerStop.Tick += new EventHandler(_timerStop_Tick);
                _timerStop.Start();
            }
        }

        void _timerStop_Tick(object sender, EventArgs e)
        {
            _timerStop.Stop();
            this.LayoutRoot.MouseMove += GamePage_MouseMove;
            _timer.Start();
            GenerateBalloon();            
        }

        private Point GetPositionNotInSuspendedRegion(List<Point> suspendedRegion, Canvas region, double width, double height)
        {
            bool isNeedRetry;
            Point topLeft;

            do
            {
                isNeedRetry = false;

                double x = Common.GetRandomInt(0, (int)(region.Width - width), 1)[0];
                double y = Common.GetRandomInt(0, (int)(region.Height - height), 1)[0];
                topLeft = new Point(x, y);
                Point topRight = new Point(x + width, y);
                Point belowLeft = new Point(x, y + height);
                Point belowRight = new Point(x + width, y + height);

                foreach (Point point in suspendedRegion)
                {
                    if (isPointIn(topLeft, point.X, point.Y, width, height) ||
                        isPointIn(topRight, point.X, point.Y, width, height) ||
                        isPointIn(belowLeft, point.X, point.Y, width, height) ||
                        isPointIn(belowRight, point.X, point.Y, width, height))
                    {
                        isNeedRetry = true;
                        break;
                    }
                }

            } while (isNeedRetry);

            return topLeft;
        }

        bool isPointIn(Point point, double left, double top, double width, double height)
        {
            bool isInHorizontalRegion = (point.X > left && point.X <= left + width);
            bool isInVerticalRegion = (point.Y > top && point.Y <= top + height);

            return isInHorizontalRegion && isInVerticalRegion;
        }

        #endregion


        private void _backgroundSound_MediaEnded(object sender, RoutedEventArgs e)
        {
            this._backgroundSound.Position = TimeSpan.FromSeconds(0);
            this._backgroundSound.Play();
        }
    }
}
