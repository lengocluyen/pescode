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

        public string WebURL
        {
            get { return _webURL; }
            set { _webURL = value; }
        }
        private IWebContext _webContext;
        public PESBanner()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _webURL = "webURL=" + _webContext.RootUrl;
            this.slBanner.InitParameters = _webURL;
        }
    }
}