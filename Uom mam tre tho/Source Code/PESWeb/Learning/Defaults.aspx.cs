﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;

namespace PESWeb.Learning
{
    public partial class Defaults : System.Web.UI.Page
    {
        string _webURL;

        public string WebURL
        {
            get { return _webURL; }
            set { _webURL = value; }
        }
        private IWebContext _webContext;
        public Defaults()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _webURL = "webURL=" + _webContext.RootUrl;
            this.Xaml1.InitParameters = _webURL;
        }
    }
}