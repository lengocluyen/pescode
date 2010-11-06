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
using PesHome.PesSessionServices;
using PesHome.LearningServices;
using System.Windows.Browser;

namespace PesHome
{
    public partial class Home : UserControl
    {

        #region Avarible
        Account _account;
        LearningServicesClient learningService = new LearningServicesClient();
        PESServicesSessionSoapClient pesSessionService = new PESServicesSessionSoapClient();
        string _URL = PESCommons.parameters["webURL"];
        #endregion
        public Home()
        {
            InitializeComponent();
            BirdSound.Play();
            pesSessionService.SetPupilLoginIDCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(pesSessionService_SetPupilLoginIDCompleted);
            pesSessionService.GetUserLoginIDCompleted += new EventHandler<GetUserLoginIDCompletedEventArgs>(pesSessionService_GetUserLoginIDCompleted);
            learningService.GetUserByAccountIDCompleted += new EventHandler<GetUserByAccountIDCompletedEventArgs>(learningService_GetUserByAccountIDCompleted);
            pesSessionService.GetUserLoginIDAsync();
            btLogin.Click += new RoutedEventHandler(btLogin_Click);
            btRegister.Click += new RoutedEventHandler(btRegister_Click);
        }

        void learningService_GetUserByAccountIDCompleted(object sender, GetUserByAccountIDCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                _account = e.Result;
                GridAvarta.Children.Clear();
                GridAvarta.Children.Add(new AvartaUC(_account.AccountID.ToString(), _account.Username));
                CanvasLogin.Visibility = Visibility.Collapsed;
                socialNetUC.MouseLeftButtonDown += new MouseButtonEventHandler(SocialNetUC_MouseLeftButtonDown);
                parkUC.MouseLeftButtonDown += new MouseButtonEventHandler(parkControl_MouseLeftButtonDown);
                schoolControl.MouseLeftButtonDown += new MouseButtonEventHandler(SchoolControl_MouseLeftButtonDown);

            }
        }

        void pesSessionService_SetPupilLoginIDCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }
        void btRegister_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(_URL + "Accounts/Register.aspx", UriKind.RelativeOrAbsolute));
        }

        void btLogin_Click(object sender, RoutedEventArgs e)
        {
            learningService.UserLoginCompleted += new EventHandler<UserLoginCompletedEventArgs>(learningService_UserLoginCompleted);
            if (txtUsername.Text.Trim().Length < 1)
            {
                txtError.Text = "Chưa nhập Tên đăng nhập!";
                return;
            }
            if (txtPassword.Password.Length < 1)
            {
                txtError.Text = "Chưa nhập mật khẩu!";
                return;
            }
            if (txtPassword.Password != "" && txtUsername.Text != "")
            {
                learningService.UserLoginAsync(txtUsername.Text, txtPassword.Password);
            }
        }

        void learningService_UserLoginCompleted(object sender, UserLoginCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                _account = e.Result as Account;
                if (_account.EmailVerified == false)
                {
                    _account = null;
                    txtError.Text = "Bạn chưa chứng thực bằng Email!"; return;
                }
                else
                    txtError.Text = "Đăng nhập thành công!";
                pesSessionService.SetPupilLoginIDAsync(_account.AccountID);
                GridAvarta.Children.Clear();
                GridAvarta.Children.Add(new AvartaUC(_account.AccountID.ToString(), _account.Username));
                CanvasLogin.Visibility = Visibility.Collapsed;
                socialNetUC.MouseLeftButtonDown += new MouseButtonEventHandler(SocialNetUC_MouseLeftButtonDown);
                parkUC.MouseLeftButtonDown += new MouseButtonEventHandler(parkControl_MouseLeftButtonDown);
                schoolControl.MouseLeftButtonDown += new MouseButtonEventHandler(SchoolControl_MouseLeftButtonDown);

                //txtError.Visibility = Visibility.Collapsed;
            }
            else { txtError.Text = "Tài khoản không đúng!"; }
        }
        void pesSessionService_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            if (e.Result < 1)
                return;
            else
            {
                learningService.GetUserByAccountIDAsync(e.Result);
            }
        }

        void SchoolControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(_URL + "Learning/Learning.aspx", UriKind.RelativeOrAbsolute));
        }

        void parkControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(_URL + "Homegames/index", UriKind.RelativeOrAbsolute));
        }

        void SocialNetUC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(_URL + "Default.aspx", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            BirdFlyST.Begin();
        }

        private void txtPassword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           
            if (e.Key == Key.Enter)
            {
                learningService.UserLoginCompleted += new EventHandler<UserLoginCompletedEventArgs>(learningService_UserLoginCompleted);
                if (txtUsername.Text.Trim().Length < 1)
                {
                    txtError.Text = "Chưa nhập Tên đăng nhập!";
                    return;
                }
                if (txtPassword.Password.Length < 1)
                {
                    txtError.Text = "Chưa nhập mật khẩu!";
                    return;
                }
                if (txtPassword.Password != "" && txtUsername.Text != "")
                {
                    learningService.UserLoginAsync(txtUsername.Text, txtPassword.Password);
                }
            }
        }

    }
}