using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;


namespace PESWeb.LearningVietNamese.UserControls
{
    public partial class ucViewAllLessions : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Starup();
        }

        private void Starup()
        {
            if (!Page.IsPostBack)
                FillData();
        }

        private void FillData()
        {
            dlViewAllLessions.DataSource =VLession.GetListLessionByGroup(37);
            dlViewAllLessions.DataBind();
        }
    }
}