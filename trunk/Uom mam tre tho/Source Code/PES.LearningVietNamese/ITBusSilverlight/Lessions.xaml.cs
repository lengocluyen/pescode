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
using System.Collections;
using ITBusSilverlight.ITBusServiceReference;
using MultiLanguages;
using ITBusSilverlight.PESServicesSession;

namespace ITBusSilverlight
{
    public partial class Lessions : UserControl
    {
        Languages lang;
        enum UpdateMode
        {
            LessionGroups,
            Lessions
        }
        UpdateMode updateMode = UpdateMode.LessionGroups;

        ITBusServicesClient web = new ITBusServicesClient();
        PESServicesSessionSoapClient ps = new PESServicesSessionSoapClient();
        string webURL = "";
        IList<VLessionGroup> listLessionGroup;
        int _currLVID = 0;
        IList<VLession> listLessions;
        bool needUpdate = true;
        int currPage = 1;
        int pageSize = 9;
        int totalPages = 1;
        Page _root;
        Account pp = null;//get pupil
        double screenWidth;
        double screenHeight;


        #region Init
        public Lessions(Page root)
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Page_Loaded);
            webURL = ITBusSilverlightCommons.parameters["webURL"].ToString();

            try
            {
                screenWidth = double.Parse(ITBusSilverlightCommons.parameters["width"].ToString());
                screenHeight = double.Parse(ITBusSilverlightCommons.parameters["height"].ToString());
            }
            catch
            {
                screenWidth = 1024;
                screenHeight = 768;
            }

            _root = root;

            InitComponent();

            this.Storyboard1.Begin();
            this.Storyboard1.Completed += new EventHandler(Storyboard1_Completed);
            this.Storyboard2.Begin();

            this.canvasMenu.Children.Add(new FishEyeMenu(root));

