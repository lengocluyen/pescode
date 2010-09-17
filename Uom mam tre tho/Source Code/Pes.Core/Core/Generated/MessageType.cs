using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MessageTypes")]
    public partial class MessageType : EntityBase<MessageType>
    {
        #region Properties

		
        public override object Id
        {

            get { return MessageTypeID; }
            set { MessageTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int MessageTypeID { get; set; }
		public string Name { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public MessageType()
        {

        }

        public MessageType(object id)
        {
			if (id != null)
            {
				MessageType entity = Single(id);
				if (entity != null)
					entity.CopyTo<MessageType>(this);
				else
					this.MessageTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MessageTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}