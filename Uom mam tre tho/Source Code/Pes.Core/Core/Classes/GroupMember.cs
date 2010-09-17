using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class GroupMember
    {
        public static List<int> GetMemberAccountIDsByGroupID(Int32 GroupID)
        {
            List<int> result = new List<int>();
                result = GroupMember.All().Where(gm => gm.IsApproved && gm.GroupID == GroupID).Select(gm => gm.AccountID).ToList();
                result.Add(Group.All().Where(g => g.GroupID == GroupID).Select(gm => gm.AccountID).FirstOrDefault());
            return result;
        }

        public static bool IsMember(Int32 AccountID, Int32 GroupID)
        {
            bool result = false;
                if (GroupMember.All().Where(gm => gm.AccountID == AccountID && gm.GroupID == GroupID && gm.IsApproved).FirstOrDefault() != null)
                    result = true;
            return result;
        }

        public static bool IsAdministrator(Int32 AccountID, Int32 GroupID)
        {
            bool result = false;
                if (GroupMember.All().Where(gm => gm.AccountID == AccountID &&
                    gm.GroupID == GroupID &&
                    gm.IsAdmin &&
                    gm.IsApproved).FirstOrDefault() != null)
                    result = true;
            return result;
        }

        public static void DeleteGroupMembers(List<int> MembersToDelete, int GroupID)
        {
                IEnumerable<GroupMember> members =
                    GroupMember.All().Where(gm => MembersToDelete.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember i in members)
                    Delete(i.AccountID);
        }

        public static void ApproveGroupMembers(List<int> MembersToApprove, int GroupID)
        {
                IEnumerable<GroupMember> members =
                    GroupMember.All().Where(gm => MembersToApprove.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember member in members)
                {
                    member.IsApproved = true;
                }
        }

        public static void PromoteGroupMembersToAdmin(List<int> MembersToPromote, int GroupID)
        {
                IEnumerable<GroupMember> members =
                    GroupMember.All().Where(gm => MembersToPromote.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember member in members)
                {
                    member.IsAdmin = true;
                    Update(member);
                }
        }

        public static void DemoteGroupMembersFromAdmin(List<int> MembersToDemote, int GroupID)
        {
                IEnumerable<GroupMember> members =
                    GroupMember.All().Where(gm => MembersToDemote.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember member in members)
                {
                    member.IsAdmin = false;
                    Update(member);
                }
        }

        public static void SaveGroupMember(GroupMember groupMember)
        {
                if (GroupMember.All().Where(gm => gm.GroupID == groupMember.GroupID && gm.AccountID == groupMember.AccountID).FirstOrDefault() == null)
                {
                    Add(groupMember);
                    Group group = Group.All().Where(g => g.GroupID == groupMember.GroupID).FirstOrDefault();
                    group.MemberCount++;
                    Group.Update(group);
            }
        }

        public static void DeleteAllGroupMembersForGroup(int GroupID)
        {
            Delete(GroupID);
        }

        public static void DeleteGroupMember(GroupMember groupMember)
        {

            Delete(groupMember.GroupID);
        }
    }
}