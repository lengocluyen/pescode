using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FriendInvitations")]
    public partial class FriendInvitation : EntityBase<FriendInvitation>
    {
        #region Properties

		
        public override object Id
        {

            get { return InvitationID; }
            set { InvitationID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int InvitationID { get; set; }
		public int AccountID { get; set; }
		public string Email { get; set; }
		public Guid GUID { get; set; }
		public DateTime CreateDate { get; set; }
		public int BecameAccountID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public FriendInvitation()
        {

        }

        public FriendInvitation(object id)
        {
			if (id != null)
            {
				FriendInvitation entity = Single(id);
				if (entity != null)
					entity.CopyTo<FriendInvitation>(this);
				else
					this.InvitationID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (InvitationID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}