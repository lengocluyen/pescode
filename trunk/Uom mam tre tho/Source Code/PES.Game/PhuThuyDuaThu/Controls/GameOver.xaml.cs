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
using PhuThuyDuaThu.Codes;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Browser;

namespace PhuThuyDuaThu.Controls
{
    public partial class GameOver : UserControl
    {
        GameServices.GameServicesSoapClient service = new PhuThuyDuaThu.GameServices.GameServicesSoapClient();
        string securityKey = "ahgnuocgnudgnouhpuhtaudyuhtuhp";
        bool _isSubmitting = false;
        MapNumbersToImages ctrlNumber;

        public GameOver()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(GameOver_Loaded);
        }

        void GameOver_Loaded(object sender, RoutedEventArgs e)
        {
            service.GetChallengeIDCompleted += new EventHandler<PhuThuyDuaThu.GameServices.GetChallengeIDCompletedEventArgs>(service_GetChallengeIDCompleted);
            service.UpdateScoreCompleted += new EventHandler<PhuThuyDuaThu.GameServices.UpdateScoreCompletedEventArgs>(service_UpdateScoreCompleted);

            ctrlNumber = new MapNumbersToImages(GlobalVarialble.Points, Constants.YellowNumber, 30, 30, true);
            ctrlNumber.SetValue(Canvas.LeftProperty, (double)200);
            ctrlNumber.SetValue(Canvas.TopProperty, (double)240);

            this.canvasGameOver.Children.Add(ctrlNumber);
        }

        #region Save Point

        void service_UpdateScoreCompleted(object sender, PhuThuyDuaThu.GameServices.UpdateScoreCompletedEventArgs e)
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

        void service_GetChallengeIDCompleted(object sender, PhuThuyDuaThu.GameServices.GetChallengeIDCompletedEventArgs e)
        {
            int challengeID = e.Result;
            string hash = CalculateHash(GlobalVarialble.Points, securityKey);
            service.UpdateScoreAsync(hash, challengeID, GlobalVarialble.Points);            
        }

        string CalculateHash(int score, string securityKey)
        {
            string str = score + "Secux" + securityKey + "ite";

            SHA256Managed sha = new SHA256Managed();
            Encoding encoding = Encoding.UTF8;

            return Convert.ToBase64String(sha.ComputeHash(encoding.GetBytes(str)));
        }

        #endregion

        private void hplReplay_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgBtnReplay.Visibility = Visibility.Collapsed;
            this.imgBtnReplaySelected.Visibility = Visibility.Visible;
        }

        private void hplReplay_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgBtnReplay.Visibility = Visibility.Visible;
            this.imgBtnReplaySelected.Visibility = Visibility.Collapsed;
        }

        private void hplReplay_Click(object sender, RoutedEventArgs e)
        {
            this.ReplayGame();
        }

        private void hplSavePoint_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgBtnSavePoint.Visibility = Visibility.Collapsed;
            this.imgBtnSavePointSelected.Visibility = Visibility.Visible;
        }

        private void hplSavePoint_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgBtnSavePoint.Visibility = Visibility.Visible;
            this.imgBtnSavePointSelected.Visibility = Visibility.Collapsed;
        }

        private void hplSavePoint_Click(object sender, RoutedEventArgs e)
        {
            //Lưu điểm
            if (!_isSubmitting)
            {
                _isSubmitting = true;

                HtmlPage.Document.GetElementById("silverlightMask").SetStyleAttribute("display", "block");
                HtmlPage.Document.GetElementById("silverlightLoading").SetStyleAttribute("display", "block");

                service.GetChallengeIDAsync(GlobalVarialble.GameID);
            }
        }

        private void ReplayGame()
        {
            this.canvasGameOver.Children.Clear();
            this.canvasGameOver.Children.Add(new Home());
        }
    }
}
