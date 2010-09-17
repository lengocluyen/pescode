using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Pes.Core;
using StructureMap;

namespace PESWeb.LearningVietNamese
{
    public partial class TestPage : System.Web.UI.Page
    {
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {

            _webContext = ObjectFactory.GetInstance<IWebContext>();
            this.Title = ConfigurationManager.AppSettings.Get("SiteName") + " - Kiem Tra Trac Nghiem";

            string webURL = _webContext.RootUrl; 
            string initParams = "webURL=" + webURL;
            if (Request.Params["levelID"] != null)
            {
                try
                {
                    int id = Commons.ConvertToInt(Request.QueryString["levelID"], 0);
                    if (id > 0)
                    {
                        string questionsNumber = "5";
                        string timeExpire = "10";

                        initParams += ",levelID=" + Request.QueryString["levelID"] + ",questionsNumber=" + questionsNumber + ",timeExpire=" + timeExpire;

                        this.Silverlight1.InitParameters = initParams;
                    }
                    else
                        Response.Redirect(webURL+"learning/defaults.aspx");
                }
                catch
                {
                    Response.Redirect(webURL + "learning/defaults.aspx");
                }
            }
            else
                Response.Redirect(webURL + "learning/defaults.aspx");
        }
    }
}
