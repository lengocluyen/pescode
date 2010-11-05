using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StructureMap;
using Pes.Core;

namespace PESWeb.Learning
{
    public partial class Testing : System.Web.UI.Page
    {
        string _webURL;

        public string WebURL
        {
            get { return _webURL; }
            set { _webURL = value; }
        }
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _webURL = "webURL=" + _webContext.RootUrl;
            this.Silverlight1.InitParameters = _webURL;
        }

    }
}
