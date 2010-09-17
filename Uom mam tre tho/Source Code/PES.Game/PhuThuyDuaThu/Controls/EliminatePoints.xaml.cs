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
using PhuThuyDuaThu.Codes;

namespace PhuThuyDuaThu.Controls
{
    public partial class EliminatePoints : UserControl
    {
        public EliminatePoints()
        {
            InitializeComponent();
        }

        public void CallAnimation()
        {
            this.stbEliminatePoints.Stop();
            this.stbEliminatePoints.Begin();
        }
    }
}
