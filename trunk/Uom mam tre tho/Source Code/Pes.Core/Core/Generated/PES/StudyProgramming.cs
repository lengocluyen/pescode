using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("StudyProgramming")]
    public partial class StudyProgramming : EntityBase<StudyProgramming>
    {
        #region Properties

        public override object Id
        {

            get { return ProgrammingID; }
            set { ProgrammingID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ProgrammingID { get; set; }
		public string ProgrammingName { get; set; }
        public string ProgrammingImg { get; set; }
        public string ProgrammingSound { get; set; }
		public string Description { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public StudyProgramming()
        {

        }

        public StudyProgramming(object id)
        {
			if (id != null)
            {
				StudyProgramming entity = Single(id);
				if (entity != null)
					entity.CopyTo<StudyProgramming>(this);
				else
					this.ProgrammingID = 0;
			}
        }


    }
}