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
using System.Windows.Browser;
using ITBusSilverlight.PESServicesSession;

namespace ITBusSilverlight
{
    public partial class Page : UserControl
    {
        PESServicesSessionSoapClient ps = new PESServicesSessionSoapClient();
        protected string webURL = ITBusSilverlightCommons.parameters["webURL"];
        public int pupilID = 0;

        public Page()
        {
            CheckPermission();
        }
        public void CheckPermission()
        {
           ps.GetUserLoginIDCompleted += new EventHandler<GetUserLoginIDCompletedEventArgs>(ps_GetUserLoginIDCompleted);
            ps.GetUserLoginIDAsync();
        }

        void ps_GetUserLoginIDCompleted(object sender, GetUserLoginIDCompletedEventArgs e)
        {
            if (e.Result > 0)
            {
                pupilID = e.Result;

                InitializeComponent();

                this.LayoutRoot.Children.Add(new Lessions(this));
            }
            else
                HtmlPage.Window.Navigate(new Uri(webURL + "Learning/Learning.aspx",UriKind.RelativeOrAbsolute));
        }

      
    }
}
