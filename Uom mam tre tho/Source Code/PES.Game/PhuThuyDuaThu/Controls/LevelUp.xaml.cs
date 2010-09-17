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

namespace PhuThuyDuaThu.Controls
{
    public partial class LevelUp : UserControl
    {
        public LevelUp()
        {
            InitializeComponent();
            CallAnimation();
        }

        public void CallAnimation()
        {
            meLevelUp.Play();
            stbLevelUp.Begin();
            stbLevelUp.Completed += new EventHandler(stbLevelUp_Completed);
        }

        void stbLevelUp_Completed(object sender, EventArgs e)
        {
            stbLevelUp.Stop();
            this.canvasLevelUP.Children.Clear();
            this.canvasLevelUP.Children.Add(new Play());
        }
    }
}
