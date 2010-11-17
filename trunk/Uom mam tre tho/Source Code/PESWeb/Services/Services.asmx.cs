using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Pes.Core;
using StructureMap;

namespace PESWeb.Services
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class Services : System.Web.Services.WebService
    {
        [WebMethod]
        public string DeleteComment(int CommentID)
        {
            if (IsValid())
                return Comment.Delete(CommentID) > 0 ? Boolean.TrueString : Boolean.FalseString;
            return Boolean.FalseString;
        }
        [WebMethod(EnableSession = true)]
        public List<Comment> AddComment(Comment data)
        {
            if (IsValid())
            {
                IUserSession userSession = ObjectFactory.GetInstance<IUserSession>();
                data.CommentByAccountID = userSession.CurrentUser.AccountID;
                data.CommentByUsername = userSession.CurrentUser.Username;
                data.CreateDate = DateTime.Now;
                long commentID = Comment.SaveComment(data);
                List<Comment> list = Comment.Find(x => x.CommentID == commentID);
                list.ForEach(x => x.AuthorCanDelete = true);
                return list;
            }
            return new List<Comment>();
        }
        [WebMethod(EnableSession = true)]
        public List<Comment> MoreComments(int SystemObjectID, long SystemObjectRecordID, int More)
        {
            if (IsValid())
                return Comment.GetMoreCommentsBySystemObject(SystemObjectID, SystemObjectRecordID, More);
            return new List<Comment>();
        }

        [WebMethod(EnableSession = true)]
        public List<Alert> MoreAlerts(int AccountID, int Skip)
        {
            if (IsValid())
            {
                IAlertService alertService = ObjectFactory.GetInstance<IAlertService>();
                //return alertService.GetAlertsByAccountID(AccountID, Skip);

                List<Alert> list = alertService.GetAlertsByAccountID(AccountID, Skip);
                list.ForEach(x => {
                    x.Comments = x.GetTopComments();
                });
                return list;
            }
            return new List<Alert>();
        }

        [WebMethod(EnableSession = true)]
        public List<Alert> AddStatusUpdate(string Text, int AccountID)
        {
            if (IsValid())
            {
                long alertID = 0;
                IUserSession userSession = ObjectFactory.GetInstance<IUserSession>();
                IAlertService alertService = ObjectFactory.GetInstance<IAlertService>();
                if (userSession.CurrentUser.AccountID == AccountID)
                {
                    StatusUpdate su = new StatusUpdate();
                    su.CreateDate = DateTime.Now;
                    su.AccountID = userSession.CurrentUser.AccountID;
                    su.Status = Text;
                    StatusUpdate.SaveStatusUpdate(su);
                    alertID = alertService.AddStatusUpdateAlert(su);
                }
                else
                {
                    alertID = alertService.AddAlertToWallFriend(Text, AccountID);
                }
                return alertService.GetAlertsByAlertID(alertID);

            }
            return null;
        }
        private bool IsValid()
        {
            return true;
        }
    }


}
