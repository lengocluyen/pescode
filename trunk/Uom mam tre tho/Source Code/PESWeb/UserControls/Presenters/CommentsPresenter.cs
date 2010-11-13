using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core.Impl;
using Pes.Core;
using StructureMap;

namespace PESWeb.UserControls
{
    public class CommentsPresenter
    {
        private IComments _view;
        private IWebContext _webContext;

        public CommentsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();

        }

        internal void Init(IComments view, bool IsPostBack)
        {
            _view = view;
            if (_webContext.CurrentUser != null)
                _view.ShowCommentsBox(true);
            else
                _view.ShowCommentsBox(false);
        }

        internal bool IsOwner(int CommentByAccountID)
        {
            return _webContext.CurrentUser.AccountID == CommentByAccountID;
        }

        internal void LoadComments()
        {
            _view.LoadComments(Comment.GetTopCommentsBySystemObject(_view.SystemObjectID, _view.SystemObjectRecordID, 3));
            // _view.LoadComments(Comment.GetCommentsBySystemObject(_view.SystemObjectID, _view.SystemObjectRecordID, 3));
        }

        internal void AddComment(string comment)
        {
            Comment c = new Comment();
            c.Body = comment;
            c.CommentByAccountID = _webContext.CurrentUser.AccountID;
            c.CommentByUsername = _webContext.CurrentUser.Username;
            c.CreateDate = DateTime.Now;
            c.SystemObjectID = _view.SystemObjectID;
            c.SystemObjectRecordID = _view.SystemObjectRecordID;
            Comment.SaveComment(c);
            //  _view.ClearComments();
            // LoadComments();
        }
    }
}
