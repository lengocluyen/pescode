using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("AccountFolders")]
    public partial class AccountFolder : EntityBase<AccountFolder>
    {
        #region Properties

		
        public override object Id
        {

            get { return AccountID; }
            set { AccountID = (int)value; }
        }

		public int AccountID { get; set; }
		public long FolderID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public AccountFolder()
        {

        }

        public AccountFolder(object id)
        {
			if (id != null)
            {
				AccountFolder entity = Single(id);
				if (entity != null)
					entity.CopyTo<AccountFolder>(this);
				else
					this.AccountID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (AccountID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}