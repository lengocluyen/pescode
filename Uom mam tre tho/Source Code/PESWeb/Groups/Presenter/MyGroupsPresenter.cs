using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using StructureMap;
using Pes.Core;

namespace PESWeb.Groups
{
    public class MyGroupsPresenter
    {
        private IMyGroups _view;
        private IRedirector _redirector;
        private IWebContext _webContext;
        private IFileService _fileService;

        public MyGroupsPresenter()
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _fileService = ObjectFactory.GetInstance<IFileService>();
        }

        public void Init(IMyGroups view)
        {
            _view = view;
            LoadData();
        }

        public void LoadData()
        {
            _view.LoadData(Group.GetGroupsOwnedByAccount(_webContext.CurrentUser.AccountID));
        }

        public string GetImageByID(Int64 ImageID, File.Sizes Size)
        {
            return _fileService.GetFullFilePathByFileID(ImageID, Size);
        }

        public void GoToGroup(string GroupPageName)
        {
            _redirector.GoToGroupsViewGroup(GroupPageName);
        }

        public void DeleteGroup(int GroupID)
        {
            BoardForum forum = BoardForum.GetForumByGroupID(GroupID);
            if (forum != null)
            {
                BoardPost.DeletePostsByForumID(forum.ForumID);
                GroupForum.DeleteGroupForum(forum.ForumID, GroupID);
                var list1 = GroupForum.Find(g => g.GroupID == GroupID).ToList();
                foreach (GroupForum i in list1) GroupForum.Delete(i.GroupForumsID);
                //BoardForum.DeleteForum(forum);
            }
            var list = GroupToGroupType.Find(g => g.GroupID == GroupID).ToList();
            foreach (GroupToGroupType i in list) GroupToGroupType.Delete(i.GroupToGroupTypeID);
            GroupMember.DeleteAllGroupMembersForGroup(GroupID);
            Group.DeleteGroup(GroupID);
            LoadData();
        }

        public void EditGroup(int GroupID)
        {
            _redirector.GoToGroupsManageGroup(GroupID);
        }
    }
}
