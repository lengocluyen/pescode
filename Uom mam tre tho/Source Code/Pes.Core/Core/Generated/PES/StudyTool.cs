using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("StudyTools")]
    public partial class StudyTool : EntityBase<StudyTool>
    {
        #region Properties

        public override object Id
        {

            get { return StudyToolID; }
            set { StudyToolID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int StudyToolID { get; set; }
		public int? ToolTypeID { get; set; }
		public string ToolName { get; set; }
		public string SourceFileID { get; set; }
		public string Help { get; set; }
		public string Description { get; set; }

        #endregion

        public StudyTool()
        {

        }

        public StudyTool(object id)
        {
			if (id != null)
            {
				StudyTool entity = Single(id);
				if (entity != null)
					entity.CopyTo<StudyTool>(this);
				else
					this.StudyToolID = 0;
			}
        }


    }
}