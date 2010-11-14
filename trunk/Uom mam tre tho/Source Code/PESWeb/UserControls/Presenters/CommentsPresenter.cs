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
        private int moreComments = -1;
        public int MoreComments
        {
            get
            {
                if (moreComments == -1)
                    moreComments = Comment.CountMore(_view.SystemObjectID, _view.SystemObjectRecordID);
                return moreComments;
            }
        }

        public CommentsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        internal void Init(IComments view, bool IsPostBack)
        {
            _view = view;
            //if (_webContext.CurrentUser != null)
            //    _view.ShowViewComment(true);
            //else
            //    _view.ShowViewComment(false);
        }

        internal bool IsOwner(int CommentByAccountID)
        {
            return _webContext.CurrentUser.AccountID == CommentByAccountID;
        }

        internal void LoadComments()
        {
            List<Comment> list = Comment.GetTopCommentsBySystemObject(_view.SystemObjectID, _view.SystemObjectRecordID, MoreComments);
            if (list.Count > 0)
            {
                // _view.LoadComments(Comment.GetCommentsBySystemObject(_view.SystemObjectID, _view.SystemObjectRecordID, 3));
                _view.LoadComments(list);
                _view.ShowViewComment(MoreComments > 0);
                _view.ShowCommentInput(true);
            }
            else
            {
                _view.ShowViewComment(false);
                _view.ShowCommentInput(false);
            }
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
