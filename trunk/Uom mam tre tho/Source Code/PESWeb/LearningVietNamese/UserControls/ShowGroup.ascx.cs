using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;

namespace PESWeb.LearningVietNamese.UserControls
{
    public partial class ShowGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.rptShowGroup.DataSource = VLessionGroup.GetListLessionGroups();
            this.rptShowGroup.DataBind();
        }
    }
}