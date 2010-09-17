using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Permissions")]
    public partial class Permission : EntityBase<Permission>
    {
        #region Properties

		
        public override object Id
        {

            get { return PermissionID; }
            set { PermissionID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PermissionID { get; set; }
		public string Name { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public Permission()
        {

        }

        public Permission(object id)
        {
			if (id != null)
            {
				Permission entity = Single(id);
				if (entity != null)
					entity.CopyTo<Permission>(this);
				else
					this.PermissionID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (PermissionID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}