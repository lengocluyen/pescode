using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PesHome
{
	public partial class Aboutus : UserControl
	{
		public Aboutus()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			LoadingST.Begin();
		}

		private void btOut_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Visibility = Visibility.Collapsed;
            MainPage rootPage = Application.Current.RootVisual as MainPage;
            rootPage.LayoutRoot.Children.Clear();
            Home home = new Home();
            rootPage.LayoutRoot.Children.Add(home);
		}
	}
}