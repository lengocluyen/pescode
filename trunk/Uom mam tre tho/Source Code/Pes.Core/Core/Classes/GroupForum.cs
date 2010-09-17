using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class GroupForum
    {
        public static int GetGroupIdByForumID(int ForumID)
        {
            int result = 0;
           
                result = GroupForum.All().Where(gf => gf.ForumID == ForumID).Select(gf => gf.GroupID).FirstOrDefault();
            
            return result;
        }

        public static void SaveGroupForum(GroupForum groupForum)
        {
                if (GroupForum.All().Where(gf => gf.ForumID == groupForum.ForumID && gf.GroupID == groupForum.GroupID).FirstOrDefault() == null)
                {
                    Add(groupForum);
                }
        }

        public static void DeleteGroupForum(int ForumID, int GroupID)
        {
                Delete(GroupForum.All().Where(gf => gf.GroupID == GroupID && gf.ForumID == ForumID).FirstOrDefault().GroupID);
        }

        public static void DeleteGroupForum(GroupForum groupForum)
        {
            Delete(groupForum);
        }
    }
}