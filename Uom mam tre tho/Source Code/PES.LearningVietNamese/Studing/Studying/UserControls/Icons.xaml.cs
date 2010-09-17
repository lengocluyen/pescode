using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Studying
{
    public partial class Icons : UserControl
    {

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Icons()
        {
            InitializeComponent();

        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.StoryboardZoom.Begin();
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.StoryboardZoom.Stop();
        }


    }
}