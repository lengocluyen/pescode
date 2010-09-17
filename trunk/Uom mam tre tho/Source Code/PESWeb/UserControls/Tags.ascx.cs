using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;

namespace PESWeb.UserControls
{
    public enum TagState
    {
        ShowCloud,
        ShowTagBox,
        ShowCloudAndTagBox,
        ShowParentCloud,
        ShowGlobalCloud
    }
    public partial class Tags : System.Web.UI.UserControl, ITags
    {
        public TagState Display { get; set; }
        public int SystemObjectID { get; set; }
        public long SystemObjectRecordID { get; set; }

        private TagsPresenter _presenter;

        public Tags()
        {
            _presenter = new TagsPresenter();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Init(this, IsPostBack);
        }

        public void ClearTagCloud()
        {
            phTagCloud.Controls.Clear();
        }

        public void ShowTagCloud(bool IsVisible)
        {
            pnlTagCloud.Visible = IsVisible;
        }

        public void ShowTagBox(bool IsVisible)
        {
            pnlTag.Visible = IsVisible;
        }

        public void AddTagsToTagCloud(TagWithState tag)
        {
            HyperLink hlTag = new HyperLink();
            hlTag.Text = tag.Name;
            hlTag.NavigateUrl = "~/Tags/" + tag.Name.Replace(" ", "-");
            hlTag.Attributes.Add("style", "font-size:" + tag.FontSize + "px;");
            phTagCloud.Controls.Add(hlTag);

            phTagCloud.Controls.Add(new LiteralControl(" "));
        }

        protected void btnTag_Click(object sender, EventArgs e)
        {
            _presenter.Init(this, IsPostBack);
            _presenter.btnTag_Click(txtTag.Text);
            txtTag.Text = "";
        }
    }
}