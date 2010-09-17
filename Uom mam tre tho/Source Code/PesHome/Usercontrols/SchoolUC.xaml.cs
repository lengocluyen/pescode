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

namespace PesHome
{
	public partial class SchoolUC : UserControl
	{
		public SchoolUC()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        
        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            Entering.Begin();
        }

        private void image_MouseLeave(object sender, MouseEventArgs e)
        {
            Entering.Stop();
        }
	}
}