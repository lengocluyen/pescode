using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("GroupToGroupTypes")]
    public partial class GroupToGroupType : EntityBase<GroupToGroupType>
    {
        #region Properties

		
        public override object Id
        {

            get { return ID; }
            set { ID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long ID { get; set; }
		public int GroupID { get; set; }
		public long GroupTypeID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public GroupToGroupType()
        {

        }

        public GroupToGroupType(object id)
        {
			if (id != null)
            {
				GroupToGroupType entity = Single(id);
				if (entity != null)
					entity.CopyTo<GroupToGroupType>(this);
				else
					this.ID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}