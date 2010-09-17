using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Ratings")]
    public partial class Rating : EntityBase<Rating>
    {
        #region Properties

		
        public override object Id
        {

            get { return RatingID; }
            set { RatingID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long RatingID { get; set; }
		public int Score { get; set; }
		public string CreatedByUsername { get; set; }
		public int CreatedByAccountID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public DateTime CreateDate { get; set; }
		public int SystemObjectID { get; set; }
		public long SystemObjectRecordID { get; set; }
		public int SystemObjectRatingOptionID { get; set; }

        #endregion

        public Rating()
        {

        }

        public Rating(object id)
        {
			if (id != null)
            {
				Rating entity = Single(id);
				if (entity != null)
					entity.CopyTo<Rating>(this);
				else
					this.RatingID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (RatingID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}