using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MessageRecipients")]
    public partial class MessageRecipient : EntityBase<MessageRecipient>
    {
        #region Properties

		
        public override object Id
        {

            get { return MessageRecipientID; }
            set { MessageRecipientID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long MessageRecipientID { get; set; }
		public long MessageID { get; set; }
		public int MessageRecipientTypeID { get; set; }
		public int AccountID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int MessageFolderID { get; set; }
		public int MessageStatusTypeID { get; set; }

        #endregion

        public MessageRecipient()
        {

        }

        public MessageRecipient(object id)
        {
			if (id != null)
            {
				MessageRecipient entity = Single(id);
				if (entity != null)
					entity.CopyTo<MessageRecipient>(this);
				else
					this.MessageRecipientID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MessageRecipientID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}