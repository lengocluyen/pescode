using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail.UserControls
{
    public partial class Folders : System.Web.UI.UserControl, IFolders
    {
        protected IWebContext _webContext;
        private FoldersPresenter _presenter;
        public string CatHTML = "";
        int folderID = 0;
        public Folders()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new FoldersPresenter();
            _presenter.Init(this);
            LoadCategories();
        }

        private void LoadCategories()
        {
            folderID = _webContext.FolderID;

            bool IsNewMessage = String.Compare(System.IO.Path.GetFileName(Request.FilePath), "NewMessage.aspx", true) == 0;
            if (IsNewMessage)
                folderID = -1;

            //bool IsReadMessage = String.Compare(System.IO.Path.GetFileName(Request.FilePath), "ReadMessage.aspx", true) == 0;
            //if (IsReadMessage)
            //{
            //    folderID = -1;
            //    IsNewMessage = false;
            //}
            CatHTML = string.Format(@"
                <li class='{4}'><a id='createmaillink' href='NewMessage.aspx' title='Soạn thư'>Soạn thư</a></li>
                <li class='{5}'><a id='inboxlonk' href='Default.aspx?folder={0}'>Hộp thư đến</a></li>
                <li class='{6}'><a id='sendlink' href='Default.aspx?folder={1}'>Hộp thư đi</a></li>
                <li class='{7}'><a id='draflink' href='Default.aspx?folder={2}'>Thư nháp</a></li>
                <li class='{8}'><a id='spamlink' href='Default.aspx?folder={3}'>Thư rác</a></li>",
                   (int)MessageFolders.Inbox, (int)MessageFolders.Sent, (int)MessageFolders.Spam, (int)MessageFolders.Trash,
                    IsNewMessage ? "current-cat" : "cat-item", SetCSS(1), SetCSS(2), SetCSS(3), SetCSS(4));

        }

        private string SetCSS(int num)
        {
            return folderID == num ? "current-cat" : "cat-item";
        }
    }
}