using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("SystemObjectRatingOptions")]
    public partial class SystemObjectRatingOption : EntityBase<SystemObjectRatingOption>
    {
        #region Properties

		
        public override object Id
        {

            get { return SystemObjectRatingOptionID; }
            set { SystemObjectRatingOptionID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int SystemObjectRatingOptionID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int SystemObjectID { get; set; }

        #endregion

        public SystemObjectRatingOption()
        {

        }

        public SystemObjectRatingOption(object id)
        {
			if (id != null)
            {
				SystemObjectRatingOption entity = Single(id);
				if (entity != null)
					entity.CopyTo<SystemObjectRatingOption>(this);
				else
					this.SystemObjectRatingOptionID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (SystemObjectRatingOptionID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}