using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MailQueue_History")]
    public partial class MailQueue_History : EntityBase<MailQueue_History>
    {
        #region Properties

		
        public override object Id
        {

            get { return MailQueueID; }
            set { MailQueueID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long MailQueueID { get; set; }
		public string SerializedMailMessage { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime SendDate { get; set; }

        #endregion

        public MailQueue_History()
        {

        }

        public MailQueue_History(object id)
        {
			if (id != null)
            {
				MailQueue_History entity = Single(id);
				if (entity != null)
					entity.CopyTo<MailQueue_History>(this);
				else
					this.MailQueueID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MailQueueID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}