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
using System.Windows.Navigation;
using LibraryBooks.LearningServices;
using LibraryBooks.PesSessionServices;
using System.Windows.Media.Imaging;
namespace LibraryBooks
{
    public partial class Library : UserControl
    {
        #region
        string webURL = PESCommons.parameters["webURL"];
        LearningServicesClient learningService = new LearningServicesClient();
        PESServicesSessionSoapClient sessionService = new PESServicesSessionSoapClient();

        private List<Book> _BookList;
        private List<Book> _BookTopList;
        private List<BookType> _BookTypeList;
        private Book _book;

        private int take;
        private int skip;
        private int loop = 8;
        #endregion

        #region Funtions

        private void WaittingServices(bool _bool)
        {
            if (_bool == true)
            {
                this.BookListStackPanel.Visibility = Visibility.Collapsed;
                this.BookTopStackPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.BookListStackPanel.Visibility = Visibility.Visible;
                this.BookTopStackPanel.Visibility = Visibility.Visible;
            }
        }

        private void AddControl(double _textOp, Thickness _imagethicness, Thickness _thickness, double _pwidth, double _pHeight, double _imgHeight, string _imgSource, string _textName, double _fontSize, int _id, string _type, UIElement _UIElement)
        {

            NoteBook nb = new NoteBook();

            //Content
            nb.Height = _pHeight;
            nb.Width = _pwidth;
            nb._Image.Source = new BitmapImage(new Uri(_imgSource, UriKind.RelativeOrAbsolute));
            nb._Image.Margin = _imagethicness;
            nb._Image.Height = _imgHeight;
            nb._TextBlock.FontSize = _fontSize;
            nb._TextBlock.Opacity = _textOp;
            nb._ID.Text = _id.ToString();
            nb._TextBlock.Text = _textName;

            nb._Name.Text = _type;
            nb.Margin = _thickness;

            nb._link.Click += new RoutedEventHandler(_link_Click);
            nb._link.MouseEnter += new MouseEventHandler(_link_MouseEnter);
            nb._link.MouseLeave += new MouseEventHandler(_link_MouseLeave);

            if (_UIElement is Canvas)
            {
                Canvas cv = _UIElement as Canvas;
                cv.Children.Add(nb);
            }
            if (_UIElement is StackPanel)
            {
                StackPanel st = _UIElement as StackPanel;
                st.Children.Add(nb);
            }
        }

        private void TakeAndSkip()
        {
            this.BookLeftButton.Visibility = Visibility.Collapsed;
            if (_BookList.Count() > take)
                this.BookRightButton.Visibility = Visibility.Visible;
            else
                this.BookRightButton.Visibility = Visibility.Collapsed;
        }

        private void ColapsedControl()
        {
            this.BookLeftButton.Visibility = Visibility.Collapsed;
            this.BookRightButton.Visibility = Visibility.Collapsed;
        }

