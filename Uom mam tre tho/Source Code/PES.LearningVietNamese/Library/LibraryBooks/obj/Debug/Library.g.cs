#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PES.LearningVietNamese\Library\LibraryBooks\Library.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D6EDA1E9732321E6C20B8EA7EEDA40F4"
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


namespace LibraryBooks {
    
    
    public partial class Library : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock PupilNameTextBlock;
        
        internal System.Windows.Controls.Canvas Layer_1;
        
        internal System.Windows.Controls.Canvas BookInfoCanvas;
        
        internal System.Windows.Controls.TextBlock BookDescription;
        
        internal System.Windows.Controls.Image BookImage;
        
        internal System.Windows.Controls.TextBlock BookTitlelb;
        
        internal System.Windows.Controls.TextBlock BookTitle;
        
        internal System.Windows.Controls.TextBlock BookAuthorlb;
        
        internal System.Windows.Controls.TextBlock BookAuthor;
        
        internal System.Windows.Controls.TextBlock BookpublishYearlb;
        
        internal System.Windows.Controls.TextBlock BookPubkishYear;
        
        internal System.Windows.Controls.TextBlock BookReadNumlbb;
        
        internal System.Windows.Controls.TextBlock BookReadNum;
        
        internal System.Windows.Controls.StackPanel BookListStackPanel;
        
        internal System.Windows.Controls.StackPanel BookTopStackPanel;
        
        internal System.Windows.Controls.StackPanel BookTypeStackPanel;
        
        internal System.Windows.Controls.Button BookLeftButton;
        
        internal System.Windows.Controls.Button BookRightButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LibraryBooks;component/Library.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PupilNameTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("PupilNameTextBlock")));
            this.Layer_1 = ((System.Windows.Controls.Canvas)(this.FindName("Layer_1")));
            this.BookInfoCanvas = ((System.Windows.Controls.Canvas)(this.FindName("BookInfoCanvas")));
            this.BookDescription = ((System.Windows.Controls.TextBlock)(this.FindName("BookDescription")));
            this.BookImage = ((System.Windows.Controls.Image)(this.FindName("BookImage")));
            this.BookTitlelb = ((System.Windows.Controls.TextBlock)(this.FindName("BookTitlelb")));
            this.BookTitle = ((System.Windows.Controls.TextBlock)(this.FindName("BookTitle")));
            this.BookAuthorlb = ((System.Windows.Controls.TextBlock)(this.FindName("BookAuthorlb")));
            this.BookAuthor = ((System.Windows.Controls.TextBlock)(this.FindName("BookAuthor")));
            this.BookpublishYearlb = ((System.Windows.Controls.TextBlock)(this.FindName("BookpublishYearlb")));
            this.BookPubkishYear = ((System.Windows.Controls.TextBlock)(this.FindName("BookPubkishYear")));
            this.BookReadNumlbb = ((System.Windows.Controls.TextBlock)(this.FindName("BookReadNumlbb")));
            this.BookReadNum = ((System.Windows.Controls.TextBlock)(this.FindName("BookReadNum")));
            this.BookListStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("BookListStackPanel")));
            this.BookTopStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("BookTopStackPanel")));
            this.BookTypeStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("BookTypeStackPanel")));
            this.BookLeftButton = ((System.Windows.Controls.Button)(this.FindName("BookLeftButton")));
            this.BookRightButton = ((System.Windows.Controls.Button)(this.FindName("BookRightButton")));
        }
    }
}