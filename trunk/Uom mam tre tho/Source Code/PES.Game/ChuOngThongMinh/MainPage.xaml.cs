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

namespace ChuOngThongMinh
{
    public partial class MainPage : UserControl
    {
        #region Variables
        private int resultJar1;
        private int resultJar2;
        private int resultJar3;
        private int resultBall;
        private int beeLifes = 0;
        //static int points = 0;
        private bool beeHoldBall = true;

        private bool beeDropingBall = false;
        private int delayTime = 0;
        private int secondTick = 0;
        private AppEnum.AnimationTicker animationTick;

        static AppEnum.Level currentLevel;
        #endregion

        public MainPage()
        {
            InitializeComponent();
            this.SizeChanged += new SizeChangedEventHandler(MainPage_SizeChanged);
        }

        #region StartUp
        public void StartUp()
        {
            //Change some properties
            hplClick.Cursor = Cursors.None;
            MouseMove += new MouseEventHandler(MainPage_MouseMove);
            tblPoints.Text = "0";
            beeLifes = 5;

            this.ShowLifes();

            //Clould flying.
            this.MpClouldFly();

            //Bee flying
            this.MpBeeFly();

            //Assign Calculation to Jar
            this.AssignCalculation();

            //Assign area
            this.AssignAreas();

            //this.BeeBeginTired();
        }

        private void ShowLifes()
        {
            switch (beeLifes)
            {
                case 1:
                    this.imgLife01.Visibility = Visibility.Collapsed;
                    this.imgLife02.Visibility = Visibility.Collapsed;
                    this.imgLife03.Visibility = Visibility.Collapsed;
                    this.imgLife04.Visibility = Visibility.Collapsed;
                    this.imgLife05.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.imgLife01.Visibility = Visibility.Collapsed;
                    this.imgLife02.Visibility = Visibility.Collapsed;
                    this.imgLife03.Visibility = Visibility.Collapsed;
                    this.imgLife04.Visibility = Visibility.Visible;
                    this.imgLife05.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.imgLife01.Visibility = Visibility.Collapsed;
                    this.imgLife02.Visibility = Visibility.Collapsed;
                    this.imgLife03.Visibility = Visibility.Visible;
                    this.imgLife04.Visibility = Visibility.Visible;
                    this.imgLife05.Visibility = Visibility.Visible;
                    break;
                case 4:
                    this.imgLife01.Visibility = Visibility.Collapsed;
                    this.imgLife02.Visibility = Visibility.Visible;
                    this.imgLife03.Visibility = Visibility.Visible;
                    this.imgLife04.Visibility = Visibility.Visible;
                    this.imgLife05.Visibility = Visibility.Visible;
                    break;
                case 5:
                    this.imgLife01.Visibility = Visibility.Visible;
                    this.imgLife02.Visibility = Visibility.Visible;
                    this.imgLife03.Visibility = Visibility.Visible;
                    this.imgLife04.Visibility = Visibility.Visible;
                    this.imgLife05.Visibility = Visibility.Visible;
                    break;

                case 0:
                    GameOver();
                    break;
            }
        }

        private void MpClouldFly()
        {
            this.StbDefault.Stop();
            this.StbDefault.RepeatBehavior = RepeatBehavior.Forever;
            this.StbDefault.Begin();
        }

        //Assign Calculation
        private void AssignCalculation()
        {
            string addToJar = string.Empty;

            //Assign to Jar 1.
            ChooseCalculation(currentLevel, ref resultJar1, ref addToJar);
            ctrlHoneyJar.AssignMath(addToJar);

            //Assign to Jar 2.
            ChooseCalculation(currentLevel, ref resultJar2, ref addToJar);
            ctrlHoneyJar1.AssignMath(addToJar);

            //Assign to Jar 3.
            ChooseCalculation(currentLevel, ref resultJar3, ref addToJar);
            ctrlHoneyJar2.AssignMath(addToJar);

            resultBall = GetRandomResult();

            ctrlBeeOB.AddNumberToBall(resultBall.ToString());
        }

