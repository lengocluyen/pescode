using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("AccountPermissions")]
    public partial class AccountPermission : EntityBase<AccountPermission>
    {
        #region Properties

		
        public override object Id
        {

            get { return apid; }
            set { apid = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int apid { get; set; }
		public int AccountID { get; set; }
		public int PermissionID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public AccountPermission()
        {

        }

        public AccountPermission(object id)
        {
			if (id != null)
            {
				AccountPermission entity = Single(id);
				if (entity != null)
					entity.CopyTo<AccountPermission>(this);
				else
					this.apid = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (apid > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}