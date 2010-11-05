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

namespace PrimaryEducationSystem.Study.Lessons
{
    public partial class PartList : UserControl
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string partName;

        public string PartName
        {
            get { return partName; }
            set { partName = value; }
        }
        public PartList()
        {
            InitializeComponent();
        }
    }
}
