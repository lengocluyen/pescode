using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("ContentFilters")]
    public partial class ContentFilter : EntityBase<ContentFilter>
    {
        #region Properties

		
        public override object Id
        {

            get { return ContentFilterID; }
            set { ContentFilterID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ContentFilterID { get; set; }
		public string StringToFilter { get; set; }
		public string ReplaceWith { get; set; }
		public int AccountID { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary TimeStamp { get; set; }

        #endregion

        public ContentFilter()
        {

        }

        public ContentFilter(object id)
        {
			if (id != null)
            {
				ContentFilter entity = Single(id);
				if (entity != null)
					entity.CopyTo<ContentFilter>(this);
				else
					this.ContentFilterID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ContentFilterID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}