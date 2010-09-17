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

namespace DynamicNavigation.Utilities.Loader
{
    public class Dependency : DependencyObject
    {
        public Dependency()
        {
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
                    throw new InvalidOperationException("Once a Dependency's AssemblyName has been set, it cannot be changed.");
            }
        }
    }
}
