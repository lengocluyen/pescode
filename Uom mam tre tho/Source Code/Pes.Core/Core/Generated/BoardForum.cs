using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("BoardForums")]
    public partial class BoardForum : EntityBase<BoardForum>
    {
        #region Properties

		
        public override object Id
        {

            get { return ForumID; }
            set { ForumID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ForumID { get; set; }
		public string Name { get; set; }
		public string Subject { get; set; }
		public long ThreadCount { get; set; }
		public long PostCount { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public DateTime LastPostDate { get; set; }
		public int LastPostByAccountID { get; set; }
		public string LastPostByUsername { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int CategoryID { get; set; }
		public string PageName { get; set; }

        #endregion

        public BoardForum()
        {

        }

        public BoardForum(object id)
        {
			if (id != null)
            {
				BoardForum entity = Single(id);
				if (entity != null)
					entity.CopyTo<BoardForum>(this);
				else
					this.ForumID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ForumID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}