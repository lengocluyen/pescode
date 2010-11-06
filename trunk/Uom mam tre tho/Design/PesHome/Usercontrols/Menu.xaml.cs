using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PesHome.LearningServices;
using PesHome.PesSessionServices;
using System.Windows.Browser;

namespace PesHome
{
	public partial class Menu : UserControl
	{
        LearningServicesClient learningService = new LearningServicesClient();
        PESServicesSessionSoapClient pesSessionService = new PESServicesSessionSoapClient();
        string _URL = PESCommons.parameters["webURL"];
		public Menu()
		{
			// Required to initialize variables
			InitializeComponent();
            
            pesSessionService.SetPupilLoginIDCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(pesSessionService_SetPupilLoginIDCompleted);
            pesSessionService.GetUserLoginIDCompleted += new EventHandler<GetUserLoginIDCompletedEventArgs>(pesSessionService_GetUserLoginIDCompleted);
           
		}

        void pesSessionService_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            
                if (e.Result > 0)
                {
                    pesSessionService.SetPupilLoginIDAsync(-1);

                }
        }

        void pesSessionService_SetPupilLoginIDCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri(_URL + "Learning/defaults.aspx", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingST.Begin();
        }
        int pp;
       
        private void Contactimage_MouseEnter(object sender, MouseEventArgs e)
        {
            ContactST.Begin();
        }

        private void Contactimage_MouseLeave(object sender, MouseEventArgs e)
        {
            ContactST.Stop();
        }

        private void Exitimage_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitST.Begin();
        }

        private void Exitimage_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitST.Stop();
        }

        private void Helpimage_MouseEnter(object sender, MouseEventArgs e)
        {
            HelpST.Begin();
        }

        private void Helpimage_MouseLeave(object sender, MouseEventArgs e)
        {
            HelpST.Stop();
        }

        private void Helpimage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Exitimage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            pesSessionService.GetUserLoginIDAsync();
            
        }

        private void Contactimage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainPage rootPage = Application.Current.RootVisual as MainPage;
            rootPage.LayoutRoot.Children.Clear();
            Home home = new Home();
            home.ContentBorder.Children.Add(new Aboutus());
            rootPage.LayoutRoot.Children.Add(home);
        }
	}
}