using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("ProfileAttributeTypes")]
    public partial class ProfileAttributeType : EntityBase<ProfileAttributeType>
    {
        #region Properties

		
        public override object Id
        {

            get { return ProfileAttributeTypeID; }
            set { ProfileAttributeTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ProfileAttributeTypeID { get; set; }
		public string AttributeType { get; set; }
		public int SortOrder { get; set; }
		public int PrivacyFlagTypeID { get; set; }

        #endregion

        public ProfileAttributeType()
        {

        }

        public ProfileAttributeType(object id)
        {
			if (id != null)
            {
				ProfileAttributeType entity = Single(id);
				if (entity != null)
					entity.CopyTo<ProfileAttributeType>(this);
				else
					this.ProfileAttributeTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ProfileAttributeTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}