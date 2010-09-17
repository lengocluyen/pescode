using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using ITBusSilverlight.ITBusServiceReference;
using System.Windows.Browser;
using MultiLanguages;
using ITBusSilverlight.PESServicesSession;

namespace ITBusSilverlight
{
    public partial class Parts : UserControl
    {
        Page _root;
        Languages lang;

        PESServicesSessionSoapClient ps = new PESServicesSessionSoapClient();

        double browserWidth = double.Parse(ITBusSilverlightCommons.parameters["width"].ToString());
        double browserHeight = double.Parse(ITBusSilverlightCommons.parameters["height"].ToString());
        string webURL = "";
        ITBusServicesClient servives = new ITBusServicesClient();
        IList<VLession> listLessions;
        int currLessionIndex;

        List<VPart> listParts = new List<VPart>();

        #region Images Global Variable
        Image board;
        int countModule = 0;
        int minPartPriority = 0;
        Image previousPart = null;
        #endregion


        public Parts(Page root, IList<VLession> listLessions, int currLessionIndex)
        {
            InitializeComponent();

            this._root = root;
            this.listLessions = listLessions;
            this.currLessionIndex = currLessionIndex;

            webURL = ITBusSilverlightCommons.parameters["webURL"].ToString();

            InitImages();
            this.StoryboardButton.Begin();

            this.Loaded += new RoutedEventHandler(Parts_Loaded);
            servives.GetAllPartsByLessionCompleted += new EventHandler<GetAllPartsByLessionCompletedEventArgs>(servives_GetAllPartsByLessionCompleted);
            servives.GetModuleByIDCompleted += new EventHandler<GetModuleByIDCompletedEventArgs>(servives_GetModuleByIDCompleted);

            InitContentPart();

            ps.GetLanguageStateCompleted += new EventHandler<ITBusSilverlight.PESServicesSession.GetLanguageStateCompletedEventArgs>(ps_GetLanguageStateCompleted);
            ps.GetLanguageStateAsync();
          }

        void ps_GetLanguageStateCompleted(object sender, ITBusSilverlight.PESServicesSession.GetLanguageStateCompletedEventArgs e)
        {
            //if (e.Result == 0)
                lang = new Languages(EnumLanguages.Vietnamese);
            //else
            //    lang = new Languages(EnumLanguages.English);
            AddMediaSource();
        }

      
        private void AddMediaSource()
        {
            mediaBack.Source = new Uri(lang.GetWord("LessionMediaBack"), UriKind.Relative);
            mediaGoHome.Source = new Uri(lang.GetWord("MenuGoHomePage"), UriKind.Relative);            
            mediaListOfLession.Source = new Uri(lang.GetWord("MenuLessionGroupList"), UriKind.Relative);            
            mediaNext.Source = new Uri(lang.GetWord("PartNextLession"), UriKind.Relative);
            
            mediaKeChuyen.Source = new Uri(lang.GetWord("PartTellStory"), UriKind.Relative);
            mediaLuyenNoi.Source = new Uri(lang.GetWord("PartLearnTalking"), UriKind.Relative);
            mediaTapDoc.Source = new Uri(lang.GetWord("PartLearnReading"), UriKind.Relative);
            mediaTapViet.Source = new Uri(lang.GetWord("PartLearnWriting"), UriKind.Relative);

        }



        #region Parts

        void Parts_Loaded(object sender, RoutedEventArgs e)
        {
            servives.GetAllPartsByLessionAsync(listLessions[currLessionIndex].LessionID);
            this.runLessionTitle.Text = listLessions[currLessionIndex].LessionName;
        }

