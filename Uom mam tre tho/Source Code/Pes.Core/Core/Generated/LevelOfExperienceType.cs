using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("LevelOfExperienceTypes")]
    public partial class LevelOfExperienceType : EntityBase<LevelOfExperienceType>
    {
        #region Properties

		
        public override object Id
        {

            get { return LevelOfExperienceTypeID; }
            set { LevelOfExperienceTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int LevelOfExperienceTypeID { get; set; }
		public string LevelOfExperience { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int SortOrder { get; set; }

        #endregion

        public LevelOfExperienceType()
        {

        }

        public LevelOfExperienceType(object id)
        {
			if (id != null)
            {
				LevelOfExperienceType entity = Single(id);
				if (entity != null)
					entity.CopyTo<LevelOfExperienceType>(this);
				else
					this.LevelOfExperienceTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (LevelOfExperienceTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}