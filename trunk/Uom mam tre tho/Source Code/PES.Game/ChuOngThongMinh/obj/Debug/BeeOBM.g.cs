#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\Team SVN\PES\SourceCode\SubSonic\PES.Game\ChuOngThongMinh\BeeOBM.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6EC3188568FE0BB5BE254C2B842DC75E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
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


namespace ChuOngThongMinh {
    
    
    public partial class BeeOBM : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard StbFlying;
        
        internal System.Windows.Media.Animation.Storyboard StbTired;
        
        internal System.Windows.Media.Animation.Storyboard stbDropBall;
        
        internal System.Windows.Media.Animation.DoubleAnimation daDropballNumber;
        
        internal System.Windows.Media.Animation.DoubleAnimation daDropballText;
        
        internal System.Windows.Controls.Image imgLeftSmallWing;
        
        internal System.Windows.Controls.Image imgRightSmallWing;
        
        internal System.Windows.Controls.Image imgLeftWing;
        
        internal System.Windows.Controls.Image imgRightWing;
        
        internal System.Windows.Controls.Image imgBelly;
        
        internal System.Windows.Controls.Image imgLeftSmallLeg;
        
        internal System.Windows.Controls.Image imgRightSmallLeg;
        
        internal System.Windows.Controls.Image imgRightLeg;
        
        internal System.Windows.Controls.Image imgLeftLeg;
        
        internal System.Windows.Controls.Image imgNappy;
        
        internal System.Windows.Controls.Image imgHead;
        
        internal System.Windows.Controls.Image imgCryingFace;
        
        internal System.Windows.Controls.Image imgCryingMouth;
        
        internal System.Windows.Controls.Image imgLeftCryingEye1;
        
        internal System.Windows.Controls.Image imgRightCryingEye1;
        
        internal System.Windows.Controls.Image imgLeftCryingEye2;
        
        internal System.Windows.Controls.Image imgRightCryingEye2;
        
        internal System.Windows.Controls.Image imgNose;
        
        internal System.Windows.Controls.Image imgRightEye;
        
        internal System.Windows.Controls.Image imgLeftEye;
        
        internal System.Windows.Controls.Image imgRightPinkFace;
        
        internal System.Windows.Controls.Image imgLeftPinkFace;
        
        internal System.Windows.Controls.Image imgSweat1;
        
        internal System.Windows.Controls.Image imgSweat2;
        
        internal System.Windows.Controls.Image imgSweat3;
        
        internal System.Windows.Controls.Image imgNumber;
        
        internal System.Windows.Controls.TextBlock tblNumber;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ChuOngThongMinh;component/BeeOBM.xaml", System.UriKind.Relative));
            this.StbFlying = ((System.Windows.Media.Animation.Storyboard)(this.FindName("StbFlying")));
            this.StbTired = ((System.Windows.Media.Animation.Storyboard)(this.FindName("StbTired")));
            this.stbDropBall = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbDropBall")));
            this.daDropballNumber = ((System.Windows.Media.Animation.DoubleAnimation)(this.FindName("daDropballNumber")));
            this.daDropballText = ((System.Windows.Media.Animation.DoubleAnimation)(this.FindName("daDropballText")));
            this.imgLeftSmallWing = ((System.Windows.Controls.Image)(this.FindName("imgLeftSmallWing")));
            this.imgRightSmallWing = ((System.Windows.Controls.Image)(this.FindName("imgRightSmallWing")));
            this.imgLeftWing = ((System.Windows.Controls.Image)(this.FindName("imgLeftWing")));
            this.imgRightWing = ((System.Windows.Controls.Image)(this.FindName("imgRightWing")));
            this.imgBelly = ((System.Windows.Controls.Image)(this.FindName("imgBelly")));
            this.imgLeftSmallLeg = ((System.Windows.Controls.Image)(this.FindName("imgLeftSmallLeg")));
            this.imgRightSmallLeg = ((System.Windows.Controls.Image)(this.FindName("imgRightSmallLeg")));
            this.imgRightLeg = ((System.Windows.Controls.Image)(this.FindName("imgRightLeg")));
            this.imgLeftLeg = ((System.Windows.Controls.Image)(this.FindName("imgLeftLeg")));
            this.imgNappy = ((System.Windows.Controls.Image)(this.FindName("imgNappy")));
            this.imgHead = ((System.Windows.Controls.Image)(this.FindName("imgHead")));
            this.imgCryingFace = ((System.Windows.Controls.Image)(this.FindName("imgCryingFace")));
            this.imgCryingMouth = ((System.Windows.Controls.Image)(this.FindName("imgCryingMouth")));
            this.imgLeftCryingEye1 = ((System.Windows.Controls.Image)(this.FindName("imgLeftCryingEye1")));
            this.imgRightCryingEye1 = ((System.Windows.Controls.Image)(this.FindName("imgRightCryingEye1")));
            this.imgLeftCryingEye2 = ((System.Windows.Controls.Image)(this.FindName("imgLeftCryingEye2")));
            this.imgRightCryingEye2 = ((System.Windows.Controls.Image)(this.FindName("imgRightCryingEye2")));
            this.imgNose = ((System.Windows.Controls.Image)(this.FindName("imgNose")));
            this.imgRightEye = ((System.Windows.Controls.Image)(this.FindName("imgRightEye")));
            this.imgLeftEye = ((System.Windows.Controls.Image)(this.FindName("imgLeftEye")));
            this.imgRightPinkFace = ((System.Windows.Controls.Image)(this.FindName("imgRightPinkFace")));
            this.imgLeftPinkFace = ((System.Windows.Controls.Image)(this.FindName("imgLeftPinkFace")));
            this.imgSweat1 = ((System.Windows.Controls.Image)(this.FindName("imgSweat1")));
            this.imgSweat2 = ((System.Windows.Controls.Image)(this.FindName("imgSweat2")));
            this.imgSweat3 = ((System.Windows.Controls.Image)(this.FindName("imgSweat3")));
            this.imgNumber = ((System.Windows.Controls.Image)(this.FindName("imgNumber")));
            this.tblNumber = ((System.Windows.Controls.TextBlock)(this.FindName("tblNumber")));
        }
    }
}