        //Choose Calculation
        private void ChooseCalculation(AppEnum.Level _level, ref int resultOfCalculation, ref string resultToAddToJar)
        {
            int firstNumber = 0;
            int secondNumber = 0;

            switch (_level)
            {
                case AppEnum.Level.level1:
                    firstNumber = Commons.GetRandomNumber(AppConstant.Level1_Number_From, AppConstant.Level1_Number_To);
                    secondNumber = Commons.GetRandomNumber(AppConstant.Level1_Number_From, AppConstant.Level1_Number_To);
                    break;
                case AppEnum.Level.level2:
                    firstNumber = Commons.GetRandomNumber(AppConstant.Level2_Number_From, AppConstant.Level2_Number_To);
                    secondNumber = Commons.GetRandomNumber(AppConstant.Level2_Number_From, AppConstant.Level2_Number_To);
                    break;
                case AppEnum.Level.level3:
                    firstNumber = Commons.GetRandomNumber(AppConstant.Level3_Number_From, AppConstant.Level3_Number_To);
                    secondNumber = Commons.GetRandomNumber(AppConstant.Level3_Number_From, AppConstant.Level3_Number_To);
                    break;
            }
            AppEnum.Calculation calcul = Commons.GetRandomCalculation();

            switch (calcul)
            {
                case AppEnum.Calculation.mathAdd:
                    resultOfCalculation = firstNumber + secondNumber;
                    resultToAddToJar = firstNumber + " + " + secondNumber;
                    break;
                case AppEnum.Calculation.mathdEliminate:
                    resultOfCalculation = firstNumber - secondNumber;
                    resultToAddToJar = firstNumber + " - " + secondNumber;
                    break;
            }
        }

        //Get ramdom result
        private int GetRandomResult()
        {
            int randomNum = Commons.GetRandomNumber(1, 3);
            int result = 0;

            switch (randomNum)
            {
                case 1:
                    result = resultJar1;
                    break;
                case 2:
                    result = resultJar2;
                    break;
                case 3:
                    result = resultJar3;
                    break;
            }

            return result;
        }

        private void AssignAreas()
        {
            AppConstant.Jar1_Area_From = Convert.ToDouble(ctrlHoneyJar.GetValue(Canvas.LeftProperty)) + AppConstant.Distance_First;
            AppConstant.Jar2_Area_From = Convert.ToDouble(ctrlHoneyJar1.GetValue(Canvas.LeftProperty)) + AppConstant.Distance_First;
            AppConstant.Jar3_Area_From = Convert.ToDouble(ctrlHoneyJar2.GetValue(Canvas.LeftProperty)) + AppConstant.Distance_First;
        }

        #endregion

        #region Timer Tick
        private void TimerTick(int _delay)
        {
            delayTime = _delay;
            secondTick = 0;
            DispatcherTimer timertick = new DispatcherTimer();
            timertick.Interval = new TimeSpan(0, 0, 1);

            timertick.Start();
            timertick.Tick += new EventHandler(timertick_Tick);
        }

        void timertick_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timertick = (DispatcherTimer)sender;
            secondTick ++;
            if (secondTick == delayTime)
            {
                timertick.Stop();
                switch (animationTick)
                {
                    case AppEnum.AnimationTicker.dropBall:
                        this.DropBallCompleted(true);
                        break;
                    //case AppEnum.AnimationTicker.beginTired:
                    //    ctrlBeeOB.BeeTired();
                    //    this.BeeEndTired();
                    //    break;
                    //case AppEnum.AnimationTicker.endTired:
                    //    this.MpBeeDropBall(true);
                    //    break;
                }
            }
        }
        #endregion

        #region Bee State
        private void MpBeeFly()
        {
            this.stbBeeMove.Stop();
            this.stbBeeMove.RepeatBehavior = RepeatBehavior.Forever;
            this.stbBeeMove.Begin();
        }

