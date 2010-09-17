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

namespace LuyenTriNho.Controls
{
    public partial class ucStoryboadDropStone : UserControl
    {
        public ucStoryboadDropStone()
        {
            InitializeComponent();
        }

        public void SetStoneNumberAndPosition(int number, int theNumOfStone)
        {
            switch (number)
            {
                case 0:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question00.png", UriKind.Relative));
                    break;
                case 1:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question01.png", UriKind.Relative));
                    break;
                case 2:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question02.png", UriKind.Relative));
                    break;
                case 3:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question03.png", UriKind.Relative));
                    break;
                case 4:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question04.png", UriKind.Relative));
                    break;
                case 5:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question05.png", UriKind.Relative));
                    break;
                case 6:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question06.png", UriKind.Relative));
                    break;
                case 7:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question07.png", UriKind.Relative));
                    break;
                case 8:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question08.png", UriKind.Relative));
                    break;
                case 9:
                    imgStone.Source = new BitmapImage(new Uri("../Images/QuestionNumbers/question09.png", UriKind.Relative));
                    break;
            }

            edkfStoneDropValue.Value = edkfStoneDropValue.Value - theNumOfStone * imgStone.Height;
            edkfStoneDropValue01.Value = edkfStoneDropValue01.Value - theNumOfStone * imgStone.Height;
            edkfStoneDropValue02.Value = edkfStoneDropValue02.Value - theNumOfStone * imgStone.Height;

            imgDust01.SetValue(Canvas.TopProperty, (double)imgDust01.GetValue(Canvas.TopProperty) - theNumOfStone * imgStone.Height);
            imgDust02.SetValue(Canvas.TopProperty, (double)imgDust02.GetValue(Canvas.TopProperty) - theNumOfStone * imgStone.Height);
            imgDust03.SetValue(Canvas.TopProperty, (double)imgDust03.GetValue(Canvas.TopProperty) - theNumOfStone * imgStone.Height);
            imgDust04.SetValue(Canvas.TopProperty, (double)imgDust04.GetValue(Canvas.TopProperty) - theNumOfStone * imgStone.Height);
        }

        public void StartDropStone()
        {
            this.storyboardStoneDrop.Begin();
            this.storyboardStoneDrop.Completed += new EventHandler(storyboardStoneDrop_Completed);
        }

        public void StartDropStone(int number, int theNumOfStone)
        {
            this.SetStoneNumberAndPosition(number, theNumOfStone);
            this.StartDropStone();
        }

        void storyboardStoneDrop_Completed(object sender, EventArgs e)
        {
            this.meDropStone.Stop();
            this.meDropStone.Play();
        }
    }
}
