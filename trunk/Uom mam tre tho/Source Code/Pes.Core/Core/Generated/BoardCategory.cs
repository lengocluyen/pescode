using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("BoardCategorys")]
    public partial class BoardCategory : EntityBase<BoardCategory>
    {
        #region Properties

		
        public override object Id
        {

            get { return CategoryID; }
            set { CategoryID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Subject { get; set; }
		public int SortOrder { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int ThreadCount { get; set; }
		public int PostCount { get; set; }
		public DateTime LastPostDate { get; set; }
		public int LastPostByAccountID { get; set; }
		public string LastPostByUsername { get; set; }
		public string PageName { get; set; }

        #endregion

        public BoardCategory()
        {

        }

        public BoardCategory(object id)
        {
			if (id != null)
            {
				BoardCategory entity = Single(id);
				if (entity != null)
					entity.CopyTo<BoardCategory>(this);
				else
					this.CategoryID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (CategoryID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}