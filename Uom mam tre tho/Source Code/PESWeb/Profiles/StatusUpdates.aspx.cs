using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;
using PESWeb.Profiles.Presenter;
using PESWeb.Profiles.Interface;

namespace PESWeb.Profiles
{
    public partial class StatusUpdates : System.Web.UI.Page, IStatusUpdates
    {
        private StatusUpdatesPresenter _presenter;
        private IWebContext _webContext;
        private IUserSession _userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new StatusUpdatesPresenter();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();

            if (_webContext.AccountID > 0)
                _presenter.Init(this, _webContext.AccountID);
            else if (_userSession.CurrentUser != null)
                _presenter.Init(this, _userSession.CurrentUser.AccountID);
        }

        public void ShowUpdates(List<StatusUpdate> StatusUpdates)
        {
             lvStatus.DataSource = StatusUpdates;
                lvStatus.DataBind();
            
        }
        public void lvStatus_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                StatusUpdate data = ((ListViewDataItem)e.Item).DataItem as StatusUpdate;
                HyperLink linkAvatar = e.Item.FindControl("linkAvatar") as HyperLink;
                linkAvatar.NavigateUrl = "~/profiles/profile.aspx?AccountID=" + data.AccountID;
                Image imaAvatar = e.Item.FindControl("imaAvatar") as Image;
                imaAvatar.ImageUrl = "~/images/ProfileAvatar/ProfileImage.aspx?AccountID=" + data.AccountID;

                Label lbStatus = e.Item.FindControl("lbStatus") as Label;
                lbStatus.Text = data.Status;

                Label lbCreateDate = e.Item.FindControl("lbCreateDate") as Label;
                lbCreateDate.Text = data.CreateDate.ToString("dd-MM-yyyy lúc HH:mm");


            }
        }
    }
}
