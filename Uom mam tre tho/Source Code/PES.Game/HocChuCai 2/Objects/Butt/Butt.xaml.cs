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

namespace HocChuCai_2.Objects
{
    public enum ButtState
    {
        Close,
        Open
    }

    public partial class Butt : UserControl
    {
        private ButtState _buttState = ButtState.Close;
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public ButtState ButtState
        {
            get { return _buttState; }
            set { _buttState = value; }
        }

        public string Character
        {
            get { return this.textBlock.Text; }
            set { this.textBlock.Text = value; }
        }

        public Butt()
        {
            InitializeComponent();
        }

        public void OpenHead()
        {
            this.stbOpenButt.Begin();
        }

        public void CloseHead()
        {
            this.stbCloseButt.Begin();
        }
    }
}
