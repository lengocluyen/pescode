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
    public partial class Default : System.Web.UI.Page, IDefault
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
            _presenter.Init(this, IsPostBack);
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
        }

    }
}
