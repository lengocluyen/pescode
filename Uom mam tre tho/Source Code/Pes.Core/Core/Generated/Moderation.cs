using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Moderations")]
    public partial class Moderation : EntityBase<Moderation>
    {
        #region Properties

		
        public override object Id
        {

            get { return ModerationID; }
            set { ModerationID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long ModerationID { get; set; }
		public int? AccountID { get; set; }
		public string AccountUsername { get; set; }
		public int SystemObjectID { get; set; }
		public long SystemObjectRecordID { get; set; }
		public System.Data.Linq.Binary TimeStamp { get; set; }
		public DateTime CreateDate { get; set; }
		public bool? IsApproved { get; set; }
		public bool? IsDenied { get; set; }
		public int? ActionByAccountID { get; set; }
		public string ActionByUsername { get; set; }

        #endregion

        public Moderation()
        {

        }

        public Moderation(object id)
        {
			if (id != null)
            {
				Moderation entity = Single(id);
				if (entity != null)
					entity.CopyTo<Moderation>(this);
				else
					this.ModerationID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ModerationID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}