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
using System.Windows.Browser;
using System.Security.Cryptography;
using System.Text;

namespace ChuOngThongMinh
{
    public partial class GameOver : UserControl
    {
        private int points = 0;
        GameServices.GameServicesSoapClient service = new ChuOngThongMinh.GameServices.GameServicesSoapClient();
        public GameOver()
        {
            InitializeComponent();
            this.Startup();
        }

        private void Startup()
        {
            service.GetChallengeIDCompleted += new EventHandler<ChuOngThongMinh.GameServices.GetChallengeIDCompletedEventArgs>(service_GetChallengeIDCompleted);
            service.UpdateScoreCompleted += new EventHandler<ChuOngThongMinh.GameServices.UpdateScoreCompletedEventArgs>(service_UpdateScoreCompleted);
            this.stbClould.RepeatBehavior = RepeatBehavior.Forever;
            this.stbClould.Begin();

            this.stbGameOver.Begin();
            this.stbGameOver.Completed += new EventHandler(stbGameOver_Completed);
        }

        string securityKey = "ahgnuocgnudgnouhphnimgnohtgnouhc";
        bool _isSubmitting = false;

        void service_UpdateScoreCompleted(object sender, ChuOngThongMinh.GameServices.UpdateScoreCompletedEventArgs e)
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

        void service_GetChallengeIDCompleted(object sender, ChuOngThongMinh.GameServices.GetChallengeIDCompletedEventArgs e)
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

        void stbGameOver_Completed(object sender, EventArgs e)
        {
            this.imgFrame.Visibility = Visibility.Visible;
            this.imgPoint.Visibility = Visibility.Visible;
            this.imgReplay.Visibility = Visibility.Visible;
            this.tblPoints.Visibility = Visibility.Visible;
            this.hplReplay.Visibility = Visibility.Visible;
            this.hplSavePoint.Visibility = Visibility.Visible;
            this.imgSavePoint.Visibility = Visibility.Visible;
        }

        public void AddPoint(string points)
        {
            this.tblPoints.Text = points;
        }

        private void hplReplay_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgReplay.Visibility = Visibility.Collapsed;
            this.imgReplaySelected.Visibility = Visibility.Visible;
        }

        private void hplReplay_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgReplay.Visibility = Visibility.Visible;
            this.imgReplaySelected.Visibility = Visibility.Collapsed;
        }

        private void hplReplay_Click(object sender, RoutedEventArgs e)
        {
            this.ReplayGame();
        }

        private void hplSavePoint_Click(object sender, RoutedEventArgs e)
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

        private void ReplayGame()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void hplSavePoint_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgSavePoint.Visibility = Visibility.Visible;
            this.imgSavePointSelected.Visibility = Visibility.Collapsed;
        }

        private void hplSavePoint_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgSavePointSelected.Visibility = Visibility.Visible;
            this.imgSavePoint.Visibility = Visibility.Collapsed;
        }
    }
}
