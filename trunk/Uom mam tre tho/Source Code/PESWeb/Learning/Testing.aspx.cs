using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StructureMap;
using Pes.Core;
using System.Configuration;

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
            this.Title = ConfigurationManager.AppSettings.Get("SiteName") + " - Kiem Tra Trac Nghiem";

            string webURL = _webContext.RootUrl;
            string initParams = "webURL=" + webURL;
            if (Request.Params["idlesson"] != null)
            {
                try
                {
                    int id = Commons.ConvertToInt(Request.QueryString["idlesson"], 0);
                    if (id > 0)
                    {
                        string questionsNumber = "5";
                        string timeExpire = "10";

                        initParams += ",levelID=" + Request.QueryString["idlesson"] + ",questionsNumber=" + questionsNumber + ",timeExpire=" + timeExpire;

                        this.dienroi.InitParameters = initParams;
                    }
                    else
                        Response.Redirect(webURL + "learning/Maths.aspx");
                }
                catch
                {
                    Response.Redirect(webURL + "learning/Maths.aspx");
                }
            }
            else
                Response.Redirect(webURL + "learning/Maths.aspx");
        }
    }
}
