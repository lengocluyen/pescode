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
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                _presenter.LoadComments();
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            _presenter.AddComment(txtComment.Text);
        }

        public void ShowCommentsBox(bool IsVisible)
        {
            this.Visible = IsVisible;
        }

        public void ClearComments()
        {
            phComments.Controls.Clear();
        }

        public void LoadComments(List<Comment> comments)
        {
            if (comments.Count > 0)
            {
                if (comments.Count <= _config.PageNumItem - 3)
                {
                    phComments.Controls.Add(new LiteralControl("<div class='comments'>"));
                    foreach (Comment comment in comments)
                    {
                        phComments.Controls.Add(new LiteralControl(
                        "<div class=\"cmt\">" +
                                    "<a class=\"image\">" +
                                        "<img src=\"/images/profileavatar/profileimage.aspx?AccountID=" + comment.CommentByAccountID + "\" alt=\"\" /></a>" +
                                    "<div class=\"para\">" +
                                        "<a href=\"#\" class=\"bold\">" + "(" + comment.CreateDate.ToShortDateString() + ") " + comment.CommentByUsername + ": " + "</a>" + comment.Body +
                                    "</div>" +
                        "</div>"));
                    }
                    phComments.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    phComments.Controls.Add(new LiteralControl("<div class='comments'>"));
                    int i = 0;
                    for (i = 0; i < _config.PageNumItem - 3; i++)
                    {
                        phComments.Controls.Add(new LiteralControl(
                        "<div class=\"cmt\">" +
                                    "<a class=\"image\">" +
                                        "<img src=\"/images/profileavatar/profileimage.aspx?AccountID=" + comments[i].CommentByAccountID + "\" alt=\"\" /></a>" +
                                    "<div class=\"para\">" +
                                        "<a href=\"#\" class=\"bold\">" + "(" + comments[i].CreateDate.ToShortDateString() + ") " + comments[i].CommentByUsername + ": " + "</a>" + comments[i].Body +
                                    "</div>" +
                        "</div>"));
                    }
                    phComments.Controls.Add(new LiteralControl("</div>"));

                    phComments.Controls.Add(new LiteralControl("<div class='exComments' style='margin-top:-8px'>"));
                    phComments.Controls.Add(new LiteralControl("<div class='comments'>"));
                    for (i = _config.PageNumItem - 3; i < comments.Count; i++)
                    {
                        phComments.Controls.Add(new LiteralControl(
                        "<div class=\"cmt\">" +
                                    "<a class=\"image\">" +
                                        "<img src=\"/images/profileavatar/profileimage.aspx?AccountID=" + comments[i].CommentByAccountID + "\" alt=\"\" /></a>" +
                                    "<div class=\"para\">" +
                                        "<a href=\"#\" class=\"bold\">" + "(" + comments[i].CreateDate.ToShortDateString() + ") " + comments[i].CommentByUsername + ": " + "</a>" + comments[i].Body +
                                    "</div>" +
                        "</div>"));
                    }
                    phComments.Controls.Add(new LiteralControl("</div>"));
                    phComments.Controls.Add(new LiteralControl("</div>"));
                    phComments.Controls.Add(new LiteralControl("<div class='exComments_title' style='width:70px;cursor:pointer;float:left;padding-right:3px;font-weight:bold'><span onclick=\"this.innerHTML=='Thu gọn'?this.innerHTML='Xem tất cả':this.innerHTML='Thu gọn'\">Xem tất cả</span></div>"));
                }

            }
        }
    }
}