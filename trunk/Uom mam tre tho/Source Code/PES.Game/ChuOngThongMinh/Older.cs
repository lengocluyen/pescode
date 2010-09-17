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
        int delayTime = 0;
        int secondTick = 0;
        AppEnum.AnimationTicker animationTick;

        public MainPage()
        {
            InitializeComponent();
            StartUp();
        }

        private void StartUp()
        {
            //Clould flying.
            this.MpClouldFly();

            //Bee flying
            this.MpBeeFly();

            //Bee tired
            BeeBeginTired();
        }

        #region Feelling Of Bee.
        private void MpClouldFly()
        {
            StbDefault.RepeatBehavior = RepeatBehavior.Forever;
            StbDefault.Begin();
        }

        private void MpBeeFly()
        {
            stbBeeMove.RepeatBehavior = RepeatBehavior.Forever;
            stbBeeMove.Begin();
        }

        private void MpBeeDropBall(double dropTo)
        {
            stbBeeMove.Pause();
            ctrlBeeOB.BeeDropBall(dropTo);
            ctrlBeeOB.BeeStrong();
            animationTick = AppEnum.AnimationTicker.dropBall;

            TimeTick(2);
            //this.BeeBeginTired();
        }

        private void BeeBeginTired()
        {
            animationTick = AppEnum.AnimationTicker.beginTired;
            TimeTick(AppConstant.Storyboard_BeeMove_TimeSecond);
        }

        private void BeeEndTired()
        {
            animationTick = AppEnum.AnimationTicker.endTired;
            TimeTick(3);
        }

        private void BeeNotTired()
        {
            animationTick = AppEnum.AnimationTicker.normal;
        }

        private void Result(bool addPoint)
        {
            if (addPoint == true)
            {
                //Cong diem
            }
            else
            {
                //Tru diem
            }
        }

        //Chấm điểm - xét theo toạ độ điểm rơi.
        private void Grading()
        {

        }
        #endregion

        private void hplClick_Click(object sender, RoutedEventArgs e)
        {
            this.MpBeeDropBall(105);
            //this.BeeNotTired();
        } 

        private void TimeTick(int _delay)
        {
            delayTime = _delay;
            DispatcherTimer timertick = new DispatcherTimer();
            timertick.Interval = new TimeSpan(0, 0, 1);
            secondTick = 0;
            timertick.Start();
            timertick.Tick += new EventHandler(timertick_Tick);
        }

        void timertick_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timertick = (DispatcherTimer)sender;
            secondTick += 1;
            if (secondTick == delayTime)
            {
                timertick.Stop();
                switch (animationTick)
                {
                    case AppEnum.AnimationTicker.dropBall:
                        ctrlHoneyJar.AddPoint(AppEnum.Level.level2);
                        //stbBeeMove.Resume();
                        break;
                    case AppEnum.AnimationTicker.beginTired:
                        ctrlBeeOB.BeeTired();                        
                        this.BeeEndTired();
                        break;
                    case AppEnum.AnimationTicker.endTired:
                        this.MpBeeDropBall(105);                        
                        break;
                }
            }
        }
    }
}