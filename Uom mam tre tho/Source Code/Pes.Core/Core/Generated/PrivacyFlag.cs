using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("PrivacyFlags")]
    public partial class PrivacyFlag : EntityBase<PrivacyFlag>
    {
        #region Properties

		
        public override object Id
        {

            get { return PrivacyFlagID; }
            set { PrivacyFlagID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PrivacyFlagID { get; set; }
		public int PrivacyFlagTypeID { get; set; }
		public int ProfileID { get; set; }
		public int VisibilityLevelID { get; set; }
		public System.Data.Linq.Binary TimeStamp { get; set; }
		public DateTime CreateDate { get; set; }

        #endregion

        public PrivacyFlag()
        {

        }

        public PrivacyFlag(object id)
        {
			if (id != null)
            {
				PrivacyFlag entity = Single(id);
				if (entity != null)
					entity.CopyTo<PrivacyFlag>(this);
				else
					this.PrivacyFlagID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (PrivacyFlagID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}