using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MessageRecipientTypes")]
    public partial class MessageRecipientType : EntityBase<MessageRecipientType>
    {
        #region Properties

		
        public override object Id
        {

            get { return MessageRecipientTypeID; }
            set { MessageRecipientTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int MessageRecipientTypeID { get; set; }
		public string Name { get; set; }

        #endregion

        public MessageRecipientType()
        {

        }

        public MessageRecipientType(object id)
        {
			if (id != null)
            {
				MessageRecipientType entity = Single(id);
				if (entity != null)
					entity.CopyTo<MessageRecipientType>(this);
				else
					this.MessageRecipientTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MessageRecipientTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}