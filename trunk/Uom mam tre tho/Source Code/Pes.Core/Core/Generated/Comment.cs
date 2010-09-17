using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Comments")]
    public partial class Comment : EntityBase<Comment>
    {
        #region Properties

		
        public override object Id
        {

            get { return CommentID; }
            set { CommentID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long CommentID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public string Body { get; set; }
		public DateTime CreateDate { get; set; }
		public int CommentByAccountID { get; set; }
		public string CommentByUsername { get; set; }
		public int SystemObjectID { get; set; }
		public long SystemObjectRecordID { get; set; }

        #endregion

        public Comment()
        {

        }

        public Comment(object id)
        {
			if (id != null)
            {
				Comment entity = Single(id);
				if (entity != null)
					entity.CopyTo<Comment>(this);
				else
					this.CommentID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (CommentID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}