        void InitContentPart()
        {
            // Init content parts
            double width, height, top, left;
            double boardWidth, boardHeight, boardTop, boardLeft;

            Image board = ITBusSilverlightCommons.FindCanvasChildrenByName(this.LayoutRoot, "boardPart");

            boardWidth = board.Width;
            boardHeight = board.Height;
            boardTop = (double)board.GetValue(Canvas.TopProperty);
            boardLeft = (double)board.GetValue(Canvas.LeftProperty);

            width = boardWidth / 1.32;
            height = boardHeight / 1.36;

            top = boardTop * 2.55;
            left = boardLeft * 1.3;

            HtmlElement m = HtmlPage.Document.GetElementById("iframeContentPart");
            if (m != null)
            {
                m.SetStyleAttribute("width", width + "px");
                m.SetStyleAttribute("height", height + "px");
                m.SetStyleAttribute("top", top + "px");
                m.SetStyleAttribute("left", left + "px");
                m.SetStyleAttribute("position", "absolute");
                m.SetStyleAttribute("z-index", "2");
            }
        }


        void servives_GetAllPartsByLessionCompleted(object sender, GetAllPartsByLessionCompletedEventArgs e)
        {
            IList<VPart> parts = e.Result;
            Clear();

            // Display the first part
            HtmlElement iframe = HtmlPage.Document.GetElementById("iframeContentPart");
            if (iframe != null)
            {
                iframe.SetStyleAttribute("visibility", "visible");
                iframe.SetAttribute("src", webURL + "LearningVietNamese/DisplayPart.aspx?partID=" + parts[0].PartID);
            }
            // ----------------------

            List<int> lstPrio = new List<int>();
            minPartPriority = (int)parts[0].PartPriority;
            foreach (VPart part in parts)
            {
                if (lstPrio.Contains((int)part.PartPriority))
                    part.PartPriority = (int)(ITBusSilverlightCommons.FindMaxValue(lstPrio) + 1);

                lstPrio.Add((int)part.PartPriority);
                listParts.Add(part);                
                servives.GetModuleByIDAsync(part.PartModuleID, part);
            }            

            this.btnBack1.Visibility = Visibility.Visible;
            this.btnNext1.Visibility = Visibility.Visible;
            if (currLessionIndex == 0)
                this.btnBack1.Visibility = Visibility.Collapsed;
            else if (currLessionIndex == listLessions.Count - 1)
                this.btnNext1.Visibility = Visibility.Collapsed;
        }



        void servives_GetModuleByIDCompleted(object sender, GetModuleByIDCompletedEventArgs e)
        {
            VModule module = e.Result;
            VPart part = e.UserState as VPart;

            // Add module frame
            Image moduleFrame = new Image();
            moduleFrame.Source = new BitmapImage(new Uri("/Images/Parts/PartTitle.png", UriKind.RelativeOrAbsolute));
            moduleFrame.Width = browserWidth / 10;
            moduleFrame.Height = moduleFrame.Width / 2;
            moduleFrame.Stretch = Stretch.Fill;

            double imageCanvasLeft = (browserWidth - board.Width) / 2;
            double imageCanvasTop = (browserHeight - board.Height) / 5.5;

            int potision = (int)(part.PartPriority - 1);

            moduleFrame.SetValue(Canvas.LeftProperty, imageCanvasLeft + board.Width / 1.2);
            moduleFrame.SetValue(Canvas.TopProperty, imageCanvasTop * 2.3 + (potision * moduleFrame.Height));

            // Add module content           


            Image moduleImage = new Image();
            moduleImage.Source = new BitmapImage(new Uri(webURL + module.ModuleImage, UriKind.Absolute));

            moduleImage.Width = moduleFrame.Width / 1.2;
            moduleImage.Height = moduleFrame.Height / 1.2;
            moduleImage.Stretch = Stretch.Fill;

            if (part.PartPriority == minPartPriority)
                ResizeModule(moduleImage);

            moduleImage.SetValue(Canvas.TopProperty, (double)moduleFrame.GetValue(Canvas.TopProperty) + moduleFrame.Height / 11);
            moduleImage.SetValue(Canvas.LeftProperty, (double)moduleFrame.GetValue(Canvas.LeftProperty) + moduleFrame.Width / 11);
            moduleImage.SetValue(Image.NameProperty, module.ModuleName);
            //moduleImage.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip(module.ModuleName));


            moduleFrame.Name = "canClearModuleFrame" + module.ModuleId.ToString() + countModule.ToString() + "--" + part.PartID.ToString();
            moduleImage.Name = "canClearModuleImage" + module.ModuleName + module.ModuleId.ToString() + countModule.ToString() + "--" + part.PartID.ToString();

            // Event
            moduleImage.MouseEnter += new MouseEventHandler(moduleImage_MouseEnter);
            moduleImage.MouseLeave += new MouseEventHandler(moduleImage_MouseLeave);
            moduleImage.MouseLeftButtonUp += new MouseButtonEventHandler(moduleImage_MouseLeftButtonUp);


            // Add
            this.LayoutRoot.Children.Add(moduleFrame);
            this.LayoutRoot.Children.Add(moduleImage);

        }

