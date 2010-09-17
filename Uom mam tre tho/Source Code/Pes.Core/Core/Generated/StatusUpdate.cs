using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("StatusUpdates")]
    public partial class StatusUpdate : EntityBase<StatusUpdate>
    {
        #region Properties

		
        public override object Id
        {

            get { return StatusUpdateID; }
            set { StatusUpdateID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long StatusUpdateID { get; set; }
		public DateTime CreateDate { get; set; }
		public string Status { get; set; }
		public int? AccountID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public StatusUpdate()
        {

        }

        public StatusUpdate(object id)
        {
			if (id != null)
            {
				StatusUpdate entity = Single(id);
				if (entity != null)
					entity.CopyTo<StatusUpdate>(this);
				else
					this.StatusUpdateID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (StatusUpdateID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}