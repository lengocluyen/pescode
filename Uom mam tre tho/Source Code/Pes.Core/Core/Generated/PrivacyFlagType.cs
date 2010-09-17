using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("PrivacyFlagTypes")]
    public partial class PrivacyFlagType : EntityBase<PrivacyFlagType>
    {
        #region Properties

		
        public override object Id
        {

            get { return PrivacyFlagTypeID; }
            set { PrivacyFlagTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PrivacyFlagTypeID { get; set; }
		public string FieldName { get; set; }
		public System.Data.Linq.Binary TimeStamp { get; set; }
		public int SortOrder { get; set; }

        #endregion

        public PrivacyFlagType()
        {

        }

        public PrivacyFlagType(object id)
        {
			if (id != null)
            {
				PrivacyFlagType entity = Single(id);
				if (entity != null)
					entity.CopyTo<PrivacyFlagType>(this);
				else
					this.PrivacyFlagTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (PrivacyFlagTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}