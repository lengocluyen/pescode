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

namespace ChuOngThongMinh
{
    public partial class HoneyJar : UserControl
    {
        public HoneyJar()
        {
            InitializeComponent();
            HoneyJarShake();
        }

        public void HoneyJarShake()
        {
            StbShake.RepeatBehavior = RepeatBehavior.Forever;
            StbShake.Begin();
        }

        public void AddPoint(AppEnum.Level level)
        {
            switch (level)
            {
                case AppEnum.Level.level1:
                    obaStbAddPoint100_01.SetValue(Storyboard.TargetNameProperty, imgAdd100Points.Name);
                    damStbAddPoint100_02.SetValue(Storyboard.TargetNameProperty, imgAdd100Points.Name);
                    break;
                case AppEnum.Level.level2:
                    obaStbAddPoint100_01.SetValue(Storyboard.TargetNameProperty, imgAdd250Points.Name);
                    damStbAddPoint100_02.SetValue(Storyboard.TargetNameProperty, imgAdd250Points.Name);
                    break;
                case AppEnum.Level.level3:
                    obaStbAddPoint100_01.SetValue(Storyboard.TargetNameProperty, imgAdd500Points.Name);
                    damStbAddPoint100_02.SetValue(Storyboard.TargetNameProperty, imgAdd500Points.Name);
                    break;
            }
            StbAddPoint.Begin();
            StbAddPoint.Completed += new EventHandler(StbAddPoint_Completed);
        }

        public void EliminatePoint(AppEnum.Level level)
        {
            switch (level)
            {
                case AppEnum.Level.level1:
                    obaEliminatePoint600_01.SetValue(Storyboard.TargetNameProperty, imgEliminate60Points.Name);
                    obaEliminatePoint600_02.SetValue(Storyboard.TargetNameProperty, imgEliminate60Points.Name);
                    obaEliminatePoint600_03.SetValue(Storyboard.TargetNameProperty, imgEliminate60Points.Name);
                    break;
                case AppEnum.Level.level2:
                    obaEliminatePoint600_01.SetValue(Storyboard.TargetNameProperty, imgEliminate100Points.Name);
                    break;
                case AppEnum.Level.level3:
                    obaEliminatePoint600_01.SetValue(Storyboard.TargetNameProperty, imgEliminate200Points.Name);
                    break;
            }
            StbEliminatePoint.Begin();
            StbEliminatePoint.Completed += new EventHandler(StbEliminatePoint_Completed);
        }

        public void AssignMath(string mathAssigned)
        {
            tblMath.Text = mathAssigned;
        }

        void StbEliminatePoint_Completed(object sender, EventArgs e)
        {
            StbEliminatePoint.Stop();
        }

        void StbAddPoint_Completed(object sender, EventArgs e)
        {
            StbAddPoint.Stop();
        }
    }
}
