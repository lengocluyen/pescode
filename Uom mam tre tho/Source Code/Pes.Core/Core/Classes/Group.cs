using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    public partial class Group
    {
        [SubSonicIgnore]
        public List<GroupTypes> Types { get; set; }
        [SubSonicIgnore]
        public List<Folder> Folders { get; set; }
        [SubSonicIgnore]
        public List<BoardForum> Forums { get; set; }
        [SubSonicIgnore]
        public List<Account> Members { get; set; }
        [SubSonicIgnore]
        public List<Group> RelatedGroups { get; set; }


        public static Group GetGroupByForumID(int ForumID)
        {
            Group result = null;
                result = (from g in Group.All()
                          join f in GroupForum.All() on g.GroupID equals f.GroupID
                          where f.ForumID == ForumID
                          select g).FirstOrDefault();
            return result;
        }

        public static bool IsOwner(int AccountID, int GroupID)
        {
            bool result = false;
                if (Group.All().Where(g => g.AccountID == AccountID && g.GroupID == GroupID).FirstOrDefault() != null)
                    result = true;
            return result;
        }

        public static List<Group> GetLatestGroups()
        {
            List<Group> results = new List<Group>();
                IEnumerable<Group> groups = Group.All().OrderByDescending(g => g.UpdateDate).Take(50);
                results = groups.ToList();
            return results;
        }

        public static bool CheckIfGroupPageNameExists(string PageName)
        {
            bool result = false;
                Group group = Group.All().Where(g => g.PageName == PageName).FirstOrDefault();
                if (group == null)
                    result = false;
            return result;
        }

        public static List<Group> GetGroupsAccountIsMemberOf(Int32 AccountID)
        {
            List<Group> result = new List<Group>();
                IEnumerable<Group> groups = from g in Group.All()
                                            join m in GroupMember.All() on g.GroupID equals m.GroupID
                                            where m.AccountID == AccountID
                                            select g;
                result = groups.ToList();
            return result;
        }

        public static List<Group> GetGroupsOwnedByAccount(Int32 AccountID)
        {
            List<Group> result = new List<Group>();
                IEnumerable<Group> groups = Group.All().Where(g => g.AccountID == AccountID);
                result = groups.ToList();
            return result;
        }
        public static Group GetGroupByID(Int32 GroupID)
        {
            Group result;
                result = Group.All().Where(g => g.GroupID == GroupID).FirstOrDefault();
            return result;
        }

        public static Group GetGroupByPageName(string PageName)
        {
            Group result;
                result = Group.All().Where(g => g.PageName == PageName).FirstOrDefault();
            return result;
        }

        public static Int32 SaveGroup(Group group)
        {
                    group.CreateDate = DateTime.Now;
                    group.UpdateDate = DateTime.Now;
                    Add(group);
            return group.GroupID;
        }

        public static void DeleteGroup(Group group)
        {
            Delete(group.GroupID);
        }

        public static void DeleteGroup(int GroupID)
        {
            Delete(GroupID);
        }
    }
}