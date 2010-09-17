using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("GroupTypes")]
    public partial class GroupType : EntityBase<GroupType>
    {
        #region Properties

		
        public override object Id
        {

            get { return GroupTypeID; }
            set { GroupTypeID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long GroupTypeID { get; set; }
		public string Name { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public GroupType()
        {

        }

        public GroupType(object id)
        {
			if (id != null)
            {
				GroupType entity = Single(id);
				if (entity != null)
					entity.CopyTo<GroupType>(this);
				else
					this.GroupTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (GroupTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}