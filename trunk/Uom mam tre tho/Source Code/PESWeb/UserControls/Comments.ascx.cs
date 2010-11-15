using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;
namespace PESWeb.UserControls
{

    public partial class Comments : System.Web.UI.UserControl, IComments
    {
        private CommentsPresenter _presenter;
        public string _IDRecord;
        public IConfiguration _config;
        public int SystemObjectID { get; set; }
        public long SystemObjectRecordID { get; set; }

        public SystemObject.Names SystemObject
        {
            set
            {
                SystemObjectID = (int)value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            _presenter = new CommentsPresenter();
            _config = ObjectFactory.GetInstance<IConfiguration>();
            _presenter.Init(this, IsPostBack);
            repComment.ItemDataBound += new RepeaterItemEventHandler(repComment_ItemDataBound);
        }

        void repComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Comment data = e.Item.DataItem as Comment;
                HyperLink lnk = (HyperLink)e.Item.FindControl("lnkDel");

                if (_presenter.IsOwner(data.CommentByAccountID))
                {
                    //lnk.Attributes["url"] = Page.ResolveClientUrl("~/Services/Services.asmx/DeleteComment");
                    lnk.Attributes["data"] = data.CommentID.ToString();
                    lnk.Visible = true;
                }
                else
                {
                    lnk.Visible = false;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                _presenter.LoadComments();
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            //_presenter.AddComment(txtComment.Text);
        }

        public void LoadComments(List<Comment> comments)
        {
            repComment.DataSource = comments;
            repComment.DataBind();
        }

        public void ShowViewComment(bool Value)
        {
            pnlMore.Visible = Value;
            if (pnlMore.Visible)
            {
                lnkMore.Text = string.Format("Xem tất cả ({0})", _presenter.MoreComments);
                lnkMore.Attributes["data"] = SystemObjectID + "-" + SystemObjectRecordID + "-" + _presenter.MoreComments;
                //lnkMore.Attributes["SystemObjectRecordID"] = SystemObjectRecordID.ToString();
            }
        }

        public void ShowCommentInput(bool Value)
        {
            pnlCommentInput.Attributes["style"] = "display:" + ((Value == true) ? "block" : "none");
        }

    }
}