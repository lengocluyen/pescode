#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PES.Game\PhuThuyDuaThu\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1F5F51706C4C8D4BF253304D095A32D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PhuThuyDuaThu;
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


namespace PhuThuyDuaThu {
    
    
    public partial class Home : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard stbTextShow;
        
        internal System.Windows.Media.Animation.Storyboard stbGuide;
        
        internal System.Windows.Controls.Canvas canvasMain;
        
        internal System.Windows.Media.ScaleTransform PageScale;
        
        internal System.Windows.Media.ImageBrush backgroundImageBrush;
        
        internal System.Windows.Controls.Image imgTextPhuThuy;
        
        internal System.Windows.Controls.Image imgTextDuaThu;
        
        internal System.Windows.Controls.MediaElement meShowText;
        
        internal PhuThuyDuaThu.Guide ctrlGuide;
        
        internal System.Windows.Controls.Image imgPlaySelected;
        
        internal System.Windows.Controls.Image imgPlay;
        
        internal System.Windows.Controls.HyperlinkButton hplPlay;
        
        internal System.Windows.Controls.Canvas canvasSomeBtn;
        
        internal System.Windows.Controls.Image imgUseGuideSelected;
        
        internal System.Windows.Controls.Image imgUseGuide;
        
        internal System.Windows.Controls.HyperlinkButton hplUseGuide;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhuThuyDuaThu;component/Home.xaml", System.UriKind.Relative));
            this.stbTextShow = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbTextShow")));
            this.stbGuide = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbGuide")));
            this.canvasMain = ((System.Windows.Controls.Canvas)(this.FindName("canvasMain")));
            this.PageScale = ((System.Windows.Media.ScaleTransform)(this.FindName("PageScale")));
            this.backgroundImageBrush = ((System.Windows.Media.ImageBrush)(this.FindName("backgroundImageBrush")));
            this.imgTextPhuThuy = ((System.Windows.Controls.Image)(this.FindName("imgTextPhuThuy")));
            this.imgTextDuaThu = ((System.Windows.Controls.Image)(this.FindName("imgTextDuaThu")));
            this.meShowText = ((System.Windows.Controls.MediaElement)(this.FindName("meShowText")));
            this.ctrlGuide = ((PhuThuyDuaThu.Guide)(this.FindName("ctrlGuide")));
            this.imgPlaySelected = ((System.Windows.Controls.Image)(this.FindName("imgPlaySelected")));
            this.imgPlay = ((System.Windows.Controls.Image)(this.FindName("imgPlay")));
            this.hplPlay = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplPlay")));
            this.canvasSomeBtn = ((System.Windows.Controls.Canvas)(this.FindName("canvasSomeBtn")));
            this.imgUseGuideSelected = ((System.Windows.Controls.Image)(this.FindName("imgUseGuideSelected")));
            this.imgUseGuide = ((System.Windows.Controls.Image)(this.FindName("imgUseGuide")));
            this.hplUseGuide = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplUseGuide")));
        }
    }
}