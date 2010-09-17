using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Pes.Core;
using StructureMap;
using System.Collections;
using System.Text;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;

namespace PESWeb
{
    public partial class Tests : System.Web.UI.Page, ITests
    {
        ArrayList numA = new ArrayList();
        ArrayList numC = new ArrayList();
        private TestsPresenter _presenter;
        public IWebContext _webContext;

        protected override void OnInit(EventArgs e)
        {
            this.BuildJS();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter = new TestsPresenter();
            _presenter.Init(this);
            base.OnInit(e);
        }

        private void BuildJS()
        {
            StringBuilder _js = new StringBuilder();
            _js.AppendLine("<script type=''text/javascript' language='javascript'>");
            _js.AppendLine("CKEDITOR.replace('" + txtMessageHK.ClientID + "',{extraPlugins : 'uicolor',uiColor: '#bad3ed',skin:'kama'});");
            _js.AppendLine("</script>");
            ClientScript.RegisterStartupScript(GetType(), "CKEditor", _js.ToString());
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            string s = hidden1.Value;
            string vv = ccddTest.SelectedValue;
            string testID = vv.Substring(0,vv.IndexOf(":::"));
        }

    }
}
