using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Pes.Core
{
    public class GroupService : IGroupService
    {
        private IWebContext _webContext;
        public GroupService()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public bool IsOwnerOrAdministrator(Int32 AccountID, Int32 GroupID)
        {
            bool result = false;
            if (IsOwner(AccountID, GroupID) || IsAdministrator(AccountID, GroupID))
                result = true;
            return result;
        }

        public bool IsOwner(Int32 AccountID, Int32 GroupID)
        {
            return Group.IsOwner(AccountID, GroupID);
        }

        public bool IsAdministrator(Int32 AccountID, Int32 GroupID)
        {
            return GroupMember.IsAdministrator(AccountID, GroupID);
        }

        public bool IsMember(Int32 AccountID, Int32 GroupID)
        {
            return GroupMember.IsMember(AccountID, GroupID);
        }

        public int SaveGroup(Group group)
        {
            int result = 0;
            if (group.GroupID > 0)
            {
                result = Group.SaveGroup(group);
            }
            else
            {
                result = Group.SaveGroup(group);

                BoardForum forum = new BoardForum();
                forum.CategoryID = 4; //group forums container
                forum.CreateDate = DateTime.Now;
                forum.LastPostByAccountID = _webContext.CurrentUser.AccountID;
                forum.LastPostByUsername = _webContext.CurrentUser.Username;
                forum.LastPostDate = DateTime.Now;
                forum.Name = group.Name;
                forum.PageName = group.PageName;
                forum.PostCount = 0;
                forum.Subject = group.Name;
                forum.ThreadCount = 0;
                forum.UpdateDate = DateTime.Now;
                int ForumID = BoardForum.SaveForum(forum);

                //create relationship between the group and forum
                GroupForum gf = new GroupForum();
                gf.ForumID = ForumID;
                gf.GroupID = group.GroupID;
                gf.CreateDate = DateTime.Now;
                GroupForum.SaveGroupForum(gf);
            }

            return result;
        }
    }
}
