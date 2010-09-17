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
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.Collections.Generic;

namespace DynamicNavigation.Utilities.Loader
{
    [ContentProperty("Dependencies")]
    public class AssemblyDescription : DependencyObject
    {
        private static Dictionary<string, Assembly> deployed;
        static AssemblyDescription()
        {
            deployed = new Dictionary<string, Assembly>();
            foreach (AssemblyPart part in Deployment.Current.Parts)
            {
                Assembly assembly = part.Load(Application.GetResourceStream(new Uri(part.Source, UriKind.Relative)).Stream);
                deployed[assembly.FullName.Split(',')[0]] = assembly;
            }
        }


        public AssemblyDescription()
        {
            Dependencies = new ObservableCollection<Dependency>();
        }

        private string assemblyName;
        public string AssemblyName
        {
            get
            {
                return assemblyName;
            }
            set
            {
                if (assemblyName == null)
                    assemblyName = value;
                else
                    throw new InvalidOperationException("Once an AssemblyDescription's name has been set, it cannot be changed.");
                if (deployed.ContainsKey(assemblyName))
                    Assembly = deployed[assemblyName];
            }
        }
        private Uri location;
        public Uri Location
        {
            get
            {
                return location;
            }
            set
            {
                if (location == null)
                {
                    location = value;
                    if (!location.IsAbsoluteUri)
                        location = new Uri(Application.Current.Host.Source, location);
                }
                else
                    throw new InvalidOperationException("Once an AssemblyDescription's location has been set, it cannot be changed.");
            }
        }



        public ObservableCollection<Dependency> Dependencies
        {
            get { return (ObservableCollection<Dependency>)GetValue(DependenciesProperty); }
            private set { SetValue(DependenciesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dependencies.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DependenciesProperty =
            DependencyProperty.Register("Dependencies", typeof(ObservableCollection<Dependency>), typeof(AssemblyDescription), new PropertyMetadata(null));

        internal bool DependsOn(string name)
        {
            foreach (Dependency dep in Dependencies)
                if (dep.AssemblyName.Equals(name))
                    return true;
            return false;
        }

        public Assembly Assembly { get; internal set; }

        private IWebRequestCreate webRequestCreator;
        [TypeConverter(typeof(WebRequestCreateConverter))]
        public IWebRequestCreate WebRequestCreator
        {
            get
            {
                return webRequestCreator;
            }
            set
            {
                if (webRequestCreator == null)
                    webRequestCreator = value;
                else
                    throw new InvalidOperationException("Once an AssemblyDescription's WebRequestCreator has been set, it cannot be changed.");
            }
        }

        public bool IsLoaded
        {
            get { return (bool)GetValue(IsLoadedProperty); }
            internal set { SetValue(IsLoadedProperty, value); }
        }

        internal bool IsLoading
        { get; set; }

        // Using a DependencyProperty as the backing store for IsLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadedProperty =
            DependencyProperty.Register("IsLoaded", typeof(bool), typeof(AssemblyDescription), new PropertyMetadata(false));


    }
}
