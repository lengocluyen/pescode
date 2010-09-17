using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("BoardPosts")]
    public partial class BoardPost : EntityBase<BoardPost>
    {
        #region Properties

		
        public override object Id
        {

            get { return PostID; }
            set { PostID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long PostID { get; set; }
		public bool IsThread { get; set; }
		public string Name { get; set; }
		public string Post { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int AccountID { get; set; }
		public string Username { get; set; }
		public int ReplyCount { get; set; }
		public string ReplyByUsername { get; set; }
		public int ViewCount { get; set; }
		public int ForumID { get; set; }
		public string PageName { get; set; }
		public long? ThreadID { get; set; }
		public int? ReplyByAccountID { get; set; }

        #endregion

        public BoardPost()
        {

        }

        public BoardPost(object id)
        {
			if (id != null)
            {
				BoardPost entity = Single(id);
				if (entity != null)
					entity.CopyTo<BoardPost>(this);
				else
					this.PostID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (PostID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}