using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StructureMap;
using Pes.Core;

namespace PESWeb.UserControls
{
    public partial class PESBanner : System.Web.UI.UserControl
    {
        string _webURL;

        public string webURL
        {
            get { return "webURL=" + _webContext.RootUrl; }
            set { _webURL = "webURL=" + _webContext.RootUrl; }
        }
        private IWebContext _webContext;
        public PESBanner()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}