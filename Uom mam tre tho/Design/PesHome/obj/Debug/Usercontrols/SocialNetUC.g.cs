#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PesHome\Usercontrols\SocialNetUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6AB53986F11E213307F4727DA973976A"
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


namespace PesHome {
    
    
    public partial class SocialNetUC : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard LoadingST;
        
        internal System.Windows.Media.Animation.Storyboard EnteringST;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image image;
        
        internal System.Windows.Controls.Canvas NoteCanvas;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PesHome;component/Usercontrols/SocialNetUC.xaml", System.UriKind.Relative));
            this.LoadingST = ((System.Windows.Media.Animation.Storyboard)(this.FindName("LoadingST")));
            this.EnteringST = ((System.Windows.Media.Animation.Storyboard)(this.FindName("EnteringST")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
            this.NoteCanvas = ((System.Windows.Controls.Canvas)(this.FindName("NoteCanvas")));
        }
    }
}
