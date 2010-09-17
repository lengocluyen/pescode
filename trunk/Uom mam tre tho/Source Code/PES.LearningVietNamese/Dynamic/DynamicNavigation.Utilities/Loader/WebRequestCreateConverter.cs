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
using System.Net.Browser;
using System.ComponentModel;

namespace DynamicNavigation.Utilities.Loader
{
    public class WebRequestCreateConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType.Equals(typeof(string));
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            switch (value.ToString())
            {
                case "ClientHttp":
                    return WebRequestCreator.ClientHttp;
                case "BrowserHttp":
                    return WebRequestCreator.BrowserHttp;
            }
            return null;
        }
    }
}
