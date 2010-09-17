using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Friends")]
    public partial class Friend : EntityBase<Friend>
    {
        #region Properties

		
        public override object Id
        {

            get { return FriendID; }
            set { FriendID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int FriendID { get; set; }
		public int AccountID { get; set; }
		public int MyFriendsAccountID { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public Friend()
        {

        }

        public Friend(object id)
        {
			if (id != null)
            {
				Friend entity = Single(id);
				if (entity != null)
					entity.CopyTo<Friend>(this);
				else
					this.FriendID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FriendID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}