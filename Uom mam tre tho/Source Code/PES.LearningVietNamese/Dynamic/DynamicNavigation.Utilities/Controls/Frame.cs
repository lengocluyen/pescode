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
using DynamicNavigation.Utilities.Loader;

namespace DynamicNavigation.Utilities.Controls
{
    public class Frame : System.Windows.Controls.Frame
    {
        public Frame()
        {
            base.Navigating += new System.Windows.Navigation.NavigatingCancelEventHandler(Frame_Navigating);
            base.NavigationFailed += new System.Windows.Navigation.NavigationFailedEventHandler(Frame_NavigationFailed);
            base.NavigationStopped += new System.Windows.Navigation.NavigationStoppedEventHandler(Frame_NavigationStopped);
            DynamicLoader = new DynamicLoader();
        }

        private void Frame_NavigationStopped(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!isWaitingForLoad)
            {
                var stopped = navigationStopped;
                if (stopped != null)
                    stopped(sender, e);
            }
        }

        private void Frame_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            if (!isWaitingForLoad)
            {
                var failed = navigationFailed;
                if (failed != null)
                    failed(sender, e);
            }
        }

        private System.Windows.Navigation.NavigationFailedEventHandler navigationFailed;
        public new event System.Windows.Navigation.NavigationFailedEventHandler NavigationFailed
        {
            add
            {
                navigationFailed += value;
            }
            remove
            {
                navigationFailed -= value;
            }
        }

        private System.Windows.Navigation.NavigationStoppedEventHandler navigationStopped;
        public new event System.Windows.Navigation.NavigationStoppedEventHandler NavigationStopped
        {
            add
            {
                navigationStopped += value;
            }
            remove
            {
                navigationStopped -= value;
            }
        }


        public DynamicLoader DynamicLoader
        {
            get { return (DynamicLoader)GetValue(DynamicLoaderProperty); }
            set { SetValue(DynamicLoaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DynamicLoader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DynamicLoaderProperty =
            DependencyProperty.Register("DynamicLoader", typeof(DynamicLoader), typeof(Frame), new PropertyMetadata(null, LoaderChanged));

        private static void LoaderChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ((Frame)obj).LoaderChanged(args);
        }

        private void LoaderChanged(DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != null)
            {
                (args.OldValue as DynamicLoader).AssemblyLoaded -= new EventHandler<DynamicLoadEventArgs>(DynamicLoader_AssemblyLoaded);
                (args.OldValue as DynamicLoader).DynamicLoadError -= new EventHandler<DynamicLoadErrorEventArgs>(DynamicLoader_DynamicLoadError);
            }
            if (args.NewValue != null)
            {
                DynamicLoader.AssemblyLoaded += new EventHandler<DynamicLoadEventArgs>(DynamicLoader_AssemblyLoaded);
                DynamicLoader.DynamicLoadError += new EventHandler<DynamicLoadErrorEventArgs>(DynamicLoader_DynamicLoadError);
            }
        }

        private void DynamicLoader_DynamicLoadError(object sender, DynamicLoadErrorEventArgs e)
        {
            if (isWaitingForLoad && e.AssemblyDescription.AssemblyName.Equals(loadingAssemblyName))
            {
                navFailure = e.Error;
                base.Navigate(lastLoadAttempt);
            }
        }

        private void DynamicLoader_AssemblyLoaded(object sender, DynamicLoadEventArgs e)
        {
            if (isWaitingForLoad && e.AssemblyDescription.AssemblyName.Equals(loadingAssemblyName))
            {
                base.Navigate(lastLoadAttempt);
            }
        }

        private Uri lastLoadAttempt;
        private string loadingAssemblyName;
        private bool isWaitingForLoad;
        private Exception navFailure;
        private void Frame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (navFailure != null)
            {
                var fail = navFailure;
                navFailure = null;
                throw fail;
            }
            if (isWaitingForLoad)
            {
                isWaitingForLoad = false;
                return;
            }
            if (navigating != null)
            {
                navigating(sender, e);
                if (e.Cancel)
                    return;
            }
            var realUri = UriMapper.MapUri(e.Uri);
            if (realUri.ToString().Contains(";component/"))
            {
                string assemblyName = realUri.ToString().Substring(1, realUri.ToString().IndexOf(";component/") - 1);
                if (DynamicLoader.Load(assemblyName))
                {
                    isWaitingForLoad = true;
                    loadingAssemblyName = assemblyName;
                    lastLoadAttempt = e.Uri;
                    e.Cancel = true;
                }
            }
        }

        private System.Windows.Navigation.NavigatingCancelEventHandler navigating;
        public new event System.Windows.Navigation.NavigatingCancelEventHandler Navigating
        {
            add
            {
                navigating += value;
            }
            remove
            {
                navigating -= value;
            }
        }

        public new void StopLoading()
        {
            isWaitingForLoad = false;
            base.StopLoading();
        }
    }
}
