using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using PesHome.LearningServices;
using PesHome.PesSessionServices;
using System.Windows.Media.Imaging;
namespace PesHome
{
    public partial class AvartaUC : UserControl
    {
        #region Avarible
     
        #endregion
        string username = "";
        string _URL = PESCommons.parameters["webURL"];
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public AvartaUC(string urlAvatar,string userName)
        {
          
            InitializeComponent();
            username = userName;

            AvartaImg.Source = new BitmapImage(new Uri(_URL + "images/profileavatar/profileimage.aspx?AccountID=" + urlAvatar, UriKind.RelativeOrAbsolute));
           	this.PupilNameTextBlock.Text = username;

        }

      
        private void image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Entering.Begin();
        }

        private void image_MouseLeave(object sender, MouseEventArgs e)
        {
            Entering.Begin();
        }


        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(_URL + username));
        }

        private void canvas_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Loading.Begin();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loading.Begin();
        }

    }
}