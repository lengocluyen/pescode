#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PES.Game\PhuThuyDuaThu\Guide.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9EC173B36A1134ACE967669D494EE3D3"
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


namespace PhuThuyDuaThu {
    
    
    public partial class Guide : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas canvasGuide;
        
        internal System.Windows.Media.ImageBrush backgroundImageBrush;
        
        internal System.Windows.Controls.TextBlock tblUseGuide;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhuThuyDuaThu;component/Guide.xaml", System.UriKind.Relative));
            this.canvasGuide = ((System.Windows.Controls.Canvas)(this.FindName("canvasGuide")));
            this.backgroundImageBrush = ((System.Windows.Media.ImageBrush)(this.FindName("backgroundImageBrush")));
            this.tblUseGuide = ((System.Windows.Controls.TextBlock)(this.FindName("tblUseGuide")));
        }
    }
}