        void moduleImage_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        void moduleImage_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Image moduleImage = sender as Image;

            this.StoryboardFading.Stop();
            this.StoryboardFading.SetValue(Storyboard.TargetNameProperty, moduleImage.Name);
            this.StoryboardFading.Begin();

            StopMedia();
            PlayModuleFunction(moduleImage.Name);
        }


        private void PlayModuleFunction(string ModuleNameIp)
        {
            if (ModuleNameIp.ToLower().IndexOf("tập viết") != -1)
            {
                this.mediaTapViet.Play();
                return;
            }
            if (ModuleNameIp.ToLower().IndexOf("tập đọc") != -1)
            {
                this.mediaTapDoc.Play();
                return;
            }
            if (ModuleNameIp.ToLower().IndexOf("kể chuyện") != -1)
            {
                this.mediaKeChuyen.Play();
                return;
            }
            if (ModuleNameIp.ToLower().IndexOf("luyện nói") != -1)
            {
                this.mediaLuyenNoi.Play();
                return;
            }
        }

        void moduleImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image module = sender as Image;
            string[] key = module.Name.Split(new string[1] { "--" }, StringSplitOptions.RemoveEmptyEntries);
            string partID = key[1];

            HtmlElement iframe = HtmlPage.Document.GetElementById("iframeContentPart");
            if (iframe != null)
            {
                iframe.SetAttribute("src", webURL + "LearningVietNamese/DisplayPart.aspx?partID=" + partID);
            }
            ResizeModule(module);
        }

        void ResizeModule(Image module)
        {
            // Resize previous module
            double a = 1.3;
            if (previousPart != null)
            {
                previousPart.Width = previousPart.Width / a;
                previousPart.Height = previousPart.Height / a;
            }

            // Resize current module
            module.Width = module.Width * a;
            module.Height = module.Height * a;
            previousPart = module;
        }
        #endregion

        #region InitImages
        void InitImages()
        {
            #region Board
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("/Images/Parts/Board.png", UriKind.RelativeOrAbsolute));
            img.Name = "boardPart";

            img.Width = (browserWidth * 3 / 4);
            img.Height = (browserHeight * 0.70);
            img.Stretch = Stretch.Fill;

            double imageCanvasLeft = (browserWidth - img.Width) / 2;
            double imageCanvasTop = (browserHeight - img.Height) / 6;

            img.SetValue(Canvas.LeftProperty, imageCanvasLeft);
            img.SetValue(Canvas.TopProperty, imageCanvasTop);

            this.LayoutRoot.Children.Add(img);
            board = img;

            #endregion

            #region Animals

            // Tiger
            Image tiger = new Image();
            tiger.Source = new BitmapImage(new Uri("/Images/Parts/Tiger.png", UriKind.RelativeOrAbsolute));

            tiger.Width = browserWidth / 11;

            double tigerCanvasLeft = imageCanvasLeft + img.Width / 1.5;
            double tigerCanvasTop = (double)img.GetValue(Canvas.TopProperty) + img.Height / 1.17;

            tiger.SetValue(Canvas.LeftProperty, tigerCanvasLeft);
            tiger.SetValue(Canvas.TopProperty, tigerCanvasTop);

            this.LayoutRoot.Children.Add(tiger);

            // Pig
            Image pig = new Image();
            pig.Source = new BitmapImage(new Uri("/Images/Parts/Pig.png", UriKind.RelativeOrAbsolute));

            pig.Width = tiger.Width / 1.5;

            double pigCanvasLeft = (double)tiger.GetValue(Canvas.LeftProperty) - tiger.Width / 2;
            double pigCanvasTop = (double)tiger.GetValue(Canvas.TopProperty) * 1.08;

            pig.SetValue(Canvas.LeftProperty, pigCanvasLeft);
            pig.SetValue(Canvas.TopProperty, pigCanvasTop);

            this.LayoutRoot.Children.Add(pig);
            #endregion

            #region Posts
            // Homepage
            Image postHome = new Image();
            postHome.Source = new BitmapImage(new Uri("/Images/Parts/BackToHomePage.png", UriKind.RelativeOrAbsolute));

            postHome.Width = imageCanvasLeft * 0.8;

            double postHomeCanvasLeft = (imageCanvasLeft - postHome.Width) / 2;
            double postHomeCanvasTop = imageCanvasTop * 3.9;

            postHome.SetValue(Canvas.LeftProperty, postHomeCanvasLeft);
            postHome.SetValue(Canvas.TopProperty, postHomeCanvasTop);

            postHome.Name = "imgPostHome";
            postHome.MouseEnter += new MouseEventHandler(postHome_MouseEnter);
            postHome.MouseLeave += new MouseEventHandler(postHome_MouseLeave);
            postHome.MouseLeftButtonUp += new MouseButtonEventHandler(postHome_MouseLeftButtonUp);
            //postHome.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip("Về trang chủ"));

            this.LayoutRoot.Children.Add(postHome);


            // Lessions
            Image postLessions = new Image();
            postLessions.Source = new BitmapImage(new Uri("/Images/Parts/LessionsBoard.png", UriKind.Relative));

            postLessions.Width = postHome.Width * 0.9;

            double postLessionsCanvasLeft = (img.Width + imageCanvasLeft) + postLessions.Width / 5;
            double postLessionsCanvasTop = imageCanvasTop * 10;

            postLessions.SetValue(Canvas.LeftProperty, postLessionsCanvasLeft);
            postLessions.SetValue(Canvas.TopProperty, postLessionsCanvasTop);

            postLessions.Name = "imgPostLessions";
            this.StoryboardFading.SetValue(Storyboard.TargetNameProperty, postLessions.Name);
            postLessions.MouseEnter += new MouseEventHandler(postLessions_MouseEnter);
            postLessions.MouseLeave += new MouseEventHandler(postLessions_MouseLeave);
            postLessions.MouseLeftButtonUp += new MouseButtonEventHandler(postLessions_MouseLeftButtonUp);
            //postLessions.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip("Danh sách bài học"));

            this.LayoutRoot.Children.Add(postLessions);
            #endregion

            #region Buttons
            this.btnBack1.Width = postHome.Width / 1.5;

            this.btnBack1.SetValue(Canvas.LeftProperty, (imageCanvasLeft - this.btnBack1.Width) / 2);
            this.btnBack1.SetValue(Canvas.TopProperty, imageCanvasTop + img.Height / 2 - (btnBack1.Width / 2));

            this.btnNext1.Width = this.btnBack1.Width;

            this.btnNext1.SetValue(Canvas.LeftProperty, imageCanvasLeft + img.Width + (imageCanvasLeft - this.btnBack1.Width) / 2);
            this.btnNext1.SetValue(Canvas.TopProperty, this.btnBack1.GetValue(Canvas.TopProperty));
            #endregion

            #region TxtLesstionTitle
            this.txtLessionTitle.SetValue(Canvas.TopProperty, imageCanvasTop / 1.7);
            this.txtLessionTitle.SetValue(Canvas.LeftProperty, imageCanvasLeft * 2.2);
            #endregion
        }


        #region Post Mouse Event
        // Home
        void postHome_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;

            StoryboardFading.Stop();
            this.StoryboardFading.SetValue(Storyboard.TargetNameProperty, "imgPostHome");
            StoryboardFading.Begin();

            StopMedia();
            this.mediaGoHome.Play();
        }

        void postLessions_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _root.LayoutRoot.Children.Clear();
            ITBusSilverlightCommons.parameters.Remove("group");
            ITBusSilverlightCommons.parameters.Add("group", listLessions[0].GroupID.ToString());
            HtmlElement iframe = HtmlPage.Document.GetElementById("iframeContentPart");
            if (iframe != null)
            {
                iframe.SetAttribute("src", "");
                iframe.SetAttribute("class", "");
                iframe.SetStyleAttribute("visibility", "hidden");
                iframe.SetAttribute("frameborder", "0");
            }
            _root.LayoutRoot.Children.Add(new Lessions(_root));

            this.StopMedia();
        }

        void postHome_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            StopMedia();
        }

        void postHome_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopMedia();
            HtmlPage.Window.Navigate(new Uri(webURL + "LearningVietNamese/PreView.aspx", UriKind.RelativeOrAbsolute));
        }


        // Lessions
        void postLessions_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;

            StoryboardFading.Stop();
            this.StoryboardFading.SetValue(Storyboard.TargetNameProperty, "imgPostLessions");
            StoryboardFading.Begin();

            StopMedia();
            this.mediaListOfLession.Play();
        }

        void postLessions_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.StopMedia();
        }
        #endregion
        #endregion


        #region Button
        private void btnNext1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.btnNext1.Source = new BitmapImage(new Uri("/Images/Next02.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Hand;

            StopMedia();
            mediaNext.Play();
        }

        private void btnNext1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.btnNext1.Source = new BitmapImage(new Uri("/Images/Next01.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Arrow;

            StopMedia();
        }

        private void btnBack1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.btnBack1.Source = new BitmapImage(new Uri("/Images/Back02.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Hand;

            StopMedia();
            mediaBack.Play();
        }

        private void btnBack1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.btnBack1.Source = new BitmapImage(new Uri("/Images/Back01.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Arrow;

            StopMedia();
        }

        private void btnBack1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopMedia();
            this.btnBack1.Visibility = Visibility.Collapsed;

            currLessionIndex--;
            if (currLessionIndex < 0)
                currLessionIndex = 0;

            this.btnBack1.Source = new BitmapImage(new Uri("/Images/Back01.png", UriKind.RelativeOrAbsolute));
            Parts_Loaded(null, null);
        }

        private void btnNext1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopMedia();
            this.btnNext1.Visibility = Visibility.Collapsed;

            currLessionIndex++;
            if (currLessionIndex >= listLessions.Count)
                currLessionIndex = listLessions.Count - 1;

            this.btnNext1.Source = new BitmapImage(new Uri("/Images/Next01.png", UriKind.RelativeOrAbsolute));
            Parts_Loaded(null, null);
        }
        #endregion

        #region Other Functions
        void Clear()
        {
            for (int i = 0; i < this.LayoutRoot.Children.Count; i++)
            {
                if (this.LayoutRoot.Children[i] is Image)
                {
                    Image img = this.LayoutRoot.Children[i] as Image;
                    if (img.Name.Contains("canClear"))
                    {
                        this.LayoutRoot.Children.Remove(img);
                        i--;
                    }
                }
            }
            countModule = 0;
        }

        private void StopMedia()
        {
            this.mediaNext.Stop();
            this.mediaBack.Stop();
            this.mediaGoHome.Stop();
            this.mediaListOfLession.Stop();
            this.mediaKeChuyen.Stop();
            this.mediaLuyenNoi.Stop();
            this.mediaTapDoc.Stop();
            this.mediaTapViet.Stop();
        }
        #endregion

    }
}
