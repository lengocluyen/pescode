#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\Team SVN\PES\SourceCode\SubSonic\PES.Game\Danh Trong\Objects\Numbers\Number.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "834FF63EB9D2B9C9829AFD339FA308F7"
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


namespace Danh_Trong.Objects {
    
    
    public partial class Number : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard stbAppear;
        
        internal System.Windows.Controls.StackPanel LayoutRoot;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Danh%20Trong;component/Objects/Numbers/Number.xaml", System.UriKind.Relative));
            this.stbAppear = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbAppear")));
            this.LayoutRoot = ((System.Windows.Controls.StackPanel)(this.FindName("LayoutRoot")));
        }
    }
}
