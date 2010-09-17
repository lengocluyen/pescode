using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Subjects")]
    public partial class Subject : EntityBase<Subject>
    {
        #region Properties

        public override object Id
        {

            get { return SubjectID; }
            set { SubjectID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int SubjectID { get; set; }
		public int? StudyLevelID { get; set; }
		public string SubjectName { get; set; }
        public string SubjectImg { get; set; }
        public string SubjectSound { get; set; }
		public int? TestID { get; set; }

        #endregion

        public Subject()
        {

        }

        public Subject(object id)
        {
			if (id != null)
            {
				Subject entity = Single(id);
				if (entity != null)
					entity.CopyTo<Subject>(this);
				else
					this.SubjectID = 0;
			}
        }


    }
}