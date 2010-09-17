using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Blogs")]
    public partial class Blog : EntityBase<Blog>
    {
        #region Properties

		
        public override object Id
        {

            get { return BlogID; }
            set { BlogID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long BlogID { get; set; }
		public int AccountID { get; set; }
		public string Title { get; set; }
		public string Subject { get; set; }
		public string Post { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public bool IsPublished { get; set; }
		public string PageName { get; set; }

        #endregion

        public Blog()
        {

        }

        public Blog(object id)
        {
			if (id != null)
            {
				Blog entity = Single(id);
				if (entity != null)
					entity.CopyTo<Blog>(this);
				else
					this.BlogID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (BlogID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}