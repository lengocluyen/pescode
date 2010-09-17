using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("SystemObjectTags")]
    public partial class SystemObjectTag : EntityBase<SystemObjectTag>
    {
        #region Properties

		
        public override object Id
        {

            get { return SystemObjectTagID; }
            set { SystemObjectTagID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long SystemObjectTagID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public long TagID { get; set; }
		public long SystemObjectRecordID { get; set; }
		public int SystemObjectID { get; set; }
		public DateTime CreateDate { get; set; }
		public int CreatedByAccountID { get; set; }
		public string CreatedByUsername { get; set; }

        #endregion

        public SystemObjectTag()
        {

        }

        public SystemObjectTag(object id)
        {
			if (id != null)
            {
				SystemObjectTag entity = Single(id);
				if (entity != null)
					entity.CopyTo<SystemObjectTag>(this);
				else
					this.SystemObjectTagID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (SystemObjectTagID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}