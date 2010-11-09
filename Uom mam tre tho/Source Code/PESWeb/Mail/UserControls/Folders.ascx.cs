using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail.UserControls
{
    public partial class Folders : System.Web.UI.UserControl, IFolders
    {
        protected IWebContext _webContext;
        private FoldersPresenter _presenter;
        public Folders()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new FoldersPresenter();
            _presenter.Init(this);
        }
        public void LoadFolders(List<MessageFolder> Folders)
        {
            repFolders.DataSource = Folders;
            repFolders.DataBind();
        }
        protected void repFolders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
                HyperLink linkFolder = e.Item.FindControl("linkFolder") as HyperLink;
                Image im = e.Item.FindControl("ImageLink") as Image;
                Label lb = e.Item.FindControl("LabelLink") as Label;
                im.ImageUrl = "~/images/letter.gif";
                lb.Text = ((MessageFolder)e.Item.DataItem).FolderName;
                //linkFolder.Text = ((MessageFolder)e.Item.DataItem).FolderName;

                linkFolder.NavigateUrl = "~/Mail/Default.aspx?folder=" + ((MessageFolder)e.Item.DataItem).MessageFolderID.ToString();
                linkFolder.Attributes.Add("FolderID", ((MessageFolder)e.Item.DataItem).MessageFolderID.ToString());
            }
        }
    }
}