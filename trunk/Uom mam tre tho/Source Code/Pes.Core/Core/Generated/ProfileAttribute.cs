using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("ProfileAttributes")]
    public partial class ProfileAttribute : EntityBase<ProfileAttribute>
    {
        #region Properties

		
        public override object Id
        {

            get { return ProfileAttributeID; }
            set { ProfileAttributeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ProfileAttributeID { get; set; }
		public int ProfileID { get; set; }
		public int ProfileAttributeTypeID { get; set; }
		public string Response { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary TimeStamp { get; set; }

        #endregion

        public ProfileAttribute()
        {

        }

        public ProfileAttribute(object id)
        {
			if (id != null)
            {
				ProfileAttribute entity = Single(id);
				if (entity != null)
					entity.CopyTo<ProfileAttribute>(this);
				else
					this.ProfileAttributeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ProfileAttributeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}