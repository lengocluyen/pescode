using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace DynamicNavigation.Utilities.Loader
{
    [ContentProperty("AssemblyDescriptions")]
    public sealed class DynamicLoader : DependencyObject
    {
        public DynamicLoader()
        {
            AssemblyDescriptions = new ObservableCollection<AssemblyDescription>();
            requests = new List<WebRequest>();
        }

        private int loadCount;
        private int LoadCount
        {
            get
            {
                return loadCount;
            }
            set
            {
                loadCount = value;
                IsLoading = loadCount > 0;
            }
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(DynamicLoader), new PropertyMetadata(false));

        public void Stop()
        {
            lock (requests)
            {
                foreach (var req in requests)
                {
                    try
                    {
                        req.Abort();
                    }
                    catch { }
                    LoadCount--;
                }
                requests.Clear();
            }
        }

        private List<WebRequest> requests;

        public ObservableCollection<AssemblyDescription> AssemblyDescriptions
        {
            get { return (ObservableCollection<AssemblyDescription>)GetValue(AssemblyDescriptionsProperty); }
            private set { SetValue(AssemblyDescriptionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AssemblyDescriptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssemblyDescriptionsProperty =
            DependencyProperty.Register("AssemblyDescriptions", typeof(ObservableCollection<AssemblyDescription>), typeof(DynamicLoader), new PropertyMetadata(null));

        private bool DependenciesFilled(AssemblyDescription desc)
        {
            var v = from dep in desc.Dependencies
                    where FromName(dep.AssemblyName).IsLoaded
                    select dep;
            return v.Count() == desc.Dependencies.Count;
        }

        private void UpdateDependencies()
        {
            var v = from related in AssemblyDescriptions
                    where related.Assembly != null && !related.IsLoaded && DependenciesFilled(related)
                    select related;
            foreach (var filled in v)
            {
                filled.IsLoaded = true;
                filled.IsLoading = false;
                OnAssemblyLoaded(filled);
            }
        }

        private void OnAssemblyLoaded(AssemblyDescription desc)
        {
            var loaded = AssemblyLoaded;
            if (loaded != null)
                loaded(this, new DynamicLoadEventArgs(desc));
            UpdateDependencies();
        }

        private void OnLoadError(AssemblyDescription desc, Exception exc)
        {
            if (!desc.IsLoading)
                return;
            desc.IsLoading = false;
            var error = DynamicLoadError;
            if (error != null)
                error(this, new DynamicLoadErrorEventArgs(desc, exc));
            var related = from d in AssemblyDescriptions
                          where d.IsLoading && d.DependsOn(desc.AssemblyName)
                          select d;
            foreach (var d in related)
            {
                OnLoadError(d, exc);
            }
        }

        /// <summary>
        /// Loads the assembly and any dependencies.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if an async load was triggered.  False otherwise.</returns>
        public bool Load(string name)
        {

            AssemblyDescription description = FromName(name);
            if (description == null)
                return false;
            if (description.Location == null)
                throw new ArgumentException("AssemblyDescription's location must not be null");
            bool loadingDependency = false;
            foreach (var dependency in description.Dependencies)
            {
                try
                {
                    loadingDependency = Load(dependency.AssemblyName) || loadingDependency;
                }
                catch { }
            }
            if (description.Assembly != null)
                return loadingDependency;
            LoadCount++;
            try
            {
                WebRequest request;
                if (description.WebRequestCreator == null)
                {
                    request = WebRequest.Create(description.Location);
                }
                else
                {
                    request = description.WebRequestCreator.Create(description.Location);
                }
                Dispatcher.BeginInvoke(() =>
                    {
                        lock (requests)
                        {
                            requests.Add(request);
                            description.IsLoading = true;
                            request.BeginGetResponse((result) =>
                                {
                                    Dispatcher.BeginInvoke(() =>
                                        {
                                            try
                                            {
                                                WebResponse response = request.EndGetResponse(result);
                                                Assembly assembly = null;
                                                if (description.Location.ToString().EndsWith(".dll"))
                                                {
                                                    assembly = new AssemblyPart().Load(response.GetResponseStream());
                                                }
                                                else
                                                {
                                                    assembly = new AssemblyPart().Load(Application.GetResourceStream(new System.Windows.Resources.StreamResourceInfo(response.GetResponseStream(), "application/zip"),
                                                        new Uri(description.AssemblyName + ".dll", UriKind.Relative)).Stream);
                                                }
                                                lock (requests) requests.Remove(request);
                                                description.Assembly = assembly;
                                                UpdateDependencies();
                                            }
                                            catch (Exception e)
                                            {
                                                OnLoadError(description, e);
                                            }
                                            finally
                                            {
                                                LoadCount--;
                                            }
                                        });
                                }, description);
                        }
                    });
                return true;
            }
            catch (Exception e)
            {
                LoadCount--;
                throw e;
            }
        }

        private AssemblyDescription FromName(string name)
        {
            return (from description in AssemblyDescriptions
                    where description.AssemblyName.Equals(name)
                    select description).SingleOrDefault();
        }

        public event EventHandler<DynamicLoadEventArgs> AssemblyLoaded;
        public event EventHandler<DynamicLoadErrorEventArgs> DynamicLoadError;
    }
}
