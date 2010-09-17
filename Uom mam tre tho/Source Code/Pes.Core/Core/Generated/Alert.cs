using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Alerts")]
    public partial class Alert : EntityBase<Alert>
    {
        #region Properties

		
        public override object Id
        {

            get { return AlertID; }
            set { AlertID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long AlertID { get; set; }
		public int AccountID { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int AlertTypeID { get; set; }
		public bool IsHidden { get; set; }
		public string Message { get; set; }

        #endregion

        public Alert()
        {

        }

        public Alert(object id)
        {
			if (id != null)
            {
				Alert entity = Single(id);
				if (entity != null)
					entity.CopyTo<Alert>(this);
				else
					this.AlertID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (AlertID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}