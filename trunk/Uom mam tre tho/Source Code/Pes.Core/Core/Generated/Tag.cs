using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("Tags")]
    public partial class Tag :EntityBase<Tag>
    {
        #region Properties

		
        public override object Id
        {

            get { return TagID; }
            set { TagID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long TagID { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public DateTime CreateDate { get; set; }

        #endregion

        public Tag()
        {

        }

        public Tag(object id)
        {
			if (id != null)
            {
				Tag entity = Single(id);
				if (entity != null)
					entity.CopyTo<Tag>(this);
				else
					this.TagID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (TagID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}