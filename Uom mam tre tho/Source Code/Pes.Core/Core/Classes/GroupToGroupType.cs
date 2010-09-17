using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class GroupToGroupType
    {
        public static void SaveGroupTypesForGroup(List<long> SelectedGroupTypeIDs, int GroupID)
        {
                //get a list of current selections
                List<long> currentTypes =
                    All().Where(gt => gt.GroupID == GroupID).Select(gt => gt.GroupTypeID).ToList();

                //make a list of items to delete
                List<long> itemsToDelete = currentTypes.Where(ct => !SelectedGroupTypeIDs.Contains(ct)).ToList();

                //make a list of items to insert
                List<long> itemsToInsert =
                    SelectedGroupTypeIDs.Where(s => !currentTypes.Contains(s)).ToList();

                //delete grouptogrouptypes
                Delete(
                    All().Where(g => itemsToDelete.Contains(g.GroupTypeID) && g.GroupID == GroupID).FirstOrDefault());

                //create the actual objects to insert
                List<GroupToGroupType> typesToInsert = new List<GroupToGroupType>();
                foreach (long l in itemsToInsert)
                {
                    GroupToGroupType g = new GroupToGroupType() { GroupID = GroupID, GroupTypeID = l };
                    Add(g);
                }

        }

        public static void SaveGroupToGroupType(GroupToGroupType groupToGroupType)
        {
                if (All().Where(gt => gt.GroupID == groupToGroupType.GroupID && gt.GroupTypeID == groupToGroupType.GroupTypeID).FirstOrDefault() == null)
                {
                    Add(groupToGroupType);
                }
        }

        public static void DeleteGroupToGroupType(GroupToGroupType groupToGroupType)
        {
            Delete(groupToGroupType.ID);
        }
 
    }
}