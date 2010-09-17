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

namespace Danh_Trong.Objects
{
    public enum KeyResult
    {
        Miss,
        Good,
        Perfect
    }

    public partial class FlowRegion : UserControl
    {
        DispatcherTimer _timer = new DispatcherTimer();
        int _time = 0;
        int _timeSpan = 50;

        Color[] arrColors = new Color[] { Colors.Black, Colors.Blue, Colors.Brown, Colors.Cyan, Colors.DarkGray, Colors.Gray, Colors.Green,
                                        Colors.LightGray, Colors.Magenta, Colors.Orange, Colors.Purple, Colors.Red, Colors.White};

        public delegate void DelegatePlayInstruments(int position);
        public DelegatePlayInstruments dlgPlayInstruments;
        public delegate void DelegateAdjustScore(int score);
        public DelegateAdjustScore dlgAdjustScore;
        public delegate void DelegateWrong();
        public DelegateWrong dlgWrong;

        public FlowRegion()
        {
            InitializeComponent();
        }

        public void Begin()
        {
            // Game-loop
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(_timeSpan);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _time += _timeSpan;
            PlayScript(ScriptCollection.ScriptOne, _time);
            DoAnimationForAllCanvas();
        }

        public void Stop()
        {
            _timer.Tick -= _timer_Tick;
        }

        public void CheckKey(Key key)
        {
            string character = Common.ConvertKeyToCharacter(key);
            if (character == String.Empty)
                return;
            else
                FindCharacterInCorrectRegion(character);
        }

        void FindCharacterInCorrectRegion(string character)
        {
            int position = 0;

            EnterKeyResult result = FindCharacterInCorrectRegionByCanvas(this.canvasChar1, character);
            position = 1;
            if (result.Result == KeyResult.Miss)
            {
                result = FindCharacterInCorrectRegionByCanvas(this.canvasChar2, character);
                position = 2;
            }
            if (result.Result == KeyResult.Miss)
            {
                result = FindCharacterInCorrectRegionByCanvas(this.canvasChar3, character);
                position = 3;
            }
            if (result.Result == KeyResult.Miss)
            {
                result = FindCharacterInCorrectRegionByCanvas(this.canvasChar4, character);
                position = 4;
            }
            if (result.Result == KeyResult.Miss)
            {
                result = FindCharacterInCorrectRegionByCanvas(this.canvasChar5, character);
                position = 5;
            }

            if (result.Result == KeyResult.Miss)
                dlgWrong();
            else
            {
                Number _number = new Number(false);
                this.LayoutRoot.Children.Add(_number);
                _number.SetValue(Canvas.LeftProperty, (double)result.TextControl.GetValue(Canvas.LeftProperty));
                _number.SetValue(Canvas.TopProperty, (double)result.TextControl.GetValue(Canvas.TopProperty) - 100);
                _number.SetValue(Canvas.ZIndexProperty, 10);

                if (result.Result == KeyResult.Good)
                {
                    _number.Data = "50";
                    dlgAdjustScore(50);
                }
                else // Perfect
                {
                    _number.Data = "100";
                    dlgAdjustScore(100);
                }

                (result.TextControl.Parent as Canvas).Children.Remove(result.TextControl);

                if (position > 0)
                    dlgPlayInstruments(position);
            }
        }

        EnterKeyResult FindCharacterInCorrectRegionByCanvas(Canvas canvas, string character)
        {
            //double topLine = (double)this.canvasCorrectRegion.GetValue(Canvas.TopProperty);
            //double bottomLine = (double)this.canvasCorrectRegion.GetValue(Canvas.TopProperty) + this.canvasCorrectRegion.Height;

            int keyTime = 4500;

            TextBlock txt;
            foreach (UIElement ui in canvas.Children)
            {
                if (ui is TextBlock && (txt = ui as TextBlock).Text == character)
                {
                    //double top = (double)txt.GetValue(Canvas.TopProperty);
                    //double bottom = top + txt.ActualHeight;
                    //if ((top < topLine && bottom < bottomLine && bottom > topLine) || (top > topLine && top < bottomLine && bottom > bottomLine))
                    //    return new EnterKeyResult(txt, KeyResult.Good);
                    //else if ((top > topLine && bottom < bottomLine))
                    //    return new EnterKeyResult(txt, KeyResult.Perfect);
                    //else
                    //    return new EnterKeyResult(txt, KeyResult.Miss);

                    if ((int)txt.Tag > keyTime - 200 && (int)txt.Tag < keyTime + 200)
                        return new EnterKeyResult(txt, KeyResult.Perfect);
                    else if ((int)txt.Tag > keyTime - 700 && (int)txt.Tag < keyTime + 700)
                        return new EnterKeyResult(txt, KeyResult.Good);
                }
            }

            return new EnterKeyResult(null, KeyResult.Miss);
        }


