using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public enum GroupTypes
        {

        }
    public partial class GroupType
    {
        
        public static List<GroupType> GetAllGroupTypes()
        {
            List<GroupType> result = new List<GroupType>();
                result = All().OrderBy(gt => gt.Name).ToList();
            return result;
        }

        public static GroupType GetGroupTypeByID(Int32 GroupTypeID)
        {
            GroupType result;
                result = All().Where(gt => gt.GroupTypeID == GroupTypeID).FirstOrDefault();
            return result;
        }

        public static List<GroupType> GetGroupTypesByGroupID(Int32 GroupID)
        {
            List<GroupType> result = new List<GroupType>();
                IEnumerable<GroupType> groupTypes = from gt in All()
                                                    join gtgt in GroupToGroupType.All() on gt.GroupTypeID equals
                                                        gtgt.GroupTypeID
                                                    where gtgt.GroupID == GroupID
                                                    select gt;
                result = groupTypes.ToList();
            return result;
        }

        public static Int64 SaveGroupType(GroupType groupType)
        {
                if (groupType.GroupTypeID > 0)
                {
                    Update(groupType);
                }
                else
                {
                    Add(groupType);
                }
            return groupType.GroupTypeID;
        }

        public static void DeleteGroupType(GroupType groupType)
        {
            GroupType.Delete(groupType.GroupTypeID);
        }
    }
}