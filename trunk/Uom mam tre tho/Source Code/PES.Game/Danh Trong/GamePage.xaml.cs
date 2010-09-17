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
using Danh_Trong.Objects;
using System.Windows.Browser;

namespace Danh_Trong
{
    public partial class GamePage : UserControl
    {
        FlowRegion _flowRegion = new FlowRegion();
        Drums _drums = new Drums();
        Singer _singer = new Singer();

        Number _score = new Number(true);
        int _lives = 3;

        public GamePage()
        {
            InitializeComponent();

            this.canvasFlow.Children.Add(_flowRegion);
            this.canvasDrums.Children.Add(_drums);
            this.canvasSinger.Children.Add(_singer);

            this.Loaded += new RoutedEventHandler(GamePage_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(GamePage_SizeChanged);
            this.KeyUp += new KeyEventHandler(GamePage_KeyUp);

            _flowRegion.dlgPlayInstruments = new FlowRegion.DelegatePlayInstruments(PlayInstruments);
            _flowRegion.dlgAdjustScore = new FlowRegion.DelegateAdjustScore(AdjustScore);
            _flowRegion.dlgWrong = new FlowRegion.DelegateWrong(Wrong);

            _score.Data = String.Format("{0:0000}", 0);
            this.canvasPoint.Children.Add(_score);

            // Tutorial
            TutBoard tut = new TutBoard();
            this.canvasTutBoard.Children.Add(tut);
            tut.dlgStartGame = new TutBoard.DelegateStartGame(StartGame);
            tut.PlayAnimation();
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

        void StartGame()
        {
            this._backgroundSound.Source = new Uri("/Sound/Cac-Tung-Cac-Tung.mp3", UriKind.Relative);
            _flowRegion.Begin();
        }

        void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            HtmlPage.Plugin.Focus();
            this.Focus();
        }

        void GamePage_KeyUp(object sender, KeyEventArgs e)
        {
            _flowRegion.CheckKey(e.Key);
        }

        void PlayInstruments(int position)
        {
            _drums.Play(position);
        }

        void AdjustScore(int score)
        {
            _score.Data = String.Format("{0:00000}", int.Parse(_score.Data) + score);
        }

        void Wrong()
        {
            _lives--;
            this.canvasLives.Children.RemoveAt(this.canvasLives.Children.Count - 1);
            this._effectSound.Source = new Uri("/Sound/wrong.mp3", UriKind.Relative);
            if (_lives == 0) // Game over
                _backgroundSound_MediaEnded(null, null);
        }

        private void _backgroundSound_MediaEnded(object sender, RoutedEventArgs e)
        {
            this._backgroundSound.Stop();
            this.canvasMainContent.Opacity = 0.5;
            _flowRegion.Stop();

            GameOver gameOver = new GameOver(int.Parse(_score.Data));
            gameOver.SetValue(Canvas.LeftProperty, (this.canvasGameOver.Width - gameOver.Width) / 2);
            gameOver.SetValue(Canvas.TopProperty, (this.canvasGameOver.Height - gameOver.Height) / 2);
            gameOver.SetValue(Canvas.ZIndexProperty, 5);
            gameOver.dlgPlayAgain = new GameOver.DelegatePlayAgain(Play);

            this.canvasGameOver.Children.Add(gameOver);
        }

        void Play()
        {
            Grid parent = this.Parent as Grid;
            parent.Children.Clear();
            parent.Children.Add(new GamePage());
            HtmlPage.Plugin.Focus();
        }
    }
}
