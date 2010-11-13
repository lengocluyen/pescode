using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Pes.Core;

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

        private bool IsValid()
        {
            return true;
        }
    }


}
