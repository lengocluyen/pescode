#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PES.Game\HocChuCai 2\GamePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "893A38054DF5945C85C043699BC12905"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HocChuCai_2.Objects;
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


namespace HocChuCai_2 {
    
    
    public partial class GamePage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard stbLevelUp;
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal System.Windows.Media.ScaleTransform PageScale;
        
        internal HocChuCai_2.Objects.Butt Butt1;
        
        internal HocChuCai_2.Objects.Butt Butt2;
        
        internal HocChuCai_2.Objects.Butt Butt3;
        
        internal HocChuCai_2.Objects.Butt Butt4;
        
        internal HocChuCai_2.Objects.Butt Butt5;
        
        internal HocChuCai_2.Objects.Butt Butt6;
        
        internal System.Windows.Controls.Canvas canvasBottom;
        
        internal System.Windows.Controls.Image imgLevel;
        
        internal System.Windows.Controls.Image imgScore;
        
        internal System.Windows.Controls.StackPanel stackLive;
        
        internal System.Windows.Controls.Image image;
        
        internal System.Windows.Controls.MediaElement _backgroundSound;
        
        internal System.Windows.Controls.MediaElement _chooseCharSound;
        
        internal System.Windows.Controls.MediaElement _effectSound;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/HocChuCai%202;component/GamePage.xaml", System.UriKind.Relative));
            this.stbLevelUp = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbLevelUp")));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.PageScale = ((System.Windows.Media.ScaleTransform)(this.FindName("PageScale")));
            this.Butt1 = ((HocChuCai_2.Objects.Butt)(this.FindName("Butt1")));
            this.Butt2 = ((HocChuCai_2.Objects.Butt)(this.FindName("Butt2")));
            this.Butt3 = ((HocChuCai_2.Objects.Butt)(this.FindName("Butt3")));
            this.Butt4 = ((HocChuCai_2.Objects.Butt)(this.FindName("Butt4")));
            this.Butt5 = ((HocChuCai_2.Objects.Butt)(this.FindName("Butt5")));
            this.Butt6 = ((HocChuCai_2.Objects.Butt)(this.FindName("Butt6")));
            this.canvasBottom = ((System.Windows.Controls.Canvas)(this.FindName("canvasBottom")));
            this.imgLevel = ((System.Windows.Controls.Image)(this.FindName("imgLevel")));
            this.imgScore = ((System.Windows.Controls.Image)(this.FindName("imgScore")));
            this.stackLive = ((System.Windows.Controls.StackPanel)(this.FindName("stackLive")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
            this._backgroundSound = ((System.Windows.Controls.MediaElement)(this.FindName("_backgroundSound")));
            this._chooseCharSound = ((System.Windows.Controls.MediaElement)(this.FindName("_chooseCharSound")));
            this._effectSound = ((System.Windows.Controls.MediaElement)(this.FindName("_effectSound")));
        }
    }
}