        void _link_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                this.BookTitle.Text = _book.BookName;
            }
            catch
            {
                return;
            }
        }

        void _link_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                HyperlinkButton hy = sender as HyperlinkButton;
                Grid _grid = hy.Parent as Grid;
                NoteBook nb = _grid.Parent as NoteBook;

                int id = int.Parse(nb._ID.Text);

                Book book = new Book();

                switch (nb._Name.Text)
                {
                    case "Book":
                        book = _BookList.Where(b => b.BookID == id).FirstOrDefault();
                        this.BookTitle.Text = book.BookName;
                        break;
                    case "BookTop":
                        book = _BookTopList.Where(b => b.BookID == id).FirstOrDefault();
                        this.BookTitle.Text = book.BookName;
                        break;
                    default:
                        return;
                }
            }
            catch
            {
                return;
            }

        }

        void _link_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HyperlinkButton hy = sender as HyperlinkButton;
                Grid _grid = hy.Parent as Grid;
                NoteBook nb = _grid.Parent as NoteBook;
                
                int id = int.Parse(nb._ID.Text);
                _book = new Book();
                switch (nb._Name.Text)
                {

                    case "BookType":
                        WaittingServices(true);
                        this.BookListStackPanel.Children.Clear();
                        learningService.BookGetByBookTypeAsync(id);
                        break;


                    default:
                        if (nb._Name.Text == "Book")
                            _book = _BookList.Where(b => b.BookID == id).FirstOrDefault();
                        else
                            _book = _BookTopList.Where(b => b.BookID == id).FirstOrDefault();
                        this.BookImage.Source = new BitmapImage(new Uri("../Images/Library/Data/" + _book.BookImg, UriKind.RelativeOrAbsolute));
                        this.BookTitle.Text = _book.BookName;
                        this.BookAuthor.Text = _book.Author;
                        this.BookPubkishYear.Text = _book.PublishYear;
                        this.BookReadNum.Text = _book.ReadNum;
                        return;
                }
            }
            catch
            {
                return;
            }

        }

        #endregion

        public Library()
        {
            InitializeComponent();

            ColapsedControl();

            sessionService.GetUserLoginIDCompleted += new EventHandler<GetUserLoginIDCompletedEventArgs>(sessionService_GetUserLoginIDCompleted);

            learningService.BookTypeGetAllCompleted += new EventHandler<BookTypeGetAllCompletedEventArgs>(learningService_BookTypeGetAllCompleted);
            learningService.BookGetByBookTypeCompleted += new EventHandler<BookGetByBookTypeCompletedEventArgs>(learningService_BookGetByBookTypeCompleted);
            learningService.BookTopCompleted += new EventHandler<BookTopCompletedEventArgs>(learningService_BookTopCompleted);

            learningService.PupilGetByAccountIDCompleted += new EventHandler<PupilGetByAccountIDCompletedEventArgs>(learningService_PupilGetByAccountIDCompleted);
            sessionService.GetUserLoginIDAsync();

            //learningService.BookTypeGetAllAsync();
            //learningService.BookTopAsync(5);
        }

        //Pupils
        void learningService_PupilGetByAccountIDCompleted(object sender, PupilGetByAccountIDCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PupilNameTextBlock.Text = e.Result.NickName;
            }
        }

        void sessionService_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            if (e.Result == -1)
            {
                System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(webURL,UriKind.RelativeOrAbsolute));

            }
            else
            {
                learningService.PupilGetByAccountIDAsync(e.Result);
                learningService.BookTypeGetAllAsync();
                learningService.BookTopAsync(5);
            }
        }

        void learningService_BookTopCompleted(object sender, BookTopCompletedEventArgs e)
        {
            try
            {
                _BookTopList = new List<Book>();
                if (e.Error == null)
                {
                    foreach (Book book in e.Result)
                    {
                        _BookTopList.Add(book);
                        AddControl(0, new Thickness(0, 0, 0, 0), new Thickness(15, 0, 0, 0), 50.0, 80.0, 75.0, "../Images/Library/Data/" + book.BookImg, book.BookName, 11, book.BookID, "BookTop", BookTopStackPanel);
                    }
                    WaittingServices(false);
                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }

        void learningService_BookGetByBookTypeCompleted(object sender, BookGetByBookTypeCompletedEventArgs e)
        {
            try
            {
                take = loop;
                skip = 0;
                _BookList = new List<Book>();
                if (e.Error == null)
                {
                    foreach (Book book in e.Result)
                    {
                        _BookList.Add(book);
                        
                    }
                    List<Book> list = _BookList.Skip(skip).Take(take).ToList();
                    foreach (Book _book in list)
                    {
                        AddControl(0, new Thickness(0, 0, 0, 0), new Thickness(10, 0, 0, 0), 50.0, 80.0, 75.0, "../Images/Library/Data/" + _book.BookImg, _book.BookName, 11, _book.BookID, "Book", BookListStackPanel);
                    }
                    WaittingServices(false);
                    TakeAndSkip();
                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }

        void learningService_BookTypeGetAllCompleted(object sender, BookTypeGetAllCompletedEventArgs e)
        {
            try
            {
                _BookTypeList = new List<BookType>();
                if (e.Error == null)
                {
                    foreach (BookType bt in e.Result)
                    {
                        _BookTypeList.Add(bt);
                        AddControl(1, new Thickness(0, 0, 0, 30), new Thickness(0, 15, 0, 0), 150.0, 120.0, 100.0, "../Images/Library/Data/" + bt.BookTypeImg, bt.BookTypeName, 11, bt.BookTypeID, "BookType", BookTypeStackPanel);

                    }
                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }

        private void BookTopLeftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BookRightButton.IsPressed == true)
                {
                    this.BookLeftButton.Visibility = Visibility.Visible;
                    if (this.BookListStackPanel.Children.Count() < take)
                    {
                        this.BookRightButton.Visibility = Visibility.Collapsed;
                        return;
                    }
                    this.BookListStackPanel.Children.Clear();
                    skip += loop;
                    take += loop;
                    
                    List<Book> list = _BookList.Skip(skip).Take(take).ToList();
                    foreach (Book book in list)
                    {
                        AddControl(0, new Thickness(0, 0, 0, 0), new Thickness(10, 0, 0, 0), 50.0, 80.0, 75.0, "../Images/Library/Data/" + book.BookImg, book.BookName, 11, book.BookID, "Book", BookListStackPanel);
                    }
                }

                if (BookLeftButton.IsPressed == true)
                {
                        this.BookListStackPanel.Children.Clear();
                        take -= loop;
                        skip -= loop;
                        if (skip == 0)
                        {
                            this.BookRightButton.Visibility = Visibility.Visible;
                            this.BookLeftButton.Visibility = Visibility.Collapsed;
                        }
                    List<Book> list = _BookList.Skip(skip).Take(take).ToList();
                    foreach (Book book in list)
                    {
                        AddControl(0, new Thickness(0, 0, 0, 0), new Thickness(10, 0, 0, 0), 50.0, 80.0, 75.0, "../Images/Library/Data/" + book.BookImg, book.BookName, 11, book.BookID, "Book", BookListStackPanel);
                    }
                }
            }
            catch
            {
                return;
            }

        }
    }
}