        private void MpBeeTired()
        {
            ctrlBeeOB.BeeTired();
        }

        private void BeeBeginTired()
        {
            animationTick = AppEnum.AnimationTicker.beginTired;
            TimerTick(AppConstant.Storyboard_BeeMove_TimeSecond);
        }

        private void BeeEndTired()
        {
            animationTick = AppEnum.AnimationTicker.endTired;
            TimerTick(2);
        }

        private void MpBeeDropBall(bool tired)
        {
            double height = 0;
            if (tired == true)
                height = Commons.GetHeightToDrop(currentLevel) / 2;
            else
                height = Commons.GetHeightToDrop(currentLevel);

            this.stbBeeMove.Pause();
            ctrlBeeOB.BeeDropBall(height);
            this.beeDropingBall = true;
            this.animationTick = AppEnum.AnimationTicker.dropBall;
            this.TimerTick(1);
        }
        #endregion

        #region Private Function
        private void MoveCursorToCurrentPosition(Point pt)
        {
            imgHandHold.SetValue(Canvas.LeftProperty, pt.X);
            imgHandHold.SetValue(Canvas.TopProperty, pt.Y);

            imgHand.SetValue(Canvas.LeftProperty, pt.X);
            imgHand.SetValue(Canvas.TopProperty, pt.Y);
        }

        private void DropBallCompleted(bool clicked)
        {
            if (clicked == true)
            {
                double ballPosition = Convert.ToDouble(ctrlBeeOB.GetValue(Canvas.LeftProperty));
                if (ballPosition >= AppConstant.Jar1_Area_From && ballPosition <= (AppConstant.Jar1_Area_From + AppConstant.Distance_Second))
                {
                    if (resultBall == resultJar1)
                    {
                        ctrlHoneyJar.AddPoint(currentLevel);
                        GlobalVariables.Points += Commons.GetPointsToAdd(currentLevel);
                    }
                    else
                    {
                        ctrlHoneyJar.EliminatePoint(currentLevel);
                        GlobalVariables.Points -= Commons.GetPointsToEliminate(currentLevel);
                        beeLifes--;
                        ShowLifes();
                    }
                }

                else if (ballPosition >= AppConstant.Jar2_Area_From && ballPosition <= (AppConstant.Jar2_Area_From + AppConstant.Distance_Second))
                {
                    if (resultBall == resultJar2)
                    {
                        ctrlHoneyJar1.AddPoint(currentLevel);
                        GlobalVariables.Points += Commons.GetPointsToAdd(currentLevel);
                    }
                    else
                    {
                        ctrlHoneyJar1.EliminatePoint(currentLevel);
                        GlobalVariables.Points -= Commons.GetPointsToEliminate(currentLevel);
                        beeLifes--;
                        ShowLifes();
                    }
                }

                else if (ballPosition >= AppConstant.Jar3_Area_From && ballPosition <= (AppConstant.Jar3_Area_From + AppConstant.Distance_Second))
                {
                    if (resultBall == resultJar3)
                    {
                        ctrlHoneyJar2.AddPoint(currentLevel);
                        GlobalVariables.Points += Commons.GetPointsToAdd(currentLevel);
                    }
                    else
                    {
                        ctrlHoneyJar2.EliminatePoint(currentLevel);
                        GlobalVariables.Points -= Commons.GetPointsToEliminate(currentLevel);
                        beeLifes--;
                        ShowLifes();
                    }
                }

                else
                {
                    this.EliminatePoints();
                }
            }
            else
                this.EliminatePoints();

            //After ball droped.
            stbBeeMove.Resume();
            this.AssignCalculation();

            this.imgHand.Visibility = Visibility.Collapsed;
            this.imgHandHold.Visibility = Visibility.Visible;

            tblPoints.Text = GlobalVariables.Points.ToString();
            this.beeDropingBall = false;
            //this.BeeBeginTired();
        }