            // Event
            web.GetLessionsCompleted += new EventHandler<GetLessionsCompletedEventArgs>(web_GetLessionsCompleted);
            web.GetAllLessionGroupCompleted += new EventHandler<GetAllLessionGroupCompletedEventArgs>(web_GetAllLessionGroupCompleted);
            web.GetLessionGroupByIDCompleted += new EventHandler<GetLessionGroupByIDCompletedEventArgs>(web_GetLessionGroupByIDCompleted);
            web.GetPupilByIDCompleted += new EventHandler<GetPupilByIDCompletedEventArgs>(web_GetPupilByIDCompleted);
            web.GetProfileByAccountIDCompleted += new EventHandler<GetProfileByAccountIDCompletedEventArgs>(web_GetProfileByAccountIDCompleted);
            web.GetPupilByIDAsync(_root.pupilID);//Get pupil to check level
            //Go to web_GetPupilByIDCompleted(....) when complete
        }



        void web_GetPupilByIDCompleted(object sender, GetPupilByIDCompletedEventArgs e)
        {
            pp = e.Result;//Get pupil to check level
        }


        #region Init Component
        void InitComponent()
        {
            InitKhung();
            InitCloud();
            InitGrid();
            InitBook();
            InitButton();
        }

        void InitKhung()
        {
            double width = screenWidth;
            double height = screenHeight;

            this.image.Width = width / 1.5;
            this.image.Height = height / 1.55;
            this.image.Stretch = Stretch.Fill;

            double left, top;
            left = width / 1.08 - this.image.Width;
            top = (height - this.image.Height) / 6;

            Canvas.SetLeft(image, left);
            Canvas.SetTop(image, top);
        }

        void InitCloud()
        {
            double width = screenWidth;
            double height = screenHeight;

            this.imageCloud.Width = width / 7;

            double left, top;
            left = width / 1.08 - this.image.Width;
            top = (height - this.image.Height) / 7;

            Canvas.SetLeft(imageCloud, left);
            Canvas.SetTop(imageCloud, top);

            Canvas.SetLeft(txtLessionGroup, left * 1.12);
            Canvas.SetTop(txtLessionGroup, top * 1.7);
            runLessionGroup.FontSize = imageCloud.Width / 7;
            imageCloud.Visibility = Visibility.Collapsed;
        }

        void InitGrid()
        {
            double width = this.image.Width;
            double height = this.image.Height;

            this.MyGrid.Width = width / 1.3;
            this.MyGrid.Height = height / 1.3;

            Canvas.SetLeft(MyGrid, Canvas.GetLeft(this.image) / 0.745);
            Canvas.SetTop(MyGrid, Canvas.GetTop(this.image) / 0.40);
        }

        void InitButton()
        {
            double width;
            width = (this.image.Width - this.MyGrid.Width) / 2.5;

            this.btnBack1.Width = width;
            this.btnBack1.Height = width;
            this.btnNext1.Width = width;
            this.btnNext1.Height = width;


            double top, left;
            top = Canvas.GetTop(this.image) + this.image.ActualHeight / 2 - width / 2;
            left = Canvas.GetLeft(this.image) + width / 1.7;

            Canvas.SetTop(this.btnBack1, top);
            Canvas.SetLeft(this.btnBack1, left);

            left = Canvas.GetLeft(this.image) + this.image.Width - (width * 1.3);
            Canvas.SetTop(this.btnNext1, top);
            Canvas.SetLeft(this.btnNext1, left);
        }

        void InitBook()
        {
            for (int i = 0; i < pageSize; i++)
            {
                Image book = this.MyGrid.Children[i] as Image;
                book.Width = this.MyGrid.Width / 5;
                book.Height = book.Width;
            }
        }
        #endregion


        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ps.GetLanguageStateCompleted += new EventHandler<ITBusSilverlight.PESServicesSession.GetLanguageStateCompletedEventArgs>(ps_GetLanguageStateCompleted);
            ps.GetLanguageStateAsync();
            try
            {
                if (ITBusSilverlightCommons.parameters["group"] != null)
                {
                    int id = int.Parse(ITBusSilverlightCommons.parameters["group"].ToString());
                    web.GetLessionsAsync(id);
                    web.GetLessionGroupByIDAsync(id);
                }
                else
                    web.GetAllLessionGroupAsync();
            }
            catch
            {
                web.GetAllLessionGroupAsync();
            }
        }

        void ps_GetLanguageStateCompleted(object sender, ITBusSilverlight.PESServicesSession.GetLanguageStateCompletedEventArgs e)
        {
            //if (e.Result == 0)
            lang = new Languages(EnumLanguages.Vietnamese);
            //else
            //    lang = new Languages(EnumLanguages.English);

            SetMediaSource();
        }



        private void SetMediaSource()
        {
            mediaNext.Source = new Uri(lang.GetWord("LessionMediaNext"), UriKind.RelativeOrAbsolute);
            mediaBack.Source = new Uri(lang.GetWord("LessionMediaBack"), UriKind.RelativeOrAbsolute);
            mediaFirst.Source = new Uri(lang.GetWord("LessionMediaLoadFirst"), UriKind.RelativeOrAbsolute);
        }

        #endregion


        #region StoryBoard
        void Storyboard1_Completed(object sender, EventArgs e)
        {
            Update();
        }
        #endregion


        #region Functions
        void ClearLessionGroupImage()
        {
            int totalChilds = this.MyGrid.Children.Count;
            for (int i = pageSize; i < totalChilds; i++)
            {
                this.MyGrid.Children.RemoveAt(pageSize);
            }
        }

        int CalculateTotalPages(int totalItems)
        {
            int result = 0;
            if (totalItems % pageSize == 0)
                result = totalItems / pageSize;
            else
                result = totalItems / pageSize + 1;
            return result;
        }

        TransformGroup GetDefaultTransformGroup()
        {
            ScaleTransform scale = new ScaleTransform();
            SkewTransform skew = new SkewTransform();
            RotateTransform rotate = new RotateTransform();
            TranslateTransform translate = new TranslateTransform();

            TransformGroup tg = new TransformGroup();
            tg.Children.Add(scale);
            tg.Children.Add(skew);
            tg.Children.Add(rotate);
            tg.Children.Add(translate);

            return tg;
        }


        #endregion


        #region Buttons
        private void HandleButton()
        {
            if (updateMode == UpdateMode.LessionGroups && listLessionGroup.Count == 0)
            {
                this.btnBack1.Visibility = Visibility.Collapsed;
                this.btnNext1.Visibility = Visibility.Collapsed;
            }
            else if (updateMode == UpdateMode.Lessions && listLessions.Count == 0)
            {
                this.btnBack1.Visibility = Visibility.Collapsed;
                this.btnNext1.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.btnBack1.Visibility = Visibility.Visible;
                this.btnNext1.Visibility = Visibility.Visible;
            }

            if (currPage == 1)
                this.btnBack1.Visibility = Visibility.Collapsed;
            if (currPage == totalPages)
                this.btnNext1.Visibility = Visibility.Collapsed;
        }

        private void btnNext1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.btnNext1.Source = new BitmapImage(new Uri("Images/Next02.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Hand;

            StopMedia();
            this.mediaNext.Play();
        }

        private void btnNext1_MouseLeave(object sender, MouseEventArgs e)
        {
            StopMedia();

            this.btnNext1.Source = new BitmapImage(new Uri("Images/Next01.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Arrow;
        }

        private void btnBack1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.btnBack1.Source = new BitmapImage(new Uri("Images/Back02.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Hand;

            StopMedia();
            this.mediaBack.Play();
        }

        private void btnBack1_MouseLeave(object sender, MouseEventArgs e)
        {
            StopMedia();

            this.btnBack1.Source = new BitmapImage(new Uri("Images/Back01.png", UriKind.RelativeOrAbsolute));
            this.Cursor = Cursors.Arrow;
        }

        private void btnBack1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopMedia();

            currPage = currPage - 1;
            if (currPage < 1)
                currPage = 1;

            HandleButton();
            needUpdate = true;
            ClearLessionGroupImage();
            btnBack1_MouseLeave(null, null);
            this.Storyboard1.Begin();
        }

        private void StopMedia()
        {
            this.mediaNext.Stop();
            this.mediaBack.Stop();
        }

        private void btnNext1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopMedia();

            currPage = currPage + 1;
            if (currPage > totalPages)
                currPage = totalPages;

            HandleButton();
            needUpdate = true;
            ClearLessionGroupImage();
            btnNext1_MouseLeave(null, null);
            this.Storyboard1.Begin();
        }
        #endregion


        #region Images
        void img_MouseLeave(object sender, MouseEventArgs e)
        {
            double a = 1.2;
            Image img = sender as Image;
            //img.Opacity = 1;
            img.Width = img.Width / a;
            img.Height = img.Height / a;

            int column = Grid.GetColumn(img);
            int row = Grid.GetRow(img);
            Image book = GetBook(column, row);
            book.Width = book.Width / a;
            book.Height = book.Height / a;

            this.Cursor = Cursors.Arrow;

            this.StoryboardHover.Stop();
        }

        void img_MouseEnter(object sender, MouseEventArgs e)//Mouse over
        {
            double a = 1.2;
            Image img = sender as Image;
            //img.Opacity = 0.5;
            img.Width = img.Width * a;
            img.Height = img.Height * a;

            int column = Grid.GetColumn(img);
            int row = Grid.GetRow(img);
            Image book = GetBook(column, row);
            book.Width = book.Width * a;
            book.Height = book.Height * a;

            Storyboard.SetTargetName(StoryboardHover.Children[0], img.Name);
            img.RenderTransform = GetDefaultTransformGroup();
            Storyboard.SetTargetName(StoryboardHover.Children[1], book.Name);
            book.RenderTransform = GetDefaultTransformGroup();

            StoryboardHover.Begin();

            this.Cursor = Cursors.Hand;
        }

        // Click Lession Groups --> Lessions
        bool isCheckLevel = false;
        Image img_lessionGroup_Cloude = null;
        void img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            img_lessionGroup_Cloude = sender as Image;

            int lessonGroupID = int.Parse(img_lessionGroup_Cloude.Name.Replace("imgLGroup", ""));

            web.GetLessionGroupByIDAsync(lessonGroupID);

            isCheckLevel = true;//Set to check level
        }

        // Click Lession --> Parts

        void imgLession_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image lession = sender as Image;

            this._root.LayoutRoot.Children.Clear();
            this._root.LayoutRoot.Children.Add(new Parts(_root, listLessions, int.Parse(lession.Name.Replace("imgLession", ""))));

            img_MouseLeave(lession, null);
        }

        #endregion


        #region Books
        private Image GetBook(int column, int row)
        {
            if (column == 0 && row == 0)
                return Book1;
            else if (column == 1 && row == 0)
                return Book2;
            else if (column == 2 && row == 0)
                return Book3;
            else if (column == 0 && row == 1)
                return Book4;
            else if (column == 1 && row == 1)
                return Book5;
            else if (column == 2 && row == 1)
                return Book6;
            else if (column == 0 && row == 2)
                return Book7;
            else if (column == 1 && row == 2)
                return Book8;
            else if (column == 2 && row == 2)
                return Book9;

            return null;
        }

        void CollapseAllBooks()
        {
            //if ((updateMode == UpdateMode.LessionGroups && listLessionGroup != null && listLessionGroup.Count > 0) || (updateMode == UpdateMode.Lessions && listLessions != null && listLessions.Count > 0))
            //{
            //    for (int i = 0; i < pageSize; i++)
            //    {
            //        Image book = this.MyGrid.Children[i] as Image;
            //        book.Visibility = Visibility.Visible;
            //    }
            //}
            //else
            //{
            for (int i = 0; i < pageSize; i++)
            {
                Image book = this.MyGrid.Children[i] as Image;
                book.Visibility = Visibility.Collapsed;
            }
            //}
        }
        #endregion


        private void Update()
        {
            if (updateMode == UpdateMode.LessionGroups)
            {
                #region Update LessionGroups
                if (listLessionGroup != null)
                {
                    imageCloud.Visibility = Visibility.Collapsed;
                    if (listLessionGroup.Count == 0)
                        CollapseAllBooks();
                    else
                    {
                        if (needUpdate == true)
                        {
                            needUpdate = false;

                            int col = 0, ro = 0;

                            int start = currPage * pageSize - (pageSize - 1);
                            int end = start + pageSize - 1;
                            int originalEnd = end;
                            if (end > listLessionGroup.Count)
                                end = listLessionGroup.Count;

                            int i, row = 0, column = 0;
                            Image img = new Image();
                            for (i = start - 1; i < end; i++)
                            {
                                VLessionGroup lGroup = listLessionGroup[i] as VLessionGroup;
                                img = new Image();
                                img.Source = new BitmapImage(new Uri(webURL + lGroup.LessionGroupImg, UriKind.RelativeOrAbsolute));

                                row = ro;
                                column = col;

                                Grid.SetColumn(img, column);
                                Grid.SetRow(img, row);

                                if (col == 2)
                                {
                                    col = 0;
                                    ro++;
                                }
                                else
                                    col++;

                                img.Width = this.Book1.Width / 1.5;
                                img.Height = img.Width;
                                img.Stretch = Stretch.Fill;
                                Point p = new Point(0.5, 0.5);
                                img.RenderTransformOrigin = p;
                                img.Name = "imgLGroup" + lGroup.LessionGroupID;

                                img.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip(lGroup.LessionGroupName));


                                img.MouseEnter += new MouseEventHandler(img_MouseEnter);
                                img.MouseLeave += new MouseEventHandler(img_MouseLeave);
                                img.MouseLeftButtonUp += new MouseButtonEventHandler(img_MouseLeftButtonUp);
                                this.MyGrid.Children.Add(img);
                            }

                            // Clear remaining
                            i = originalEnd - end;
                            i = pageSize - i;
                            for (; i < pageSize; i++)
                            {
                                Image bookImage = this.MyGrid.Children[i] as Image;
                                bookImage.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
                #endregion
            }
            else if (updateMode == UpdateMode.Lessions)
            {
                #region Update Lessions

                if (listLessions != null)
                {
                    if (listLessions.Count == 0)
                        CollapseAllBooks();
                    else
                    {
                        if (needUpdate == true)
                        {
                            needUpdate = false;

                            int col = 0, ro = 0;

                            int start = currPage * pageSize - (pageSize - 1);
                            int end = start + pageSize - 1;
                            int originalEnd = end;
                            if (end > listLessions.Count)
                                end = listLessions.Count;

                            Image img;
                            int i;
                            for (i = start - 1; i < end; i++)
                            {
                                VLession lession = listLessions[i] as VLession;
                                img = new Image();
                                if (lession.LessionImg == String.Empty)
                                    lession.LessionImg = "Upload/Images/noimage.jpg";
                                img.Source = new BitmapImage(new Uri(webURL + lession.LessionImg, UriKind.RelativeOrAbsolute));

                                int row = ro;
                                int column = col;

                                Grid.SetColumn(img, column);
                                Grid.SetRow(img, row);

                                if (col == 2)
                                {
                                    col = 0;
                                    ro++;
                                }
                                else
                                    col++;

                                img.Width = this.Book1.Width / 1.5;
                                img.Height = img.Width;
                                img.Stretch = Stretch.Fill;
                                Point p = new Point(0.5, 0.5);
                                img.RenderTransformOrigin = p;
                                img.Name = "imgLession" + i;

                                img.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip(lession.LessionName));

                                img.MouseEnter += new MouseEventHandler(img_MouseEnter);
                                img.MouseLeave += new MouseEventHandler(img_MouseLeave);
                                img.MouseLeftButtonUp += new MouseButtonEventHandler(imgLession_MouseLeftButtonUp);
                                this.MyGrid.Children.Add(img);
                            }

                            // Questions
                            if (end - start + 1 < 9)
                            {
                                img = new Image();
                                img.Source = new BitmapImage(new Uri("images/question_mark.png", UriKind.RelativeOrAbsolute));
                                img.Width = this.Book1.Width / 1.5;
                                img.Height = img.Width;
                                img.Stretch = Stretch.Fill;
                                img.RenderTransformOrigin = new Point(0.5, 0.5);
                                img.SetValue(ToolTipService.ToolTipProperty, ITBusSilverlightCommons.GetToolTip("Làm bài kiểm tra"));
                                img.Name = "imgQuestions";
                                img.MouseEnter += new MouseEventHandler(img_MouseEnter);
                                img.MouseLeave += new MouseEventHandler(img_MouseLeave);
                                img.MouseLeftButtonUp += new MouseButtonEventHandler(getTest_MouseLeftButtonUp);
                                Grid.SetColumn(img, col);
                                Grid.SetRow(img, ro);
                                this.MyGrid.Children.Add(img);
                            }


                            // Clear remaining
                            i = originalEnd - end;
                            i = pageSize - i;
                            for (; i < pageSize; i++)
                            {
                                Image bookImage = this.MyGrid.Children[i] as Image;
                                bookImage.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }

                #endregion
            }
        }

        void getTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(webURL + "LearningVietNamese/TestPage.aspx?levelID=" + _currLVID.ToString()));
        }

        void web_GetLessionsCompleted(object sender, GetLessionsCompletedEventArgs e)
        {
            listLessions = e.Result;
            totalPages = CalculateTotalPages(listLessions.Count);
            updateMode = UpdateMode.Lessions;

            HandleButton();

            if (this.Storyboard1.GetCurrentState() == ClockState.Filling) // If get lessions finish after storyboard
                Update();

        }

        void web_GetAllLessionGroupCompleted(object sender, GetAllLessionGroupCompletedEventArgs e)
        {
            listLessionGroup = e.Result;
            totalPages = CalculateTotalPages(listLessionGroup.Count);
            updateMode = UpdateMode.LessionGroups;
            HandleButton();

            if (this.Storyboard1.GetCurrentState() == ClockState.Filling) // If get all lession groups finish after storyboard
                Update();

        }
        VLessionGroup lGroup;
        void web_GetLessionGroupByIDCompleted(object sender, GetLessionGroupByIDCompletedEventArgs e)
        {
            lGroup = e.Result;
            if (isCheckLevel == true)
            {
                if (pp != null)
                {
                    web.GetProfileByAccountIDAsync(pp.AccountID);
                }
                return;
            }
        }
        Profile pfile;
        void web_GetProfileByAccountIDCompleted(object sender, GetProfileByAccountIDCompletedEventArgs e)
        {
            if (isCheckLevel == true)
            {
                if (e.Result != null)
                {
                    pfile = e.Result;
                    if (pfile.LevelOfExperienceTypeID >= (int)lGroup.LevelID)
                    {
                        _currLVID = (int)lGroup.LevelID;

                        web.GetLessionsAsync(lGroup.LessionGroupID);
                        this.Storyboard1.Begin();
                        ClearLessionGroupImage();
                        needUpdate = true;

                        img_MouseLeave(img_lessionGroup_Cloude, null);
                        imageCloud.Visibility = Visibility.Visible;
                        StoryboardCloud.Begin();
                        runLessionGroup.Text = ((ToolTip)img_lessionGroup_Cloude.GetValue(ToolTipService.ToolTipProperty)).Content.ToString();
                    }
                    else
                        MessageBox.Show("Bạn chưa thể học nhóm bài học này!\nBạn phải vượt qua bài kiểm tra trắc nghiệm của nhóm bài học hiện tại thì mới có thể học được các bài học của nhóm bài học này", "..:: Thông báo ::..", MessageBoxButton.OK);
                    
                }
                return;
            }
            imageCloud.Visibility = Visibility.Visible;
            StoryboardCloud.Begin();
            runLessionGroup.Text = lGroup.LessionGroupName;
        }
    }
}
