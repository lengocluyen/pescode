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
    public partial class View : System.Web.UI.Page
    {
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            this.Title = ConfigurationManager.AppSettings.Get("SiteName") + " - Thu vien bai hoc";
            string initParams = "";
            if (Request.Params["width"] != null && Request.Params["height"] != null)
            {
                PESSession.Set1(SessionConstants.Session_PageWidth, Request.Params["width"].ToString());
                PESSession.Set1(SessionConstants.Session_PageHeight, Request.Params["height"].ToString());
            }

            initParams = "webURL=" + _webContext.RootUrl +
                ",width=" + PESSession.Get1(SessionConstants.Session_PageWidth).ToString() +
                ",height=" + PESSession.Get1(SessionConstants.Session_PageHeight).ToString();

            if (Request.Params["group"] != null)
            {
                int groupID = Commons.ConvertToInt(Request.Params["group"].ToString(), -1);
                if (groupID != -1)
                    initParams += ",group=" + groupID.ToString();
            }

            this.Xaml1.InitParameters = initParams;
        }
    }
}