        private void EliminatePoints()
        {
            if (resultBall == resultJar1)
                ctrlHoneyJar.EliminatePoint(currentLevel);
            else
                if (resultBall == resultJar2)
                    ctrlHoneyJar1.EliminatePoint(currentLevel);
                else
                    ctrlHoneyJar2.EliminatePoint(currentLevel);

            GlobalVariables.Points -= Commons.GetPointsToEliminate(currentLevel);

            beeLifes--;
            this.ShowLifes();
        }

        private void GameOver()
        {
            this.ctrlHomePage.Visibility = Visibility.Visible;
            this.ctrlGameOver.Visibility = Visibility.Visible;
            this.canvasHomeButton.Visibility = Visibility.Visible;
            this.ctrlGameOver.AddPoint(GlobalVariables.Points.ToString());
        }
        #endregion

        #region Event Handle
        void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PageScale.ScaleX = 1;
            PageScale.ScaleY = 1;

            // if the plugin is bigger than the minimum values set,
            // scale the contents of the silverlight application

            // get the ratios of plugin height/width to design-time height/width
            double heightRatio = e.NewSize.Height / this.canvasMain.Height;
            double widthRatio = e.NewSize.Width / this.canvasMain.Width;

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
            this.canvasMain.RenderTransform = PageScale;
        }

        private void hplClick_Click(object sender, RoutedEventArgs e)
        {
            if (beeDropingBall == true)
                return;
            this.imgHandHold.Visibility = Visibility.Collapsed;
            this.imgHand.Visibility = Visibility.Visible;
            this.MpBeeDropBall(false);
        }

        private void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(canvasMain);
            MoveCursorToCurrentPosition(position);
        }

        private void hplMute_Click(object sender, RoutedEventArgs e)
        {
            if (imgMusic.Visibility == Visibility.Visible)
            {
                imgMusic.Visibility = Visibility.Collapsed;
                imgMute.Visibility = Visibility.Visible;
            }
            else
            {
                imgMusic.Visibility = Visibility.Visible;
                imgMute.Visibility = Visibility.Collapsed;
            }
        }

        private void hplMute_MouseEnter(object sender, MouseEventArgs e)
        {
            imgHand.Visibility = Visibility.Collapsed;
            imgHandHold.Visibility = Visibility.Collapsed;
        }

        private void hplMute_MouseLeave(object sender, MouseEventArgs e)
        {
            if (beeHoldBall == true)
            {
                imgHandHold.Visibility = Visibility.Visible;
                imgHand.Visibility = Visibility.Collapsed;
            }
            else
            {
                imgHandHold.Visibility = Visibility.Collapsed;
                imgHand.Visibility = Visibility.Visible;
            }

        }

        private void hplbStart_MouseEnter(object sender, MouseEventArgs e)
        {
            imgStart.Visibility = Visibility.Collapsed;
            imgStartSelected.Visibility = Visibility.Visible;
        }

        private void hplbStart_MouseLeave(object sender, MouseEventArgs e)
        {
            imgStart.Visibility = Visibility.Visible;
            imgStartSelected.Visibility = Visibility.Collapsed;
        }

        private void hplbUseGuide_MouseEnter(object sender, MouseEventArgs e)
        {
            imgUseGuide.Visibility = Visibility.Collapsed;
            imgUseGuideSelected.Visibility = Visibility.Visible;
        }

        private void hplbUseGuide_MouseLeave(object sender, MouseEventArgs e)
        {
            imgUseGuide.Visibility = Visibility.Visible;
            imgUseGuideSelected.Visibility = Visibility.Collapsed;
        }

        private void hplbStart_Click(object sender, RoutedEventArgs e)
        {
            this.canvasHomeButton.Visibility = Visibility.Collapsed;
            this.ctrlHomePage.Visibility = Visibility.Collapsed;
            this.ctrlUseGuide.Visibility = Visibility.Collapsed;

            this.StartUp();
        }

        private void hplbUseGuide_Click(object sender, RoutedEventArgs e)
        {
            this.stbUseGuide.Begin();
        }
        #endregion
    }
}