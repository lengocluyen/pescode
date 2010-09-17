using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("StudyLevel")]
    public partial class StudyLevel : EntityBase<StudyLevel>
    {
        #region Properties

        public override object Id
        {

            get { return StudyLevelID; }
            set { StudyLevelID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int StudyLevelID { get; set; }
		public string StudyLevelName { get; set; }
        public string StudyLevelImg { get; set; }
        public string Sound { get; set; }
		public string Description { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public StudyLevel()
        {

        }

        public StudyLevel(object id)
        {
			if (id != null)
            {
				StudyLevel entity = Single(id);
				if (entity != null)
					entity.CopyTo<StudyLevel>(this);
				else
					this.StudyLevelID = 0;
			}
        }


    }
}