#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\Team SVN\PES\SourceCode\SubSonic\PES.Game\LuyenTriNho\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0CB81404403E810EFFC1323104A71EDF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LuyenTriNho.Controls;
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


namespace LuyenTriNho {
    
    
    public partial class Home : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard storyboardDropText;
        
        internal System.Windows.Media.Animation.Storyboard storyboardShowGuide;
        
        internal System.Windows.Controls.Canvas canvasRoot;
        
        internal System.Windows.Media.ScaleTransform PageScale;
        
        internal System.Windows.Controls.Image imgTriNhoText;
        
        internal System.Windows.Controls.Image imgNhaBacHocText;
        
        internal System.Windows.Controls.Image imgBtnPlaySeleted;
        
        internal System.Windows.Controls.Image imgBtnPlay;
        
        internal System.Windows.Controls.Image imgBtnUseGuideSelected;
        
        internal System.Windows.Controls.Image imgBtnUseGuide;
        
        internal System.Windows.Controls.Image imgBtnSoundSelected;
        
        internal System.Windows.Controls.Image imgBtnSound;
        
        internal System.Windows.Controls.Image imgBtnSoundMute;
        
        internal System.Windows.Controls.HyperlinkButton hplBtnMute;
        
        internal System.Windows.Controls.HyperlinkButton hplBtnPlay;
        
        internal System.Windows.Controls.HyperlinkButton hplBtnUseGuide;
        
        internal System.Windows.Controls.HyperlinkButton hplBtnFillAll;
        
        internal LuyenTriNho.Controls.UseGuide ctrlUseGuide;
        
        internal System.Windows.Controls.Image imgCloseSelected;
        
        internal System.Windows.Controls.Image imgClose;
        
        internal System.Windows.Controls.HyperlinkButton hplBtnClose;
        
        internal System.Windows.Controls.MediaElement meHomePage;
        
        internal System.Windows.Controls.MediaElement meOpenGuide;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LuyenTriNho;component/Home.xaml", System.UriKind.Relative));
            this.storyboardDropText = ((System.Windows.Media.Animation.Storyboard)(this.FindName("storyboardDropText")));
            this.storyboardShowGuide = ((System.Windows.Media.Animation.Storyboard)(this.FindName("storyboardShowGuide")));
            this.canvasRoot = ((System.Windows.Controls.Canvas)(this.FindName("canvasRoot")));
            this.PageScale = ((System.Windows.Media.ScaleTransform)(this.FindName("PageScale")));
            this.imgTriNhoText = ((System.Windows.Controls.Image)(this.FindName("imgTriNhoText")));
            this.imgNhaBacHocText = ((System.Windows.Controls.Image)(this.FindName("imgNhaBacHocText")));
            this.imgBtnPlaySeleted = ((System.Windows.Controls.Image)(this.FindName("imgBtnPlaySeleted")));
            this.imgBtnPlay = ((System.Windows.Controls.Image)(this.FindName("imgBtnPlay")));
            this.imgBtnUseGuideSelected = ((System.Windows.Controls.Image)(this.FindName("imgBtnUseGuideSelected")));
            this.imgBtnUseGuide = ((System.Windows.Controls.Image)(this.FindName("imgBtnUseGuide")));
            this.imgBtnSoundSelected = ((System.Windows.Controls.Image)(this.FindName("imgBtnSoundSelected")));
            this.imgBtnSound = ((System.Windows.Controls.Image)(this.FindName("imgBtnSound")));
            this.imgBtnSoundMute = ((System.Windows.Controls.Image)(this.FindName("imgBtnSoundMute")));
            this.hplBtnMute = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplBtnMute")));
            this.hplBtnPlay = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplBtnPlay")));
            this.hplBtnUseGuide = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplBtnUseGuide")));
            this.hplBtnFillAll = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplBtnFillAll")));
            this.ctrlUseGuide = ((LuyenTriNho.Controls.UseGuide)(this.FindName("ctrlUseGuide")));
            this.imgCloseSelected = ((System.Windows.Controls.Image)(this.FindName("imgCloseSelected")));
            this.imgClose = ((System.Windows.Controls.Image)(this.FindName("imgClose")));
            this.hplBtnClose = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplBtnClose")));
            this.meHomePage = ((System.Windows.Controls.MediaElement)(this.FindName("meHomePage")));
            this.meOpenGuide = ((System.Windows.Controls.MediaElement)(this.FindName("meOpenGuide")));
        }
    }
}
