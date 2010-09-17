using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using SubSonic.Security;
using PESWeb.Interface;
using PESWeb.Presenter;

namespace PESWeb
{
    public partial class Default : System.Web.UI.Page,IDefault
    {
        DefaultPresenter _presenter;
        public int ItemAdd { get; set; }
        public int TotalItem { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnInit(EventArgs e)
        {
            ItemAdd = 5;
            btnAddStatus.Click += new EventHandler(btnAddStatus_Click);
            _presenter = new DefaultPresenter();
            _presenter.Init(this,IsPostBack);
        }

        void btnAddStatus_Click(object sender, EventArgs e)
        {
            _presenter.AddStatus(txtStatus.Text);
            txtStatus.Text = "";
        }
        public void ShowAlerts(List<Alert> alerts)
        {
            repFilter.DataSource = alerts;
            repFilter.DataBind();
            if (TotalItem > 20)
            {
                bt_exFeeds.Visible = true;
                bt_exFeeds.Click += new ImageClickEventHandler(bt_exFeeds_Click);
            }
            else
            {
                bt_exFeeds.Visible = false;
                ph_exFeeds.Visible = false;
            }
            if (repFilter.Items.Count == 0)
                lblMessage.Text = "You don't have any alerts yet!";
        }

        void bt_exFeeds_Click(object sender, ImageClickEventArgs e)
        {
            ph_exFeeds.Visible = true;

            _presenter.ShowDisplayPaging();

            
        }
        public void ShowAlertsExtra(List<Alert> alerts)
        {
            rp_exFead.DataSource = alerts;
            rp_exFead.DataBind();
            DefaultPresenter.currentItem = repFilter.Items.Count + rp_exFead.Items.Count;
            if (DefaultPresenter.currentItem >= TotalItem)
            {
                bt_exFeeds.Visible = false;
                return;
            }
        }

    }
}
