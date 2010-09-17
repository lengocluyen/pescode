using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VTestResults")]
    public partial class VTestResults : EntityBase<VTestResults>
    {
           #region Properties

        public override object Id
        {

            get { return TestResultID; }
            set { TestResultID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int TestResultID { get; set; }
        public int Level{get;set;}
        public int PupilID{get;set;}
        public float Mark{get;set;}
        public DateTime? TestDate{get;set;}
        #endregion

        public VTestResults()
        {

        }

        public VTestResults(object id)
        {
			if (id != null)
            {
                VTestResults entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VTestResults>(this);
				else
					this.TestResultID = 0;
			}
        }

    }
}
