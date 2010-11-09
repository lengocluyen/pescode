using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("GroupMembers")]
    public partial class GroupMember : EntityBase<GroupMember>
    {
        #region Properties

		
        public override object Id
        {

            get { return GroupMemberID; }
            set { GroupMemberID = (long)value; }
        }

		[SubSonicPrimaryKey]
        public long GroupMemberID { get; set; }
		public int GroupID { get; set; }
		public int AccountID { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsApproved { get; set; }

        #endregion

        public GroupMember()
        {

        }

        public GroupMember(object id)
        {
			if (id != null)
            {
				GroupMember entity = Single(id);
				if (entity != null)
					entity.CopyTo<GroupMember>(this);
				else
                    this.GroupMemberID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (GroupMemberID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}