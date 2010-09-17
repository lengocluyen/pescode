using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("AccountFiles")]
    public partial class AccountFile : EntityBase<AccountFile>
    {
        #region Properties

		
        public override object Id
        {

            get { return AccountID; }
            set { AccountID = (int)value; }
        }

		public int AccountID { get; set; }
		public long FileID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public AccountFile()
        {

        }

        public AccountFile(object id)
        {
			if (id != null)
            {
				AccountFile entity = Single(id);
				if (entity != null)
					entity.CopyTo<AccountFile>(this);
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