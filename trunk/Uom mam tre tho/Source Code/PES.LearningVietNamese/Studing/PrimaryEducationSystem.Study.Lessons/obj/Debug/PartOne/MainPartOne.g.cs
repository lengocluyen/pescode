#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PES.LearningVietNamese\Studing\PrimaryEducationSystem.Study.Lessons\PartOne\MainPartOne.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8FC83A0B8D0EDA5C56A569234C6857BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PrimaryEducationSystem.Study.Lessons.PartOne {
    
    
    public partial class MainPartOne : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard note_ST;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button next_Button;
        
        internal System.Windows.Controls.Button prev_Button;
        
        internal System.Windows.Controls.Button Button_Home;
        
        internal System.Windows.Controls.Border container;
        
        internal System.Windows.Controls.TextBlock TextBlock_Lessonname;
        
        internal System.Windows.Controls.MediaElement media_next;
        
        internal System.Windows.Controls.MediaElement media_prev;
        
        internal System.Windows.Controls.MediaElement media_home;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PrimaryEducationSystem.Study.Lessons;component/PartOne/MainPartOne.xaml", System.UriKind.Relative));
            this.note_ST = ((System.Windows.Media.Animation.Storyboard)(this.FindName("note_ST")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.next_Button = ((System.Windows.Controls.Button)(this.FindName("next_Button")));
            this.prev_Button = ((System.Windows.Controls.Button)(this.FindName("prev_Button")));
            this.Button_Home = ((System.Windows.Controls.Button)(this.FindName("Button_Home")));
            this.container = ((System.Windows.Controls.Border)(this.FindName("container")));
            this.TextBlock_Lessonname = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlock_Lessonname")));
            this.media_next = ((System.Windows.Controls.MediaElement)(this.FindName("media_next")));
            this.media_prev = ((System.Windows.Controls.MediaElement)(this.FindName("media_prev")));
            this.media_home = ((System.Windows.Controls.MediaElement)(this.FindName("media_home")));
        }
    }
}