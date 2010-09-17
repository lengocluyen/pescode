using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MessageFolders")]
    public partial class MessageFolder : EntityBase<MessageFolder>
    {
        #region Properties

		
        public override object Id
        {

            get { return MessageFolderID; }
            set { MessageFolderID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int MessageFolderID { get; set; }
		public string FolderName { get; set; }
		public bool IsSystem { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int AccountID { get; set; }

        #endregion

        public MessageFolder()
        {

        }

        public MessageFolder(object id)
        {
			if (id != null)
            {
				MessageFolder entity = Single(id);
				if (entity != null)
					entity.CopyTo<MessageFolder>(this);
				else
					this.MessageFolderID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (MessageFolderID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}