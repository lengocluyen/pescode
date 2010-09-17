using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("StudyLevelType")]
    public partial class StudyLevelType : EntityBase<StudyLevelType>
    {
        #region Properties

        public override object Id
        {

            get { return StudyLevelTypeID; }
            set { StudyLevelTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int StudyLevelTypeID { get; set; }
		public int? StudyLevelID { get; set; }
		public int? StudyProgrammingID { get; set; }

        #endregion

        public StudyLevelType()
        {

        }

        public StudyLevelType(object id)
        {
			if (id != null)
            {
				StudyLevelType entity = Single(id);
				if (entity != null)
					entity.CopyTo<StudyLevelType>(this);
				else
					this.StudyLevelTypeID = 0;
			}
        }


    }
}