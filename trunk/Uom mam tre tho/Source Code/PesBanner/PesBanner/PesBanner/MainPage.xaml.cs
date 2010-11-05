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

namespace PesBanner
{
   
	public partial class MainPage : UserControl
	{

        string _URL;
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            try
            {
                _URL = PESCommons.parameters["webURL"];
            }
            catch
            {
                return;
            }
            
			this.Storyboard_Bird.Begin();
		}

		private void image_Park_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            HtmlPage.Window.Navigate(new Uri(_URL + "Homegames/index", UriKind.RelativeOrAbsolute));
		}

		private void image_Edu_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            HtmlPage.Window.Navigate(new Uri(_URL + "Learning/Learning.aspx", UriKind.RelativeOrAbsolute));
		}

		private void Image_Social_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            HtmlPage.Window.Navigate(new Uri(_URL + "Default.aspx", UriKind.RelativeOrAbsolute));
		}
	}
}