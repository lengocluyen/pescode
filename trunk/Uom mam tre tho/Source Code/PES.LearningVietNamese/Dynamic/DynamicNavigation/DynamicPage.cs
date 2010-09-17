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
using System.Windows.Navigation;
using System.Windows.Markup;

namespace DynamicNavigation
{
    public class DynamicPage : Page
    {
        public DynamicPage()
        {
        }

        public new NavigationContext NavigationContext
        {
            get
            {
                return Shim.NavigationContext;
            }
        }

        public new NavigationCacheMode NavigationCacheMode
        {
            get
            {
                return Shim.NavigationCacheMode;
            }
            set
            {
                base.NavigationCacheMode = value;
                Shim.NavigationCacheMode = value;
            }
        }

        public new string Title
        {
            get
            {
                return Shim.Title;
            }
            set
            {
                base.Title=value;
                Shim.Title = value;
            }
        }

        private Page shim;
        internal Page Shim
        {
            get
            {
                return shim ?? this;
            }
            set
            {
                shim = value;
                if (shim != null)
                {
                    shim.Title = base.Title;
                    shim.CacheMode = base.CacheMode;
                }
            }
        }

        internal void IOnNavigatedTo(NavigationEventArgs e)
        {
            OnNavigatedTo(e);
        }
    }
}
