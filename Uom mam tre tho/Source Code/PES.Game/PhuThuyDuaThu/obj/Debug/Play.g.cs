#pragma checksum "E:\LAM VIEC\NTDVSocialNetwork\PesGiaidoan 2\PES_Rebuild\trunk\Source Code\Source Code\PES.Game\PhuThuyDuaThu\Play.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C032028D49887151AF4EA23A08E0E51"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PhuThuyDuaThu.Controls;
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
    
    
    public partial class Play : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard stbSendMail;
        
        internal System.Windows.Media.Animation.EasingDoubleKeyFrame edkfSendMailY01;
        
        internal System.Windows.Media.Animation.EasingDoubleKeyFrame edkfSendMailY02;
        
        internal System.Windows.Media.Animation.EasingDoubleKeyFrame edkfSendMailX01;
        
        internal System.Windows.Media.Animation.EasingDoubleKeyFrame edkfSendMailX02;
        
        internal System.Windows.Media.Animation.Storyboard stbShowMailBoxes;
        
        internal System.Windows.Media.Animation.Storyboard stbTimeUp;
        
        internal System.Windows.Media.Animation.EasingDoubleKeyFrame easingDKFTimeUp01;
        
        internal System.Windows.Media.Animation.EasingDoubleKeyFrame easingDKFTimeUp02;
        
        internal System.Windows.Media.Animation.Storyboard stbTimeOut;
        
        internal System.Windows.Media.Animation.Storyboard stbHideMailBox;
        
        internal System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames daHideMail_MailBox01;
        
        internal System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames daHideMail_MailBoxNumber01;
        
        internal System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames daHideMail_MailBoxNumber02;
        
        internal System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames daHideMail_MailBoxNumber03;
        
        internal System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames daHideMail_MailBox02;
        
        internal System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames daHideMail_MailBoxNumber04;
        
        internal System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames daHideMail_hplMailBox03;
        
        internal System.Windows.Media.Animation.Storyboard stbLevelUp;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Canvas canvasPlay;
        
        internal System.Windows.Media.ImageBrush backgroundImageBrush;
        
        internal System.Windows.Controls.Image imgTopFrame;
        
        internal System.Windows.Controls.Image imgTextCapDo;
        
        internal System.Windows.Controls.Image imgDauXiec;
        
        internal System.Windows.Controls.Image imgCotHomThu1;
        
        internal System.Windows.Controls.Image imgCotHomThu2;
        
        internal System.Windows.Controls.Image imgCotHomThu3;
        
        internal System.Windows.Controls.Image imgCotHomThu4;
        
        internal System.Windows.Controls.Image imgMailBox01;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox01;
        
        internal System.Windows.Controls.Image imgMailBox02;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox02;
        
        internal System.Windows.Controls.Image imgMailBox03;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox03;
        
        internal System.Windows.Controls.Image imgMailBox04;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox04;
        
        internal System.Windows.Controls.Image imgMailBox05;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox05;
        
        internal System.Windows.Controls.Image imgMailBox06;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox06;
        
        internal System.Windows.Controls.Image imgMailBox07;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox07;
        
        internal System.Windows.Controls.Image imgMailBox08;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox08;
        
        internal System.Windows.Controls.Image imgMailBox09;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox09;
        
        internal System.Windows.Controls.Image imgMailBox10;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox010;
        
        internal System.Windows.Controls.Image imgMailBox11;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox011;
        
        internal System.Windows.Controls.Image imgMailBox12;
        
        internal System.Windows.Controls.HyperlinkButton hplMailBox012;
        
        internal System.Windows.Controls.Canvas canvasMailBoxNumber;
        
        internal System.Windows.Controls.Image imgTimeOut1;
        
        internal System.Windows.Shapes.Rectangle rtlTimeOut2;
        
        internal System.Windows.Controls.Image imgTimeOutFrame;
        
        internal System.Windows.Controls.Image imgWall;
        
        internal System.Windows.Controls.Image imgMailFrame;
        
        internal System.Windows.Controls.Image imgHomThuText;
        
        internal System.Windows.Controls.Image imgMail;
        
        internal System.Windows.Controls.Image imgLetters;
        
        internal System.Windows.Controls.Image imgDefaultHand;
        
        internal System.Windows.Controls.Image imgHand02;
        
        internal System.Windows.Controls.Image imgHand03;
        
        internal System.Windows.Controls.Image imgMute;
        
        internal System.Windows.Controls.Image imgSound;
        
        internal System.Windows.Controls.HyperlinkButton hplMute;
        
        internal System.Windows.Controls.Image imgTextBegin;
        
        internal System.Windows.Controls.MediaElement meBGMusic;
        
        internal System.Windows.Controls.MediaElement meThankyou;
        
        internal System.Windows.Controls.MediaElement meSendMail;
        
        internal System.Windows.Controls.MediaElement meOK;
        
        internal System.Windows.Controls.MediaElement meNoSound;
        
        internal System.Windows.Controls.MediaElement meLevelUp;
        
        internal System.Windows.Controls.MediaElement meFail;
        
        internal System.Windows.Controls.MediaElement meEnd;
        
        internal System.Windows.Controls.MediaElement mePost;
        
        internal PhuThuyDuaThu.Controls.AddPoint ctrlAddPoints;
        
        internal PhuThuyDuaThu.Controls.EliminatePoints ctrlEliminatePoints;
        
        internal System.Windows.Controls.Image imgLenCap;
        
        internal System.Windows.Controls.Image imgTextChamChan;
        
        internal System.Windows.Shapes.Rectangle rtTimeOut;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhuThuyDuaThu;component/Play.xaml", System.UriKind.Relative));
            this.stbSendMail = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbSendMail")));
            this.edkfSendMailY01 = ((System.Windows.Media.Animation.EasingDoubleKeyFrame)(this.FindName("edkfSendMailY01")));
            this.edkfSendMailY02 = ((System.Windows.Media.Animation.EasingDoubleKeyFrame)(this.FindName("edkfSendMailY02")));
            this.edkfSendMailX01 = ((System.Windows.Media.Animation.EasingDoubleKeyFrame)(this.FindName("edkfSendMailX01")));
            this.edkfSendMailX02 = ((System.Windows.Media.Animation.EasingDoubleKeyFrame)(this.FindName("edkfSendMailX02")));
            this.stbShowMailBoxes = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbShowMailBoxes")));
            this.stbTimeUp = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbTimeUp")));
            this.easingDKFTimeUp01 = ((System.Windows.Media.Animation.EasingDoubleKeyFrame)(this.FindName("easingDKFTimeUp01")));
            this.easingDKFTimeUp02 = ((System.Windows.Media.Animation.EasingDoubleKeyFrame)(this.FindName("easingDKFTimeUp02")));
            this.stbTimeOut = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbTimeOut")));
            this.stbHideMailBox = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbHideMailBox")));
            this.daHideMail_MailBox01 = ((System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames)(this.FindName("daHideMail_MailBox01")));
            this.daHideMail_MailBoxNumber01 = ((System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames)(this.FindName("daHideMail_MailBoxNumber01")));
            this.daHideMail_MailBoxNumber02 = ((System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames)(this.FindName("daHideMail_MailBoxNumber02")));
            this.daHideMail_MailBoxNumber03 = ((System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames)(this.FindName("daHideMail_MailBoxNumber03")));
            this.daHideMail_MailBox02 = ((System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames)(this.FindName("daHideMail_MailBox02")));
            this.daHideMail_MailBoxNumber04 = ((System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames)(this.FindName("daHideMail_MailBoxNumber04")));
            this.daHideMail_hplMailBox03 = ((System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames)(this.FindName("daHideMail_hplMailBox03")));
            this.stbLevelUp = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stbLevelUp")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.canvasPlay = ((System.Windows.Controls.Canvas)(this.FindName("canvasPlay")));
            this.backgroundImageBrush = ((System.Windows.Media.ImageBrush)(this.FindName("backgroundImageBrush")));
            this.imgTopFrame = ((System.Windows.Controls.Image)(this.FindName("imgTopFrame")));
            this.imgTextCapDo = ((System.Windows.Controls.Image)(this.FindName("imgTextCapDo")));
            this.imgDauXiec = ((System.Windows.Controls.Image)(this.FindName("imgDauXiec")));
            this.imgCotHomThu1 = ((System.Windows.Controls.Image)(this.FindName("imgCotHomThu1")));
            this.imgCotHomThu2 = ((System.Windows.Controls.Image)(this.FindName("imgCotHomThu2")));
            this.imgCotHomThu3 = ((System.Windows.Controls.Image)(this.FindName("imgCotHomThu3")));
            this.imgCotHomThu4 = ((System.Windows.Controls.Image)(this.FindName("imgCotHomThu4")));
            this.imgMailBox01 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox01")));
            this.hplMailBox01 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox01")));
            this.imgMailBox02 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox02")));
            this.hplMailBox02 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox02")));
            this.imgMailBox03 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox03")));
            this.hplMailBox03 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox03")));
            this.imgMailBox04 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox04")));
            this.hplMailBox04 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox04")));
            this.imgMailBox05 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox05")));
            this.hplMailBox05 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox05")));
            this.imgMailBox06 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox06")));
            this.hplMailBox06 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox06")));
            this.imgMailBox07 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox07")));
            this.hplMailBox07 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox07")));
            this.imgMailBox08 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox08")));
            this.hplMailBox08 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox08")));
            this.imgMailBox09 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox09")));
            this.hplMailBox09 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox09")));
            this.imgMailBox10 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox10")));
            this.hplMailBox010 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox010")));
            this.imgMailBox11 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox11")));
            this.hplMailBox011 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox011")));
            this.imgMailBox12 = ((System.Windows.Controls.Image)(this.FindName("imgMailBox12")));
            this.hplMailBox012 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMailBox012")));
            this.canvasMailBoxNumber = ((System.Windows.Controls.Canvas)(this.FindName("canvasMailBoxNumber")));
            this.imgTimeOut1 = ((System.Windows.Controls.Image)(this.FindName("imgTimeOut1")));
            this.rtlTimeOut2 = ((System.Windows.Shapes.Rectangle)(this.FindName("rtlTimeOut2")));
            this.imgTimeOutFrame = ((System.Windows.Controls.Image)(this.FindName("imgTimeOutFrame")));
            this.imgWall = ((System.Windows.Controls.Image)(this.FindName("imgWall")));
            this.imgMailFrame = ((System.Windows.Controls.Image)(this.FindName("imgMailFrame")));
            this.imgHomThuText = ((System.Windows.Controls.Image)(this.FindName("imgHomThuText")));
            this.imgMail = ((System.Windows.Controls.Image)(this.FindName("imgMail")));
            this.imgLetters = ((System.Windows.Controls.Image)(this.FindName("imgLetters")));
            this.imgDefaultHand = ((System.Windows.Controls.Image)(this.FindName("imgDefaultHand")));
            this.imgHand02 = ((System.Windows.Controls.Image)(this.FindName("imgHand02")));
            this.imgHand03 = ((System.Windows.Controls.Image)(this.FindName("imgHand03")));
            this.imgMute = ((System.Windows.Controls.Image)(this.FindName("imgMute")));
            this.imgSound = ((System.Windows.Controls.Image)(this.FindName("imgSound")));
            this.hplMute = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hplMute")));
            this.imgTextBegin = ((System.Windows.Controls.Image)(this.FindName("imgTextBegin")));
            this.meBGMusic = ((System.Windows.Controls.MediaElement)(this.FindName("meBGMusic")));
            this.meThankyou = ((System.Windows.Controls.MediaElement)(this.FindName("meThankyou")));
            this.meSendMail = ((System.Windows.Controls.MediaElement)(this.FindName("meSendMail")));
            this.meOK = ((System.Windows.Controls.MediaElement)(this.FindName("meOK")));
            this.meNoSound = ((System.Windows.Controls.MediaElement)(this.FindName("meNoSound")));
            this.meLevelUp = ((System.Windows.Controls.MediaElement)(this.FindName("meLevelUp")));
            this.meFail = ((System.Windows.Controls.MediaElement)(this.FindName("meFail")));
            this.meEnd = ((System.Windows.Controls.MediaElement)(this.FindName("meEnd")));
            this.mePost = ((System.Windows.Controls.MediaElement)(this.FindName("mePost")));
            this.ctrlAddPoints = ((PhuThuyDuaThu.Controls.AddPoint)(this.FindName("ctrlAddPoints")));
            this.ctrlEliminatePoints = ((PhuThuyDuaThu.Controls.EliminatePoints)(this.FindName("ctrlEliminatePoints")));
            this.imgLenCap = ((System.Windows.Controls.Image)(this.FindName("imgLenCap")));
            this.imgTextChamChan = ((System.Windows.Controls.Image)(this.FindName("imgTextChamChan")));
            this.rtTimeOut = ((System.Windows.Shapes.Rectangle)(this.FindName("rtTimeOut")));
        }
    }
}