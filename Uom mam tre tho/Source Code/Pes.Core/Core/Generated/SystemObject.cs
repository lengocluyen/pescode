using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("SystemObjects")]
    public partial class SystemObject : EntityBase<SystemObject>
    {
        #region Properties

		
        public override object Id
        {

            get { return SystemObjectID; }
            set { SystemObjectID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int SystemObjectID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public string Name { get; set; }

        #endregion

        public SystemObject()
        {

        }

        public SystemObject(object id)
        {
			if (id != null)
            {
				SystemObject entity = Single(id);
				if (entity != null)
					entity.CopyTo<SystemObject>(this);
				else
					this.SystemObjectID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (SystemObjectID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}