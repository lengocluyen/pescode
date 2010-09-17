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
using System.Windows.Media.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Browser;

namespace Danh_Trong.Objects
{
    public partial class GameOver : UserControl
    {
        public delegate void DelegatePlayAgain();
        public DelegatePlayAgain dlgPlayAgain;

        int _score;
        GameServices.GameServicesSoapClient service = new Danh_Trong.GameServices.GameServicesSoapClient();

        public GameOver(int score)
        {
            InitializeComponent();
            _score = score;

            service.GetChallengeIDCompleted += new EventHandler<Danh_Trong.GameServices.GetChallengeIDCompletedEventArgs>(service_GetChallengeIDCompleted);
            service.UpdateScoreCompleted += new EventHandler<Danh_Trong.GameServices.UpdateScoreCompletedEventArgs>(service_UpdateScoreCompleted);

            Number number = new Number(true);
            number.Data = score.ToString();
            number.SetValue(Canvas.LeftProperty, (this.LayoutRoot.Width - number.Data.Length * 32) / 2 );
            number.SetValue(Canvas.TopProperty, (this.LayoutRoot.Height - 20) / 2);
            number.SetValue(Canvas.ZIndexProperty, 10);

            this.LayoutRoot.Children.Add(number);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgButtonPlayAgain.Source = new BitmapImage(new Uri("gameover_button2.png", UriKind.Relative));
            this.imgTextPlayAgain.Source = new BitmapImage(new Uri("choilai_do.png", UriKind.Relative));
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgButtonPlayAgain.Source = new BitmapImage(new Uri("gameover_button1.png", UriKind.Relative));
            this.imgTextPlayAgain.Source = new BitmapImage(new Uri("choilai_Xanh.png", UriKind.Relative));
        }

        private void imgButtonSubmitScore_MouseEnter(object sender, MouseEventArgs e)
        {
            this.imgButtonSubmitScore.Source = new BitmapImage(new Uri("gameover_button2.png", UriKind.Relative));
            this.imgTextSubmitScore.Source = new BitmapImage(new Uri("Luudiem_do.png", UriKind.Relative));
        }

        private void imgButtonSubmitScore_MouseLeave(object sender, MouseEventArgs e)
        {
            this.imgButtonSubmitScore.Source = new BitmapImage(new Uri("gameover_button1.png", UriKind.Relative));
            this.imgTextSubmitScore.Source = new BitmapImage(new Uri("Luudiem_Xanh.png", UriKind.Relative));
        }

        private void imgButtonPlayAgain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dlgPlayAgain();
        }


        // --------------------------------
        // SUBMIT SCORE
        // --------------------------------

        string securityKey = "dsu3832s213";
        bool _isSubmitting = false;

        private void imgButtonSubmitScore_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isSubmitting)
            {
                _isSubmitting = true;

                HtmlPage.Document.GetElementById("silverlightMask").SetStyleAttribute("display", "block");
                HtmlPage.Document.GetElementById("silverlightLoading").SetStyleAttribute("display", "block");

                service.GetChallengeIDAsync(Common.gameID);
            }
        }

        void service_GetChallengeIDCompleted(object sender, Danh_Trong.GameServices.GetChallengeIDCompletedEventArgs e)
        {
            int challengeID = e.Result;
            string hash = CalculateHash(_score, securityKey);
            service.UpdateScoreAsync(hash, challengeID, _score);
        }

        void service_UpdateScoreCompleted(object sender, Danh_Trong.GameServices.UpdateScoreCompletedEventArgs e)
        {
            int point = e.Result;
            if (point > -1)
                MessageBox.Show("Đã lưu điểm cao nhất của bạn! Bạn được thưởng " + point + " kẹo!");
            else
                MessageBox.Show("Có lỗi xảy ra!");

            _isSubmitting = false;
            HtmlPage.Document.GetElementById("silverlightLoading").SetStyleAttribute("display", "none");
            HtmlPage.Document.GetElementById("silverlightMask").SetStyleAttribute("display", "none");
            dlgPlayAgain();
        }

        string CalculateHash(int score, string securityKey)
        {
            string str = score + "Secux" + securityKey + "ite";

            SHA256Managed sha = new SHA256Managed();
            Encoding encoding = Encoding.UTF8;

            return Convert.ToBase64String(sha.ComputeHash(encoding.GetBytes(str)));
        }

        // --------------------------------
    }
}
