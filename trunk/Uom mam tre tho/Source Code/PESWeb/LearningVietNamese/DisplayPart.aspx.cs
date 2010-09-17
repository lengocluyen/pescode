using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
namespace PESWeb.LearningVietNamese
{
    public partial class DisplayPart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["partID"] != null)
            {
                int id = Commons.ConvertToInt(Request.Params["partID"].ToString(), -1);
                if (id == -1)
                    return;
                VPart part = VPart.GetPartByID(id);
                this.content.InnerHtml = part.PartContent;
            }
        }
    }
}
