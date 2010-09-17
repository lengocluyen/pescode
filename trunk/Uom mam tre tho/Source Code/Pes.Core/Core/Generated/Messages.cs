using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Messages")]
    public partial class Messages : EntityBase<Messages>
    {
        #region Properties

		
        public override object Id
        {

            get { return MessageID; }
            set { MessageID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long MessageID { get; set; }
		public int SentByAccountID { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int MessageTypeID { get; set; }

        #endregion

        public Messages()
        {

        }

        public Messages(object id)
        {
			if (id != null)
            {
				Messages entity = Single(id);
				if (entity != null)
					entity.CopyTo<Messages>(this);
				else
					this.MessageID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MessageID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}