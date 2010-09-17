using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MessageStatusTypes")]
    public partial class MessageStatusType : EntityBase<MessageStatusType>
    {
        #region Properties

		
        public override object Id
        {

            get { return MessageStatusTypeID; }
            set { MessageStatusTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int MessageStatusTypeID { get; set; }
		public string Name { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public MessageStatusType()
        {

        }

        public MessageStatusType(object id)
        {
			if (id != null)
            {
				MessageStatusType entity = Single(id);
				if (entity != null)
					entity.CopyTo<MessageStatusType>(this);
				else
					this.MessageStatusTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MessageStatusTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}