using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("GroupForums")]
    public partial class GroupForum : EntityBase<GroupForum>
    {
        #region Properties

		
        public override object Id
        {

            get { return GroupForumsID; }
            set { GroupForumsID = (long)value; }
        }

		[SubSonicPrimaryKey]
        public long GroupForumsID { get; set; }
		public int GroupID { get; set; }
		public int ForumID { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public GroupForum()
        {

        }

        public GroupForum(object id)
        {
			if (id != null)
            {
				GroupForum entity = Single(id);
				if (entity != null)
					entity.CopyTo<GroupForum>(this);
				else
                    this.GroupForumsID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (GroupForumsID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}