        #region SCRIPTs

        void PlayScript(List<Script> lstScript, int time)
        {
            foreach (Script script in lstScript)
                if (script.Time == time)
                    AddCharacter(script.Character, script.Position);
        }

        void AddCharacter(string character, int position)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 70;
            textBlock.Text = character;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.FontFamily = new FontFamily("../../Fonts/CHERI__.TTF#Cheri");

            int randColor = Common.GetRandomInt(0, arrColors.Length, 1)[0];
            textBlock.Foreground = new SolidColorBrush(arrColors[randColor]);

            textBlock.Tag = 0;

            Canvas canvas = GetCanvasByPosition(position);
            canvas.Children.Add(textBlock);
            textBlock.SetValue(Canvas.LeftProperty, (canvas.Width - textBlock.ActualWidth) / 2);
        }

        Canvas GetCanvasByPosition(int position)
        {
            if (position == 1)
                return this.canvasChar1;
            else if (position == 2)
                return this.canvasChar2;
            else if (position == 3)
                return this.canvasChar3;
            else if (position == 4)
                return this.canvasChar4;
            else if (position == 5)
                return this.canvasChar5;

            return this.canvasChar1;
        }

        #endregion



        #region ANIMATIONs

        void DoAnimation(Canvas canvas)
        {
            List<UIElement> lstNeedRemoved = new List<UIElement>();

            foreach (UIElement ui in canvas.Children)
                if (ui is TextBlock)
                {
                    (ui as TextBlock).Tag = (int)(ui as TextBlock).Tag + _timeSpan;
                    double position = (double)ui.GetValue(Canvas.TopProperty) + 3;
                    ui.SetValue(Canvas.TopProperty, position);
                    if (position + (ui as TextBlock).ActualHeight - 30 > canvas.Height)
                    {
                        DoFade(ui);
                        lstNeedRemoved.Add(ui);
                    }
                }

            foreach (UIElement ui in lstNeedRemoved)
            {
                if ((double)ui.GetValue(Canvas.TopProperty) > this.canvasBG.Height)
                    canvas.Children.Remove(ui);
            }
        }

        void DoAnimationForAllCanvas()
        {
            DoAnimation(this.canvasChar1);
            DoAnimation(this.canvasChar2);
            DoAnimation(this.canvasChar3);
            DoAnimation(this.canvasChar4);
            DoAnimation(this.canvasChar5);
        }

        void DoFade(UIElement ui)
        {
            Storyboard stb = new Storyboard();

            DoubleAnimationUsingKeyFrames doubleAnimation = new DoubleAnimationUsingKeyFrames();
            Storyboard.SetTarget(doubleAnimation, ui);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(UIElement.OpacityProperty));

            EasingDoubleKeyFrame easing1 = new EasingDoubleKeyFrame();
            easing1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.5));
            easing1.Value = 0;

            doubleAnimation.KeyFrames.Add(easing1);

            stb.Children.Add(doubleAnimation);
            stb.Begin();
        }

        #endregion
    }

    public class EnterKeyResult
    {
        TextBlock _textControl;

        public TextBlock TextControl
        {
            get { return _textControl; }
            set { _textControl = value; }
        }
        KeyResult _result;

        public KeyResult Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public EnterKeyResult(TextBlock textBlock, KeyResult result)
        {
            this.TextControl = textBlock;
            this.Result = result;
        }
    }
}
