using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Data;

namespace DynamicNavigation
{
    [ContentProperty("Page")]
    public class DynamicPageShim : Page
    {
        private Frame parentFrame;

        public DynamicPageShim()
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (parentFrame == null)
                parentFrame = Parent as Frame;
            if (parentFrame != null)
            {
                parentFrame.Content = Page;
                Page.IOnNavigatedTo(e);
            }
        }

        private DynamicPage page;
        public virtual DynamicPage Page
        {
            get
            {
                return page;
            }
            set
            {
                page = value;
                page.Shim = this;
                if (parentFrame != null)
                    parentFrame.Content = page;
            }
        }
    }
}
