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
    public partial class AddPoint : UserControl
    {
        public AddPoint()
        {
            InitializeComponent();
        }

        public void CallAnimation()
        {
            this.stbSendMailOk.Stop();
            this.stbSendMailOk.Begin();
        }
    }
}
