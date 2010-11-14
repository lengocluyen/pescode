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
        public string DeleteComment(int commentId)
        {
            if (IsValid())
                return Comment.Delete(commentId) > 0 ? Boolean.TrueString : Boolean.FalseString;
            return Boolean.FalseString;
        }
        [WebMethod(EnableSession = true)]
        public List<Comment> Test(Comment data)
        {
            if (IsValid())
            {
                IUserSession userSession = ObjectFactory.GetInstance<IUserSession>();
                data.CommentByAccountID = userSession.CurrentUser.AccountID;
                data.CommentByUsername = userSession.CurrentUser.Username;
                data.CreateDate = DateTime.Now;
                long commentID = Comment.SaveComment(data);
                return Comment.Find(x => x.CommentID == commentID);
            }
            return null;
        }

        private bool IsValid()
        {
            return true;
        }
    }


}
